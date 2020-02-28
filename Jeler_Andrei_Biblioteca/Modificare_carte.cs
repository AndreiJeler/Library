using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jeler_Andrei_Biblioteca
{
    public partial class Modificare_carte : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        string calef = "", numef = "fara.jpg";
        public Modificare_carte()
        {
            InitializeComponent();
            con.Open();
        }

        private void Modificare_carte_Load(object sender, EventArgs e)
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
                    numericUpDown1.Value = Convert.ToInt32(reader[4].ToString());
                    numericUpDown2.Value = Convert.ToInt32(reader[5].ToString());
                    pictureBox1.Load("Imagini\\" + reader[6].ToString());
                }
            }
       }

        private void button1_Click(object sender, EventArgs e)
        {
            string titlu = textBox1.Text;
            string autor = textBox2.Text;
            string editura = textBox3.Text;
            string an = numericUpDown1.Value.ToString();
            string nr = numericUpDown2.Value.ToString();
            string t = listBox1.SelectedItem.ToString();
            string[] s = t.Split(' ');
            string id = s[0];
            OleDbCommand com = new OleDbCommand("Update Carti set Titlu='" + titlu + "',Autor='" + autor + "',Editura='" + editura + "',AnulAparitiei='" + an + "',Nrcarti='" + nr + "',CaleImagine='" + numef + "' where ID="+id+"", con);
            if (calef != "" && File.Exists("Imagini\\" + numef) == false)
            {
                File.Copy(calef, "Imagini\\" + numef);
                com.ExecuteNonQuery();
                MessageBox.Show("Cartea a fost modificata");
            }
            else if (calef != "" && File.Exists("Imagini\\" + numef) == true)
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Cartea a fost modificata");
            }
            else if (calef == "")
            { 
                com.ExecuteNonQuery();
                MessageBox.Show("Cartea a fost modificata");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Fisiere jpg|*.jpg";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(op.FileName);
                calef = op.FileName;
                numef = op.SafeFileName;
            }
        }
    }
}
