using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3._3.Factory_Metod_Classes
{
    internal class CardService_FM_13
    {
        public CardService_FM_13(SqlConnection connection, int CardNo, int CardPassword) 
        {
            DataServiceDB_FM_13 dataService = new DataServiceDB_FM_13(connection);
            dataService.TableAddCard(connection, CardNo, CardPassword);
        }

        // kart şifresi kontrol uygulaması da yazılır.
    }
}
