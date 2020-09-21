using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Threading;
using System.IO;

using Batpox.Logging;

namespace CoilStore
{

    public class FileEntry
    {
        public FileEntry(DateTime dt, string fullPath)
        {
            EntryTime = dt;
            FilePath = fullPath;
        }

        /// <summary>
        /// The UTC time the entry occurred.
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// the name of the file
        /// </summary>
        public string FilePath { get; set; }

    }

    /// <summary>
    /// The engine that finds and processes files.
    /// It finds files in two ways:
    /// 1. By system file watcher. External caller should call BeginFileWatching (or EndFileWatching)
    /// 2. By external caller (formMain:timer) calling checkForFiles
    /// 
    /// </summary>
    public class CoilStoreEngine
    {

        /// <summary>
        /// Where files are placed by the external system.
        /// </summary>
        string ImportFolder { get; set; }

        /// <summary>
        /// Where files are moved to so they can be processed into the database.
        /// </summary>
        string ProcessingFolder { get; set; }

        string FailureFolder { get; set; }

        string SuccessFolder { get; set; }

        /// <summary>
        /// The watcher to look for file events.
        /// See BeginFileWatching.
        /// </summary>
        private FileSystemWatcher fsw { get; set; }

        /// <summary>
        /// A FIFO queue of files to be processed.
        /// </summary>
        private Queue<FileEntry> CoilFileQueue { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="queue"></param>
        public CoilStoreEngine(Queue<FileEntry> queue)
        {
            try
            {
                CoilFileQueue = new Queue<FileEntry>();

                ImportFolder = Properties.Settings.Default.CoilImportFolder;
                if ( !Directory.Exists(ImportFolder))
                {
                    throw new ApplicationException(string.Format("No Import folder found={0}", ImportFolder ));
                }

                ProcessingFolder = Properties.Settings.Default.CoilProcessingFolder;
                if (!Directory.Exists(ProcessingFolder))
                {
                    throw new ApplicationException(string.Format("No Processing folder found={0}", ProcessingFolder));
                }

                SuccessFolder = Properties.Settings.Default.CoilSuccessFolder;
                if (!Directory.Exists(SuccessFolder))
                {
                    throw new ApplicationException(string.Format("No Success folder found={0}", SuccessFolder));
                }

                FailureFolder = Properties.Settings.Default.CoilFailureFolder;
                if (!Directory.Exists(FailureFolder))
                {
                    throw new ApplicationException(string.Format("No Failure folder found={0}", FailureFolder));
                }

            }
            catch (Exception ex)
            {
                logit(ex.ToString());
            }
        } // constructor

        /// <summary>
        /// Begin filewatching.
        /// Set up the fileWatcher based on the arguments provided.
        /// The fsw is set to enableRaisingEvents.
        /// </summary>
        /// <param name="fsw"></param>
        /// <param name="folder"></param>
        /// <param name="filter"></param>
        /// <param name="includeSubfolders"></param>
        /// <param name="explanation"></param>
        /// <returns></returns>
        public bool BeginFileWatching( string folder, string filter, bool includeSubfolders, out string explanation)
        {
            explanation = "";

            try
            {
                // cleanup
                if ( fsw != null )
                {
                    fsw.EnableRaisingEvents = false;
                    fsw.Dispose();
                    fsw = null;
                }

                fsw = new FileSystemWatcher(folder, filter);

                fsw.IncludeSubdirectories = includeSubfolders;
                fsw.NotifyFilter = NotifyFilters.Attributes
                    | NotifyFilters.LastAccess
                    | NotifyFilters.FileName
                    | NotifyFilters.Attributes
                    | NotifyFilters.LastWrite;


                fsw.Created += new FileSystemEventHandler(OnCreated);
                fsw.Renamed += new RenamedEventHandler(OnRenamed);

                fsw.EnableRaisingEvents = true;
               

                return true;
            }
            catch (Exception ex)
            {
                explanation = string.Format("Folder={0} Filter={1} Err={2}", folder, filter, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// A file is renamed. Process it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnRenamed(object sender, RenamedEventArgs e)
        {
            try
            {
                logit(string.Format("FileWatcher OnRenamed Event. Checking files..."));
                Thread.Sleep(500); // Give the mover a chance to release file.
                CheckForFiles();
            }
            catch (Exception ex)
            {
                logit(ex.ToString());
            }
        } // method

        /// <summary>
        /// Move the file to the destination folder.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="destinationFolder"></param>
        /// <returns></returns>
        public bool MoveFile(string fullPath, string destinationFolder)
        {
            try
            {
                string destPath;
                string fn = Path.GetFileName(fullPath);

                destPath = Path.Combine(destinationFolder, fn);

                if ( File.Exists(destPath) )
                {
                    logit(string.Format("Warning: File={0} already existing at={1}. Deleted it.", 
                        fullPath, destPath));
                    File.Delete(destPath);
                }

                File.Move(fullPath, destPath);
                return true;
            }
            catch (Exception ex)
            {
                logit(string.Format("Full={0} Destination={1} Err={2}", fullPath, destinationFolder, ex.ToString()));
                return false;
            }
        } // method

        /// <summary>
        /// The file is created. put it in the queue.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnCreated(object source, FileSystemEventArgs e)
        {
            try
            {
                logit(string.Format("FileWatcher OnCreated Event. Checking files..."));
                Thread.Sleep(500); // Give the creator a chance to release file
                CheckForFiles();
            }
            catch (Exception ex)
            {
                logit(ex.ToString());
            }
        }

        /// <summary>
        /// Look for files in the import folder and put them in the queue for processing.
        /// </summary>
        /// <returns></returns>
        public bool CheckForFiles()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(ImportFolder);

                lock (CoilFileQueue)
                {
                    foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.TopDirectoryOnly))
                    {
                        // Make the new destination
                        string fn = Path.Combine(ProcessingFolder, fi.Name);
                        FileEntry fe = new FileEntry(DateTime.UtcNow, fn);
                        MoveFile(fi.FullName, ProcessingFolder);
                        CoilFileQueue.Enqueue(fe);
                    } // foreach
                } // lock 
                return true;
            }
            catch (Exception ex)
            {
                logit(ex.ToString());
                return false;
            }
        } // method

