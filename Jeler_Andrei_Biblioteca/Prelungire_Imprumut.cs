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
    public partial class Prelungire_Imprumut : Form
    {
        private int idi;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        private void UmplereImprumuturi()
        {

            OleDbCommand com = new OleDbCommand("select Imprumuturi.ID,Carti.Titlu,Carti.Autor from Imprumuturi,Carti where Imprumuturi.ID_Cititor=" + Start.id_user + " and Imprumuturi.ID_Carte=Carti.ID", con);
            OleDbDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string temp1 = reader[0].ToString();
                string temp2 = reader[1].ToString();
                string temp3 = reader[2].ToString();
                listBox1.Items.Add(temp1 + " " + temp2 + " " + temp3);
            }
        }
        public Prelungire_Imprumut()
        {
            InitializeComponent();
            con.Open();
            UmplereImprumuturi();
        }

        private void Prelungire_Imprumut_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = false;
            if (listBox1.SelectedIndex != -1)
            {
                string t = listBox1.SelectedItem.ToString();
                string[] s = t.Split(' ');
                string id = s[0];
                OleDbCommand com = new OleDbCommand("select * from Imprumuturi where ID=" + id + "", con);
                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DateTime d1 = Convert.ToDateTime(reader[3]);
                    DateTime d2 = Convert.ToDateTime(reader[4]);
                    textBox1.Text = d1.ToShortDateString();
                    textBox2.Text = d2.ToShortDateString();
                    TimeSpan ts = d2 - DateTime.Now;
                    textBox3.Text = ts.Days.ToString();
                    if (ts.Days >= 0) button1.Visible = true;
                }
                idi = Convert.ToInt32(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            OleDbCommand com = new OleDbCommand("select SfarsitulImprumutului from Imprumuturi where ID=" + idi + "", con);
            OleDbDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                d = Convert.ToDateTime(reader[0]);
            }
            d = d.AddDays(5);
            OleDbCommand upd = new OleDbCommand("update Imprumuturi set SfarsitulImprumutului='" + d + "' where ID=" + idi + "", con);
            upd.ExecuteNonQuery();
            MessageBox.Show("Imprumutul cu numarul " + idi.ToString() + " a fost prelungit cu 5 zile.\nNoua data este:"+d.ToShortDateString());
        }
    }
}
