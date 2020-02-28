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
    public partial class Eliminare_carte : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");
        public void UmplereCarti()
        {
            con.Open();
            OleDbCommand comCarti = new OleDbCommand("Select * from Carti", con);
            OleDbDataAdapter adapt = new OleDbDataAdapter(comCarti);
            DataTable cl = new DataTable();
            adapt.Fill(cl);
            carti.DataSource = cl;
            carti.DisplayMember = "Titlu";
            carti.ValueMember = "id";
        }

        public Eliminare_carte()
        {
            InitializeComponent();
            UmplereCarti();
        }
        
        private void Eliminare_carte_Load(object sender, EventArgs e)
        {

        }

        private void carti_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand delete = new OleDbCommand("delete * from Carti where ID=" + carti.SelectedValue + "", con);
            delete.ExecuteNonQuery();
            MessageBox.Show("Eliminarea a reusit.");
        }
    }
}
