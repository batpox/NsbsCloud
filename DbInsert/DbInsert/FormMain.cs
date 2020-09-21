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

using Batpox.Logging;


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


                    //// Dequeue eventpump notifications
                    //lock (EventPumpQueue)
                    //{
                    //    if (EventPumpQueue.Count > 0)
                    //    {
                    //        EpMessage msg = EventPumpQueue.Dequeue();
                    //        if (msg != null)
                    //        {
                    //            switch (msg.EntryType.ToUpper())
                    //            {
                    //                case "INFO":
                    //                    textEventInfo.Text = String.Format("{0}:{1}",
                    //                        msg.Info1, msg.InsertionTimeUtc.ToString("dd-MMM HH:mm:ss"));
                    //                    break;
                    //                case "PROBLEM":
                    //                    textEventProblem.Text = String.Format("{0}:{1}",
                    //                        msg.Info1, msg.InsertionTimeUtc.ToString("dd-MMM HH:mm:ss"));
                    //                    break;
                    //            } // switch
                    //        } // check for null coming out of queue

                    //    }
                    //} // lock queue

                } // every 1 tick

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


    }   // class
}   // namespace
