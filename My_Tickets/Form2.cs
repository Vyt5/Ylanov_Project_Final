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
using System.IO;
using System.Diagnostics;

namespace My_Tickets
{
    public partial class Form2 : Form
    {
        public static MySqlConnection conn;


        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //finally
            //{
            conn.Close();
            conn.Dispose();
            conn = null;
            
            //}   
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            Console.WriteLine("Getting Connection ...");
            //MySqlConnection conn = DBUtils.GetDBConnection();
            conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            f.BackColor = Color.Yellow;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void insert_data_Click(object sender, EventArgs e)
        {
            Insert(conn);
        }



        private void Insert(MySqlConnection conn) //функция запроса данных
        {
            try
            {
                // Команда Insert.
                string sql = "Insert into My_Tickets (Мероприятие, Дата, Время, Место, Адрес, Цена) "
                                                 + " values (@eventsStr, @dateStr, @timeStr, @placeStr, @addressStr, @priceStr) ";

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                // Создать объект Parameter.
                MySqlParameter eventsParam = new MySqlParameter("@eventsStr", MySqlDbType.VarChar);
                eventsParam.Value = Convert.ToString(events.Text); 
                cmd.Parameters.Add(eventsParam);

                // Добавить параметр @highSalary (Написать кратко).
                //MySqlParameter dateStrParam = cmd.Parameters.Add("@dateStr", (MySqlDbType)SqlDbType.Date);
                //dateStrParam.Value = date.Text;


                //избавляемся от всех разгранечителей 
                ////string date = dateS.Text.Replace("-", "");
                ////Console.WriteLine(date);
                ////cmd.Parameters.Add("@dateStr", (MySqlDbType)SqlDbType.Date).Value = dateS.Text.Replace("-", ""); ;


                MySqlParameter dateParam = new MySqlParameter("@dateStr", SqlDbType.Date);
                //dateParam.Value = DateTime.Now.ToString("yyyyMMdd");//Convert.ToString(dateS.Text);
                //Console.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                //dateParam.Value = DateTime.Now.ToString("yyyyMMdd"); //
                dateParam.Value = Convert.ToString(dateS.Text.Replace("-", ""));
               // dateParam.Value = "20221111";
                cmd.Parameters.Add(dateParam);



                // Добавить параметр @lowSalary (Написать кратко).
                //cmd.Parameters.Add("@timeStr", (MySqlDbType)SqlDbType.Time).Value = time.Text;

                MySqlParameter timeParam = new MySqlParameter("@timeStr", SqlDbType.Time);
                //dateParam.Value = DateTime.Now.ToString("yyyyMMdd");//Convert.ToString(dateS.Text);
                //Console.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                string timeS = String.Concat(Convert.ToString(time.Text.Replace(":", "")), "00");

                timeParam.Value = timeS;//.Replace(":", "")
               // timeParam.Value = "170000";

               cmd.Parameters.Add(timeParam);




                //cmd.Parameters.Add("@placeStr", (MySqlDbType)SqlDbType.VarChar).Value = place.Text;
                MySqlParameter placeParam = new MySqlParameter("@placeStr", MySqlDbType.VarChar);
                placeParam.Value = Convert.ToString(placeS.Text);
               // placeParam.Value = "sad";
               cmd.Parameters.Add(placeParam);


                MySqlParameter addressParam = new MySqlParameter("@addressStr", MySqlDbType.VarChar);
                addressParam.Value = Convert.ToString(addressS.Text);
               // addressParam.Value = "sad";
                cmd.Parameters.Add(addressParam);

                MySqlParameter priceParam = new MySqlParameter("@priceStr", SqlDbType.Decimal);

                string priceSS = Convert.ToString(priceS.Text);
                //int priceSS = int.Parse(priceS.Text);

                Console.WriteLine(priceSS);

                // priceParam.Value = Convert.ToString(priceS.Text);
                priceParam.Value = priceSS;
                // priceParam.Value = 3000;
                 cmd.Parameters.Add(priceParam);


                Console.WriteLine(cmd.CommandText);
                //cmd.Parameters.Add("@addressStr", (MySqlDbType)SqlDbType.VarChar).Value = address.Text;

                //cmd.Parameters.Add("@priceStr", (MySqlDbType)SqlDbType.Decimal).Value = price.Text;

                // Выполнить Command (использованная для  delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            //finally
            //{
            //    conn.Close();
            //    conn.Dispose();
            //    conn = null;
            //}


            // Console.Read();




            //var cmdToBeExecute = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\myScript.py";
            //var start = new ProcessStartInfo
            //{
            //    FileName = "C:\\Python27\\python.exe", 
            //    Arguments = string.Format("{0} {1}", cmdToBeExecute, "\"Rahul done good\""),
            //    UseShellExecute = false,
            //    RedirectStandardOutput = true,
            //    CreateNoWindow = true
            //};





        }



        private void Delete(MySqlConnection conn) //функция запроса данных
        {
            try
            {
                // Команда Insert.
                string sql = "Delete into My_Tickets where Дата  ";

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                // Создать объект Parameter.
                MySqlParameter eventsParam = new MySqlParameter("@eventsStr", MySqlDbType.VarChar);
                eventsParam.Value = Convert.ToString(events.Text);
                cmd.Parameters.Add(eventsParam);

               

                MySqlParameter dateParam = new MySqlParameter("@dateStr", SqlDbType.Date);
               
                dateParam.Value = Convert.ToString(dateS.Text.Replace("-", ""));
                
                cmd.Parameters.Add(dateParam);

                MySqlParameter timeParam = new MySqlParameter("@timeStr", SqlDbType.Time);
               
                string timeS = String.Concat(Convert.ToString(time.Text.Replace(":", "")), "00");

                timeParam.Value = timeS;//.Replace(":", "")
                                        // timeParam.Value = "170000";

                cmd.Parameters.Add(timeParam);

                MySqlParameter placeParam = new MySqlParameter("@placeStr", MySqlDbType.VarChar);
                placeParam.Value = Convert.ToString(placeS.Text);
                
                cmd.Parameters.Add(placeParam);


                MySqlParameter addressParam = new MySqlParameter("@addressStr", MySqlDbType.VarChar);
                addressParam.Value = Convert.ToString(addressS.Text);
               
                cmd.Parameters.Add(addressParam);

                MySqlParameter priceParam = new MySqlParameter("@priceStr", SqlDbType.Decimal);

                string priceSS = Convert.ToString(priceS.Text);
                //int priceSS = int.Parse(priceS.Text);

                Console.WriteLine(priceSS);

                // priceParam.Value = Convert.ToString(priceS.Text);
                priceParam.Value = priceSS;
                // priceParam.Value = 3000;
                cmd.Parameters.Add(priceParam);


                Console.WriteLine(cmd.CommandText);
                //cmd.Parameters.Add("@addressStr", (MySqlDbType)SqlDbType.VarChar).Value = address.Text;

                //cmd.Parameters.Add("@priceStr", (MySqlDbType)SqlDbType.Decimal).Value = price.Text;

                // Выполнить Command (использованная для  delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            
        }


        private void Insert2(MySqlConnection conn) //функция запроса данных
        {
            try
            {
                // Команда Insert.
                string sql = "Insert into тест (тест, тест_дата) "
                                                 + " values (@eventsStr, @dateStr) ";

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                // Создать объект Parameter.
                MySqlParameter eventsParam = new MySqlParameter("@eventsStr", SqlDbType.Int);
                eventsParam.Value = events.Text;
                cmd.Parameters.Add(eventsParam);

                // Добавить параметр @highSalary (Написать кратко).
                //MySqlParameter dateStrParam = cmd.Parameters.Add("@dateStr", (MySqlDbType)SqlDbType.Date);
                //dateStrParam.Value = date.Text;

                //cmd.Parameters.Add("@dateStr", (MySqlDbType)SqlDbType.Date).Value = Convert.ToDateTime(dateS.Text); 

                MySqlParameter dateParam = new MySqlParameter("@dateStr", SqlDbType.Date);
                //dateParam.Value = DateTime.Now.ToString("yyyyMMdd");//Convert.ToString(dateS.Text);
                Console.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                dateParam.Value = Convert.ToString(dateS.Text);
                
                cmd.Parameters.Add(dateParam);





                // Выполнить Command (использованная для  delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }


            // Console.Read();


        }


        private void Insert3(MySqlConnection conn) //функция запроса данных
        {
            try
            {
                // Команда Insert.
                string sql = "Insert into тест3 (тест, тест_дата, тест_время, тест4) "
                                                 + " values (@eventsStr, @dateStr, @timeStr,  @priceStr) ";

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                // Создать объект Parameter.
                MySqlParameter eventsParam = new MySqlParameter("@eventsStr", MySqlDbType.VarChar);
                eventsParam.Value = events.Text;
                cmd.Parameters.Add(eventsParam);

                // Добавить параметр @highSalary (Написать кратко).
                //MySqlParameter dateStrParam = cmd.Parameters.Add("@dateStr", (MySqlDbType)SqlDbType.Date);
                //dateStrParam.Value = date.Text;

                //cmd.Parameters.Add("@dateStr", (MySqlDbType)SqlDbType.Date).Value = Convert.ToDateTime(dateS.Text); 

                MySqlParameter dateParam = new MySqlParameter("@dateStr", SqlDbType.Date);
                dateParam.Value = DateTime.Now.ToString("yyyyMMdd");//Convert.ToString(dateS.Text);
                Console.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                //dateParam.Value = Convert.ToString(dateS.Text);

                cmd.Parameters.Add(dateParam);


                MySqlParameter timeParam = new MySqlParameter("@timeStr", SqlDbType.Time);
                //dateParam.Value = DateTime.Now.ToString("yyyyMMdd");//Convert.ToString(dateS.Text);
                //Console.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                string timeS = String.Concat(Convert.ToString(time.Text.Replace(":", "")) ,"00");
                
                timeParam.Value = timeS;//.Replace(":", "")
                Console.WriteLine(timeS);
                //timeParam.Value =  "170000";
                //DateTime newTime = new DateTime();
                //Console.WriteLine(DateTime.Now.ToString("HHmmss"));
                cmd.Parameters.Add(timeParam);


                MySqlParameter priceParam = new MySqlParameter("@priceStr", SqlDbType.Int);
                string priceSS = Convert.ToString(priceS.Text);
                //int priceSS = int.Parse(priceS.Text);

                Console.WriteLine(priceSS);
                priceParam.Value = priceSS;
                //priceParam.Value = 3000;
                cmd.Parameters.Add(priceParam);


                // Выполнить Command (использованная для  delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }


            // Console.Read();


        }




        private void dateS_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
