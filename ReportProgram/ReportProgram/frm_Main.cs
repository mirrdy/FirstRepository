﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ReportProgram
{
    public partial class frm_Main : Form
    {
        private frm_Monitor child_Monitor = null;
        private frm_DataManage child_DataManage = null;
        private frm_JobOrder child_JobWork = null;
        private frm_Set child_Set = null;
        private xml_Setting mySetting = new xml_Setting();

        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);
            //화면 크기/위치 조정
            Set_Form_Size_Pos();
            this.WindowState = FormWindowState.Maximized;

            // Odbc 연결 후 테이블 생성이 안되어있으면 자동 생성
            Check_TableExist("dsn=" + mySetting.Info_DBConnection);

            if (mySetting.StartViewIndex == Const.FORM_MONITOR) btn_Monitor.PerformClick();
            else if (mySetting.StartViewIndex == Const.FORM_DATAMANAGE) btn_DataManage.PerformClick();
            else if (mySetting.StartViewIndex == Const.FORM_JOBWORK) btn_JobOrder.PerformClick();
            else btn_Monitor.PerformClick();
        }
        private void Check_TableExist(string connectionString)
        {
            // model 테이블 체크
            string queryString = "SHOW TABLES LIKE 'model'";
            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();

                    OdbcDataReader dr = command.ExecuteReader();

                    dr.Read();
                    // 테이블 생성시 무조건 Column을 하나 이상 포함해야 하기 때문에 0번이 없으면 해당 테이블이 존재하지 않음
                    if (dr[0] != DBNull.Value)
                    {
                        // Table이 존재함
                    }
                    dr.Close();
                }
            }
            catch (InvalidOperationException ex)
            {
                // Table이 없음
                //MessageBox.Show("model 테이블이 존재하지 않습니다. 테이블을 생성합니다.\n\n" + ex.ToString());

                queryString = "CREATE TABLE `model` ( " +
                    "`No` INT(10) NOT NULL AUTO_INCREMENT," +
                    "`name` VARCHAR(1024) NOT NULL," +
                    "`update_date` VARCHAR(128) NULL DEFAULT NULL," +
                    "`update_user` VARCHAR(32) NULL DEFAULT NULL," +
                    "`data_header` TEXT NULL DEFAULT NULL," +
                    "PRIMARY KEY(`No`)" +
                ")" +
                "COLLATE = 'utf8_general_ci';";

                command.CommandText = queryString;

                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {    
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("DB 연결 중 오류가 발생했습니다. \n\n" + e.ToString());
            }

            // Test_Data 테이블 체크
            queryString = "SHOW TABLES LIKE 'Test_Data'";
            command.CommandText = queryString;
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();

                    OdbcDataReader dr = command.ExecuteReader();

                    dr.Read();
                    // 테이블 생성시 무조건 Column을 하나 이상 포함해야 하기 때문에 0번이 없으면 해당 테이블이 존재하지 않음
                    if (dr[0] != DBNull.Value)
                    {
                        // Table이 존재함
                    }
                    dr.Close();
                }
            }
            catch (InvalidOperationException ex)
            {
                // Table이 없음
                //MessageBox.Show("Test_Data 테이블이 존재하지 않습니다. 테이블을 생성합니다.\n\n" + ex.ToString());

                queryString = "CREATE TABLE `Test_Data` ( " +
                    "`No` INT(10) NOT NULL AUTO_INCREMENT," +
                    "`Model_name` VARCHAR(1024) NOT NULL," +
                    "`Test_user` VARCHAR(32) NULL DEFAULT NULL," +
                    "`Start_time` VARCHAR(128) NULL DEFAULT NULL," +
                    "`End_time` VARCHAR(128) NULL DEFAULT NULL," +
                    "`Serial_number` VARCHAR(2048) NULL DEFAULT NULL," +
                    "`Barcode` VARCHAR(2048) NULL DEFAULT NULL," +
                    "`Total_result` VARCHAR(32) NULL DEFAULT NULL," +
                    "`Test_Data` TEXT NULL DEFAULT NULL," +
                    "PRIMARY KEY(`No`)" +
                ")" +
                "COLLATE = 'utf8_general_ci';";

                command.CommandText = queryString;

                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("DB 연결 중 오류가 발생했습니다. \n\n" + e.ToString());
            }
        }

        private void Set_Form_Size_Pos()
        {
            int tmp_W = 1280;
            int tmp_H = 983;

            // 프로그램 위치
            this.Location = new Point(mySetting.Location_X-3, mySetting.Location_Y-3);

            // 프로그램 크기
            if (mySetting.Size_W != 0) tmp_W = mySetting.Size_W;
            if (mySetting.Size_H != 0) tmp_H = mySetting.Size_H;
            this.Size = new Size(tmp_W, tmp_H);

        }

        private void btn_Monitor_Click(object sender, EventArgs e)
        {
            if (child_Monitor != null)
            {
                return;
            }
            else if (child_DataManage != null)
            {
                child_DataManage.Close();
                child_DataManage.Dispose();
                child_DataManage = null;
            }
            else if (child_Set != null)
            {
                child_Set.Close();
                child_Set.Dispose();
                child_Set = null;
            }
            else if (child_JobWork != null)
            {
                child_JobWork.Close();
                child_JobWork.Dispose();
                child_JobWork = null;
            }

            btn_Monitor.BackColor = Color.LightCyan;
            btn_JobOrder.BackColor = Color.AliceBlue;
            btn_Set.BackColor = Color.AliceBlue;
            btn_DataManage.BackColor = Color.AliceBlue;

            child_Monitor = new frm_Monitor();
            child_Monitor.TopLevel = false;
            child_Monitor.TopMost = true;
            child_Monitor.Parent = pnl_Center;
            child_Monitor.Show();
            child_Monitor.Size = pnl_Center.Size;
            lbl_Title.Text = "공정 모니터링";
            lbl_Title.Location = new Point(this.Width - (lbl_Title.Size.Width + 28), lbl_Title.Location.Y);
        }

        private void btn_DataManage_Click(object sender, EventArgs e)
        {
            if (child_Monitor != null)
            {
                child_Monitor.Close();
                child_Monitor.Dispose();
                child_Monitor = null;
            }
            else if (child_DataManage != null)
            {
                return;
            }
            else if (child_Set != null)
            {
                child_Set.Close();
                child_Set.Dispose();
                child_Set = null;
            }
            else if (child_JobWork != null)
            {
                child_JobWork.Close();
                child_JobWork.Dispose();
                child_JobWork = null;
            }

            btn_Monitor.BackColor = Color.AliceBlue;
            btn_JobOrder.BackColor = Color.AliceBlue;
            btn_Set.BackColor = Color.AliceBlue;
            btn_DataManage.BackColor = Color.LightCyan;

            child_DataManage = new frm_DataManage();
            child_DataManage.TopLevel = false;
            child_DataManage.TopMost = true;
            child_DataManage.Parent = pnl_Center;
            child_DataManage.Show();
            child_DataManage.Size = pnl_Center.Size;
            lbl_Title.Text = "데이터 조회";
            lbl_Title.Location = new Point(this.Width - (lbl_Title.Size.Width + 28), lbl_Title.Location.Y);
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (child_Monitor != null)
            {
                child_Monitor.Close();
                child_Monitor.Dispose();
                child_Monitor = null;
            }
            else if (child_DataManage != null)
            {
                child_DataManage.Close();
                child_DataManage.Dispose();
                child_DataManage = null;
            }
            else if (child_Set != null)
            {
                return;
            }
            else if (child_JobWork != null)
            {
                child_JobWork.Close();
                child_JobWork.Dispose();
                child_JobWork = null;
            }

            btn_Monitor.BackColor = Color.AliceBlue;
            btn_JobOrder.BackColor = Color.AliceBlue;
            btn_Set.BackColor = Color.LightCyan;
            btn_DataManage.BackColor = Color.AliceBlue;

            child_Set = new frm_Set();
            child_Set.TopLevel = false;
            child_Set.TopMost = true;
            child_Set.Parent = pnl_Center;
            child_Set.Show();
            child_Set.Size = pnl_Center.Size;
            lbl_Title.Text = "환경설정";
            lbl_Title.Location = new Point(this.Width - (lbl_Title.Size.Width + 28), lbl_Title.Location.Y);
        }

        private void frm_Main_Resize(object sender, EventArgs e)
        {
            lbl_Title.Location = new Point(this.Width - (lbl_Title.Size.Width + 28), lbl_Title.Location.Y);
            if (child_Monitor != null)
            {
                child_Monitor.Size = pnl_Center.Size;
            }
            else if (child_DataManage != null)
            {
                child_DataManage.Size = pnl_Center.Size;
            }
            else if (child_Set != null)
            {
                child_Set.Size = pnl_Center.Size;
            }
            else if (child_JobWork != null)
            {
                child_JobWork.Size = pnl_Center.Size;
            }
        }

        private void btn_JobOrder_Click(object sender, EventArgs e)
        {
            if (child_JobWork != null)
            {
                return;
            }
            else if (child_Monitor != null)
            {
                child_Monitor.Close();
                child_Monitor.Dispose();
                child_Monitor = null;
            }
            else if (child_DataManage != null)
            {
                child_DataManage.Close();
                child_DataManage.Dispose();
                child_DataManage = null;
            }
            else if (child_Set != null)
            {
                child_Set.Close();
                child_Set.Dispose();
                child_Set = null;
            }

            btn_Monitor.BackColor = Color.AliceBlue;
            btn_JobOrder.BackColor = Color.LightCyan;
            btn_Set.BackColor = Color.AliceBlue;
            btn_DataManage.BackColor = Color.AliceBlue;

            child_JobWork = new frm_JobOrder();
            child_JobWork.TopLevel = false;
            child_JobWork.TopMost = true;
            child_JobWork.Parent = pnl_Center;
            child_JobWork.Show();
            child_JobWork.Size = pnl_Center.Size;
            lbl_Title.Text = "작업지시서";
            lbl_Title.Location = new Point(this.Width - (lbl_Title.Size.Width + 28), lbl_Title.Location.Y);
        }
    }
}
