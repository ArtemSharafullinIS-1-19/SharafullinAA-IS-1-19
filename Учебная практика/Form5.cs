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
using ConnDBDLL;
using static ConnDBDLL.Class1;

namespace Учебная_практика
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        // строка подключения к БД
        readonly string connStr = "server=caseum.ru;port=33333;user=" +
            "test_user;database=db_test;password=test_pass;";

        public bool InsertStud(string fiostud, string date)
        {
            MySqlConnection conn = new MySqlConnection();
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT INTO t_PraktStud (fioStud, datetimeStud) VALUES ('{fiostud}', '{date}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                // закрываем подключение к БД
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    //то результат операции - истина
                    result = true;
                }
            }
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }
        // создаем метод который будет получать данные из таблицы и вставлять в наш листбокс
        public void GetListUsers(ListBox lv)
        {
            //Чистим ListBox
            lv.Items.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM t_PraktStud";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                //Присваеваем переменным значения в ридере
                // элементы массива [] - это значения столбцов из запроса SELECT
                string id_stud = reader[0].ToString();
                string name_stud = reader[1].ToString();
                string drstud = reader[2].ToString();

                lv.Items.Add($"{id_stud}) {name_stud} - {drstud}");


            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // присваеваем переменную подключения к бд
            conn = ConnBaza.ConnBaz(connStr);
            //Вызываем метод для заполнение дата Грида
            GetListUsers(listBox1);
        }
    }
}
