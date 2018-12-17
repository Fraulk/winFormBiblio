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
        private string connexionString = "server=serverbtssiojv.ddns.net;port=3306;Database=ulker_biblio;Uid=ulker;password=ulker";
        private MySqlConnection maCo;
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        public Form_ListeAuteur()
        {
            InitializeComponent();
            RemplirListe();
        }

        private void Form_ListeAuteur_Load(object sender, EventArgs e)
        {
            
        }

        private void RemplirListe()
        {
            try
            {
                maCo = new MySqlConnection(connexionString);
                maCo.Open();
                maRequete = maCo.CreateCommand();
                maRequete.CommandText = "select * from auteur order by nom";
                monReader = maRequete.ExecuteReader();
                while (monReader.Read())
                {
                    dgvListeAuteur.Rows.Add(
                        monReader["num"].ToString(),
                        monReader["nom"].ToString(),
                        monReader["prenom"].ToString(),
                        monReader["nationalite"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e.Message);
                throw;
            }
            finally
            {
                monReader.Close();
                maCo.Close();
            }
        }


    }
}
