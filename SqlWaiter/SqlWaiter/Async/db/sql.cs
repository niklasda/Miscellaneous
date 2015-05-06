using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;

namespace Dotway.Demo
{
    class sql
    {

        public static XmlDocument Receive()
        {
            const string _sqlReceive = "RECEIVE conversation_handle, message_type_name, CAST(message_body AS XML) AS message_body FROM NotificationQ;";
            //const string _sqlReceiveWait = "WAITFOR (RECEIVE conversation_handle, message_type_name, CAST(message_body AS XML) AS message_body FROM NotificationQ);";
            const string _sqlEndDialog = "END CONVERSATION @conversationHandle";
            const string _errorMessageType = "http://schemas.microsoft.com/SQL/ServiceBroker/Error";
            const string _endDialogMessageType = "http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog";

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = ".";
            scsb.IntegratedSecurity = true;
            scsb.InitialCatalog = "DemoStage3";
            scsb.MultipleActiveResultSets = true;


            using (SqlConnection cn = new SqlConnection(scsb.ConnectionString))
            {
                cn.Open();

                SqlCommand cm = new SqlCommand(_sqlReceive, cn);
                cm.CommandTimeout = 0;

                //while (true)
               // {
                    using (SqlTransaction tn = cn.BeginTransaction())
                    {
                        cm.Transaction = tn;

                        using (SqlDataReader rd = cm.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            while (rd.Read())
                            {
                                Guid conversationHandle = rd.GetGuid(0);
                                string messageType = rd.GetString(1);
                                if (messageType == _endDialogMessageType || messageType == _errorMessageType)
                                {
                                    SqlCommand cmEndDialog = new SqlCommand(_sqlEndDialog, cn, tn);
                                    cmEndDialog.Parameters.AddWithValue("@conversationHandle", conversationHandle);
                                    cmEndDialog.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlXml xmlNot = rd.GetSqlXml(2);
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load(xmlNot.CreateReader());
                                                                      
                                    return doc;
                                }
                            }
                        }
                        tn.Commit();
                    }
                //}
            }
            return null;
        }
    }
}
