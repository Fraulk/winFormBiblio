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
    public partial class Supprimer : Form
    {
        private MySqlCommand maRequete;
        int numAuteur;
        public Supprimer(int num)
        {
            InitializeComponent();
            numAuteur = num;
        }

        private void btnOui_Click(object sender, EventArgs e)
        {
            maRequete = Connexion.MaCo.CreateCommand();
            maRequete.CommandText = "Delete From auteur where num=@paramNum";
            maRequete.Parameters.Clear();
            maRequete.Parameters.AddWithValue("@paramNum", numAuteur);
            try
            {
                Connexion.MaCo.Open();
                int resultat = maRequete.ExecuteNonQuery();
                if (resultat > 0)
                {
                    MessageBox.Show("La suppression à bien été effectué.");
                }
                else
                {
                    MessageBox.Show("Une erreur s'est produite.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                Connexion.MaCo.Close();
                this.Close();
            }
        }

        private void btnNon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
