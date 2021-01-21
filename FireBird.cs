using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompareDBases
{
    public partial class FireBird : Form
    {
        public FireBird()
        {
            InitializeComponent();
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
            Access acc = new Access();
            acc.Show();
        }
    }
}
