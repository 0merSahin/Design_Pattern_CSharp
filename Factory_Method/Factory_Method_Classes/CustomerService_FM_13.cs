using System;
using System.Data.SqlClient;

namespace Project3._3.Factory_Metod_Classes
{
	public class CustomerService_FM_13
	{
		public CustomerService_FM_13(SqlConnection connection, string Name, int CustomerType, int CardID, int CargoID, int AddressID, int OrderListID)
		{
			DataServiceDB_FM_13 dataService = new DataServiceDB_FM_13(connection);
			dataService.TableAddCustomer(connection, Name, CustomerType, CardID, CargoID, AddressID, OrderListID);
		}
	}
}

