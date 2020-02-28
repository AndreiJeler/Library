using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Jeler_Andrei_Biblioteca
{
    public partial class Lista_carti : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        public void Umplerecarti()
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

        public Lista_carti()
        {
            InitializeComponent();
            con.Open();
            Umplerecarti();
        }

        

        private void Lista_carti_Load(object sender, EventArgs e)
        {

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
    }
}
