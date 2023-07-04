using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3._3.Factory_Metod_Classes
{
	public interface IPrice_FM_13
	{
		int CalculatePrice(SqlConnection connection, List<int> ProductIDList, int CargoDistance);
	}
}

