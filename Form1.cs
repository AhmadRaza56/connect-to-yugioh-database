using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connect_to_yugioh_database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string connStr;
            MySqlConnection cnn;
            connStr = @"Data Source=localhost;Initial Catalog=mydb;User ID=root;Password=root";
            cnn = new MySqlConnection(connStr);
            cnn.Open();
            MessageBox.Show("Connection Open  !");

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM mydb.spells;", conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

            cnn.Close();
        }
    }
}
