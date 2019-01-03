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
    public partial class ficheGenre : Form
    {
        private MySqlCommand maRequete;
        private MySqlDataReader monReader;
        private int numGenre;
        private bool addMode = false;
        public ficheGenre(bool edit, int num, bool add)
        {
            InitializeComponent();
            numGenre = num;
            addMode = add;
            try
            {
                Connexion.MaCo.Open();
                maRequete = Connexion.MaCo.CreateCommand();

                if (!add)
                {
                    maRequete.CommandText = "select * from genre where num=@paramNum";
                    maRequete.Prepare();
                    maRequete.Parameters.AddWithValue("@paramNum", num);
                    monReader = maRequete.ExecuteReader();
                    if (monReader.Read())
                    {
                        txtNum.Text = num.ToString();
                        txtLibelle.Text = monReader["libelle"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Erreur: auteur introuvable");
                    }
                    if (edit == false)
                    {
                        txtLibelle.Enabled = false;
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
                    maRequete.CommandText = "update genre set " +
                        "libelle=@paramLibelle where num=@paramNum";
                    maRequete.Parameters.Clear();
                    maRequete.Parameters.AddWithValue("@paramLibelle", txtLibelle.Text);
                    maRequete.Parameters.AddWithValue("@paramNum", numGenre);
                }
                else
                {
                    maRequete.CommandText = "insert into genre values(@paramNum, @paramLibelle)";
                    maRequete.Parameters.AddWithValue("@paramNum", numGenre);
                    maRequete.Parameters.AddWithValue("@paramLibelle", txtLibelle.Text);
                }

                try
                {
                    Connexion.MaCo.Open();
                    int resultat = maRequete.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Le genre a bien été mis à jour/ajouté");
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
            if (txtLibelle.Text == "")
            {
                MessageBox.Show("Vous devez saisir un libelle"); controle = false;
            }
            return controle;
        }
    }
}
