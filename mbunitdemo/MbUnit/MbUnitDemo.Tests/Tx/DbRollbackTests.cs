using System.Data;
using System.Data.SqlClient;
using Gallio.Framework;
using MbUnit.Framework;

namespace MbUnitDemo.Tests.Tx
{
    public class DbRollbackTests
    {
        [Test]
        [Pending("Has nothing to rollback, this not work")]
        [Importance(Importance.Serious)]
        [Rollback(IncludeSetUpAndTearDown = false)]
        public void Ignored()
        {
            var cn = new SqlConnection("SERVER=.;DATABASE=Persons;Trusted_Connection=True;");
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Persons (name, age) VALUES ('niklas', 32)";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();

            TestLog.WriteLine("Count: "+ getPeopleCount());
        }

        private int getPeopleCount()
        {
            SqlConnection cn = new SqlConnection("SERVER=.;DATABASE=Persons;Trusted_Connection=True;");
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Persons;";
            cmd.CommandType = CommandType.Text;
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count;
        }

        [SetUp]
        public void setup()
        {
            TestLog.WriteLine("Setup Count: " + getPeopleCount());
        }

        [TearDown]
        public void tear()
        {
            TestLog.WriteLine("Tear Count: " + getPeopleCount());
        }
    }
}