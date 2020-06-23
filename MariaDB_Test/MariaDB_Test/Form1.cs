using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Odbc;
using System.Diagnostics;

namespace MariaDB_Test
{
    public partial class Form1 : Form
    {
        private string ConString = "dsn=MariaDB";
        private string start_time;
        private string end_time;
        private string serial_number;
        private string barcode;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectModel(ConString);
            
        }

        private void InsertRow(string connectionString, bool judge)
        {

            string queryString = "select * from Test_Data order by no desc limit 1";

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while(dr.Read())
                {
                    start_time = dr["Start_time"].ToString();
                    end_time = dr["End_time"].ToString();
                    serial_number = dr["Serial_number"].ToString();
                    barcode = dr["Barcode"].ToString();
                }
            }
            //label1.Text = DateTime.ParseExact(start_time, "yyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString();

            DateTime tmpDate = DateTime.Now;
            string dateFormat = "yyyy-MM-dd HH:mm:ss";
            string tmpStr = tmpDate.ToString(dateFormat);
            string tmpStr1 = tmpDate.AddDays(1).ToString(dateFormat);

            start_time = tmpStr;
            end_time = tmpStr;


            queryString = "INSERT INTO Test_Data (Model_name, Test_user, Start_time, End_time, Serial_number, Barcode, Total_result, Test_Data) " +
                "Values('CN7','ABC', '" + 
                DateTime.ParseExact(start_time, dateFormat, System.Globalization.CultureInfo.InvariantCulture).AddMinutes(1).ToString(dateFormat) +
                "', '" + DateTime.ParseExact(end_time, dateFormat, System.Globalization.CultureInfo.InvariantCulture).AddMinutes(1).ToString(dateFormat) +
                "', '" + (Convert.ToInt64(serial_number) + 1).ToString("D4") +
                "', 'CJ" + (Convert.ToInt64(barcode.Substring(2)) + 1).ToString() +
                "', '" + (judge ? "양품" : "불량") +
                "', 'OK; OK;3.5;43.0;')";


            label1.Text = start_time;
            label2.Text = end_time;
            label3.Text = serial_number;
            label4.Text = barcode;
            label5.Text = queryString;


            //string queryString = "INSERT INTO model (name, update_date, update_user, data_header) Values('HM3', '20200609 145122', 'GCW', '전류;전압;절연저항;내전압;')";
            /*queryString = "INSERT INTO Test_Data (Model_name, Test_user, Start_time, End_time, Serial_number, Barcode, Total_result, Test_Data) " +
                "Values('CN7','ABC', " + start_time + ", " + end_time + ", " + serial_number + ", " + barcode + ", '양품', 'OK; OK;3.5;43.0;')";*/

            

            command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();


                // The connection is automatically closed at
                // the end of the Using block.
            }
        }

        private void SelectModel(string connectionString)
        {
            string queryString = "select * from Test_Data";

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table1");
                ds.Tables.Add(dt);
                ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);
                dgv_Data.DataSource = ds.Tables["Table1"];

                // The connection is automatically closed at
                // the end of the Using block.
            }
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertRow(ConString, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertRow(ConString, false);
        }
    }
}
