using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Linq;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Transactions;
using System.Web.Caching;
using System.Windows.Forms;
using System.Xml;
using AdoCert.AdventureWorksLTDataSetTableAdapters;
using AdoCert.EF;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;

namespace AdoCert
{
    [SqlClientPermission(SecurityAction.Assert)]
    public partial class Form1 : Form
    {
        private string _connStr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Configuration exeConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection confSec = exeConfiguration.GetSection("connectionStrings");

                if (confSec != null && !confSec.IsReadOnly() && !confSec.SectionInformation.IsLocked && !confSec.SectionInformation.IsProtected)
                {
                    confSec.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                    confSec.SectionInformation.ForceSave = true;
                    exeConfiguration.Save(ConfigurationSaveMode.Full);
                }
                else
                {
                    confSec.SectionInformation.UnprotectSection();
                    confSec.SectionInformation.ForceSave = true;
                    exeConfiguration.Save(ConfigurationSaveMode.Full);
                }

                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Local.Adventureworks"];
                _connStr = settings.ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonConn_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            textBoxLog.AppendText(string.Format("{0} {1} {2}", cn.State, cn.WorkstationId, Environment.NewLine));
            cn.ConnectionString = _connStr;
            cn.StatisticsEnabled = true;
            cn.FireInfoMessageEventOnUserErrors = true;

            cn.StateChange += new StateChangeEventHandler(cn_StateChange);
            cn.InfoMessage += new SqlInfoMessageEventHandler(cn_InfoMessage);

            cn.Open();

            textBoxLog.AppendText(string.Format("{0} {1} {2}b {3}s{4}", cn.DataSource, cn.Database, cn.PacketSize, cn.ConnectionTimeout, Environment.NewLine));

            cn.ChangeDatabase("AdventureWorksLT");

            var sqlCommand = cn.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 20 * FROM SalesLT.Product";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Prepare();
            sqlCommand.ExecuteNonQuery();

            IDictionary statistics = cn.RetrieveStatistics();
            foreach (DictionaryEntry s in statistics)
            {

                textBoxLog.AppendText(string.Format("{0} {1}{2}", s.Key, s.Value, Environment.NewLine));
            }

            textBoxLog.AppendText(string.Format("{0} {1} {2} {3}", cn.State, cn.WorkstationId, cn.ServerVersion, Environment.NewLine));

            cn.Close();
        }

        private void buttonParams_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            textBoxLog.AppendText(string.Format("{0} {1} {2}", cn.State, cn.WorkstationId, Environment.NewLine));
            cn.ConnectionString = _connStr;

            cn.Open();

            textBoxLog.AppendText(string.Format("{0} {1} {2}b {3}s{4}", cn.DataSource, cn.Database, cn.PacketSize, cn.ConnectionTimeout, Environment.NewLine));

            cn.ChangeDatabase("AdventureWorksLT");

            var sqlCommand = cn.CreateCommand();
            sqlCommand.CommandText = "SELECT Count(*) FROM SalesLT.Product WHERE ProductID < @ProductIdLimit";
            sqlCommand.CommandType = CommandType.Text;
            SqlParameter parame = sqlCommand.Parameters.AddWithValue("@ProductIdLimit", 1300);
            parame.SourceColumn = "ProductID";
            parame.SourceColumnNullMapping = false;

            object count = sqlCommand.ExecuteScalar();

            var tvp = SqlDbType.Structured;

