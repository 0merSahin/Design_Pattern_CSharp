using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project3._3.Factory_Metod_Classes
{
	public class CargoService_FM_13
	{
        public CargoService_FM_13(SqlConnection connection, int CustomerType, int AddressID, int customerPoint, List<int> ProductIDList)
        {
            DataServiceDB_FM_13 dataService = new DataServiceDB_FM_13(connection);

            // Factory Method:
            // Factory Method:
            IPrice_FM_13 Price = PriceFactory_FM_13.createPrice(CustomerType);
            int price = Price.CalculatePrice(connection, ProductIDList, CalculateDistance(AddressID));
            dataService.TableAddCargo(connection, CalculateDistance(AddressID), AddressID, price, AddressID);
        }

        public int CalculateDistance(int AddressID)
        {
            return AddressID * 100;
        }

    }
}

