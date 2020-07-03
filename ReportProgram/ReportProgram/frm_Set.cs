using ReportProgram.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgram
{
    public partial class frm_Set : Form
    {
        private xml_Setting mySetting = new xml_Setting();

        private string conString;

        public frm_Set()
        {
            InitializeComponent();
            loadMySetting();
        }

        private void loadMySetting()
        {
            mySetting.Setting_Load_Xml(Const.SYSTEM_PATH);

            targetInputBox.Text = mySetting.Target_Count.ToString();
            infoDBConInputBox.Text = mySetting.Info_DBConnection.Substring(4);
            cbb_StartViewIndex.SelectedIndex = mySetting.StartViewIndex;
            conString = mySetting.Info_DBConnection;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            #region textSaveSetting
            /*string modelCheck;
                int targetQuantity;
                DateTime targetDate = targetCalendar.SelectionStart;
                string dateFormat = "yyyyMMdd";

                if (selectModelCB.SelectedItem != null)
                    modelCheck = selectModelCB.SelectedItem.ToString();
                *//*else
                {
                    MessageBox.Show("모델을 선택해주세요.");
                    return;
                }*//*

                if (targetInputBox.Text.Equals(""))
                {
                    MessageBox.Show("목표수량을 입력해주세요.");
                    return;
                }
                else if (!int.TryParse(targetInputBox.Text, out _))
                {
                    MessageBox.Show("목표 수량에는 정수만 입력해야 합니다.");
                    return;
                }
                else
                {
                    targetQuantity = Convert.ToInt32(targetInputBox.Text);
                }

                MessageBox.Show(targetQuantity.ToString());


                if(Directory.Exists("d:\\targetSaveFolder") == false)
                {
                    Directory.CreateDirectory("d:\\targetSaveFolder");
                }

                StreamWriter saveFile = new StreamWriter(new FileStream("d:\\targetSaveFolder\\"+targetDate.ToString(dateFormat)+".txt", FileMode.Create));

                saveFile.WriteLine(targetInputBox.Text);

                saveFile.Close();*/
            #endregion
            mySetting.Target_Count = Convert.ToInt32(targetInputBox.Text);
            mySetting.Info_DBConnection = infoDBConInputBox.Text;
            mySetting.StartViewIndex = cbb_StartViewIndex.SelectedIndex;

            mySetting.Setting_Save_Xml(Const.SYSTEM_PATH);
            MessageBox.Show("저장 완료!");
        }
    }
}
