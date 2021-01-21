using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CompareDBases
{
    public partial class Access : Form
    {
        public Access()
        {
            InitializeComponent();
        }

        private void Access_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productBaseAccessDataSet.Worksheet' table. You can move, or remove it, as needed.
            this.worksheetTableAdapter.Fill(this.productBaseAccessDataSet.Worksheet);

        }

        private DataTable Searchdata(int code)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\ForJob\CompareDBases\CompareDBases\ProductBaseAccess.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            string query = "select * from worksheet where Barcode = " + code;
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader rd = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(rd);
            return dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sqlite sq = new Sqlite();
            sq.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FireBird fb = new FireBird();
            fb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(Search_txt.Text);
            DateTime then = DateTime.Now;
            dataGridView1.DataSource = Searchdata(code);
            DateTime now = DateTime.Now;
            AccessTime_lbl.Text = (now - then).ToString();
        }
    }
}
