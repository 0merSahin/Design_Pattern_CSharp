using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Project3._3.Factory_Metod_Classes;


namespace Project3._3.Factory_Metod_Classes
{
	public class PriceFactory_FM_13
	{
        public static IPrice_FM_13 createPrice(int CustomerType)
        {
            IPrice_FM_13 Price;

            if (CustomerType == 1)
            {
                Price = new PriceType1_FM_13();
                Console.WriteLine("Price Type: 1");
                return Price;
            }
            else if (CustomerType == 2)
            {
                Price = new PriceType2_FM_13();
                Console.WriteLine("Price Type: 2");
                return Price;
            }
            else if (CustomerType == 3)
            {
                Price = new PriceType3_FM_13();
                Console.WriteLine("Price Type: 3");
                return Price;
            }
            else
            {
                Console.WriteLine("Belirttiğiniz türde price yok!");
                return null;
            }
        }
    }
}
