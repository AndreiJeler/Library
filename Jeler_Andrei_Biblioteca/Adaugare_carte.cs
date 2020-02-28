using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
namespace Jeler_Andrei_Biblioteca
{
    public partial class Adaugare_carte : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");

        private string calef="",numef="fara.jpg";
        public Adaugare_carte()
        {
            InitializeComponent();
            con.Open();
            pictureBox1.Load("Imagini\\fara.jpg");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(open.FileName);
                calef = open.FileName;
                numef = open.SafeFileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand comc = new OleDbCommand("insert into Carti(Titlu,Autor,Editura,AnulAparitiei,NrCarti,CaleImagine) values('" + titlu.Text + "','" + autor.Text + "','" + editura.Text + "','" + an.Value.ToString() + "','" + nr.Value.ToString() + "','" + numef + "')", con);
            if (calef != "" && File.Exists("Imagini\\" + numef)==false)
            {
                File.Copy(calef, "Imagini\\" + numef);
                comc.ExecuteNonQuery();
                MessageBox.Show("Cartea a fost adaugata");
            }
            else if (calef != "" && File.Exists("Imagini\\" + numef) == true)
            {
                comc.ExecuteNonQuery();
                MessageBox.Show("Cartea a fost adaugata");
            }
            else if (calef == "")
            {
                comc.ExecuteNonQuery();
                MessageBox.Show("Cartea a fost adaugata");
            }
        }
    }
}
