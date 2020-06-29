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

        public xml_Setting()
        {
            Setting_Init();
        }
        public void Setting_Init()
        {
            Target_Count = 0;
            Info_DBConnection = "dsn=MariaDB";
        }
        public void Setting_Save_Xml(string SettingPath)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlSetting = doc.CreateElement("Setting");

            // 저장 경로에 폴더가 없으면 생성
            DirectoryInfo di = new DirectoryInfo(SettingPath);
            if (!di.Exists)
            {
                di.Create();
            }

            // xml 문서에 들어갈 요소 생성
            XmlElement el_Target_Count = doc.CreateElement("Target_Count");
            XmlElement el_Info_DBConnection = doc.CreateElement("Info_DBConnection");

            // 각각의 요소 내용으로 그에 맞는 객체 속성값을 넣음
            el_Target_Count.InnerText = Target_Count.ToString();
            el_Info_DBConnection.InnerText = Info_DBConnection;

            // 각각 요소들을 xml 최상위부모 밑으로 넣음
            xmlSetting.AppendChild(el_Target_Count);
            xmlSetting.AppendChild(el_Info_DBConnection);

            // 최상위 헤더를 문서에 넣음
            doc.AppendChild(xmlSetting);

            // 저장
            doc.Save(SettingPath+"Setting.sys");
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

            if(node_Target_Count != null)
            {
                Target_Count = Convert.ToInt32(node_Target_Count.InnerText);
            }
            if(node_Info_DBConnection != null)
            {
                Info_DBConnection = node_Info_DBConnection.InnerText;
            }
        }
        public void OpenModelPath_Save_Xml(string LastModelPath)
        {
            
        }
    }
}
