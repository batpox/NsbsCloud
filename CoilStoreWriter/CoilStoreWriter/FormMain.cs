using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;
using System.IO;


using Batpox.Logging;
using CoilStoreApi;


namespace CoilStore
{
    public partial class FormMain : Form
    {
        public long ticksGeneral;

        /// <summary>
        /// Are we still alive? Set to false by DIE EventPump message.
        /// </summary>
        public bool IsAlive;

        public long ticksCheck;

        /// <summary>
        /// The name of his process. This shows on the title bar
        /// </summary>
        public string MyName;


        public Queue<FileEntry> FileQ = new Queue<FileEntry>();

        public CoilStoreEngine engine;
        
        /// <summary>
        /// Main routine.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogAbout dialogAbout = new DialogAbout();
            dialogAbout.Text = MyName;
            dialogAbout.ShowDialog();
        }

        /// <summary>
        /// Wire up the logging, eventpump, and show the application settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            string marker = "";
            try
            {
                marker = "Starting Log";
                IsAlive = true;

                engine = new CoilStoreEngine(FileQ);

                Log.Instance().LogFolder = Properties.Settings.Default.LogFolder;

                propertyGrid1.SelectedObject = Properties.Settings.Default; //todo: fix this

                showStatus("Info: Starting...");


                // Set our name onto the text of the main window so ProcessFerret can manage us better.
                MyName = Properties.Settings.Default.ProcessName;
                this.Text = MyName;


                marker = "Starting timer";

                Thread.Sleep(500);

                // The last thing to do is to start the timers
                timerGeneral.Interval = 1000; // 1 second
                timerGeneral.Enabled = true;

                string explanation = "";
                if ( !engine.BeginFileWatching( Properties.Settings.Default.CoilImportFolder, "*.*", false, out explanation) )
                    logit( string.Format("Problem watching on={0}. Err={1}", explanation));

                showStatus("Info. Initialization complete. Running...");
            }
            catch (Exception ex)
            {
                alert(string.Format("Cannot load main. Marker={0} Error={1}", marker, ex.Message));
            }

        } // method Load




        /// <summary>
        /// The general timer ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerGeneral_Tick(object sender, EventArgs e)
        {
            timerGeneral.Enabled = false;
            try
            {

                ticksGeneral++;


                if ((ticksGeneral % 1) == 0)
                {
                    textLogs.Text = Log.Instance().LogString;

                } // every 1 tick

                // Process any files found
                if ((ticksGeneral % 2) == 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    engine.ProcessFiles();
                    Cursor.Current = Cursors.Default;
                }

                // Look for files that may have not been 'file watched'
                if ((ticksGeneral & Properties.Settings.Default.FilePollSeconds) == 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    engine.CheckForFiles();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                logit(ex.Message);
            }
            finally
            {
                timerGeneral.Enabled = true;
            }

        } // method




        /// <summary>
        /// Show status line and log the message
        /// </summary>
        /// <param name="message"></param>
        private void showStatus(string message)
        {
            LabelStatus.Text = message;
            if ( message.Trim().Length > 0 )
                logit(message);
        }


        /// <summary>
        /// The application is being shut down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }




        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();

        }


        /// <summary>
        /// Private logging routine
        /// </summary>
        /// <param name="message"></param>
        private void logit(string message)
        {
            Log.Instance().LogIt(string.Format("{0}", message));
        }

        /// <summary>
        /// Private logging routine with messagebox (for testing only)
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            logit(message);
            MessageBox.Show(message);
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogAbout dialog = new DialogAbout();
            dialog.ShowDialog();
        }

        private void dgvCoils_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

                vCoil vc = dgvr.DataBoundItem as vCoil;

                using ( CoilStoreContext context = new CoilStoreContext())
                {
                    List<vCoilReading> readingList = context.vCoilReadings
                        .Where(rr => rr.CoilId == vc.CoilId)
                        .OrderBy(rr => rr.ReadingNumber)
                        .ToList();

                    dgvCoilReadingsDb.DataSource = readingList;

                }

                List<CoilReadingValue> crvList = null;
                string explanation = "";

                if ( vc.Readings != null )
                { 
                    if (CoilStoreHelpers.GetCoilReadings(vc.Readings, out crvList, out explanation))
                    {
                        dgvCoilReadingsList.DataSource = crvList;
                    }
                    else
                        alert(explanation);
                }

            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }

        }

        private void buttonTestRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                using (CoilStoreContext context = new CoilStoreContext())
                {
                    List<vCoil> coilList = context.vCoils.ToList();
                    dgvCoils.DataSource = coilList; 
                }
            }
            catch (Exception ex)
            {
                logit(ex.ToString());
            }
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Properties.Settings.Default.TestFolder;
                
                DialogResult result = dialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                textFileCandidate.Text = dialog.FileName;

                string fnOnly = Path.GetFileName(dialog.FileName);
                string targetPath = Path.Combine(Properties.Settings.Default.CoilImportFolder, fnOnly);

                File.Copy(dialog.FileName, targetPath);
            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }
        }

        private void dgvCoils_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }   // class
}   // namespace
