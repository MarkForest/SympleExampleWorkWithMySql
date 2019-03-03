using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlDemo
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        MySqlConnectionStringBuilder builder = null;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection();
            builder = new MySqlConnectionStringBuilder();
            builder.Database = "markfo00_db";
            builder.UserID = "markfo00_db";
            builder.Server = "markfo00.mysql.tools";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            builder.Password = textBox1.Text;
            connection.ConnectionString = builder.ConnectionString;
            connection.Open();

            try
            {
                command = new MySqlCommand("select * from teachers", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string line = $"{reader[0]} | {reader[1]} | {reader[2]}";
                    listBox1.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
