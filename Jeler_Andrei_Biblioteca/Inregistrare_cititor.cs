using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Jeler_Andrei_Biblioteca
{
    public partial class Inregistrare_cititor : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        int p; Random rnd=new Random();
        string cale,dir;
        public Inregistrare_cititor()
        {
            InitializeComponent();
            con.Open();
            string[] cod = Directory.GetFiles("Logare");
            p = rnd.Next(0, cod.Length);
            cale = cod[p];
            pictureBox1.Load(cale);
            string[] c=cod[p].Split('\\');
            string[] c1 = c[1].Split('.');
            dir = c1[0];
        }
        void Reimprospatare()
        {
            string[] cod = Directory.GetFiles("Logare");
            p = rnd.Next(0, cod.Length);
            cale = cod[p];
            pictureBox1.Load(cale);
            string[] c = cod[p].Split('\\');
            string[] c1 = c[1].Split('.');
            dir = c1[0];
        }

        private void Inregistrare_cititor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cod.Text != dir) { MessageBox.Show("Codul este incorect"); Reimprospatare(); }
            else if (nume.Text == "" | prenume.Text == "" | user.Text == "" | parola1.Text == "" | parola2.Text == "" | cod.Text == "") { MessageBox.Show("Introduce-ti toate datele."); Reimprospatare(); }
            else if (parola1.Text != parola2.Text) {MessageBox.Show("Parolele nu se potrivesc.");Reimprospatare();}
            else
            {
                OleDbCommand comcit = new OleDbCommand("insert into Cititori(Nume,Prenume,usern,pass) values('" + nume.Text + "','" + prenume.Text + "','" + user.Text + "','" + parola1.Text + "')", con);
                comcit.ExecuteNonQuery();
                MessageBox.Show("Inregistrare reusita.");
                this.Close();
            }
        }
    }
}
