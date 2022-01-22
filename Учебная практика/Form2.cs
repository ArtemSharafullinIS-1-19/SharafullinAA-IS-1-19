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

namespace Учебная_практика
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        class MySqlConnect
        {

            public MySqlConnection ConnDB()
            {
                string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
            public static string host = "caseum.ru";
            public static string port = "33333";
            public static string user_id = "test_user";
            public static string database = "db_test";
            public static string password = "test_pass";

            public static string SqlConnect()
            {
                string conn = $"server={host};port={port};user={user_id};database={database};password={password}";
                return conn;
            }


            private void Form2_Load(object sender, EventArgs e)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conec = new MySqlConnection(MySqlConnect.SqlConnect());
            try
            {
                conec.Open();
                MessageBox.Show("Подключение произшло успешно!");
            }
            catch
            {
                MessageBox.Show("При подключении произошла ошибка!");
                conec.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
