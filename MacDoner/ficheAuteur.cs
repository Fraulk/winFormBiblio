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
    public partial class ficheAuteur : Form
    {
        private string connexionString = "server=serverbtssiojv.ddns.net;port=3306;Database=ulker_biblio;Uid=ulker;password=ulker";
        private MySqlConnection maCo;
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        public ficheAuteur(bool edit, int num)
        {
            InitializeComponent();
            try
            {
                maCo = new MySqlConnection(connexionString);
                maCo.Open();
                maRequete = maCo.CreateCommand();
                maRequete.CommandText = "select * from auteur where num=@paramNum";
                maRequete.Prepare();
                maRequete.Parameters.AddWithValue("@paramNum", num);
                monReader = maRequete.ExecuteReader();
                if (monReader.Read())
                {
                    txtNum.Text = num.ToString();
                    txtNom.Text = monReader["nom"].ToString();
                    txtPrenom.Text = monReader["prenom"].ToString();
                    txtNation.Text = monReader["nationalite"].ToString();
                }
                if(edit == false)
                {
                    txtNom.Enabled = false;
                    txtPrenom.Enabled = false;
                    txtNation.Enabled = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
