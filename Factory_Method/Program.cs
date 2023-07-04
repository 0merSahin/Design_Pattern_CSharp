using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project3._3.Factory_Metod_Classes;

namespace Project4_211229013
{
    internal class Program
    {
        static string connectionString = "Data Source=localhost,1433;Initial Catalog=sql;User ID=sa;Password=reallyStrongPwd123";

        static void Main(string[] args)
        {
            SqlConnection connection = ConnectionServiceDB_FM_13.ConnectToSQL(connectionString);
            TableServiceDB_FM_13 tableService = new TableServiceDB_FM_13();
            tableService.TableCreator(connection);
            DataServiceDB_FM_13 dataService = new DataServiceDB_FM_13(connection);
            dataService.TableAddBasicData(connection);
            User_FM_13 user1 = new User_FM_13(connection, "Gülcan", 2, 2, 4699, 1234, OrderService_FM_13.CreateOrderList());

        }
    }
}
