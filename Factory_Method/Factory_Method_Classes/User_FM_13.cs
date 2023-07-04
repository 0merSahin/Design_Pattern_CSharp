using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3._3.Factory_Metod_Classes
{
    internal class User_FM_13
    {
        public User_FM_13(SqlConnection connection, string Name, int CustomerType, int AddressID, int CardNo, int CardPassword, List<int> ProductIDList)
        {
            try
            {
                CustomerService_FM_13 customerService = new CustomerService_FM_13(connection, Name, CustomerType, TableServiceDB_FM_13.TableLastIdDetection(connection, "Card", 2, 1), TableServiceDB_FM_13.TableLastIdDetection(connection, "Cargo", 2, 1), AddressID, TableServiceDB_FM_13.TableLastIdDetection(connection, "OrderList", 2, 1));
                OrderService_FM_13 orderService = new OrderService_FM_13(connection, ProductIDList);
                CardService_FM_13 cardService = new CardService_FM_13(connection, CardNo, CardPassword);
                CargoService_FM_13 cargoService = new CargoService_FM_13(connection, CustomerType, AddressID, DataServiceDB_FM_13.GetCustormerPoint(connection, TableServiceDB_FM_13.TableLastIdDetection(connection, "Customer", 2, 1)), ProductIDList);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştur: " + ex.Message);
                throw;
            }
        }
    }
}
