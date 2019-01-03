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
        private int num;
        private string table;
        public Supprimer(int numm, string tablee)
        {
            InitializeComponent();
            num = numm;
            table = tablee;
        }

        private void btnOui_Click(object sender, EventArgs e)
        {
            maRequete = Connexion.MaCo.CreateCommand();
            maRequete.CommandText = "Delete From " + table + " where num=@paramNum";    //impossible de faire avec param car ce dernier ajoute des apostrophe, ce qui provoque une erreur SQL
            maRequete.Parameters.Clear();
            maRequete.Parameters.AddWithValue("@paramNum", num);
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
