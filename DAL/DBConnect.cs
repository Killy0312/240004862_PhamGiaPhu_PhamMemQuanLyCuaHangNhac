using System.Data.SqlClient;

namespace DAL
{
    public class DBConnect
    {
        protected string strConnect = @"Data Source=.;Initial Catalog=MasterCD_DB;Integrated Security=True";
        protected SqlConnection conn;

        public DBConnect()
        {
            conn = new SqlConnection(strConnect);
        }
    }
}