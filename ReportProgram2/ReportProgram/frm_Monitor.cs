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
        private bool isFirstShow = true;
        private int modelCount = 0;
        private List<string> model_Name = new List<string>();
        public int targetCount = 1000;

        TextAnnotation displayNowGoal = new TextAnnotation();
        TextAnnotation displayDayTarget = new TextAnnotation();

        public frm_Monitor()
        {
            InitializeComponent();
        }

        private void frm_Monitor_Load(object sender, EventArgs e)
        {
            CreateGrid(ConString);
            loadDailyTarget();

            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;

            ShowChart(ConString);
            ShowGrid(ConString);

            tmr_Monitor.Enabled = true;
        }

        private void ShowChart(string connectionString)
        {
            string queryString;
            List<int> tmpOKCount = new List<int>();
            List<int> tmpNGCount = new List<int>();
            List<DateTime> tmpDate = new List<DateTime>();

            tmpOKCount.Clear();
            tmpNGCount.Clear();
            tmpDate.Clear();

            queryString = "select * from Test_Data order by Start_time asc;";
            OdbcCommand command = new OdbcCommand(queryString);
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();
                while(dr.Read())
                {
                    int tmpIndex = -1;
                    for (int i = 0; i < tmpDate.Count; i++)
                    {
                        DateTime GetDate = Convert.ToDateTime(dr["Start_time"].ToString().Substring(0, 10));
                        if(tmpDate[i] == GetDate)
                        {
                            tmpIndex = i;
                        }
                    }

                    if(tmpIndex == -1)
                    {
                        tmpDate.Add(Convert.ToDateTime(dr["Start_time"].ToString().Substring(0, 10)));
                        tmpOKCount.Add(0);
                        tmpNGCount.Add(0);
                        tmpIndex = tmpDate.Count - 1;
                    }

                    if (dr["Total_result"].ToString().Equals("양품"))
                        tmpOKCount[tmpIndex]++;
                    else
                        tmpNGCount[tmpIndex]++;
                }

                // chart1.ChartAreas[0].AxisX.Minimum = Convert.ToDateTime("20200531");
            }

            // Chart Display
            if (isFirstShow)
            {
                for (int i = 0; i < tmpDate.Count; i++)
                {
                    chart1.Series["Pass"].Points.AddXY(tmpDate[i].ToString("yyyy-MM-dd"), tmpOKCount[i]);
                    chart1.Series["Fail"].Points.AddXY(tmpDate[i].ToString("yyyy-MM-dd"), tmpNGCount[i]);
                    chart1.Series["Yield"].Points.AddXY(tmpDate[i].ToString("yyyy-MM-dd"), (tmpOKCount[i] / (double)(tmpOKCount[i] + tmpNGCount[i]) * 100));
                }
                isFirstShow = false;
            }
            else
            {
                for (int i = 0; i < tmpDate.Count; i++)
                {
                    chart1.Series["Pass"].Points.ElementAt(i).SetValueXY(tmpDate[i].ToString("yyyy-MM-dd"), tmpOKCount[i]);
                    chart1.Series["Fail"].Points.ElementAt(i).SetValueXY(tmpDate[i].ToString("yyyy-MM-dd"), tmpNGCount[i]);
                    chart1.Series["Yield"].Points.ElementAt(i).SetValueXY(tmpDate[i].ToString("yyyy-MM-dd"), (tmpOKCount[i] / (double)(tmpOKCount[i] + tmpNGCount[i]) * 100));
                }
            }

            //MessageBox.Show(chart1.Series["Fail"].Points[0].ToString());

            // 원형차트 디스플레이
            // 원형차트는 금일 생산수량(양품수량)을 표시
            int TodayOKCount = 0;
            chart_Test.Series[0].Points.Clear();
            chart_Test.Series[0].IsVisibleInLegend = false;
            chart_Test.Series[0].IsValueShownAsLabel = false;
            for(int i = 0; i < tmpDate.Count; i++)
            {
                if(tmpDate[i] == DateTime.Now)
                {
                    TodayOKCount = tmpOKCount[i];
                    break;
                }
            }
            chart_Test.Series[0].Points.AddXY("금일 잔여 목표생산량("+ (targetCount - TodayOKCount).ToString() + ")", targetCount - TodayOKCount);
            chart_Test.Series[0].Points[0].Color = Color.DarkGreen;
            chart_Test.Series[0].Points.AddXY("금일 총 생산량("+ TodayOKCount.ToString() + ")", TodayOKCount);
            chart_Test.Series[0].Points[1].Color = Color.LimeGreen;
            chart_Test.Annotations.Clear();
            displayNowGoal.Text = ((double)TodayOKCount / (double)targetCount) < 1 ? Math.Round(((double)TodayOKCount / (double)targetCount * 100), 2).ToString()+"%" : "100%";
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

        private void loadDailyTarget()
        {
            string path = "D:\\targetSaveFolder\\" + DateTime.Now.ToString("yyyyMMdd")+".txt";

            if (File.Exists(path) == true)
            {
                using (StreamReader loadFile = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    while (loadFile.EndOfStream == false)
                    {
                        targetCount = Convert.ToInt32(loadFile.ReadLine());
                    }
                }
            }
            else
            {
                targetCount = 1000;
            }
        }

        private void tmr_Monitor_Tick(object sender, EventArgs e)
        {
            if (TmrFlg == false)
            {
                TmrFlg = true;

                ShowChart(ConString);
                ShowGrid(ConString);

                TmrFlg = false;
            }
        }
    }
}
