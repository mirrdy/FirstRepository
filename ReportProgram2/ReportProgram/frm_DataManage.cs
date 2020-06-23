using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ReportProgram
{
    public partial class frm_DataManage : Form
    {
        private xml_Setting mySetting = new xml_Setting();
        string Constring = "dsn=MariaDB";
        public frm_DataManage()
        {
            InitializeComponent();
            addComboBox(Constring);
        }

        private void addComboBox(string ConnectionString)
        {
            string querystring = "select * from model order by name asc";
            OdbcCommand command = new OdbcCommand(querystring);

            using (OdbcConnection connection = new OdbcConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    cbx_SelModel.Items.Add(dr["name"]);
                }
            }
            //MessageBox.Show(selectModelCB.Items[3].ToString());
        }
        private void modifyData(string ConnectionString, string serialNum)
        {
            string querystring = "select * from model order by name asc";
            OdbcCommand command = new OdbcCommand(querystring);

            using (OdbcConnection connection = new OdbcConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while(dr.Read())
                {
                    cbx_SelModel.Items.Add(dr["name"]);
                }
            }
        }

        private void btn_ConfirmSelect_Click(object sender, EventArgs e)
        {
            string connectionString = "dsn=MariaDB";
            string queryString = "select * from Test_Data where ";
            string dateFormat = "yyyy-MM-dd";

            string start_Date = dtp_StartDate.Value.ToString(dateFormat);
            string end_Date = dtp_EndDate.Value.AddDays(1).ToString(dateFormat);

            //queryString += "Start_time >= " + start_Date + " and Start_time < " + end_Date;
            queryString += "Start_time >= '" + start_Date + "' and Start_time < '" + end_Date + "'";
            
            if (rdb_NoSel.Checked)
            {
                
            }
            else if(rdb_SelOk.Checked)
            {
                queryString += "and Total_result='양품'";
            }
            else
            {
                queryString += "and Total_result='불량'";
            }

            if(cbx_SelModel.Text != "")
                queryString += "and model_name='" + cbx_SelModel.Text+"'";

            queryString += "order by Start_time asc";

            OdbcCommand command = new OdbcCommand(queryString);

            create_Dgv(connectionString, cbx_SelModel.Text);
            selectedDataView.Rows.Clear();
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    string[] row = {dr["Model_name"].ToString(), dr["Test_user"].ToString(), dr["Start_time"].ToString(), dr["End_time"].ToString(),
                    dr["Serial_number"].ToString(), dr["Barcode"].ToString(), dr["Total_result"].ToString()};
                    //

                    selectedDataView.Rows.Add(row);
                }
            }
        }

        private void create_Dgv(string ConnectionString, string model_name)
        {
            string queryString = "Select * from model";
            List<string> parsingData = new List<string>();

            if (model_name != "")
                queryString += " where name='" + model_name + "'";

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while(dr.Read())
                {
                    string[] dataHeader = dr["data_header"].ToString().Split(';');
                    
                    for (int i = 0; i < dataHeader.Length; i++)
                    {
                        if (parsingData.Contains(dataHeader[i]))
                            continue;
                        else if (dataHeader[i].Equals(""))
                            break;
                        else
                            parsingData.Add(dataHeader[i]);
                    }
                }
                foreach(string parsingStr in parsingData)
                {
                    selectedDataView.Columns.Add(parsingStr, parsingStr);
                    
                }
            }
            
        }

        private void btn_ConfirmModify_Click(object sender, EventArgs e)
        {
            string serialNum = txtbox_InputSerialNum.Text;
            modifyData(Constring, serialNum);
        }
    }
}
