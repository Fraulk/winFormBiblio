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
    public partial class ListeGenre : Form
    {
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        public ListeGenre()
        {
            InitializeComponent();
            RemplirListe();
        }

        public void RemplirListe()
        {
            try
            {
                dgvListeGenre.Rows.Clear();
                Connexion.MaCo.Open();
                maRequete = Connexion.MaCo.CreateCommand();
                maRequete.CommandText = "select * from genre order by num";
                monReader = maRequete.ExecuteReader();
                while (monReader.Read())
                {
                    dgvListeGenre.Rows.Add(
                        monReader["num"].ToString(),
                        monReader["libelle"].ToString()
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
            int element = Convert.ToInt16(dgvListeGenre.SelectedRows[0].Cells[0].Value.ToString());
            ficheGenre frm = new ficheGenre(false, element, false);
            frm.Show();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeGenre.SelectedRows[0].Cells[0].Value.ToString());
            ficheGenre frm = new ficheGenre(true, element, false);
            frm.Show();
            RemplirListe();
            dgvListeGenre.Refresh();
        }

        private void btnSuprimer_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeGenre.SelectedRows[0].Cells[0].Value.ToString());
            Supprimer suppr = new Supprimer(element, "genre");
            suppr.Show();
            RemplirListe();
            dgvListeGenre.Refresh();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int nbLigne = dgvListeGenre.RowCount + 1;
            ficheGenre frm = new ficheGenre(true, nbLigne, true);
            frm.Show();
            RemplirListe();
            dgvListeGenre.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirListe();
            dgvListeGenre.Refresh();
        }
    }
}
