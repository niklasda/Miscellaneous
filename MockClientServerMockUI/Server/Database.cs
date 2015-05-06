using System.Data.SqlClient;

using Mockdemo.BusinessClasses;

namespace Mockdemo.Server
{
    public class Database : IDatabase
    {
        public Database(bool isConnected)
        {
            connected = isConnected;
        }
        public Database()
        {
        }
        private bool connected = false;
        
        private SqlConnection getConnection()
        {
            if (connected)
            {
                return new SqlConnection("SERVER=.;DATABASE=AdventureWorks;Trusted_Connection=yes;");
            }
            else
            {
                return new SqlConnection("SERVER=.;DATABASE=AdventureWorks;");
            }
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
                conn.Close();

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

        public Product GetExistingProduct(int id)
        {
            SqlConnection conn = null;
            try 
            {
                conn = getConnection();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Production.Product WHERE ProductID=@id", conn);
                comm.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader r = comm.ExecuteReader();
                if (!r.Read())
                {
                    // don't throw business exception here
                    return null;
                }
                else
                {
                    return new Product(id); 
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool ProductIdAlreadyExists(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = getConnection();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Production.Product WHERE ProductID=@id", conn);
                comm.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader r = comm.ExecuteReader();
                if (r.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
