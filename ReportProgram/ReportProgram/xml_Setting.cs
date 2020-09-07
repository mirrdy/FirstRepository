using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace ReportProgram
{
    class xml_Setting
    {
        public int Target_Count;
        public string Info_DBConnection;

        public int StartViewIndex;

        public double JobOrder_SlideShow_Time;
        public string[] JobOrder_File = new string[100];

        public xml_Setting()
        {
            Setting_Init();
        }
        public void Setting_Init()
        {
            Target_Count = 0;
            Info_DBConnection = "MariaDB";

            StartViewIndex = 0;

            for(int i = 0; i < JobOrder_File.Length; i++)
            {
                JobOrder_File[i] = "";
            }
        }
        public void Setting_Save_Xml(string SettingPath)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlSetting = doc.CreateElement("Setting");

            // 저장 경로에 폴더가 없으면 생성
            DirectoryInfo di = new DirectoryInfo(Const.SYSTEM_PATH);
            if (!di.Exists)
            {
                di.Create();
            }

            // xml 문서에 들어갈 요소 생성
            XmlElement el_Target_Count = doc.CreateElement("Target_Count");
            XmlElement el_Info_DBConnection = doc.CreateElement("Info_DBConnection");
            XmlElement el_StartViewIndex = doc.CreateElement("StartViewIndex");

            // 각각의 요소 내용으로 그에 맞는 객체 속성값을 넣음
            el_Target_Count.InnerText = Target_Count.ToString();
            el_Info_DBConnection.InnerText = Info_DBConnection;
            el_StartViewIndex.InnerText = StartViewIndex.ToString();

            // 각각 요소들을 xml 최상위부모 밑으로 넣음
            xmlSetting.AppendChild(el_Target_Count);
            xmlSetting.AppendChild(el_Info_DBConnection);
            xmlSetting.AppendChild(el_StartViewIndex);

            XmlElement el_JobOrder_SlideShow_Time = doc.CreateElement("JobOrder_SlideShow_Time");
            el_JobOrder_SlideShow_Time.InnerText = JobOrder_SlideShow_Time.ToString();
            xmlSetting.AppendChild(el_JobOrder_SlideShow_Time);

            // 작업지시서 파일 리스트
            for (int i = 0; i < 100; i++)
            {
                XmlElement el_JobOrder_File = doc.CreateElement("JobOrder_File" + (i + 1).ToString());
                el_JobOrder_File.InnerText = JobOrder_File[i];
                xmlSetting.AppendChild(el_JobOrder_File);
            }

            // 최상위 헤더를 문서에 넣음
            doc.AppendChild(xmlSetting);

            // 저장
            doc.Save(SettingPath + "Setting.sys");
        }
        public void Setting_Load_Xml(string SettingPath)
        {
            Setting_Init();

            if (System.IO.File.Exists(SettingPath + "Setting.sys") == false)
            {
                MessageBox.Show("저장된 파일이 없습니다. 기본 설정이 적용됩니다.");
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(SettingPath+"Setting.sys");

            // Daily
            XmlNode node_Target_Count = doc.SelectSingleNode("//Setting/Target_Count");
            XmlNode node_Info_DBConnection = doc.SelectSingleNode("//Setting/Info_DBConnection");
            XmlNode node_StartViewIndex = doc.SelectSingleNode("//Setting/StartViewIndex");

            if (node_Target_Count != null)
            {
                Target_Count = Convert.ToInt32(node_Target_Count.InnerText);
            }
            if (node_Info_DBConnection != null)
            {
                Info_DBConnection = node_Info_DBConnection.InnerText;
            }
            if (node_StartViewIndex != null)
            {
                StartViewIndex = Convert.ToInt32(node_StartViewIndex.InnerText);
            }

            XmlNode node_JobOrder_SlideShow_Time = doc.SelectSingleNode("//Setting/JobOrder_SlideShow_Time");
            if (node_JobOrder_SlideShow_Time != null) JobOrder_SlideShow_Time = Convert.ToInt32(node_JobOrder_SlideShow_Time.InnerText);

            // 작업지시서 파일 리스트
            for (int i = 0; i < 100; i++)
            {
                XmlNode node_JobOrder_File = doc.SelectSingleNode("//Setting/JobOrder_File" + (i + 1).ToString());
                if (node_JobOrder_File != null)
                {
                    JobOrder_File[i] = node_JobOrder_File.InnerText;
                }
            }
        }
    }
}
