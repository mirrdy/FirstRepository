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
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms.DataVisualization.Charting;

namespace ReportProgram
{
    public partial class frm_Monitor : Form
    {
        private string ConString = "dsn=MariaDB";
        private bool TmrFlg = false;



        public frm_Monitor()
        {
            InitializeComponent();
            timer1.Enabled = true;
            //ShowChart(ConString);
        }

        private void ShowChart(string connectionString)
        {
            
            string queryString = "select * from Test_Data order by Start_time asc";

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                List<int> goodCount = new List<int>();
                List<int> badCount = new List<int>();
                string tmp_Date = "";

                int dateNum = 0;

                while (dr.Read())
                {
                    if (dr["Total_result"].ToString().Equals("양품"))
                        goodCount[dateNum]++;
                    else
                        badCount[dateNum]++;

                    if (!(tmp_Date.Equals(dr["Start_time"].ToString().Substring(0, 8))))
                        dateNum++;
                    
                    tmp_Date =dr["Start_time"].ToString().Substring(0, 8);

                    //if 이전 start_time과 이번 read내용의 start_time의 첫 8자가 같으면(날짜) => quantity(양)이나 quantity(불) 변수 값(y축) 추가
                    //직전 start_time 뿐이 아닌 전체 x축 이름과 비교해야 할 것 같음


                    /*chart1.Series[0].Points.AddXY(dr["Start_time"].ToString(), goodCount);
                    chart1.Series[1].Points.AddXY(dr["start_time"].ToString(), badCount);*/
                }

                for (int i = 0; i < dateNum; i++)
                {
                    chart1.Series[0].Points.AddXY(dr["Start_time"].ToString().Substring(0, 8), goodCount[i]);
                    chart1.Series[1].Points.AddXY(dr["Start_time"].ToString().Substring(0, 8), badCount[i]);
                    
                    
                }


                //날짜가 바뀌면 수량 초기화



                /*chart1.Series[0].Name = dr.GetInt16(0).ToString();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table1");
                ds.Tables.Add(dt);
                ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);*/

                // The connection is automatically closed at
                // the end of the Using block.
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(TmrFlg == false)
            {
                TmrFlg = true;
                ShowChart(ConString);
                
                TmrFlg = false;
            }
        }
    }
}
