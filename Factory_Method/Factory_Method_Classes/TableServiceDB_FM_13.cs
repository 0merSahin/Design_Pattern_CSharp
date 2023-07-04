using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3._3.Factory_Metod_Classes
{
    internal class TableServiceDB_FM_13
    {

        public static int TableLastIdDetection(SqlConnection connection, string TableName, int control, int index)
        {
            int lastID = 0;
            try
            {
                if (control == 2) connection.Open();
                string query = "SELECT * FROM " + TableName;
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i == index - 1)
                        {
                            lastID = int.Parse(reader[i].ToString());
                            break;
                        }
                    }
                }
                Console.WriteLine("\nLast ID: " + lastID);
                reader.Close();
                if (control == 2) connection.Close();
                return ++lastID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir Hata Oluştu: \n" + ex.Message);
                throw;
            }
        }


        public void TableCreator(SqlConnection connection)
        {
            try
            {
                connection.Open();
                Console.WriteLine("Database connection established.");
                SqlCommand command = new SqlCommand("CREATE TABLE Card (ID INTEGER UNIQUE, CardNo INTEGER, CardPassword INTEGER)", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("CREATE TABLE Address (ID INTEGER UNIQUE, City VARCHAR(50), CONSTRAINT Pk_AddressID PRIMARY KEY (ID))", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("CREATE TABLE OrderList (ID INTEGER, ProductID VARCHAR(50))", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("CREATE TABLE Cargo (ID INTEGER UNIQUE, CargoDistance INTEGER, CargoDeliveryTime INTEGER, CargoPrice INTEGER, CargoDeliveryAddressID INTEGER, CONSTRAINT Pk_CargoID PRIMARY KEY (ID), " +
                    "FOREIGN KEY (CargoDeliveryAddressID) REFERENCES Address(ID) ON DELETE NO ACTION ON UPDATE NO ACTION)", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("CREATE TABLE Customer (ID INTEGER UNIQUE, Name VARCHAR(50), CustomerType INTEGER, CardID INTEGER, CargoID INTEGER, AddressID INTEGER, OrderListID INTEGER)", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("CREATE TABLE Products (ID INTEGER UNIQUE, Price INTEGER, CONSTRAINT Pk_ProductsID PRIMARY KEY (ID))", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("All Tables Created.");
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
