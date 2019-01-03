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
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        private int numAuteur;
        private bool addMode = false;
        public ficheAuteur(bool edit, int num, bool add)
        {
            InitializeComponent();
            numAuteur = num;
            addMode = add;
            try
            {
                Connexion.MaCo.Open();
                maRequete = Connexion.MaCo.CreateCommand();

                if (!add)
                {
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
                    else
                    {
                        MessageBox.Show("Erreur: auteur introuvable");
                    }
                    if (edit == false)
                    {
                        txtNom.Enabled = false;
                        txtPrenom.Enabled = false;
                        txtNation.Enabled = false;
                        btnAnnuler.Text = "Fermer";
                        btnValider.Hide();
                    }
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                if (!add)
                {
                    monReader.Close();
                }
                Connexion.MaCo.Close();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (ControleSaisie() == true)
            {
                if (!addMode)
                {
                    maRequete.CommandText = "update auteur set " +
                        "nom=@paramNom, prenom=@paramPrenom, nationalite=@paramNation where num=@paramNum";
                    maRequete.Parameters.Clear();
                    maRequete.Parameters.AddWithValue("@paramNom", txtNom.Text);
                    maRequete.Parameters.AddWithValue("@paramPrenom", txtPrenom.Text);
                    maRequete.Parameters.AddWithValue("@paramNation", txtNation.Text);
                    maRequete.Parameters.AddWithValue("@paramNum", numAuteur);
                }
                else
                {
                    maRequete.CommandText = "insert into auteur values(@paramNum, @paramNom, @paramPrenom, @paramNation)";
                    maRequete.Parameters.AddWithValue("@paramNum", numAuteur);
                    maRequete.Parameters.AddWithValue("@paramNom", txtNom.Text);
                    maRequete.Parameters.AddWithValue("@paramPrenom", txtPrenom.Text);
                    maRequete.Parameters.AddWithValue("@paramNation", txtNation.Text);
                }
                
                try
                {
                    Connexion.MaCo.Open();
                    int resultat = maRequete.ExecuteNonQuery();
                    if(resultat > 0)
                    {
                        MessageBox.Show("L'auteur a bien ete mis à jour/ajouté");
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite");
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
        }

        private bool ControleSaisie()
        {
            bool controle = true;
            if (txtNom.Text == "")
            {
                MessageBox.Show("Vous devez saisir un nom"); controle = false;
            }
            if (txtPrenom.Text == "")
            {
                MessageBox.Show("Vous devez saisir un prenom"); controle = false;
            }
            if (txtNation.Text == "")
            {
                MessageBox.Show("Vous devez saisir une nationalité"); controle = false;
            }
            return controle;
        }
    }
}
