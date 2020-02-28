using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jeler_Andrei_Biblioteca
{
    public partial class Start : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        public static int id_user=-1,id_admin=-1;
        public string text;
        public static string nume;
        public Start()
        {
            InitializeComponent();
            text = label1.Text;
            con.Open();
        }

        private void optiuniAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cititorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conectare_cititor a = new Conectare_cititor();
            a.ShowDialog();
            if (id_user != -1)
            {
                label1.Text = "Bine v-am regasit " + nume;
                optiuniUtilizatorToolStripMenuItem.Visible = true;
                conectareToolStripMenuItem.Visible = false;
                inregistrareCititorToolStripMenuItem.Visible = false;
                signoutToolStripMenuItem.Visible = true;
                DateTime now = DateTime.Now;
                label2.Text = "Imprumuturi care depasesc perioada inchirierii";
                OleDbCommand com = new OleDbCommand("select Imprumuturi.ID,Carti.Titlu,Imprumuturi.InceputulImprumutului,Imprumuturi.SfarsitulImprumutului from Imprumuturi,Carti where Imprumuturi.ID_carte=Carti.ID and Imprumuturi.ID_cititor=" + id_user + " order by Imprumuturi.ID", con);
                OleDbDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    DateTime d = Convert.ToDateTime(reader[3]);
                    if (d < now)
                    {
                        DateTime di = Convert.ToDateTime(reader[2]);
                        DateTime ds = Convert.ToDateTime(reader[3]);
                        label2.Text += '\n' + reader[0].ToString() + " " + reader[1].ToString() + " " + di.ToShortDateString() + " -> " + ds.ToShortDateString();
                        MessageBox.Show("Imprumutul cu nr " + reader[0].ToString() + " al cartii " + reader[1].ToString() + " a expirat in data de " + ds.ToShortDateString(), "Atentie");
                    }
                }
            }
            
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void conectareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conectare_admin b = new Conectare_admin();
            b.ShowDialog();
            if (id_admin != -1)
            {
                label1.Text = "Bine v-am regasit " + nume;
                optiuniAdminToolStripMenuItem.Visible = true;
                conectareToolStripMenuItem.Visible = false;
                inregistrareCititorToolStripMenuItem.Visible = false;
                signoutToolStripMenuItem.Visible = true;
            }
        }

        private void signoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conectareToolStripMenuItem.Visible = true;
            inregistrareCititorToolStripMenuItem.Visible = true;
            optiuniUtilizatorToolStripMenuItem.Visible = false;
            optiuniAdminToolStripMenuItem.Visible = false;
            signoutToolStripMenuItem.Visible = false;
            id_user = -1;
            id_admin = -1;
            nume = "";
            label1.Text = text;
            label2.Text = String.Empty;
        }

        private void listaCartiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_carti l = new Lista_carti();
            l.ShowDialog();
        }

        private void inregistrareCititorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inregistrare_cititor ic = new Inregistrare_cititor();
            ic.ShowDialog();
        }

        private void inregistrareAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inregistrare_admin ia = new Inregistrare_admin();
            ia.ShowDialog();
        }

        private void adaugareCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adaugare_carte ac = new Adaugare_carte();
            ac.ShowDialog();
        }

        private void eliminareCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminare_carte ec = new Eliminare_carte();
            ec.ShowDialog();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void modificareCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificare_carte mc = new Modificare_carte();
            mc.ShowDialog();
        }

        private void imprumutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprumut i = new Imprumut();
            i.ShowDialog();
        }

        private void listaImpruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_imprumuturi li = new Lista_imprumuturi();
            li.ShowDialog();
        }

        private void returnareCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Returnare_carte rc = new Returnare_carte();
            rc.ShowDialog();
        }

        private void plataPenalitatilorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plata_penalitatilor pp = new Plata_penalitatilor();
            pp.ShowDialog();
        }

        private void listaCititoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_cititori lc = new Lista_cititori();
            lc.ShowDialog();
        }

        private void listaPlatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_Plati lp = new Lista_Plati();
            lp.ShowDialog();
        }

        private void prelungireImprumutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prelungire_Imprumut pi = new Prelungire_Imprumut();
            pi.ShowDialog();
        }

        private void returnareCarteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Returnare_carte rc = new Returnare_carte();
            rc.ShowDialog();
        }

        private void imprumuturiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprumuturi im = new Imprumuturi();
            im.ShowDialog();
        }
    }
}
