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
                dgvListeAuteur.Rows.Clear();
                Connexion.MaCo.Open();
                maRequete = Connexion.MaCo.CreateCommand();
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
                Connexion.MaCo.Close();
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeAuteur.SelectedRows[0].Cells[0].Value.ToString());
            ficheAuteur frm = new ficheAuteur(false, element);
            frm.Show();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeAuteur.SelectedRows[0].Cells[0].Value.ToString());
            ficheAuteur frm = new ficheAuteur(true, element);
            frm.Show();
            RemplirListe();
            dgvListeAuteur.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirListe();
            dgvListeAuteur.Refresh();
        }

        private void btnSuprimer_Click(object sender, EventArgs e)
        {

        }
    }
}
