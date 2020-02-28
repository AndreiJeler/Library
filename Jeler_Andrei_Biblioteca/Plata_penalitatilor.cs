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
    public partial class Plata_penalitatilor : Form
    {
        private int idu;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        public Plata_penalitatilor()
        {
            con.Open();
            InitializeComponent();
            OleDbCommand com = new OleDbCommand("select * from Cititori", con);
            OleDbDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            }
        }

        private void Plata_penalitatilor_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = listBox1.Text;
            string[] cuv = temp.Split(' ');
            idu = Convert.ToInt32(cuv[0]);
            OleDbCommand com = new OleDbCommand("select Penalitati from Cititori where ID=" + idu + "", con);
            OleDbDataReader reader = com.ExecuteReader();
            while (reader.Read()) { textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[0].ToString();
                numericUpDown1.Value = 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double p1, p2, p3;
            p1 = Convert.ToDouble(textBox1.Text);
            p2 = Convert.ToDouble(numericUpDown1.Value);
            p3 = p1 - p2;
            textBox2.Text=p3.ToString();   
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
                
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double p1, p2, p3;
            p1 = Convert.ToDouble(textBox1.Text);
            p2 = Convert.ToDouble(numericUpDown1.Value);
            p3 = p1 - p2;
            textBox2.Text = p3.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0) MessageBox.Show("Alegeti o suma.");
            else
            {
                MessageBox.Show("Ati platit " + numericUpDown1.Value.ToString() + "\nmai aveti de platit " + textBox2.Text);
                DateTime now = DateTime.Now;
                OleDbCommand insert = new OleDbCommand("insert into Plati(ID_Cititor,Suma,Data) values('" + idu + "','" + numericUpDown1.Value.ToString() + "','" + now.ToShortDateString() + "')", con);
                insert.ExecuteNonQuery();
                OleDbCommand update = new OleDbCommand("update Cititori set Penalitati=" + textBox2.Text + " where ID=" + idu + "", con);
                update.ExecuteNonQuery();
            }
        }
    }
}
