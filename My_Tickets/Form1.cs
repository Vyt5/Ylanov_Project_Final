using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace My_Tickets
{
    public partial class Form1 : Form
    {
        //public static MySqlConnection conn; //подключение к базе данных
        public static MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            OutputOfAllElements3(); //вывод ближайщих событий в форму и запуск бота для отправки уведомления
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

     
        /// <summary>
        /// Функция вывода всех элементов лист бокс
        /// </summary>
        void OutputOfAllElements() 
        {
            Console.WriteLine("Getting Connection ...");
            conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();
                
                Console.WriteLine("Connection successful!");
                QueryEmployee(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally //разрывает соединение
            {
                // Закрыть соединение.
                conn.Close();
                // Уничтожить объект, освободить ресурс.
                conn.Dispose();
            }
        }



        void OutputOfAllElements2()
        {
            Console.WriteLine("Getting Connection ...");
            conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
                QueryEmployee2(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally //разрывает соединение
            {
                // Закрыть соединение.
                conn.Close();
                // Уничтожить объект, освободить ресурс.
                conn.Dispose();
            }
        }


        void OutputOfAllElements3()
        {
            Console.WriteLine("Getting Connection ...");
            conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
                QueryEmployee3(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally //разрывает соединение
            {
                // Закрыть соединение.
                conn.Close();
                // Уничтожить объект, освободить ресурс.
                conn.Dispose();
            }
        }


        private  void QueryEmployee(MySqlConnection conn) //функция запроса данных
        {
            string sql = "Select  Мероприятие, Дата, Время, Место, Адрес, Цена from My_Tickets";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();

            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            listBox1.Items.Add("ID Мероприятие, Дата, Время, Место, Адрес, Цена");
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        i++;
                        //int idNameIndex = reader.GetOrdinal("ID");// 2
                        //string idName = reader.GetString(idNameIndex);

                        int merNameIndex = reader.GetOrdinal("Мероприятие");// 2
                        string merName = reader.GetString(merNameIndex);

                        int dateNameIndex = reader.GetOrdinal("Дата");// 2
                        string dateName = reader.GetString(dateNameIndex).Substring(0,10); //обрезаем нули после даты

                        int timeNameIndex = reader.GetOrdinal("Время");// 2
                        string timeName = reader.GetString(timeNameIndex);

                        int placeNameIndex = reader.GetOrdinal("Место");// 2
                        string placeName = reader.GetString(placeNameIndex);

                        int addressNameIndex = reader.GetOrdinal("Адрес");// 2
                        string addressName = reader.GetString(addressNameIndex);

                        int priceNameIndex = reader.GetOrdinal("Цена");// 2
                        string priceName = reader.GetString(priceNameIndex);
                        string[] itemArr = new string[8] {Convert.ToString(i),") ", merName, dateName, timeName, placeName, addressName, priceName };
                        string itemAdd = string.Join(" ", itemArr);
                        listBox1.Items.Add(itemAdd);

                    }
                }
            }
        }



        private void QueryEmployee2(MySqlConnection conn) //функция запроса данных в ближайщие дни
        {
            string sql = "Select Мероприятие, Дата, Время, Место, Адрес, Цена from My_Tickets WHERE Дата >= NOW() ";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();

            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            listBox1.Items.Add("Мероприятие, Дата, Время, Место, Адрес, Цена");
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        i++;
                        int merNameIndex = reader.GetOrdinal("Мероприятие");// 2
                        string merName = reader.GetString(merNameIndex);

                        int dateNameIndex = reader.GetOrdinal("Дата");// 2
                        string dateName = reader.GetString(dateNameIndex).Substring(0, 10); //обрезаем нули после даты

                        int timeNameIndex = reader.GetOrdinal("Время");// 2
                        string timeName = reader.GetString(timeNameIndex);

                        int placeNameIndex = reader.GetOrdinal("Место");// 2
                        string placeName = reader.GetString(placeNameIndex);

                        int addressNameIndex = reader.GetOrdinal("Адрес");// 2
                        string addressName = reader.GetString(addressNameIndex);

                        int priceNameIndex = reader.GetOrdinal("Цена");// 2
                        string priceName = reader.GetString(priceNameIndex);
                        string[] itemArr = new string[8] { Convert.ToString(i), ") ", merName, dateName, timeName, placeName, addressName, priceName };
                        string itemAdd = string.Join(" ", itemArr);
                        listBox1.Items.Add(itemAdd);
                        if (listBox1.Items.Count == 1)
                        {
                            listBox1.Items.Add("В ближайщем будущем у вас не запланировано мероприятий");
                        }
                        

                    }
                }
            }
            
        }


        private void QueryEmployee3(MySqlConnection conn) //функция запроса данных в ближайщие дни
        {
            string sql = "Select Мероприятие, Дата, Время, Место, Адрес, Цена from My_Tickets WHERE Дата >= NOW()  AND Дата <= DATE_ADD(NOW(), INTERVAL 2 DAY)"; //можно изменить и на 1 день

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();

            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            listBox1.Items.Add("Мероприятие, Дата, Время, Место, Адрес, Цена");
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        i++;
                        int merNameIndex = reader.GetOrdinal("Мероприятие");// 2
                        string merName = reader.GetString(merNameIndex);

                        int dateNameIndex = reader.GetOrdinal("Дата");// 2
                        string dateName = reader.GetString(dateNameIndex).Substring(0, 10); //обрезаем нули после даты

                        int timeNameIndex = reader.GetOrdinal("Время");// 2
                        string timeName = reader.GetString(timeNameIndex);

                        int placeNameIndex = reader.GetOrdinal("Место");// 2
                        string placeName = reader.GetString(placeNameIndex);

                        int addressNameIndex = reader.GetOrdinal("Адрес");// 2
                        string addressName = reader.GetString(addressNameIndex);

                        int priceNameIndex = reader.GetOrdinal("Цена");// 2
                        string priceName = reader.GetString(priceNameIndex);
                        string[] itemArr = new string[8] { Convert.ToString(i), ") ", merName, dateName, timeName, placeName, addressName, priceName };
                        string itemAdd = string.Join(" ", itemArr);
                        listBox1.Items.Add(itemAdd);
                        if (listBox1.Items.Count == 1)
                        {
                            listBox1.Items.Add("В ближайщем будущем у вас не запланировано мероприятий");
                        }

                    }
                }
            }
            if (listBox1.Items.Count > 1)
            {
                string item = Convert.ToString(listBox1.Items[1]);
                run_cmd(@"C:\\Users\Home\Desktop\Bot_Vk\Bot_Vk_N1.py", item);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            { OutputOfAllElements(); }
            if (comboBox1.SelectedIndex == 1)
            { OutputOfAllElements2(); }
            if (comboBox1.SelectedIndex == 2)
            { OutputOfAllElements3(); }
        }


        static private void run_cmd(string cmd, string args)
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\\Users\Home\AppData\Local\Programs\Python\Python38\python.exe";
            string textArgs = "У Вас запланировано мероприятие в ближайщем будущем! \n" + args;
            start.Arguments = string.Format("{0} \"{1}\" ", cmd, textArgs);
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            Process.Start(start);

        }

       
    }
}
