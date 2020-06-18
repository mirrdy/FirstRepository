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
using System.ComponentModel.Design;
using System.IO;

namespace ReportProgram
{
    public partial class frm_Monitor : Form
    {
        private string ConString = "dsn=MariaDB";
        private bool TmrFlg = false;
        private List<int> goodCount = new List<int>();
        private List<int> badCount = new List<int>();
        private List<string> tmp_Date = new List<string>();
        private bool isFirstShow = true;
        private int modelCount = 0;
        private List<string> model_Name = new List<string>();
        public int targetCount = 1000;

        TextAnnotation displayNowGoal = new TextAnnotation();
        TextAnnotation displayDayTarget = new TextAnnotation();

        public frm_Monitor()
        {
            InitializeComponent();
            CreateGrid(ConString);
            timer1.Enabled = true;
        }

        private void ShowChart(string connectionString)
        {
            string queryString;

            goodCount.Clear();
            badCount.Clear();
            tmp_Date.Clear();

            queryString = "select * from Test_Data order by Start_time asc;";
            OdbcCommand command = new OdbcCommand(queryString);
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();
                while(dr.Read())
                {
                    if(tmp_Date.Count==0)
                    {
                        goodCount.Add(0);
                        badCount.Add(0);
                        tmp_Date.Add(dr["Start_time"].ToString().Substring(0, 8));
                    }
                    if(!(tmp_Date[tmp_Date.Count-1].Equals(dr["Start_time"].ToString().Substring(0,8))))
                    {
                        goodCount.Add(0);
                        badCount.Add(0);
                        tmp_Date.Add(dr["Start_time"].ToString().Substring(0, 8));
                    }
                    if (dr["Total_result"].ToString().Equals("양품"))
                        goodCount[goodCount.Count - 1]++;
                    else
                        badCount[badCount.Count - 1]++;
                }

                chart1.ChartAreas[0].AxisX.Minimum = Convert.ToInt64("20200601");
            }
            if (isFirstShow)
            {
                for (int i = 0; i < tmp_Date.Count; i++)
                {
                    chart1.Series["Fail"].Points.AddXY(Convert.ToInt64(tmp_Date[i]), badCount[i]);
                    chart1.Series["Pass"].Points.AddXY(Convert.ToInt64(tmp_Date[i]), goodCount[i]);
                    chart1.Series["Yield"].Points.AddXY(Convert.ToInt64(tmp_Date[i]), (goodCount[i] / (double)(goodCount[i] + badCount[i]) * 100));
                }
                isFirstShow = false;
            }
            
            else
            {
                for (int i = 0; i < tmp_Date.Count; i++)
                {
                    chart1.Series["Fail"].Points.ElementAt(i).SetValueXY(Convert.ToInt64(tmp_Date[i]), badCount[i]);
                    chart1.Series["Pass"].Points.ElementAt(i).SetValueXY(Convert.ToInt64(tmp_Date[i]), goodCount[i]);
                    chart1.Series["Yield"].Points.ElementAt(i).SetValueXY(Convert.ToInt64(tmp_Date[i]), (goodCount[i] / (double)(goodCount[i] + badCount[i]) * 100));
                }
            }
            //MessageBox.Show(chart1.Series["Fail"].Points[0].ToString());

            chart_Test.Series[0].Points.Clear();
            chart_Test.Series[0].IsVisibleInLegend = false;
            chart_Test.Series[0].IsValueShownAsLabel = false;
            // chart2.Series[0].LabelFormat = "0EA";
            chart_Test.Series[0].Points.AddXY("금일 잔여 목표생산량("+ ((targetCount - goodCount.Sum()) < 0 ? 0 : targetCount - goodCount.Sum()) + ")", (targetCount-goodCount.Sum())<0 ? 0 : targetCount-goodCount.Sum());
            chart_Test.Series[0].Points[0].Color = Color.LimeGreen;
            chart_Test.Series[0].Points.AddXY("금일 총 생산량("+goodCount.Sum()+")", goodCount.Sum());
            chart_Test.Series[0].Points[1].Color = Color.DarkGreen;
            chart_Test.Annotations.Clear();
            displayNowGoal.Text = (goodCount.Sum() / (double)targetCount) < 1 ? Math.Round((goodCount.Sum() / (double)targetCount * 100), 2).ToString()+"%" : "100%";
            chart_Test.Annotations.Add(displayNowGoal);
            chart_Test.Annotations.Add(displayDayTarget);
        }

        private void ShowGrid(string connectionString)
        {
            int[] goodCount = new int[modelCount];
            int[] badCount = new int[modelCount];
            string selected_Date = "20200603";
            string queryString = "select * from Test_Data where Start_time like '"+selected_Date+"%'"; //selected_Date 날짜의 데이터 선택

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();

                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < modelCount; i++)
                    {
                        if (model_Name[i].Equals(dr["Model_name"]))
                        {
                            if (dr["Total_result"].ToString().Equals("양품"))
                            {
                                goodCount[i]++;
                            }
                            else
                            {
                                badCount[i]++;
                            }
                        }
                        // ModelCount 값 참조해서 양품/불량 카운트 배열 개수 정해놓고 인덱스별로 양/불 판별해 카운트
                    }
                }
            }
            for(int i=0; i<modelCount; i++)
            {
                dgv_Data[0, i].Value = model_Name[i];
                dgv_Data[1, i].Value = 100;
                dgv_Data[2, i].Value = goodCount[i];
                dgv_Data[3, i].Value = badCount[i];
                dgv_Data[4, i].Value = Math.Round(goodCount[i] / (double)(goodCount[i] + badCount[i]) * 100, 2)+"%";
            }
        }
        private void CreateGrid(string connectionString)
        {
            string queryString = "select * from model";

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();

                OdbcDataReader dr = command.ExecuteReader();

                while(dr.Read())
                {
                    model_Name.Add(dr["name"].ToString());
                }

                modelCount = model_Name.Count;

                string[] tmpRow = { "", "", "", "", "" };

                for (int i = 0; i < modelCount; i++)
                {
                    dgv_Data.Rows.Add(tmpRow);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TmrFlg == false)
            {
                TmrFlg = true;
                ShowChart(ConString);
                ShowGrid(ConString);

                TmrFlg = false;
            }
        }
        private void chart2_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is ChartArea)
            {
                //ta.Text = "81%";
                displayNowGoal.Width = e.Position.Width;
                displayNowGoal.Height = e.Position.Height;
                displayNowGoal.X = e.Position.X;
                displayNowGoal.Y = e.Position.Y;
                displayNowGoal.ForeColor = Color.White;
                displayNowGoal.Font = new Font("Ms Sans Serif", 24, FontStyle.Bold);

                
                displayDayTarget.Width = e.Position.Width;
                displayDayTarget.Height = e.Position.Height;
                displayDayTarget.X = e.Position.X;
                displayDayTarget.Y = e.Position.Y-45;
                displayDayTarget.ForeColor = Color.White;
                displayDayTarget.Font = new Font("Ms Sans Serif", 24, FontStyle.Bold);
            }
        }
        private void frm_Monitor_Load(object sender, EventArgs e)
        {
            loadDailyTarget();
        }
        private void loadDailyTarget()
        {
            string path = "D:\\targetSaveFolder\\" + DateTime.Now.ToString("yyyyMMdd")+".txt";
            StreamReader loadFile = new StreamReader(new FileStream(path, FileMode.Open));

            while (loadFile.EndOfStream == false)
            {
                targetCount = Convert.ToInt32(loadFile.ReadLine());
            }
            displayDayTarget.Text = "금일 목표수량: " + targetCount.ToString();
        }
    }
}
