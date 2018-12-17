using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MacDoner
{
    public partial class Form_ListeAuteur : Form
    {
        private string connexionString = "server=serverbtssiojv.ddns.net;port=3306;Database=biblio;Uid=ulker;psw=ulker";
        private MySqlConnection maCo;
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        public Form_ListeAuteur()
        {
            InitializeComponent();
        }

        private void Form_ListeAuteur_Load(object sender, EventArgs e)
        {

        }



    }
}
