using System;
using System.Data.SqlClient;

namespace DependencyInjectionDemo
{
    /// <summary>
    /// This is the database layer that will be mock in the tests
    /// </summary>
    public class Database : IDatabase
    {
        private SqlConnection getConnection()
        {
            return new SqlConnection("SERVER=.;DATABASE=AdventureWorks;Trusted_Connection=yes;");
        }

        public string GetVersion()
        {
            SqlConnection conn = null;
            try
            {
                conn = getConnection();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT @@version;", conn);

                string ver = (string)comm.ExecuteScalar();

                ver = ver.Replace("\n", "\r\n");
                return ver;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
