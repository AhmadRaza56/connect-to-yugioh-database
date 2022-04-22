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
        string table;
        public void button1_Click(object sender, EventArgs e)
        { 
            string connStr;
            MySqlConnection cnn;
            connStr = @"Data Source=localhost;Initial Catalog=mydb;User ID=root;Password=root";
            cnn = new MySqlConnection(connStr);
            cnn.Open();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM mydb."+ table +";", conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

            cnn.Close();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox1.Text.ToLower() == "spells")
            {
                table = "spells";
            }
            else if (textBox1.Text.ToLower() == "traps")
            {
                table = "traps";
            }
            else if (textBox1.Text.ToLower() == "extra deck")
            {
                table = "extra_deck";
            }
            else if (textBox1.Text.ToLower() == "normal monster")
            {
                table = "normal_monster";
            }
            else if (textBox1.Text.ToLower() == "effect monster")
            {
                table = "effect_monster";
            }
        }
    }
}
