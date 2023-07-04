using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project3._3.Factory_Metod_Classes
{
	public class OrderService_FM_13
	{
        SqlConnection connection;
        DataServiceDB_FM_13 dataService;
        public List<int> OrdersIDList;

        public OrderService_FM_13(SqlConnection connection, List<int> OrderIDList)
        {
            this.connection = connection;
            this.OrdersIDList = OrderIDList;
            dataService = new DataServiceDB_FM_13(connection);
            dataService.TableAddOrderList(connection, OrderIDList);
        }


        public static List<int> CreateOrderList()
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(random.Next(1, 26));
            }
            return list;
        }

    }
}

