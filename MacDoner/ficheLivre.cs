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
    public partial class ficheLivre : Form
    {
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        private int numLivre;
        private bool addMode = false;
        public ficheLivre(bool edit, int num, bool add)
        {
            InitializeComponent();
            numLivre = num;
            addMode = add;
            try
            {
                Connexion.MaCo.Open();
                maRequete = Connexion.MaCo.CreateCommand();

                if (!add)
                {
                    maRequete.CommandText = "select num, ISBN, titre, prix, editeur, annee, langue from livre where num=@paramNum";
                    maRequete.Prepare();
                    maRequete.Parameters.AddWithValue("@paramNum", num);
                    monReader = maRequete.ExecuteReader();
                    if (monReader.Read())
                    {
                        txtNum.Text = num.ToString();
                        txtISBN.Text = monReader["ISBN"].ToString();
                        txtTitre.Text = monReader["titre"].ToString();
                        txtPrix.Text = monReader["prix"].ToString();
                        txtEditeur.Text = monReader["editeur"].ToString();
                        txtAnnee.Text = monReader["annee"].ToString();
                        txtLangue.Text = monReader["langue"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Erreur: auteur introuvable");
                    }
                    if (edit == false)
                    {
                        txtISBN.Enabled = false;
                        txtTitre.Enabled = false;
                        txtPrix.Enabled = false;
                        txtEditeur.Enabled = false;
                        txtAnnee.Enabled = false;
                        txtLangue.Enabled = false;
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
            Close();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (ControleSaisie() == true)
            {
                if (!addMode)
                {
                    maRequete.CommandText = "update livre set " +
                        "ISBN=@paramISBN, titre=@paramTitre, prix=@paramPrix, editeur=@paramEditeur, annee=@paramAnnee, langue=@paramLangue where num=@paramNum";
                    maRequete.Parameters.Clear();
                    maRequete.Parameters.AddWithValue("@paramISBN", txtISBN.Text);
                    maRequete.Parameters.AddWithValue("@paramTitre", txtTitre.Text);
                    maRequete.Parameters.AddWithValue("@paramPrix", txtPrix.Text);
                    maRequete.Parameters.AddWithValue("@paramEditeur", txtEditeur.Text);
                    maRequete.Parameters.AddWithValue("@paramAnnee", txtAnnee.Text);
                    maRequete.Parameters.AddWithValue("@paramLangue", txtLangue.Text);
                    maRequete.Parameters.AddWithValue("@paramNum", numLivre);
                }
                else
                {
                    maRequete.CommandText = "insert into livre values(@paramNum, @paramISBN, @paramTitre, @paramPrix, @paramEditeur, @paramAnnee, @paramLangue, '34', '9')";    //à faire : liste déroulante avec nom des auteurs et genres
                    maRequete.Parameters.Clear();
                    maRequete.Parameters.AddWithValue("@paramNum", numLivre);
                    maRequete.Parameters.AddWithValue("@paramISBN", txtISBN.Text);
                    maRequete.Parameters.AddWithValue("@paramTitre", txtTitre.Text);
                    maRequete.Parameters.AddWithValue("@paramPrix", txtPrix.Text);
                    maRequete.Parameters.AddWithValue("@paramEditeur", txtEditeur.Text);
                    maRequete.Parameters.AddWithValue("@paramAnnee", txtAnnee.Text);
                    maRequete.Parameters.AddWithValue("@paramLangue", txtLangue.Text);
                }

                try
                {
                    Connexion.MaCo.Open();
                    int resultat = maRequete.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Le livre a bien été mis à jour/ajouté");
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
            if (txtISBN.Text == "")
            {
                MessageBox.Show("Vous devez saisir un ISBN"); controle = false;
            }
            if (txtTitre.Text == "")
            {
                MessageBox.Show("Vous devez saisir un titre"); controle = false;
            }
            if (txtPrix.Text == "")
            {
                MessageBox.Show("Vous devez saisir un prix"); controle = false;
            }
            if (txtEditeur.Text == "")
            {
                MessageBox.Show("Vous devez saisir un editeur"); controle = false;
            }
            if (txtAnnee.Text == "")
            {
                MessageBox.Show("Vous devez saisir une annee"); controle = false;
            }
            if (txtLangue.Text == "")
            {
                MessageBox.Show("Vous devez saisir une langue"); controle = false;
            }
            return controle;
        }
    }
}
