using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project3._3.Factory_Metod_Classes
{
	public class PriceType2_FM_13 : IPrice_FM_13
	{
        public int CalculatePrice(SqlConnection connection, List<int> ProductIDList, int CargoDistance)
        {
            int price = 0;
            try
            {
                string query = "SELECT * FROM Products WHERE ID = " + ProductIDList[0];
                if (ProductIDList.Count > 1)
                {
                    for (int i = 1; i < ProductIDList.Count; i++)
                    {
                        query += " OR ID = " + ProductIDList[i];
                    }
                }
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i == 1) price += int.Parse(reader[i].ToString());
                        Console.Write(reader[i] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\nPrice: " + price);
                reader.Close();
                connection.Close();
                price -= price * 30 / 100;
                return price;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Bir Hata Oluştu: \n" + ex);
                throw;
            }
        }

    }
}

