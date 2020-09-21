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
using System.Data.OleDb;
using System.Data.SqlClient;

namespace OpenTracDashboard
{
    public partial class FormMain : Form
    {

        public DataGridViewAssistant<TRANSACTION_INBOUND> dgvaInboundOt;
        public DataGridViewAssistant<TRANSACTION_OUTBOUND> dgvaOutboundOt;
        public DataGridViewAssistant<KeyStore> dgvaKeyStore;

        public string OtConnection;
        public string SpcConnection;

        List<OpentracMessage> otMessageList = new List<OpentracMessage>();

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

                OtConnection = Properties.Settings.Default.OpenTracConnection;
                SpcConnection = Properties.Settings.Default.SpcConnection;

                string explanation = "";
                OpentracMessage.ReadFromFile(Properties.Settings.Default.OpenTracMessagesPath, out otMessageList, out explanation);

                refreshViews(OtConnection, SpcConnection);

                timerSecond.Enabled = true;

            }
            catch (Exception ex)
            {
                logit(ex.ToString());
            }
        } // method


        private void refreshViews(string OtConnection, string SpcConnection)
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

                    dgvaKeyStore.DataSource = model.KeyStores
                        .ToList();

                    KeyStore ks = model.KeyStores.First();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Format("LastTrackSys: SKey={0} Time={1} Desc={2}",
                        ks.LastTrackSysProcessed,
                        ks.LastTrackSysProcessedTime.Value.ToString("dd-MMM-yy HH:mm:ss"),
                        ks.LastTrackSysDescription));

                    sb.AppendLine(string.Format("LastFinanSys: SKey={0} Time={1} Desc={2}",
                        ks.LastFinanSysUsed,
                        ks.LastFinanSysUsedTime.Value.ToString("dd-MMM-yy HH:mm:ss"),
                        ks.LastTrackSysDescription));

                    textOpenTracInfo.Text = sb.ToString();

                }

                using (OleDbConnection conn = new OleDbConnection(SpcConnection))
                {
                    conn.Open();

                    //--------------------------------------------------------------'
                    string sql = "SELECT * FROM nb_ot_transaction_inbound ORDER BY tracksys_transaction_skey DESC";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                    DataSet dsIn = new DataSet();


                    adapter.Fill(dsIn, "nb_ot_transaction_inbound");
                    dgvInboundSpc.DataSource = dsIn;
                    dgvInboundSpc.DataMember = "nb_ot_transaction_inbound";

                    //--------------------------------------------------------------'
                    sql = "SELECT * FROM nb_ot_transaction_outbound ORDER BY finansys_transaction_skey DESC";

                    adapter = new OleDbDataAdapter(sql, conn);
                    DataSet dsOut = new DataSet();

                    adapter.Fill(dsOut, "nb_ot_transaction_outbound");
                    dgvOutboundSpc.DataSource = dsOut;
                    dgvOutboundSpc.DataMember = "nb_ot_transaction_outbound";


                }


                //    Dim adapter As New SqlDataAdapter(sqlCmd)


                //    Dim ds As New DataSet

                //    adapter.Fill(ds, 0, count, "PipeData")


                //    Dim dr As DataRow


                //    dr = ds.Tables(0).Rows(0)
                //    dgvRealtime.DataSource = ds

                //    dgvRealtime.DataMember = "PipeData"


                //End Using


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
            refreshViews(OtConnection, SpcConnection);
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

        private void buttonRunSpcSelect_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(SpcConnection))
                {
                    conn.Open();

                    //--------------------------------------------------------------'
                    string sql = textSpcSqlSelect.Text;
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);
                    cb.QuotePrefix = "[";
                    cb.QuoteSuffix = "]";

                    adapter.Fill(dt);
                    dgvSpcSelect.DataSource = dt.DefaultView;

                   // dgvInboundSpc.DataMember = dsIn.Tables[0].TableName;


                }


            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }
        }

        private void buttonRunSpcUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(SpcConnection))
                {
                    conn.Open();

                    //--------------------------------------------------------------'
                    string sql = textSpcSqlUpdate.Text;

                    OleDbCommand cmd = new OleDbCommand(sql, conn);

                    int affected = cmd.ExecuteNonQuery();
                    labelSpcUpdateResult.Text = string.Format("Affected {0} rows.", affected);

                }


            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonRunOpentracSelect_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(OtConnection))
                {
                    conn.Open();

                    //--------------------------------------------------------------'
                    string sql = textOpentracSqlSelect.Text;
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
                    cb.QuotePrefix = "[";
                    cb.QuoteSuffix = "]";

                    adapter.Fill(dt);
                    dgvOpenTracSelect.DataSource = dt.DefaultView;

                    // dgvInboundSpc.DataMember = dsIn.Tables[0].TableName;


                }


            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }

        }

        private void buttonRunOpentracUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(OtConnection))
                {
                    conn.Open();

                    //--------------------------------------------------------------'
                    string sql = textOpentracSqlUpdate.Text;

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    int affected = cmd.ExecuteNonQuery();
                    labelOpentracUpdateResult.Text = string.Format("Affected {0} rows.", affected);

                }


            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }

        }

        private void buttonOpenTracChangeSKeys_Click(object sender, EventArgs e)
        {
            try
            {
                decimal fromKey = 0;
                decimal toKey = 0;

                if (!Decimal.TryParse(textOpenTracOldSkeyValue.Text, out fromKey))
                {
                    alert(string.Format("Cannot parse 'From' key={0}", textOpenTracOldSkeyValue.Text));
                    return;
                }

                if (!Decimal.TryParse(textOpenTracNewSkeyValue.Text, out toKey))
                {
                    alert(string.Format("Cannot parse 'To' key={0}", textOpenTracNewSkeyValue.Text));
                    return;
                }


                using (SqlConnection conn = new SqlConnection(OtConnection))
                {
                    conn.Open();

                    //--------------------------------------------------------------'
                    string sqlFmt = "Update {0} Set TrackSys_Transaction_SKey={1} Where TrackSys_Transaction_Skey={2}";

                    List<string> tableList = textOpenTrackTablesToChange.Text.Split(',').ToList();

                    int ttlAffected = 0;
                    foreach (string table in tableList)
                    {
                        string sql = string.Format(sqlFmt, table, toKey, fromKey);
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        int affected = cmd.ExecuteNonQuery();
                        logit( string.Format("Info: Sql={0} Affected {0} rows.", sql, affected));
                        ttlAffected += affected;
                    }

                    if ( ttlAffected != tableList.Count)
                    {
                        alert(string.Format("Errors. There were {0} tables, but {1} affected rows", 
                            tableList.Count, ttlAffected));
                    }

                } // using

            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }
        }

        private void buttonOpentracCodeFetch_Click(object sender, EventArgs e)
        {
            try
            {
                OpentracMessage msg = otMessageList.Where(rr => rr.Code.ToUpper() == textOpenTracCode.Text.ToUpper()).First();
                if ( msg == null )
                {
                    alert(string.Format("No tables for Code={0} found", msg.Code));
                    return;
                }

                string tables = "";
                foreach ( string table in msg.TableList)
                {
                    tables += string.Format(",{0}", table);
                }
                tables = tables.Substring(1);
                textOpenTrackTablesToChange.Text = tables;


            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }
        }
    } // class
}
