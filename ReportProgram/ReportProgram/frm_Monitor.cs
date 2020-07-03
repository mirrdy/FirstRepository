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
using Org.BouncyCastle.Asn1.X509;

namespace ReportProgram
{
    public partial class frm_Monitor : Form
    {
        private xml_Setting mySetting = new xml_Setting();
        private bool TmrFlg = false;
        private int modelCount = 0;
        private List<string> model_Name = new List<string>();
        public int targetCount = 123;

        TextAnnotation displayNowGoal = new TextAnnotation();
        private bool DBOpenFlg = true;

        public frm_Monitor()
        {
            InitializeComponent();
            loadMySetting();
        }
        private void loadMySetting()
        {
            mySetting.Setting_Load_Xml(Const.SYSTEM_PATH);
            targetCount = mySetting.Target_Count;
        }

        private void frm_Monitor_Load(object sender, EventArgs e)
        {
            string tmpDSN = "dsn=" + mySetting.Info_DBConnection;

            CreateGrid(tmpDSN);

            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;

            ShowChart(tmpDSN);
            ShowGrid(tmpDSN);

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

            try
            {
                queryString = "select * from Test_Data order by Start_time asc;";
                OdbcCommand command = new OdbcCommand(queryString);
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();
                    OdbcDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        int tmpIndex = -1;
                        for (int i = 0; i < tmpDate.Count; i++)
                        {
                            DateTime GetDate = Convert.ToDateTime(dr["Start_time"].ToString().Substring(0, 10));
                            if (tmpDate[i] == GetDate)
                            {
                                tmpIndex = i;
                            }
                        }

                        if (tmpIndex == -1)
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

                // Chart Display : 최근 14개만 표시
                int tmpStartIndex = 0;
                if (tmpDate.Count > 14) tmpStartIndex = tmpDate.Count - 14;

                chart1.Series["Pass"].Points.Clear();
                chart1.Series["Fail"].Points.Clear();
                chart1.Series["Yield"].Points.Clear();
                for (int i = tmpStartIndex; i < tmpDate.Count; i++)
                {
                    chart1.Series["Pass"].Points.AddXY(tmpDate[i].ToString("yyyy-MM-dd"), tmpOKCount[i]);
                    chart1.Series["Fail"].Points.AddXY(tmpDate[i].ToString("yyyy-MM-dd"), tmpNGCount[i]);
                    chart1.Series["Yield"].Points.AddXY(tmpDate[i].ToString("yyyy-MM-dd"), (tmpOKCount[i] / (double)(tmpOKCount[i] + tmpNGCount[i]) * 100));
                }

                // 원형차트 디스플레이
                // 원형차트는 금일 생산수량(양품수량)을 표시
                int TodayOKCount = 0;
                for (int i = 0; i < tmpDate.Count; i++)
                {
                    if (tmpDate[i].Date == DateTime.Now.Date)
                    {
                        TodayOKCount = tmpOKCount[i];
                        break;
                    }
                }

                chart_Test.Series[0].Points.Clear();
                chart_Test.Series[0].IsVisibleInLegend = false;
                chart_Test.Series[0].IsValueShownAsLabel = false;
                for (int i = 0; i < tmpDate.Count; i++)
                {
                    if (tmpDate[i] == DateTime.Now)
                    {
                        TodayOKCount = tmpOKCount[i];
                        break;
                    }
                }
                chart_Test.Series[0].Points.AddXY("잔여수량 (" + (targetCount - TodayOKCount).ToString() + "EA)", targetCount - TodayOKCount);
                chart_Test.Series[0].Points[0].Color = Color.Gray;
                chart_Test.Series[0].Points[0].LabelForeColor = Color.Black;
                chart_Test.Series[0].Points.AddXY("총 생산량 (" + TodayOKCount.ToString() + "EA)", TodayOKCount);
                chart_Test.Series[0].Points[1].Color = Color.LimeGreen;
                chart_Test.Series[0].Points[1].LabelForeColor = Color.Black;
                chart_Test.Annotations.Clear();
                displayNowGoal.Text = ((double)TodayOKCount / (double)targetCount) < 1 ? Math.Round(((double)TodayOKCount / (double)targetCount * 100), 2).ToString() + "%" : "100%";

                chart_Test.Annotations.Add(displayNowGoal);
            }
            catch(Exception ex)
            {
                DBOpenFlg = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowGrid(string connectionString)
        {
            int[] goodCount = new int[modelCount];
            int[] badCount = new int[modelCount];
            string selected_Date = DateTime.Now.ToString("yyyy-MM-dd");
            string queryString = "select * from Test_Data where Start_time like '" + selected_Date + "%'"; //selected_Date 날짜의 데이터 선택

            try
            {
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

                double tmpPercent = 0;
                for (int i = 0; i < modelCount; i++)
                {
                    dgv_Data[0, i].Value = model_Name[i];
                    dgv_Data[1, i].Value = goodCount[i];
                    dgv_Data[2, i].Value = badCount[i];
                    tmpPercent = goodCount[i] / (double)(goodCount[i] + badCount[i]);
                    if (double.IsNaN(tmpPercent) == true) dgv_Data[3, i].Value = "---.--%";
                    else dgv_Data[3, i].Value = tmpPercent.ToString("0.00%");
                }
            }
            catch(Exception ex)
            {
                DBOpenFlg = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateGrid(string connectionString)
        {
            if (mySetting.Info_DBConnection.Length <= 0) return;

            string queryString = "select * from model";

            OdbcCommand command = new OdbcCommand(queryString);

            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();

                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
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
            catch(Exception ex)
            {
                DBOpenFlg = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void tmr_Monitor_Tick(object sender, EventArgs e)
        {
            if (TmrFlg == false)
            {
                TmrFlg = true;

                if(DBOpenFlg == true)
                {
                    ShowChart("dsn=" + mySetting.Info_DBConnection);
                    ShowGrid("dsn=" + mySetting.Info_DBConnection);
                }

                TmrFlg = false;
            }
        }

        private void chart_Test_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is ChartArea)
            {
                // displayNowGoal.Text = "81%";
                displayNowGoal.Width = e.Position.Width;
                displayNowGoal.Height = e.Position.Height;
                displayNowGoal.X = e.Position.X;
                displayNowGoal.Y = e.Position.Y;
                displayNowGoal.ForeColor = Color.FromArgb(80, 80, 80);
                displayNowGoal.Font = new Font("맑은 고딕", 24, FontStyle.Bold);
            }
        }
    }
}
