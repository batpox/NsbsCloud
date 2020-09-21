using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpenTracDashboard
{
    public class OpentracMessage
    {
        public string Code { get; set; }

        public List<string> TableList { get; set; }


        /// <summary>
        /// Read in a file that defines
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="explanation"></param>
        /// <returns></returns>
        public static bool ReadFromFile(string filepath, out List<OpentracMessage> messageList, out string explanation)
        {
            explanation = "";
            messageList = new List<OpentracMessage>();
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                foreach ( string line in lines )
                {
                    OpentracMessage otm = new OpentracMessage();
                    otm.TableList = new List<string>();

                    string[] tokens = line.Split(',');
                    int count = 0;
                    foreach ( string token in tokens )
                    {
                        if (count == 0)
                        {
                            otm.Code = token;
                        }
                        else
                        {
                            otm.TableList.Add(token);
                        }
                        count += 1;

                    } // for each token
                    messageList.Add(otm);
                } // for each line
                return true;

            }
            catch (Exception ex)
            {
                explanation = string.Format("File={0} Err={1}", filepath, ex.ToString());
                return false;
            }
        } // method

    } // ReadFromFile

}