            cn.Close();
        }

        private void cn_StateChange(object sender, StateChangeEventArgs e)
        {
            textBoxLog.AppendText(string.Format("STATECHANGE: {0} -> {1}{2}", e.OriginalState, e.CurrentState, Environment.NewLine));
        }

        private void cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            textBoxLog.AppendText(string.Format("INFOMESSAGE: {0} {1}{2}", e.Message, e.Source, Environment.NewLine));
        }

        private void buttonSchema_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            textBoxLog.AppendText(string.Format("{0} {1} {2}", cn.State, cn.WorkstationId, Environment.NewLine));
            cn.ConnectionString = _connStr;
            cn.StatisticsEnabled = true;
            cn.FireInfoMessageEventOnUserErrors = true;

            cn.StateChange += new StateChangeEventHandler(cn_StateChange);
            cn.InfoMessage += new SqlInfoMessageEventHandler(cn_InfoMessage);

            cn.Open();

            textBoxLog.AppendText(string.Format("{0} {1} {2}b {3}s{4}", cn.DataSource, cn.Database, cn.PacketSize, cn.ConnectionTimeout, Environment.NewLine));


            DataTable schema = cn.GetSchema();
            dataGridViewSchema.DataSource = schema;

            textBoxLog.AppendText(string.Format("SCHEMA r={0} c={1}{2}", schema.Rows.Count, schema.Columns.Count, Environment.NewLine));

            IDictionary statistics = cn.RetrieveStatistics();
            foreach (DictionaryEntry s in statistics)
            {

                textBoxLog.AppendText(string.Format("{0} {1}{2}", s.Key, s.Value, Environment.NewLine));
            }

            textBoxLog.AppendText(string.Format("{0} {1} {2} {3}", cn.State, cn.WorkstationId, cn.ServerVersion, Environment.NewLine));

        }

        private void buttonAsync_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            textBoxLog.AppendText(string.Format("{0} {1} {2}", cn.State, cn.WorkstationId, Environment.NewLine));
            cn.ConnectionString = _connStr + "Asynchronous Processing=True";
            cn.StatisticsEnabled = true;
            cn.FireInfoMessageEventOnUserErrors = true;

            cn.StateChange += new StateChangeEventHandler(cn_StateChange);
            cn.InfoMessage += new SqlInfoMessageEventHandler(cn_InfoMessage);

            cn.Open();


            var sqlCommand = cn.CreateCommand();
            sqlCommand.CommandText = "SELECT  * FROM SalesLT.Product";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Prepare();

            string state = "Niklas";
            IAsyncResult asyncResult = sqlCommand.BeginExecuteNonQuery(callback, state);

            int i = sqlCommand.EndExecuteNonQuery(asyncResult);

            IDictionary statistics = cn.RetrieveStatistics();
            foreach (DictionaryEntry s in statistics)
            {

                textBoxLog.AppendText(string.Format("{0} {1}{2}", s.Key, s.Value, Environment.NewLine));
            }

            textBoxLog.AppendText(string.Format("{0} {1} {2} {3}", cn.State, cn.WorkstationId, cn.ServerVersion, Environment.NewLine));
            cn.Close();
        }

        private void callback(IAsyncResult result)
        {
            Debug.WriteLine(string.Format("{0}", result.IsCompleted));
            Debug.WriteLine(string.Format("{0}", result.AsyncState));
            //textBoxLog.AppendText(string.Format("{0} {1} {2} {3}", result.IsCompleted, result.CompletedSynchronously, result.AsyncState, Environment.NewLine));
            //         bool waitOne = result.AsyncWaitHandle.WaitOne();
            // textBoxLog.AppendText(string.Format("{0} {1} ", waitOne, Environment.NewLine));
        }

        private void buttonAsync2_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            textBoxLog.AppendText(string.Format("{0} {1} {2}", cn.State, cn.WorkstationId, Environment.NewLine));
            cn.ConnectionString = _connStr + "Asynchronous Processing=True";
            cn.StatisticsEnabled = true;
            // cn.FireInfoMessageEventOnUserErrors = true;

            // cn.StateChange += new StateChangeEventHandler(cn_StateChange);
            // cn.InfoMessage += new SqlInfoMessageEventHandler(cn_InfoMessage);

            cn.Open();


            var sqlCommand = cn.CreateCommand();
            sqlCommand.CommandText = "SELECT  * FROM SalesLT.Product";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Prepare();

            // string state = "Niklas";
            IAsyncResult asyncResult = sqlCommand.BeginExecuteReader(callback2, sqlCommand);


        }


        private void callback2(IAsyncResult result)
        {
            Debug.WriteLine(string.Format("{0}", result.IsCompleted));
            Debug.WriteLine(string.Format("{0}", result.AsyncState));

            SqlCommand sqlCommand = (SqlCommand)result.AsyncState;
            SqlDataReader rd = sqlCommand.EndExecuteReader(result);
            while (rd.Read())
            {
                Debug.WriteLine(rd[0].ToString());
            }
            rd.Close();

            IDictionary statistics = sqlCommand.Connection.RetrieveStatistics();
            foreach (DictionaryEntry s in statistics)
            {
                Debug.Write(string.Format("{0} {1}{2}", s.Key, s.Value, Environment.NewLine));
            }

            Debug.Write(string.Format("{0} {1} {2} {3}", sqlCommand.Connection.State, sqlCommand.Connection.WorkstationId, sqlCommand.Connection.ServerVersion, Environment.NewLine));
            sqlCommand.Connection.Close();
        }



        private void buttonString_Click(object sender, EventArgs e)
        {
            var csb = new SqlConnectionStringBuilder("SERVER=.;");
            string server = csb.DataSource;

            csb.Clear();
            csb.ApplicationName = "AdventureWorksLT";
            csb.AsynchronousProcessing = false;
            // csb.AttachDBFilename = "AdventureWorks.mdb";
            csb.ConnectTimeout = 20;
            csb.ContextConnection = false;
            csb.CurrentLanguage = "Swedish";
            csb.DataSource = ".";
            csb.Encrypt = false;
            csb.Enlist = false;
            //  csb.FailoverPartner = "";
            csb.InitialCatalog = "AdventureWorksLT";
            csb.IntegratedSecurity = false;
            csb.LoadBalanceTimeout = 100;
            csb.MaxPoolSize = 100;
            csb.MinPoolSize = 1;
            csb.MultipleActiveResultSets = false;
            csb.NetworkLibrary = "dbnmpntw";
            csb.PacketSize = 6000;
            csb.Password = "";
            csb.PersistSecurityInfo = false;
            csb.Pooling = true;  // true false yes no
            csb.Replication = false;
            csb.TransactionBinding = "Implicit Unbind"; // or Explicit Unbind
            csb.TrustServerCertificate = true;
            csb.TypeSystemVersion = "Latest";
            csb.UserID = "654";
            csb.UserInstance = false;
            csb.WorkstationID = Environment.MachineName;

            //   csb.Add("Network Library", "dbmssocn");
            //    csb.Add("Pooling", "no");
            /*
                dbnmpntw - Win32 Named Pipes
                dbmssocn - Win32 Winsock TCP/IP
                dbmsspxn - Win32 SPX/IPX
                dbmsvinn - Win32 Banyan Vines
                dbmsrpcn - Win32 Multi-Protocol (Windows RPC)
            */

            //   string ic = csb["Initial Catalog"].ToString();
            //   string db = csb["Database"].ToString();
            //   csb["Database"] = "AdventureWorksLT2008";

            foreach (KeyValuePair<string, object> entry in csb)
            {
                textBoxLog.AppendText(string.Format("CS k={0} v={1} {2}", entry.Key, entry.Value, Environment.NewLine));
            }
            foreach (string key in csb.Keys)
            {
                textBoxLog.AppendText(string.Format("CS k={0} {1}", key, Environment.NewLine));
            }

            textBoxLog.AppendText(string.Format("CS {0} {1}", csb.ConnectionString, Environment.NewLine));

            IDbConnection cn = new SqlConnection();
            cn.ConnectionString = csb.ToString();

            try
            {
                cn.Open();
                cn.Close();
            }
            catch (SqlException sqlx)
            {
                textBoxLog.AppendText(string.Format("SQL SER:{0} Class:{1}  LN:{2} P:{3} EC:{4} N:{5} S:{6} HL:{7} {8}", sqlx.Server, sqlx.Class, sqlx.LineNumber, sqlx.Procedure, sqlx.ErrorCode, sqlx.Number, sqlx.State, sqlx.HelpLink, Environment.NewLine));
                foreach (SqlError er in sqlx.Errors)
                {
                    if (er.Class > 19)
                    {
                        textBoxLog.AppendText(string.Format("SQL SEVERE({0}) M:{1} {2}", er.Class, er.Message, Environment.NewLine));
                        /* 10 or less are informational and indicate problems caused by mistakes in information that a user has entered.
                         * Severity levels from 11 through 16 are generated by the user, and can be corrected by the user. 
                         * Severity levels from 17 through 25 indicate software or hardware errors.
                         
                         Security: 14
                         */
                    }

                    textBoxLog.AppendText(string.Format("SQL M:{0} {1} {2}", er.Class, er.Message, Environment.NewLine));
                }
            }
            catch (DbException dbx)
            {

            }

            textBoxLog.AppendText(string.Format("{0} {1}  ", cn.State, Environment.NewLine));
        }

        private void buttonAdapter_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            textBoxLog.AppendText(string.Format("{0} {1} {2}", cn.State, cn.WorkstationId, Environment.NewLine));
            cn.ConnectionString = _connStr;
            cn.StatisticsEnabled = true;
            cn.FireInfoMessageEventOnUserErrors = true;

            cn.StateChange += new StateChangeEventHandler(cn_StateChange);
            cn.InfoMessage += new SqlInfoMessageEventHandler(cn_InfoMessage);

            cn.Open();

            textBoxLog.AppendText(string.Format("{0} {1} {2}b {3}s{4}", cn.DataSource, cn.Database, cn.PacketSize, cn.ConnectionTimeout, Environment.NewLine));


            

            var sqlCommand = cn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM SalesLT.Product";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.ExecuteNonQuery();

            var dt = new DataTable();
            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;

            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.MissingMappingAction = MissingMappingAction.Passthrough;

            DataSet dsSch = new DataSet();
            DataTable[] dtSch = adapter.FillSchema(dsSch, SchemaType.Source);
            //      dataGridViewSchema.DataSource = dsSch.Tables[0];
            //return;
            
            var cb = new SqlCommandBuilder(adapter);
            cb.ConflictOption = ConflictOption.OverwriteChanges;
            adapter.UpdateCommand = cb.GetUpdateCommand();
            adapter.UpdateBatchSize = 10;
            adapter.MissingSchemaAction = MissingSchemaAction.Error;

            cb.SetAllValues = false;
            SqlCommand insertCommand = cb.GetInsertCommand();
            SqlCommand updateCommand2 = cb.GetUpdateCommand();
            SqlCommand deleteCommand = cb.GetDeleteCommand();

            adapter.InsertCommand = insertCommand;
            adapter.UpdateCommand = updateCommand2;
            adapter.DeleteCommand = deleteCommand;

            //           adapter = cb.DataAdapter;


            adapter.AcceptChangesDuringFill = false;
            adapter.AcceptChangesDuringUpdate = false;

            adapter.FillLoadOption = LoadOption.OverwriteChanges;
            adapter.FillSchema(dt, SchemaType.Source);
            adapter.Fill(dt);
            
            textBoxLog.AppendText(string.Format("{0} {1}", adapter.SelectCommand.CommandText, Environment.NewLine));
            textBoxLog.AppendText(string.Format("{0} {1}", adapter.InsertCommand.CommandText, Environment.NewLine));
            textBoxLog.AppendText(string.Format("{0} {1}", adapter.UpdateCommand.CommandText, Environment.NewLine));
            textBoxLog.AppendText(string.Format("{0} {1}", adapter.DeleteCommand.CommandText, Environment.NewLine));


            dataGridViewSchema.DataSource = dt;

            IDictionary statistics = cn.RetrieveStatistics();
            foreach (DictionaryEntry s in statistics)
            {

                textBoxLog.AppendText(string.Format("{0} {1}{2}", s.Key, s.Value, Environment.NewLine));
            }

            textBoxLog.AppendText(string.Format("{0} {1} {2} {3}", cn.State, cn.WorkstationId, cn.ServerVersion, Environment.NewLine));

            cn.Close();
        }

        private void buttonPool_Click(object sender, EventArgs e)
        {
            int count = 0;
            bool error = false;
            SqlConnection cn;
            while (!error)
            {
                try
                {

                    cn = new SqlConnection();
                    cn.FireInfoMessageEventOnUserErrors = true;

                    cn.StateChange += new StateChangeEventHandler(cn_StateChange);
                    cn.InfoMessage += new SqlInfoMessageEventHandler(cn_InfoMessage);

                    cn.ConnectionString = _connStr + "Pooling=True;Max Pool Size=20";
                    cn.Open();
                    count++;


                    SqlCommand who = cn.CreateCommand();
                    who.CommandType = CommandType.StoredProcedure;
                    who.CommandText = "sp_who";
                    var rWho = who.ExecuteReader();
                    int rowCount = 0;
                    while (rWho.Read())
                    {
                        rowCount++;
                    }

                    textBoxLog.AppendText(string.Format("{0} {1} {2} {3}{4}", count, cn.State, cn.WorkstationId, rowCount, Environment.NewLine));
                }
                catch (Exception ex)
                {
                    error = true;
                    textBoxLog.AppendText(ex.Message);
                    SqlConnection.ClearAllPools();
                }
            }
        }

        private void buttonFactory_Click(object sender, EventArgs e)
        {
            DataTable factoryClasses = DbProviderFactories.GetFactoryClasses();
            dataGridViewSchema.DataSource = factoryClasses;

            string providerName = ConfigurationManager.ConnectionStrings["Local.Adventureworks"].ProviderName;

            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            if (factory.CanCreateDataSourceEnumerator)
            {
                var dbDataSourceEnumerator = factory.CreateDataSourceEnumerator();
                if (dbDataSourceEnumerator != null)
                {
                    DataTable dt = dbDataSourceEnumerator.GetDataSources();
                    textBoxLog.AppendText(string.Format("DataSources: {0}", dt.Rows.Count));
                }
            }

            DbConnectionStringBuilder connectionStringBuilder = factory.CreateConnectionStringBuilder();
            connectionStringBuilder.Add("SERVER", ".");
            connectionStringBuilder.Add("DATABASE", "AdventureWorksLT");
            connectionStringBuilder.Add("Trusted_Connection", "True");

            IDbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionStringBuilder.ConnectionString;
            connection.Open();

            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(*) FROM SalesLT.Product";

            IDbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            DataSet ds = new DataSet("Set Name");
            adapter.Fill(ds);

            dataGridViewSchema.DataSource = ds;
            dataGridViewSchema.DataMember = ds.Tables[0].TableName;


            object oCount = command.ExecuteScalar();
            string count = oCount.ToString();

            textBoxLog.AppendText(string.Format("RowCount: {0}", count));

            connection.Close();
        }

        private void buttonReader_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            textBoxLog.AppendText(string.Format("{0} {1} {2}", cn.State, cn.WorkstationId, Environment.NewLine));
            cn.ConnectionString = _connStr;

            cn.Open();

            textBoxLog.AppendText(string.Format("{0} {1} {2}b {3}s{4}", cn.DataSource, cn.Database, cn.PacketSize, cn.ConnectionTimeout, Environment.NewLine));


            var sqlCommand = cn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM SalesLT.Product";
            sqlCommand.CommandType = CommandType.Text;
            SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

            bool hasRows = reader.HasRows;
            while (reader.Read())
            {
                int fc = reader.FieldCount;
                int vfc = reader.VisibleFieldCount;

                object o = reader[0];

                SqlInt32 id = reader.GetSqlInt32(0);
                SqlString name = reader.GetSqlString(1);
                SqlString prod = reader.GetSqlString(2);
                SqlString color = reader.GetSqlString(3);
                SqlMoney cost = reader.GetSqlMoney(4);
                SqlMoney price = reader.GetSqlMoney(5);
                SqlString size = reader.GetSqlString(6);
                SqlDecimal weight = reader.GetSqlDecimal(7);
                SqlInt32 catId = reader.GetSqlInt32(8);
                SqlInt32 modelId = reader.GetSqlInt32(9);
                SqlDateTime startDate = reader.GetSqlDateTime(10);
                SqlDateTime endDate = reader.GetSqlDateTime(11);
                SqlDateTime discDate = reader.GetSqlDateTime(12);
                SqlBinary photo = reader.GetSqlBinary(13);
                SqlString file = reader.GetSqlString(14);
                SqlGuid guid = reader.GetSqlGuid(15);
                SqlDateTime modDate = reader.GetSqlDateTime(16);

                textBoxLog.AppendText(string.Format("ROW: {0} {1}{2}", id, name, Environment.NewLine));

            }

            cn.Close();
        }

        private void buttonFullEdit_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            cn.ConnectionString = _connStr;
            cn.StatisticsEnabled = true;

            cn.Open();

            textBoxLog.AppendText(string.Format("{0} {1} {2}b {3}s{4}", cn.DataSource, cn.Database, cn.PacketSize, cn.ConnectionTimeout, Environment.NewLine));


            var selectCommand = cn.CreateCommand();
            selectCommand.CommandText = "SELECT * FROM SalesLT.Product";
            selectCommand.CommandType = CommandType.Text;

            var adapter = new SqlDataAdapter(selectCommand);

            var cb = new SqlCommandBuilder(adapter);
            cb.ConflictOption = ConflictOption.OverwriteChanges;

            SqlCommand insertCommand = cb.GetInsertCommand();
            SqlCommand updateCommand = cb.GetUpdateCommand();
            SqlCommand deleteCommand = cb.GetDeleteCommand();

            selectCommand.StatementCompleted += new StatementCompletedEventHandler(selectCommand_StatementCompleted);
            insertCommand.StatementCompleted += new StatementCompletedEventHandler(insertCommand_StatementCompleted);
            updateCommand.StatementCompleted += new StatementCompletedEventHandler(updateCommand_StatementCompleted);
            deleteCommand.StatementCompleted += new StatementCompletedEventHandler(deleteCommand_StatementCompleted);

            adapter.InsertCommand = insertCommand;
            adapter.UpdateCommand = updateCommand;
            adapter.DeleteCommand = deleteCommand;

            adapter.RowUpdating += new SqlRowUpdatingEventHandler(adapter_RowUpdating);
            adapter.RowUpdated += new SqlRowUpdatedEventHandler(adapter_RowUpdated);

            var ds = new DataSet("MySet");
            adapter.Fill(ds, 0, 100, "NewTable1");

            dataGridViewSchema.Tag = adapter;

            ds.Tables[0].RowChanging += new DataRowChangeEventHandler(dt_RowChanging);
            ds.Tables[0].RowChanged += new DataRowChangeEventHandler(dt_RowChanged);
            ds.Tables[0].RowDeleting += new DataRowChangeEventHandler(dt_RowDeleting);
            ds.Tables[0].RowDeleted += new DataRowChangeEventHandler(dt_RowDeleted);

            dataGridViewSchema.AllowDrop = false;
            dataGridViewSchema.AllowUserToAddRows = true;
            dataGridViewSchema.AllowUserToDeleteRows = true;
            dataGridViewSchema.AllowUserToOrderColumns = false;
            dataGridViewSchema.AllowUserToResizeColumns = true;
            dataGridViewSchema.AllowUserToResizeRows = true;
            dataGridViewSchema.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridViewSchema.ReadOnly = false;

            dataGridViewSchema.DataSource = ds;
            dataGridViewSchema.DataMember = ds.Tables[0].TableName;

            cn.Close();
        }

        void adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            textBoxLog.AppendText(string.Format("UPDATING {0} - {1} {2}{3}", e.Status, e.Command.CommandText, e.Row.RowState, Environment.NewLine));
        }

        void adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            textBoxLog.AppendText(string.Format("UPDATED {0} - {1} {2}{3}", e.Status, e.Command.CommandText, e.Row.RowState, Environment.NewLine));
        }

        void dt_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            textBoxLog.AppendText(string.Format("CHANGING {0} - {1}{2}", e.Action, e.Row.RowState, Environment.NewLine));
        }

        void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            textBoxLog.AppendText(string.Format("CHANGED {0} - {1}{2}", e.Action, e.Row.RowState, Environment.NewLine));
        }

        void dt_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            textBoxLog.AppendText(string.Format("DELETING {0} - {1}{2}", e.Action, e.Row.RowState, Environment.NewLine));
        }

        void dt_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            textBoxLog.AppendText(string.Format("DELETED {0} - {1}{2}", e.Action, e.Row.RowState, Environment.NewLine));
        }

        void selectCommand_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            SqlCommand cmd = (SqlCommand)sender;
            textBoxLog.AppendText(string.Format("SELECTCOMPLETE {0} - {1}{2}", e.RecordCount, cmd.CommandText, Environment.NewLine));
        }

        void updateCommand_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            SqlCommand cmd = (SqlCommand)sender;
            textBoxLog.AppendText(string.Format("UPDATECOMPLETE {0} - {1}{2}", e.RecordCount, cmd.CommandText, Environment.NewLine));
        }

        void insertCommand_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            SqlCommand cmd = (SqlCommand)sender;
            textBoxLog.AppendText(string.Format("INSERTCOMPLETE {0} - {1}{2}", e.RecordCount, cmd.CommandText, Environment.NewLine));
        }

        void deleteCommand_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            SqlCommand cmd = (SqlCommand)sender;
            textBoxLog.AppendText(string.Format("DELETECOMPLETE {0} - {1}{2}", e.RecordCount, cmd.CommandText, Environment.NewLine));
        }

        private void buttonXmlReader_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(_connStr);
            cn.Open();
            textBoxLog.AppendText(string.Format("OpenConnection {0}{1}", cn.State, Environment.NewLine));

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM SalesLT.Product FOR XML AUTO", cn);
            XmlReader rd = cmd1.ExecuteXmlReader();
            while (rd.Read())
            {
                // if (rd.NodeType != XmlNodeType.None)
                // {
                //    string i = rd.ReadInnerXml();
                string o = rd.ReadOuterXml();
                //string xml = rd.ReadElementString();
                //     var x0 = rd[0];
                //     var x1 = rd[1];
                //     var x2 = rd[2];
                //     var x3 = rd[3];
                //     var x4 = rd[4];
                //     var x5 = rd[5];
                textBoxLog.AppendText(string.Format("Reading XML {0}{1}", o.Substring(0, Math.Min(70, o.Length)),
                                                    Environment.NewLine));
                // }
            }
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable("My Table");
            tbl.Prefix = "XmNs";

            DataColumn col1 = tbl.Columns.Add("Col1", typeof(int));
            DataColumn col2 = tbl.Columns.Add("Col2", typeof(string));
            DataColumn col3 = tbl.Columns.Add("Col3", typeof(string));

            col1.Caption = "ettan";
            col2.Caption = "tvåan";

            // col3.Unique = true;
            col3.Expression = "'1'+Col1+Col2";
            col3.AllowDBNull = false;
            col3.AllowDBNull = false;
            col3.Caption = "Min fina kolumn";
            col3.ColumnName = "Col3";
            col3.MaxLength = 10;
            col3.ReadOnly = true;

            tbl.Rows.Add(new object[] { 0, "Niklas" });
            tbl.Rows.Add(new object[] { 1, "Niklas2" });

            

            DataTable tbl2 = new DataTable("My Table");

            DataColumn col2_1 = tbl2.Columns.Add("Col1", typeof(int));
            col2_1.AutoIncrement = true;
            col2_1.AutoIncrementSeed = 100;
            col2_1.ReadOnly = true;

            DataColumn col2_2 = tbl2.Columns.Add("Col2", typeof(string));
            DataColumn col2_3 = tbl2.Columns.Add("Col3", typeof(int));
            col2_3.DefaultValue = "42";
            col2_3.AllowDBNull = true;



            tbl2.Rows.Add(new object[] { null, "Niklas3", null });
            tbl2.Rows.Add(new object[] { 12, "Niklas4", null });



            DataTable tblTot = new DataTable("My Tot Table");
            tblTot.Load(tbl.CreateDataReader(), LoadOption.PreserveChanges);
            // tblTot.Load(tbl2.CreateDataReader(), LoadOption.PreserveChanges);
            // tblTot.Load(tbl2.CreateDataReader(), LoadOption.PreserveChanges);

            //tblTot.Merge(tbl2, true, MissingSchemaAction.Error);


            dataGridViewSchema.DataSource = tblTot;

            DataSet ds = new DataSet("a test dataset to test with");
            ds.Load(tbl.CreateDataReader(), LoadOption.OverwriteChanges, "tabl1");
            ds.Tables.Add(tbl2);

            DataTableReader rd = ds.CreateDataReader(new[] { tbl2, tbl });

            DataSet ds2 = new DataSet();
            ds2.Load(rd, LoadOption.OverwriteChanges, new[] { "t1", "t2" });

            ds.WriteXml("baradata.xml");
            ds.WriteXmlSchema("baraschema.xml");
            ds.WriteXml("dataMschema.xml", XmlWriteMode.WriteSchema);

            ds.ReadXmlSchema("baraschema.xml");
            ds.ReadXml("baradata.xml");



            DataRow loadDataRow = tblTot.LoadDataRow(new object[] { 13, "ny", null }, LoadOption.OverwriteChanges);
            loadDataRow.RowError = "my little error";
            loadDataRow.SetColumnError(0, "col 0 error");
            //loadDataRow.ItemArray[1] = "ipd";
            loadDataRow.SetModified();
            // loadDataRow.SetAdded();
            loadDataRow.AcceptChanges();
            var jhg = loadDataRow.Field<string>(2);

            DataRow[] dataRows = tblTot.GetErrors();

            DataRow[] allselect = tblTot.Select();
            object exectst = tblTot.Compute("MAX(Col1)", null);
            DataRow[] newselect = tblTot.Select(null, null, DataViewRowState.ModifiedCurrent);
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            DataTable tbl1 = new DataTable("My Table1");
            DataColumn col1_1 = tbl1.Columns.Add("Col1_1", typeof(int));
            DataColumn col1_2 = tbl1.Columns.Add("Col1_2", typeof(string));

            tbl1.Rows.Add(new object[] { 0, "Niklas" });
            tbl1.Rows.Add(new object[] { 1, "Niklas2" });

            DataTable tbl2 = new DataTable("My Table2");
            DataColumn col2_1 = tbl2.Columns.Add("Col2_1", typeof(int));
            DataColumn col2_2 = tbl2.Columns.Add("Col2_2", typeof(string));

            tbl2.Rows.Add(new object[] { 0, "Dahlman" });
            tbl2.Rows.Add(new object[] { 1, "Dahlman2" });

            //--

            DataSet ds1 = new DataSet("DataSet1");
            ds1.Tables.Add(tbl1);
            ds1.Tables.Add(tbl2);

            //--

           
            UniqueConstraint key = new UniqueConstraint(col1_1, true);
            tbl1.Constraints.Add(key);

            ForeignKeyConstraint fk = new ForeignKeyConstraint("fk", col1_1, col2_2);
            fk.AcceptRejectRule = AcceptRejectRule.Cascade;
            fk.DeleteRule = Rule.SetDefault;

            DataRelation drel = new DataRelation("TestRel", col1_1, col2_1, true);
            ds1.Relations.Add(drel);


            DataSet ds2 = new DataSet("DataSet2");

            ds2.Merge(ds1, false, MissingSchemaAction.AddWithKey);

            //--

            dataGridViewSchema.DataSource = ds2;
            dataGridViewSchema.DataMember = "My Table2";
        }

        private void buttonMars_Click(object sender, EventArgs e)
        {
            SqlConnection cn;// = new SqlConnection(_connStr + "MultipleActiveResultSets=True;");
            cn = new SqlConnection(_connStr);
            //            cn = new SqlConnection(_connStr + "MultipleActiveResultSets=True;");
            cn.Open();
            textBoxLog.AppendText(string.Format("OpenConnection {0}{1}", cn.State, Environment.NewLine));

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM SalesLT.Product", cn);
            var rd1 = cmd1.ExecuteReader();
            textBoxLog.AppendText(string.Format("Reader 1 {0}{1}", cmd1.CommandType, Environment.NewLine));

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM SalesLT.Product", cn);
            var rd2 = cmd2.ExecuteReader();
            textBoxLog.AppendText(string.Format("Reader 2 {0}{1}", cmd2.CommandText, Environment.NewLine));

            cn.Close();
            textBoxLog.AppendText(string.Format("CloseConnection {0}{1}", cn.State, Environment.NewLine));
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            object tag = dataGridViewSchema.Tag;
            var adapter = (SqlDataAdapter)tag;


            object source = dataGridViewSchema.DataSource;
            if (source != null)
            {
                var dt = source as DataTable;
                if (dt != null)
                {
                    if (!dt.HasErrors)
                    {
                        adapter.Update(dt);
                    }
                    else
                    {
                        textBoxLog.AppendText("Table has errors: " + Environment.NewLine);
                    }
                }
                else
                {
                    var ds = source as DataSet;
                    if (ds != null)
                    {
                        var dataSet = ds.GetChanges();
                        if (dataSet == null)
                        {
                            textBoxLog.AppendText(string.Format("No change: {0}", Environment.NewLine));
                        }
                        else
                        {
                            textBoxLog.AppendText(string.Format("changecount: {0} {1}", dataSet.Tables[0].Rows.Count,
                                                                Environment.NewLine));
                        }

                        if (!ds.HasErrors)
                        {
                            adapter.Update(ds);
                        }
                        else
                        {
                            textBoxLog.AppendText("Set has errors: " + Environment.NewLine);
                        }
                    }
                }
            }
        }

        private void buttonLinqSql_Click(object sender, EventArgs e)
        {
            var ctx = new DataClassesProdDataContext(_connStr);
            Table<Product> table = ctx.GetTable<Product>();
            table.InsertOnSubmit(new Product());
            ctx.SubmitChanges(ConflictMode.ContinueOnConflict);

            IQueryable<Product> products = from p in ctx.Products where p.ProductID < 730 select p;
            dataGridViewSchema.DataSource = products;

            string sql = products.ToString();
            /*
            ctx.SubmitChanges(ConflictMode.ContinueOnConflict);
            foreach(ObjectChangeConflict c in ctx.ChangeConflicts)
            {
                
            }*/
        }

        private void buttonLinqEf_Click(object sender, EventArgs e)
        {
            var ecsb = new EntityConnectionStringBuilder();
            ecsb.Metadata = "res://*/ModelProd.csdl|res://*/ModelProd.ssdl|res://*/ModelProd.msl";
            ecsb.Provider = "System.Data.SqlClient";
            ecsb.ProviderConnectionString = _connStr;



            EntityConnection cn = new EntityConnection(ecsb.ConnectionString);
            cn.Open();
            EntityCommand cd = new EntityCommand("SELECT ROW(p), p.ProductID FROM AdventureWorksLT2008Entities.Products AS p WHERE p.ProductID > 998", cn);
            EntityDataReader rd = cd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (rd.Read())
            {
                object x = rd[0];
                DbDataRecord rec = (DbDataRecord)x;
                DbDataRecord p = (DbDataRecord)rec[0];
                object pid = p[0];
                int pid2 = rd.GetInt32(1);
            }


            var ent = new AdventureWorksLT2008Entities(ecsb.ConnectionString);

            IQueryable<EF.Product> products = from p in ent.Products where p.ProductID > 320 && p.ProductID < 720 select p;
            ObjectQuery<EF.Product> q = (ObjectQuery<EF.Product>)products;
            string sql = q.ToTraceString();

            ObjectQuery<EF.Product> q1 = ent.Products.Where("it.ProductID > 330");
            string sql1 = q1.ToTraceString();

            List<EF.Product> pl = products.ToList();

            dataGridViewSchema.DataSource = pl;
        }

        private void buttonCache_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(_connStr);
            cn.Open();

            SqlCacheDependencyAdmin.EnableNotifications(_connStr);
            // SqlCacheDependencyAdmin.EnableTableForNotifications(_connStr, "SalesLT.Product");
            string[] tablesAfter = SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(_connStr);

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = cn;
            selectCommand.CommandText = "SELECT * FROM SalesLT.Product";
            selectCommand.CommandType = CommandType.Text;

            SqlCacheDependency scd = new SqlCacheDependency(selectCommand);


            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = cn;
            updateCommand.CommandText = "UPDATE SalesLT.Product SET Name = 'HL Road Frame - Black, 58' WHERE ProductID = 680";
            updateCommand.CommandType = CommandType.Text;
            updateCommand.ExecuteNonQuery();

            Cache c = new Cache();
            c.Insert("key", "value", null, DateTime.Today.AddDays(1), Cache.NoSlidingExpiration);
            c.Insert("key", "value", null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1));

            c.Add("key", "stuffToStore", scd, DateTime.Today.AddDays(1), TimeSpan.FromHours(1), CacheItemPriority.AboveNormal, null);
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            SyncOrchestrator orch = new SyncOrchestrator();
            orch.Synchronize();

            //SyncAgent sa = new SyncAgent();
            SyncGroup sg = new SyncGroup("grp1");
            
            SyncTable st = new SyncTable("cltblname");
            st.SyncGroup = sg;
            st.CreationOption = TableCreationOption.UseExistingTableOrFail;
            st.SyncDirection = SyncDirection.Bidirectional;
            st.TableName = "ClientDbName";
            st.CreationOption = TableCreationOption.UseExistingTableOrFail;

            //MyLocalDataCacheSyncAgent myAgent = new MyLocalDataCacheSyncAgent();
            // Call SyncAgent.Synchronize() to initiate the synchronization process.
            // Synchronization only updates the local database, not your project's data source.
            MyLocalDataCacheSyncAgent syncAgent = new MyLocalDataCacheSyncAgent();
            syncAgent.LocalProvider = new ClProv();
            syncAgent.RemoteProvider = new ServProv();
            SyncStatistics syncStats = syncAgent.Synchronize();

            // TODO: Reload your project data source from the local database (for example, call the TableAdapter.Fill method).
            textBoxLog.AppendText(string.Format("SYNC DCA:{0} DCF:{1} TCD:{2} TCU:{3} UCA:{4} UCF:{5} {6}", syncStats.DownloadChangesApplied, syncStats.DownloadChangesFailed, syncStats.TotalChangesDownloaded, syncStats.TotalChangesUploaded, syncStats.UploadChangesApplied, syncStats.UploadChangesFailed, Environment.NewLine));

            AdventureWorksLTDataSet data = new AdventureWorksLTDataSet();
            SalesLT_ProductTableAdapter ta = new SalesLT_ProductTableAdapter();
            ta.Fill(data.SalesLT_Product);

            TableAdapterManager tam = new TableAdapterManager();
            tam.UpdateAll(data);



            dataGridViewSchema.DataSource = data.SalesLT_Product;
        }



        public class ClProv : ClientSyncProvider
        {
            public override void BeginTransaction(SyncSession syncSession)
            {
                throw new NotImplementedException();
            }

            public override void EndTransaction(bool commit, SyncSession syncSession)
            {
                throw new NotImplementedException();
            }

            public override SyncAnchor GetTableSentAnchor(string tableName)
            {
                throw new NotImplementedException();
            }

            public override void SetTableSentAnchor(string tableName, SyncAnchor anchor)
            {
                throw new NotImplementedException();
            }

            public override SyncAnchor GetTableReceivedAnchor(string tableName)
            {
                throw new NotImplementedException();
            }

            public override void SetTableReceivedAnchor(string tableName, SyncAnchor anchor)
            {
                throw new NotImplementedException();
            }

            public override void CreateSchema(SyncTable syncTable, SyncSchema syncSchema)
            {
                throw new NotImplementedException();
            }

            public override SyncContext GetChanges(SyncGroupMetadata groupMetadata, SyncSession syncSession)
            {
                throw new NotImplementedException();
            }

            public override SyncContext ApplyChanges(SyncGroupMetadata groupMetadata, DataSet dataSet, SyncSession syncSession)
            {
                throw new NotImplementedException();
            }

            public override void Dispose()
            {
                throw new NotImplementedException();
            }

            public override Guid ClientId
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }

        public class ServProv : ServerSyncProvider
        {
            public override SyncSchema GetSchema(Collection<string> tableNames, SyncSession syncSession)
            {
                throw new NotImplementedException();
            }

            public override SyncContext GetChanges(SyncGroupMetadata groupMetadata, SyncSession syncSession)
            {
                throw new NotImplementedException();
            }

            public override SyncContext ApplyChanges(SyncGroupMetadata groupMetadata, DataSet dataSet, SyncSession syncSession)
            {
                throw new NotImplementedException();
            }

            public override void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        private void buttonDependency_Click(object sender, EventArgs e)
        {
            SqlClientPermission perm = new SqlClientPermission(PermissionState.Unrestricted);
            perm.Demand();

            SqlDependency.Stop(_connStr);
            SqlDependency.Start(_connStr);

            SqlConnection cn = new SqlConnection(_connStr);
            SqlCommand selectCommand = cn.CreateCommand();

            selectCommand.CommandText = "SELECT sdf FROM SalesLT.Product";
            selectCommand.CommandType = CommandType.Text;
            selectCommand.Notification = null;


            dep = new SqlDependency(selectCommand);
            dep.OnChange += new OnChangeEventHandler(dep_OnChange);

            cn.Open();

            Thread.Sleep(5000);

            SqlCommand updateCommand = cn.CreateCommand();
            updateCommand.CommandText = "UPDATE SalesLT.Product SET Name = 'HL Road Frame - Black, 58kks2' WHERE ProductID = 680";
            updateCommand.CommandType = CommandType.Text;
            updateCommand.ExecuteNonQuery();

        }

        private void buttonRemoveDep_Click(object sender, EventArgs e)
        {
            SqlDependency.Stop(_connStr);
        }

        private SqlDependency dep;
        void dep_OnChange(object sender, SqlNotificationEventArgs e)
        {

            if (textBoxLog.InvokeRequired)
            {
                WriteToLog w = new WriteToLog(textBoxLog.AppendText);
                textBoxLog.Invoke(w, "CHANGE delegate" + Environment.NewLine);

            }
            else
            {
                textBoxLog.AppendText("CHANGE" + Environment.NewLine);
            }
        }

        public delegate void WriteToLog(string message);


        private void buttonPermission_Click(object sender, EventArgs e)
        {
            SqlClientPermission perm = new SqlClientPermission(PermissionState.Unrestricted);
            perm.Demand();
        }

        private void buttonBulk_Click(object sender, EventArgs e)
        {
            var cn1 = new SqlConnection(_connStr);
            DataTable data = new DataTable("data to copy");

            SqlBulkCopy bulk = new SqlBulkCopy(cn1, SqlBulkCopyOptions.Default, null);
            bulk.DestinationTableName = "new table";
            bulk.WriteToServer(data);
        }

        private void buttonTrans_Click(object sender, EventArgs e)
        {


            using (TransactionScope txs = new TransactionScope(TransactionScopeOption.Required))
            {
                string li0 = "li: " + Transaction.Current.TransactionInformation.LocalIdentifier + "di: " + Transaction.Current.TransactionInformation.DistributedIdentifier + " t:" + Transaction.Current.TransactionInformation.CreationTime;
                Console.WriteLine(li0);

                //using(SqlConnection cn = new SqlConnection())
                // {
                IPromotableSinglePhaseNotification prosingle1 = new PrettyProEnlisterNote();
                ISinglePhaseNotification single1 = new PrettySinglePhaser();
                IEnlistmentNotification note1 = new PrettyEnlisterNote();
                ISinglePhaseNotification single2 = new PrettySinglePhaser();
                IEnlistmentNotification note2 = new PrettyEnlisterNote();

                string li1 = "li: " + Transaction.Current.TransactionInformation.LocalIdentifier + "di: " + Transaction.Current.TransactionInformation.DistributedIdentifier + " t:" + Transaction.Current.TransactionInformation.CreationTime;
                Console.WriteLine(li1);

                Transaction.Current.EnlistPromotableSinglePhase(prosingle1);
                string li11 = "li: " + Transaction.Current.TransactionInformation.LocalIdentifier + "di: " + Transaction.Current.TransactionInformation.DistributedIdentifier + " t:" + Transaction.Current.TransactionInformation.CreationTime;
                Console.WriteLine(li11);

                Transaction.Current.EnlistDurable(Guid.NewGuid(), single1, EnlistmentOptions.None);
                string li2 = "li: " + Transaction.Current.TransactionInformation.LocalIdentifier + "di: " + Transaction.Current.TransactionInformation.DistributedIdentifier + " t:" + Transaction.Current.TransactionInformation.CreationTime;
                Console.WriteLine(li2);

                Transaction.Current.EnlistDurable(Guid.NewGuid(), note1, EnlistmentOptions.None);

                string li3 = "li: " + Transaction.Current.TransactionInformation.LocalIdentifier + "di: " + Transaction.Current.TransactionInformation.DistributedIdentifier + " t:" + Transaction.Current.TransactionInformation.CreationTime;
                Console.WriteLine(li3);

                Transaction.Current.EnlistDurable(Guid.NewGuid(), single2, EnlistmentOptions.None);

                string li4 = "li: " + Transaction.Current.TransactionInformation.LocalIdentifier + "di: " + Transaction.Current.TransactionInformation.DistributedIdentifier + " t:" + Transaction.Current.TransactionInformation.CreationTime;
                Console.WriteLine(li4);

                Transaction.Current.EnlistDurable(Guid.NewGuid(), note2, EnlistmentOptions.None);

                //}

                txs.Complete();
            }
        }
    }

    public class PrettySinglePhaser : ISinglePhaseNotification
    {
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            preparingEnlistment.Prepared();
            Console.WriteLine("Prep");
        }

        public void Commit(Enlistment enlistment)
        {
            enlistment.Done();
            Console.WriteLine("comm");
        }

        public void Rollback(Enlistment enlistment)
        {
            Console.WriteLine("roll");
        }

        public void InDoubt(Enlistment enlistment)
        {
            Console.WriteLine("doubt");
        }

        public void SinglePhaseCommit(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            Console.WriteLine("spc");
            singlePhaseEnlistment.InDoubt();
        }
    }

    public class PrettyEnlisterNote : IEnlistmentNotification
    {
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            preparingEnlistment.Prepared();
            Console.WriteLine("Prep");
        }

        public void Commit(Enlistment enlistment)
        {
            enlistment.Done();
            Console.WriteLine("comm");
        }

        public void Rollback(Enlistment enlistment)
        {
            Console.WriteLine("roll");
        }

        public void InDoubt(Enlistment enlistment)
        {
            Console.WriteLine("doubt");
        }
    }

    public class PrettyProEnlisterNote : IPromotableSinglePhaseNotification
    {
        public byte[] Promote()
        {
            Console.WriteLine("pro");
            throw new NotImplementedException("fubar");
            //IDtcTransaction dtcTransaction = TransactionInterop.GettDtcTransaction(Transaction.Current);
            //byte[] token = TransactionInterop.GetTransmitterPropagationToken(dtcTransaction);
            //TransactionInterop.GetTransactionFromTransmitterPropagationToken(token);
            //    return token;
        }

        public void Initialize()
        {
            Console.WriteLine("ini");
        }

        public void SinglePhaseCommit(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            Console.WriteLine("spc");
        }

        public void Rollback(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            Console.WriteLine("roll");
        }
    }

}