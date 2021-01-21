using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompareDBases
{
    public partial class Sqlite : Form
    {
        
        public Sqlite()
        {
            InitializeComponent();
        }

        private void Sqlite_Load(object sender, EventArgs e)
        {
            
            dataGrid.DataSource = ReadData();
        }

        public static DataTable SearchProduct(int code)
        {

            SQLiteConnection conn = new SQLiteConnection(@"Data Source = ProductBase.db");
            conn.Open();
            string query = "select * from myTable where Barcode = " + code.ToString();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
            conn.Close();
        }

        public static DataTable ReadData()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source = ProductBase.db");
            conn.Open();
            string query = "select * from myTable";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(Search_txt.Text);
            DateTime then = DateTime.Now;
            dataGrid.DataSource = SearchProduct(code);
            DateTime now = DateTime.Now;
            SqliteTime_lbl.Text = (now - then).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Access acc = new Access();
            acc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FireBird fb = new FireBird();
            fb.Show();
        }
    }
}
