using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Batpox.Logging;

namespace OpenTracDashboard
{
    public partial class FormMain : Form
    {

        public DataGridViewAssistant<TRANSACTION_INBOUND> dgvaInboundOt;
        public DataGridViewAssistant<TRANSACTION_OUTBOUND> dgvaOutboundOt;
        public DataGridViewAssistant<KeyStore> dgvaKeyStore;


        public FormMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {

                Log.instance().LogFolder = Properties.Settings.Default.LogFolder;

                propertyGrid1.SelectedObject = Properties.Settings.Default;

                logit(string.Format("OpenTrac Dashboard Starting. Version={0}", Application.ProductVersion));


                dgvaInboundOt = new DataGridViewAssistant<TRANSACTION_INBOUND>(dgvInboundOt);
                dgvaOutboundOt = new DataGridViewAssistant<TRANSACTION_OUTBOUND>(dgvOutboundOt);
                dgvaKeyStore = new DataGridViewAssistant<KeyStore>(dgvKeyStore);

                refreshViews();

                timerSecond.Enabled = true;

            }
            catch (Exception ex)
            {
                logit(ex.ToString());
            }
        } // method


        private void refreshViews()
        {
            try
            {
                using (OpenTracModel model = new OpenTracModel())
                {
                    dgvaInboundOt.DataSource = model.TRANSACTION_INBOUND
                        .OrderByDescending(rr => rr.TRACKSYS_TRANSACTION_SKEY)
                        .ToList();

                    dgvaOutboundOt.DataSource = model.TRANSACTION_OUTBOUND
                        .OrderByDescending(rr => rr.FINANSYS_TRANSACTION_SKEY)
                        .ToList();


                }

            }
            catch (Exception ex)
            {
                logit(ex.ToString());
            }
        }

        private void logit(string message)
        {
            Log.instance().LogIt(message);
        }
        private void alert(string message)
        {
            labelStatus.Text = message;
            Log.instance().LogIt(message);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshViews();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogAbout dialog = new dialogAbout();
            dialog.ShowDialog();
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            try
            {
                textLogs.Text = Log.instance().LogString;
            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }
        }
    } // class
}
