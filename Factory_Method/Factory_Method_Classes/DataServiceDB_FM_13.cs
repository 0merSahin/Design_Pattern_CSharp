using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3._3.Factory_Metod_Classes
{
    internal class DataServiceDB_FM_13
    {
        SqlConnection connection;

        public DataServiceDB_FM_13(SqlConnection connection)
        {
            this.connection = connection;
        }


        public void TableAddCard(SqlConnection connection, int CardNo, int CardPassword)
        {
            try
            {
                connection.Open();
                int newCardID = TableServiceDB_FM_13.TableLastIdDetection(connection, "Card", 1, 1);
                SqlCommand command = new SqlCommand("INSERT INTO Card (ID, CardNo, CardPassword) VALUES (" + newCardID + ", " + CardNo + ", " + CardPassword + ")", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("New Card Added.");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir sorun oluştur: \n" + ex);
                throw;
            }
        }


        public void TableAddOrderList(SqlConnection connection, List<int> OrdersIDList)
        {
            connection.Open();
            int newOrderID = TableServiceDB_FM_13.TableLastIdDetection(connection, "OrderList", 1, 1);
            for (int i = 0; i < OrdersIDList.Count; i++)
            {
                string query = "INSERT INTO OrderList (ID, ProductID) VALUES (" + newOrderID + ", " + OrdersIDList[i] + ")";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }



        public void TableAddCargo(SqlConnection connection, int cargoDistance, int cargoDeliveryTime, int cargoPrice, int AddressID)
        {
            connection.Open();
            int newCargoID = TableServiceDB_FM_13.TableLastIdDetection(connection, "Cargo", 1, 1);
            string query = "INSERT INTO Cargo (ID, CargoDistance, CargoDeliveryTime, CargoPrice, CargoDeliveryAddressID) VALUES (" + newCargoID + ", " + cargoDistance + ", " + cargoDeliveryTime + ", " + cargoPrice + ", " + AddressID + ")";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }



        public void TableAddCustomer(SqlConnection connection, string Name, int CustomerType, int CardID, int CargoID, int AddressID, int OrderListID)
        {
            connection.Open();
            int newCustomerID = TableServiceDB_FM_13.TableLastIdDetection(connection, "Customer", 1, 1);
            //string query = "INSERT INTO Customer (ID, Name, Point, CardID, CargoID, AddressID, OrderListID) VALUES (" + newCustomerID + ", " + Name + ", " + Point + ", " + CardID + ", " + CargoID + ", " + AddressID + ", " + OrderListID + ")";
            //SqlCommand command = new SqlCommand(query, connection);

            string query2 = "INSERT INTO Customer (ID, Name, CustomerType, CardID, CargoID, AddressID, OrderListID) VALUES (@ID, @Name, @CustomerType, @CardID, @CargoID, @AddressID, @OrderListID)";
            SqlCommand command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@ID", int.Parse(newCustomerID.ToString()));
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@CustomerType", CustomerType.ToString());
            command.Parameters.AddWithValue("@CardID", CardID.ToString());
            command.Parameters.AddWithValue("@CargoID", CargoID.ToString());
            command.Parameters.AddWithValue("@AddressID", AddressID.ToString());
            command.Parameters.AddWithValue("@OrderListID", OrderListID.ToString());
            command.ExecuteNonQuery();
            connection.Close();
        }



        public static int GetCustormerPoint(SqlConnection connection, int customerID)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE ID = " + customerID, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i == 2) return int.Parse(reader[i].ToString());
                    }
                }
                connection.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: \n" + ex);
                throw;
            }
        }



        public void TableAddBasicData(SqlConnection connection)
        {
            try
            {
                connection.Open();
                Console.WriteLine("Database connection established.");
                SqlCommand command = new SqlCommand("INSERT INTO Address (ID, City) VALUES ('1', 'Aydın')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Address (ID, City) VALUES ('2', 'İzmir')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Address (ID, City) VALUES ('3', 'Konya')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('1', '3')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('1', '7')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('2', '12')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('2', '23')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('2', '3')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('3', '5')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('4', '2')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO OrderList (ID, ProductID) VALUES ('4', '22')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Card (ID, CardNo, CardPassword) VALUES ('1', '4609', '1234')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Card (ID, CardNo, CardPassword) VALUES ('2', '4619', '2345')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Card (ID, CardNo, CardPassword) VALUES ('3', '4629', '3456')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Card (ID, CardNo, CardPassword) VALUES ('4', '4639', '4567')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Cargo (ID, CargoDistance, CargoDeliveryTime, CargoPrice, CargoDeliveryAddressID) VALUES ('1', '200', '2', '180', '1')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Cargo (ID, CargoDistance, CargoDeliveryTime, CargoPrice, CargoDeliveryAddressID) VALUES ('2', '300', '3', '250', '2')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Cargo (ID, CargoDistance, CargoDeliveryTime, CargoPrice, CargoDeliveryAddressID) VALUES ('3', '300', '3', '120', '2')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Cargo (ID, CargoDistance, CargoDeliveryTime, CargoPrice, CargoDeliveryAddressID) VALUES ('4', '500', '5', '480', '3')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Customer (ID, Name, CustomerType, CardID, CargoID, AddressID, OrderListID) VALUES ('1', 'Omer', '2', '1', '1', '1', '1')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Customer (ID, Name, CustomerType, CardID, CargoID, AddressID, OrderListID) VALUES ('2', 'Yusuf', '1', '2', '2', '2', '2')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Customer (ID, Name, CustomerType, CardID, CargoID, AddressID, OrderListID) VALUES ('3', 'Ahmet', '1', '3', '3', '2', '3')", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("INSERT INTO Customer (ID, Name, CustomerType, CardID, CargoID, AddressID, OrderListID) VALUES ('4', 'Fatih', '3', '4', '4', '3', '4')", connection);
                command.ExecuteNonQuery();
                Random random = new Random();
                command = new SqlCommand("INSERT INTO Products (ID, Price) VALUES ('@ID', '@Price')", connection);
                for (int i = 1; i <= 25; i++)
                {
                    command = new SqlCommand("INSERT INTO Products (ID, Price) VALUES (" + i.ToString() + ", " + random.Next(20, 151).ToString() + ")", connection);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Tüm Veriler Eklendi");
                connection.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Bir Hata Oluştu: \n" + ex);
                throw;
            }
        }
    }
}
