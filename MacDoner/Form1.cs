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

        public void RemplirListe()
        {
            try
            {
                dgvListeAuteur.Rows.Clear();
                Connexion.MaCo.Open();
                maRequete = Connexion.MaCo.CreateCommand();
                maRequete.CommandText = "select * from auteur order by num";
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
            ficheAuteur frm = new ficheAuteur(false, element, false);
            frm.Show();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeAuteur.SelectedRows[0].Cells[0].Value.ToString());
            ficheAuteur frm = new ficheAuteur(true, element, false);
            frm.Show();
            RemplirListe();
            dgvListeAuteur.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirListe();
            dgvListeAuteur.Refresh();
        }
        /// <summary>
        /// Supprime seulement les champs créés par nous-même, n'ayant pas de clés étrangères, contrairement aux autres champs de base où il faudrait supprimer les livres de l'auteur en plus du coup c'est chiant lol (et c'est pas demandé explicitement)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuprimer_Click(object sender, EventArgs e)
        {
            int element = Convert.ToInt16(dgvListeAuteur.SelectedRows[0].Cells[0].Value.ToString());
            Supprimer suppr = new Supprimer(element);
            suppr.Show();
            RemplirListe();
            dgvListeAuteur.Refresh();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int nbLigne = dgvListeAuteur.RowCount + 1;
            ficheAuteur frm = new ficheAuteur(true, nbLigne, true);
            frm.Show();
            RemplirListe();
            dgvListeAuteur.Refresh();
        }
    }
}
