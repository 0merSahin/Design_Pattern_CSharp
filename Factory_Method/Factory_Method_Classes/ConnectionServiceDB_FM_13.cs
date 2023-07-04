using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3._3.Factory_Metod_Classes
{
    internal class ConnectionServiceDB_FM_13
    {
        public static SqlConnection ConnectToSQL(string connectionString)
        {
            try
            {
                //SqlConnection connection = new SqlConnection("Data Source=localhost,1433;Initial Catalog=sql;User ID=sa;Password=reallyStrongPwd123");
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Connect to SQL: \n" + ex);
                throw;
            }
        }
    }
}
