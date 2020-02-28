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
    public partial class Imprumut : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");

        public Imprumut()
        {
            InitializeComponent();
            con.Open();
        }

        private void Imprumut_Load(object sender, EventArgs e)
        {
            OleDbCommand com = new OleDbCommand("Select * from Carti order by ID", con);
            OleDbDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                string temp1 = reader[0].ToString();
                string temp2 = reader[1].ToString();
                string temp3 = reader[2].ToString();
                listBox1.Items.Add(temp1 + " " + temp2 + " " + temp3);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string t = listBox1.SelectedItem.ToString();
                string[] s = t.Split(' ');
                string id = s[0];
                OleDbCommand com = new OleDbCommand("select * from carti where ID=" + id + "", con);
                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                    textBox5.Text = reader[5].ToString();
                    pictureBox1.Load("Imagini\\" + reader[6].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox5.Text) <= 0) MessageBox.Show("Aceasta carte nu este disponibila momentan.");
            else
            {
                string t = listBox1.SelectedItem.ToString();
                string[] s = t.Split(' ');
                string id = s[0];
                int idu = Start.id_user;
                int nr = Convert.ToInt32(textBox5.Text) - 1;
                OleDbCommand com = new OleDbCommand("update Carti set NrCarti='" + nr + "' where ID=" + id + "", con);
                com.ExecuteNonQuery();
                DateTime azi = DateTime.Now;
                string az=azi.ToShortDateString();
                string sf = azi.AddDays(14).ToShortDateString();
                OleDbCommand insert = new OleDbCommand("insert into Imprumuturi(ID_cititor,ID_carte,InceputulImprumutului,SfarsitulImprumutului) values('" + idu + "','" + id + "','" + az + "','"+sf+"')", con);
                insert.ExecuteNonQuery();
                MessageBox.Show("Cartea a fost imprumutata.");
            }
        }
    }
}