        /// <summary>
        /// The file is created.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
        }

        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        } // method


        /// <summary>
        /// Begin filewatching.
        /// Set up the fileWatcher based on the arguments provided.
        /// The fsw is set to enableRaisingEvents.
        /// </summary>
        /// <param name="fsw"></param>
        /// <param name="folder"></param>
        /// <param name="filter"></param>
        /// <param name="includeSubfolders"></param>
        /// <param name="explanation"></param>
        /// <returns></returns>
        public static bool EndFileWatching(ref FileSystemWatcher fsw, out string explanation)
        {
            explanation = "";

            try
            {
                // cleanup
                if (fsw != null)
                {
                    fsw.EnableRaisingEvents = false;

                    fsw.Created -= null;

                    fsw.Renamed -= null;

                    fsw.Dispose();
                    fsw = null;
                }

                return true;
            }
            catch (Exception ex)
            {
                explanation = string.Format("Err={0}", ex.ToString());
                return false;
            }
        } // method


        /// <summary>
        /// Check the file processing queue and process any files found.
        /// Each file is examined and placed in the database.
        /// Depending on the result, the file that is in the processing folder is moved
        /// to either the success or failure folder.
        /// </summary>
        /// <returns></returns>
        public bool ProcessFiles()
        {
            try
            {
                while ( CoilFileQueue.Count > 0)
                {
                    FileEntry fe = null;
                    lock ( CoilFileQueue )
                    {
                        fe = CoilFileQueue.Dequeue();

                        string explanation = "";
                        if ( ParseAndStoreFile(fe, out explanation) )
                        {
                            MoveFile(fe.FilePath, SuccessFolder);
                        }
                        else
                        {
                            WriteErrorFile(fe.FilePath, FailureFolder, explanation);
                            MoveFile(fe.FilePath, FailureFolder);
                        }
                    } // lock

                }

                return true;
            }
            catch (Exception ex)
            {
                logit(ex.ToString());
                return false;
            }
        }//method

        /// <summary>
        /// Put the error file out, matching the name (but using .txt as the extension)
        /// as the original file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="failureFolder"></param>
        /// <param name="explanation"></param>
        public void WriteErrorFile( string filePath, string failureFolder, string explanation)
        {
            try
            {
                string fn = Path.GetFileName(filePath);
                fn = string.Format("{0}.err", fn);

                string outPath = Path.Combine(failureFolder, fn);
                File.WriteAllText(outPath, explanation);
                
            }
            catch (Exception ex)
            {
                logit(string.Format("File={0} Folder={1} Err={2}", filePath, failureFolder, ex.ToString()));
                
            }
        }

        /// <summary>
        /// Build a coil key from the time (down to the second), plus
        /// a one-digit identifier (which is what type of measurement)
        /// yyMMddHHmmss1
        ///        
        /// 2109876543210
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public Int64 BuildCoilKey( DateTimeOffset dto, int suffix )
        {
            try
            {
                Int64 key;

                // Keep shifting and adding
                key = (dto.Year % 100);
                key = key * 100 + dto.Month;
                key = key * 100 + dto.Day;
                key = key * 100 + dto.Hour;
                key = key * 100 + dto.Minute;
                key = key * 100 + dto.Second;
                key = key * 10 + suffix;
                return key;
            }
            catch (Exception ex)
            {
                logit(ex.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Build a coil reading key, which is the coil key, but
        /// shifted by 4 with a 4 digit reading number appended.
        /// a four-digit identifier (which is what type of measurement)
        /// yyMMddHHmmssX1234
        ///      1  
        /// 65432109876543210
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public Int64 BuildCoilReadingKey(Int64 coilId, int readingNumber)
        {
            try
            {
                Int64 key;

                key = coilId * 10000 + readingNumber;
                return key;
            }
            catch (Exception ex)
            {
                logit(ex.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Check for duplicates coils. When found the original entry
        /// and its readings are removed.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="coilNumber"></param>
        /// <returns></returns>
        public bool CheckForDuplicates(CoilStoreContext context, string coilNumber, string dataType)
        {
            string marker = "Begin.";
            try
            {
                Coil coil = context.Coils.SingleOrDefault(rr => (rr.CoilNumber == coilNumber) && (rr.DataType == dataType));
                if (coil == null) // no duplicates
                    return true;

                // Find and remove the readings
                marker = string.Format("Found coil with ID={0} and DataType={1}. Finding CoilReadings...", coilNumber, dataType);
                List<CoilReading> readingsList = context.CoilReadings.Where(rr => rr.CoilId == coil.CoilId).ToList();

                marker = string.Format("Removing {0} CoilReadings...", readingsList.Count());
                context.CoilReadings.RemoveRange(readingsList);

                marker = string.Format("Removing coil...");
                // ... and then remove the parent
                context.Coils.Remove(coil);

                logit(string.Format("Removing duplicate coil={0} (type={1}) and its {2} child readings",coil.CoilNumber, coil.DataType, readingsList.Count()));
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logit(string.Format("Removing Coil={0} Marker={1} Err={2}", coilNumber, marker, ex.ToString()));
                return false;
            }
        } // method

        /// <summary>
        /// Parse the file and store the results. Here is an example:
        /// 01350000,9/14/13 10:41:39
        /// 1
        /// 1317
        /// Actual,Ordered,Pos Tol,Neg Tol
        /// 1707.069092,1640,1680,1520
        /// 1684.532349
        /// 1705.388794
        ///    ...
        /// </summary>
        /// <param name="fe"></param>
        /// <returns></returns>
        public bool ParseAndStoreFile(FileEntry fe, out string explanation)
        {
            explanation = "";

            try
            {
                StringBuilder sbReadings = new StringBuilder();
                int numberOfReadings = 0;
                Int64 parentCoilId = -1;

                string[] lines = File.ReadAllLines(fe.FilePath);

                int suffix = 0;
                string extension = Path.GetExtension(fe.FilePath);
                // remove the initial '.' and lowercase the extension
                if ( extension.Length < 2 )
                {
                    explanation = string.Format("File={0}. Expected a legal extension on the file.");
                    return false;
                }

                extension = extension.ToLower().Substring(1);

                switch (extension)
                {
                    case "fdh":
                        suffix = 1;
                        break;

                    case "fdw":
                        suffix = 2;
                        break;

                    default:
                        explanation = string.Format("File={0} had unknown extension={1}", fe.FilePath, extension);
                        return false;

                }


                // Add the coil and readings within a transaction
                ////using ( TransactionScope scope = new TransactionScope())
                ////{
                using (CoilStoreContext context = new CoilStoreContext())
                {
                    // We're only inserting here, so the following will speed things up.
                    context.Configuration.AutoDetectChangesEnabled = false;
                    //context.Configuration.ValidateOnSaveEnabled = false;

                    Coil newCoil = new Coil();
                    newCoil.CreationTimeUTC = DateTime.UtcNow;

                    int readingCount = 0;

                    int count = 0;
                    foreach (String line in lines)
                    {
                        count += 1;
                        string[] tokens;

                        switch (count)
                        {
                            case 1: // coil number and date
                                tokens = line.Split(',');
                                if (tokens.Length != 2)
                                {
                                    explanation = string.Format("File={0} Line={1}({2}) does not have two tokens.");
                                    return false;
                                }
                                newCoil.CoilNumber = tokens[0];

                                // Check if the coil already exists.
                                // If it does, then we'll delete the existing coil and records before continuing
                                if (!CheckForDuplicates(context, newCoil.CoilNumber, extension.ToLower()))
                                {
                                    logit(String.Format("Cannot remove duplicate coil={0}. Cannot continue with file={1}",
                                        newCoil.CoilNumber, fe.FilePath));
                                    return false;
                                }

                                DateTimeOffset dto;
                                if (!DateTimeOffset.TryParse(tokens[1], out dto))
                                {
                                    explanation = string.Format("Cannot parse Date={0}", tokens[1]);
                                    return false;
                                }
                                newCoil.ProducedTime = dto;

                                newCoil.DataType = extension;

                                // {Nov2015/dth} convert to UTC
                                DateTimeOffset dtoUtc = dto.ToUniversalTime();

                                // Build the key from the data and the file type
                                newCoil.CoilId = BuildCoilKey(dtoUtc, suffix);

                                // Look for duplicates
                                Coil checkCoil = context.Coils.SingleOrDefault(rr => rr.CoilId == newCoil.CoilId);
                                if (checkCoil != null)
                                {
                                    explanation = String.Format("Coil with Key={0} Already exists. CoilNumber={1}",
                                        newCoil.CoilId, newCoil.CoilNumber.ToString());
                                    return false;
                                }
                                break;

                            case 2: // Gage in use
                                int inUse = 0;
                                if (!int.TryParse(line, out inUse))
                                {
                                    explanation = string.Format("Cannot parse Gage-In-Use. line={0}", line);
                                    return false;
                                }
                                newCoil.GageInUse = inUse;
                                break;

                            case 3: // number of readings
                                if (!int.TryParse(line, out numberOfReadings))
                                {
                                    explanation = string.Format("File={0} Line={1}({2}) reading count must be an integer.");
                                    return false;
                                }
                                newCoil.NumberOfReadings = numberOfReadings;

                                break;

                            case 4: // headers
                                /// Actual,Ordered,Pos Tol,Neg Tol
                                /// 1707.069092,1640,1680,1520

                                break;

                            case 5: // statistics
                                tokens = line.Split(',');
                                if (tokens.Length != 4)
                                {
                                    explanation = string.Format("File={0} Line={1}({2}) does not have four tokens.");
                                    return false;
                                }

                                decimal dd;


                                if (decimal.TryParse(tokens[1], out dd))
                                    newCoil.OrderValue = dd;
                                if (decimal.TryParse(tokens[2], out dd))
                                    newCoil.PositiveTolerance = dd;
                                if (decimal.TryParse(tokens[3], out dd))
                                    newCoil.NegativeTolerance = dd;

                                // This is the last 'parent' record. 
                                context.Coils.Add(newCoil);
                                context.SaveChanges();
                                parentCoilId = newCoil.CoilId;

                                // The first token is the first reading.
                                if (decimal.TryParse(tokens[0], out dd))
                                {
                                    readingCount += 1;

                                    CoilReading reading = new CoilReading();
                                    reading.CoilReadingId = BuildCoilReadingKey(newCoil.CoilId, readingCount);
                                    reading.CoilId = newCoil.CoilId;
                                    reading.ReadingNumber = readingCount;
                                    reading.Value = dd;
                                    context.CoilReadings.Add(reading);

                                    sbReadings.Append(dd.ToString("0.000000"));

                                }


                                break;

                            default: // 6 and above are the rest of the coil readings
                                {
                                    // There should be as many readings as were sepcified in case 3:

                                    CoilReading reading = new CoilReading();
                                    //reading

                                    if (!decimal.TryParse(line, out dd))
                                    {
                                        explanation = string.Format("Reading ({0}) cannot parse this={1}", line);
                                        return false;
                                    }

                                    readingCount += 1;

                                    ////// Every 100 readings save the changes
                                    ////if ( (readingCount % 100) == 0 )
                                    ////{
                                    ////    context.SaveChanges();
                                    ////    context = new CoilStoreContext();
                                    ////    context.Configuration.AutoDetectChangesEnabled = false;
                                    ////}

                                    reading.CoilReadingId = BuildCoilReadingKey(newCoil.CoilId, readingCount);
                                    reading.CoilId = newCoil.CoilId;
                                    reading.ReadingNumber = readingCount;
                                    reading.Value = dd;
                                    context.CoilReadings.Add(reading);

                                    if (readingCount > numberOfReadings)
                                    {
                                        explanation = string.Format("Readings (currently={0} exceeds the Number in the header={1}",
                                            readingCount, newCoil.NumberOfReadings);
                                        return false;
                                    }

                                    // The readings are also kept in a comma-list field. Append the reading
                                    sbReadings.Append("," + dd.ToString("0.000000"));
                                }

                                break;

                        } // switch
                    } // for each

                    if (readingCount != numberOfReadings)
                    {
                        logit(string.Format("Warning: Mismatch on readings. Found={0}, but header said={1}",
                            readingCount, numberOfReadings));
                    }

                    // Update the coil record
                    context.SaveChanges();

                    ////scope.Complete();

                } // using context
                ////} // using transactionscope

                // {Jan2016/dth} Put the lokup and update outside the transaction
                if ((parentCoilId != -1) && (numberOfReadings > 0))
                {
                    using (CoilStoreContext context = new CoilStoreContext())
                    {
                        Coil newCoil = context.Coils.Find(parentCoilId);
                        if (newCoil != null)
                        {
                            string ss = sbReadings.ToString();
                            newCoil.Readings = ss;
                            context.SaveChanges();
                            logit(string.Format("Info: Coil={0} saved, along with {1} CoilRecords",
                                newCoil.CoilNumber, numberOfReadings));
                        }
                        else
                        {
                            logit(string.Format("Info: Coil File={0} could not be processed.",
                                fe.FilePath));
                            return false;
                        }

                    } // using
                }

                return true;
            }
            catch (Exception ex)
            {
                explanation = string.Format( "{0}", ex.ToString());
                logit(ex.ToString());
                return false;
            }
        } // method
        /// <summary>
        /// Logging
        /// </summary>
        /// <param name="message"></param>
        private void logit(string message)
        {
            Log.Instance().LogIt(string.Format("CoilStore::{0}", message));
        }


    }
}
