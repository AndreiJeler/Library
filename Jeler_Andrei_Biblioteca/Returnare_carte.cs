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
    public partial class Returnare_carte : Form
    {
        private int idi,idc,idcit;
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
        private void UmplereImprumuturi(int idc)
        {

            OleDbCommand com = new OleDbCommand("select Imprumuturi.ID,Carti.Titlu,Carti.Autor from Imprumuturi,Carti where Imprumuturi.ID_Cititor=" + idc + " and Imprumuturi.ID_Carte=Carti.ID", con);
            OleDbDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string temp1 = reader[0].ToString();
                string temp2 = reader[1].ToString();
                string temp3 = reader[2].ToString();
                listBox2.Items.Add(temp1 + " " + temp2 + " " + temp3);
            }
        }
        public Returnare_carte()
        {
            InitializeComponent();
            con.Open();
            UmplereCititori();
        }

        private void Returnare_carte_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex != -1)
            {
                string t = listBox1.SelectedItem.ToString();
                string[] s = t.Split(' ');
                string id = s[0];
                UmplereImprumuturi(Convert.ToInt32(id));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int nrcarti = 0;
            int days = Convert.ToInt32(textBox3.Text);
            OleDbCommand select = new OleDbCommand("select NrCarti from Carti where ID=" + idc + "", con);
            OleDbDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                nrcarti = Convert.ToInt32(reader[0].ToString());
            }
            nrcarti++;
            OleDbCommand upd = new OleDbCommand("update Carti set NrCarti='" + nrcarti + "' where ID=" + idc + "", con);
            upd.ExecuteNonQuery();
            OleDbCommand del = new OleDbCommand("delete from Imprumuturi where ID=" + idi + "", con);
            del.ExecuteNonQuery();
            if (days < 0)
            {
                days = -days;
                double penalitati = 0;
                double pret = days * 0.15;
                MessageBox.Show("Ati intarziat cu " + days.ToString() + " zile.\nAveti de platit " + pret.ToString() + " lei.");
                OleDbCommand com = new OleDbCommand("select Penalitati from Cititori where ID=" + idcit + "", con);
                OleDbDataReader reader1 = com.ExecuteReader();
                while(reader1.Read())
                {
                    penalitati = Convert.ToDouble(reader1[0].ToString());
                }
                penalitati += pret;
                OleDbCommand com1 = new OleDbCommand("update Cititori set Penalitati='" + penalitati + "' where ID=" + idcit + "", con);
                com1.ExecuteNonQuery();
            }
            MessageBox.Show("Cartea a fost returnata.");
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            button1.Visible = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!=null) button1.Visible = true;
            if (listBox2.SelectedIndex != -1)
            {
                string t = listBox2.SelectedItem.ToString();
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
                    idcit = Convert.ToInt32(reader[1].ToString());
                    idc = Convert.ToInt32(reader[2].ToString());
                }
                idi = Convert.ToInt32(id);
            }
        }
    }
}
