using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacDoner
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void auteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ListeAuteur frm = new Form_ListeAuteur();
            frm.Show();
        }

        private void genresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeGenre lgr = new ListeGenre();
            lgr.Show();
        }

        private void adhérentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void livresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeLivre llvr = new ListeLivre();
            llvr.Show();
        }
    }
}
