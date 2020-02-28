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
    public partial class Lista_cititori : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        private void UmplereCititori()
        {
            OleDbCommand select = new OleDbCommand("select * from Cititori", con);
            OleDbDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                string temp1 = reader[0].ToString();
                string temp2 = reader[1].ToString();
                string temp3 = reader[2].ToString();
                listBox1.Items.Add(temp1 + " " + temp2 + " " + temp3);
            }
        }
        public Lista_cititori()
        {
            InitializeComponent();
            con.Open();
            UmplereCititori();
        }

        private void Lista_cititori_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string t = listBox1.SelectedItem.ToString();
                string[] s = t.Split(' ');
                string id = s[0];
                OleDbCommand com = new OleDbCommand("select Penalitati from Cititori where ID=" + id + "", con);
                OleDbDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    textBox1.Text = reader[0].ToString();
                }
            }
        }
    }
}
