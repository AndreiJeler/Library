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
    public partial class Lista_Plati : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");

        public Lista_Plati()
        {
            InitializeComponent();
            OleDbCommand select = new OleDbCommand("select * from Plati", con);
            OleDbDataAdapter adapt = new OleDbDataAdapter(select);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Lista_Plati_Load(object sender, EventArgs e)
        {

        }
    }
}
