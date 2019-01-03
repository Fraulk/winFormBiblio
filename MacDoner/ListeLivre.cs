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
    public partial class ListeLivre : Form
    {
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        public ListeLivre()
        {
            InitializeComponent();
            RemplirListe();
        }

        public void RemplirListe()
        {
            try
            {
                dgvListeLivre.Rows.Clear();
                Connexion.MaCo.Open();
                maRequete = Connexion.MaCo.CreateCommand();
                maRequete.CommandText = "select num, ISBN, titre, prix, editeur, annee, langue from livre order by num";
                monReader = maRequete.ExecuteReader();
                while (monReader.Read())
                {
                    dgvListeLivre.Rows.Add(
                        monReader["num"].ToString(),
                        monReader["ISBN"].ToString(),
                        monReader["titre"].ToString(),
                        monReader["prix"].ToString(),
                        monReader["editeur"].ToString(),
                        monReader["annee"].ToString(),
                        monReader["langue"].ToString()
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
                Connexion.MaCo.Close();
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeLivre.SelectedRows[0].Cells[0].Value.ToString());
            ficheLivre frm = new ficheLivre(false, element, false);
            frm.Show();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeLivre.SelectedRows[0].Cells[0].Value.ToString());
            ficheLivre frm = new ficheLivre(true, element, false);
            frm.Show();
            RemplirListe();
            dgvListeLivre.Refresh();
        }

        private void btnSuprimer_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeLivre.SelectedRows[0].Cells[0].Value.ToString());
            Supprimer suppr = new Supprimer(element, "livre");
            suppr.Show();
            RemplirListe();
            dgvListeLivre.Refresh();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int nbLigne = dgvListeLivre.RowCount + 1;
            ficheLivre frm = new ficheLivre(true, nbLigne, true);
            frm.Show();
            RemplirListe();
            dgvListeLivre.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirListe();
            dgvListeLivre.Refresh();
        }
    }
}
