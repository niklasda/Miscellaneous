using System;
using System.Data.SqlClient;
using System.Text;

namespace FactoryDemo
{
    public class Database : IDatabase
    {
        private SqlConnection getConnection()
        {
            return new SqlConnection("SERVER=.;DATABASE=AdventureWorks;Trusted_Connection=yes;");
        }

        public Person GetExistingPerson(int id)
        {
            SqlConnection conn = null;
            try 
            {
                conn = getConnection();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Person.Contact WHERE ContactID=@id", conn);
                comm.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader r = comm.ExecuteReader();
                if (!r.Read())
                {
                    // don't throw business exception here
                    return null;
                }
                else
                {
                    Person p = new Person(id);
                    p.SetName(r["FirstName"].ToString(), r["LastName"].ToString());
                    return p; 
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

        public bool PersonIdAlreadyExists(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = getConnection();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Person.Contact WHERE ContactID=@id", conn);
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
