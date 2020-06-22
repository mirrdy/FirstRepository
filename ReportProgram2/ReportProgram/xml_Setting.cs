using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace ReportProgram
{
    class xml_Setting
    {
        public int Target_Count;

        public xml_Setting()
        {
            Setting_Init();
        }
        public void Setting_Init()
        {
            Target_Count = 0;
        }
        public void SettingSaveXml(string SettingPath)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlSetting = doc.CreateElement("Setting");

            // Daily
            XmlElement el_Target_Count = doc.CreateElement("Target_Count");
            el_Target_Count.InnerText = Target_Count.ToString();
            xmlSetting.AppendChild(el_Target_Count);

            doc.AppendChild(xmlSetting);
            doc.Save(SettingPath);
        }
        public void Setting_Load_Xml(string SettingPath)
        {
            Setting_Init();

            if (System.IO.File.Exists(SettingPath) == false) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(SettingPath);

            // Daily
            XmlNode node_Target_Count = doc.SelectSingleNode("//Setting/Target_Count");
            if(node_Target_Count != null)
            {
                Target_Count = Convert.ToInt32(node_Target_Count.InnerText);
            }
        }
        public void OpenModelPath_Save_Xml(string LastModelPath)
        {
            
        }
    }
}
