using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MacDoner
{
    class Connexion
    {
        private static string connectionString = "Server=serverbtssiojv.ddns.net;Port=3306;Database=ulker_biblio;Uid=ulker;password=ulker";
        private static MySqlConnection maCo = new MySqlConnection(connectionString);

        public static MySqlConnection MaCo { get => maCo; }
    }
}
 