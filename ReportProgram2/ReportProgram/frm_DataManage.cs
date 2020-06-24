using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private string conString = "dsn=MariaDB";
        public frm_DataManage()
        {
            InitializeComponent();
            addComboBox(conString);
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
            }
        }

        private void btn_ConfirmSelect_Click(object sender, EventArgs e)
        {
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

            selectedDataView.Columns.Clear();
            selectedDataView.Rows.Clear();
            create_SelectedDgv(conString, cbx_SelModel.Text);
            using (OdbcConnection connection = new OdbcConnection(conString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    List<string> readRow = new List<string>();

                    readRow.Add(dr["Model_name"].ToString());
                    readRow.Add(dr["Test_user"].ToString());
                    readRow.Add(dr["Start_time"].ToString());
                    readRow.Add(dr["End_time"].ToString());
                    readRow.Add(dr["Serial_number"].ToString());
                    readRow.Add(dr["Barcode"].ToString());
                    readRow.Add(dr["Total_result"].ToString());

                    if (cbx_SelModel.Text == "")
                    {
                        readRow.Add(dr["Test_Data"].ToString());
                    }
                    else
                    {
                        List<string> parsedStrings = new List<string>();
                        parsedStrings.AddRange(dr["Test_Data"].ToString().Split(';'));
                        parsedStrings.Remove("");

                        foreach (string parsedStr in parsedStrings)
                            readRow.Add(parsedStr);
                    }
                        selectedDataView.Rows.Add(readRow.ToArray());
                }
            }

            // 행번호 붙이기
            int rowNumber = 1;
            foreach(DataGridViewRow row in selectedDataView.Rows)
            {
                if (row.IsNewRow)
                    continue;
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber = rowNumber + 1;
            }
            selectedDataView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void create_SelectedDgv(string ConnectionString, string model_name)
        {
            selectedDataView.Columns.Add("Model", "Model");
            selectedDataView.Columns.Add("Tester", "Tester");
            selectedDataView.Columns.Add("Start_time", "Start_time");
            selectedDataView.Columns.Add("End_time", "End_time");
            selectedDataView.Columns.Add("Serial_number", "Serial_number");
            selectedDataView.Columns.Add("Barcode", "Barcode");
            selectedDataView.Columns.Add("Total_result", "Total_result");

            string queryString = "Select * from model";
            List<string> parsingData = new List<string>();

            if (model_name == "")
            {
                selectedDataView.Columns.Add("Test_Data", "Test_Data");
                return;
            }
            else if (model_name != "")
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

        private void create_SearchedDgv(string ConnectionString, string identify_Num)
        {
            searchedDataView.Columns.Add("Model", "Model");
            searchedDataView.Columns.Add("Tester", "Tester");
            searchedDataView.Columns.Add("Start_time", "Start_time");
            searchedDataView.Columns.Add("End_time", "End_time");
            searchedDataView.Columns.Add("Serial_number", "Serial_number");
            searchedDataView.Columns.Add("Barcode", "Barcode");
            searchedDataView.Columns.Add("Total_result", "Total_result");

            string queryString = "Select * from Test_Data";
            string model_Name="";
            List<string> parsingData = new List<string>();

            if (identify_Num != "")
                queryString += " where Serial_number='" + identify_Num + "' or Barcode='" + identify_Num + "'";

            OdbcCommand command = new OdbcCommand(queryString);

            using(OdbcConnection connection = new OdbcConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while(dr.Read())
                {
                    model_Name = dr["Model_name"].ToString();
                    break;
                }
            }

            if (identify_Num != "" && !model_Name.Equals(""))
                queryString = "Select * from model where name='" + model_Name+"'";
            else
            {
                MessageBox.Show("wrong query");
                return;
            }
            command.CommandText = queryString;

            using (OdbcConnection connection = new OdbcConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
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
                foreach (string parsingStr in parsingData)
                {
                    searchedDataView.Columns.Add(parsingStr, parsingStr);
                }
            }
        }

        private void btn_SearchData_Click(object sender, EventArgs e)
        {
            string queryString = "select * from Test_Data where ";
            string identify_Num="";

            // Enumerable.Any() => 요소가 있으면 true, 없으면 false
            if (!txtbox_InputSerialNum.Text.Any() && !txtbox_InputBarcode.Text.Any())
            {
                MessageBox.Show("시리얼 넘버나 바코드를 입력하세요.");
                return;
            }
            else if (txtbox_InputSerialNum.Text.Any() && txtbox_InputBarcode.Text.Any())
            {
                MessageBox.Show("하나만 입력하세요(임시)");
                return;
            }
            else if (txtbox_InputSerialNum.Text.Any())
            {
                queryString += "Serial_number='" + txtbox_InputSerialNum.Text+"'";
                identify_Num = txtbox_InputSerialNum.Text;
            }
            else if (txtbox_InputBarcode.Text.Any())
            {
                queryString += "Barcode='" + txtbox_InputBarcode.Text + "'";
                identify_Num = txtbox_InputBarcode.Text;
            }
            
            string serialNum = txtbox_InputSerialNum.Text;
            searchedDataView.Columns.Clear();
            create_SearchedDgv(conString, identify_Num);

            OdbcCommand command = new OdbcCommand(queryString);
            
            using (OdbcConnection connection = new OdbcConnection(conString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    string[] row = {dr["Model_name"].ToString(), dr["Test_user"].ToString(), dr["Start_time"].ToString(), dr["End_time"].ToString(),
                    dr["Serial_number"].ToString(), dr["Barcode"].ToString(), dr["Total_result"].ToString()};

                    List<string> readRow = row.ToList();

                    List<string> parsedStrings = new List<string>();
                    parsedStrings.AddRange(dr["Test_Data"].ToString().Split(';'));
                    parsedStrings.Remove("");

                    foreach (string parsedStr in parsedStrings)
                        readRow.Add(parsedStr);

                    //Rows.Add() 인자 배열을 넣어야 원하는 결과가 나옴. 리스트 넣으면 값이 안들어감
                    searchedDataView.Rows.Add(readRow.ToArray());

                    modifyData(conString, dr["Model_name"].ToString());
                }
            }
            int rowNumber = 1;
            foreach (DataGridViewRow row in searchedDataView.Rows)
            {
                if (row.IsNewRow)
                    continue;
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber = rowNumber + 1;
            }
            searchedDataView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void btn_ImportToExcel_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_ExportToExcel_Click(object sender, EventArgs e)
        {

        }

        private void btn_DeleteData_Click(object sender, EventArgs e)
        {
            string queryString = "delete from Test_Data where ";
            string identify_Num = "";

            if (!txtbox_InputSerialNum.Text.Any() && !txtbox_InputBarcode.Text.Any())
            {
                MessageBox.Show("시리얼 넘버나 바코드를 입력하세요.");
                return;
            }
            else if (txtbox_InputSerialNum.Text.Any() && txtbox_InputBarcode.Text.Any())
            {
                MessageBox.Show("하나만 입력하세요(임시)");
                return;
            }
            else if (txtbox_InputSerialNum.Text.Any())
            {
                identify_Num = txtbox_InputSerialNum.Text;
                queryString += "Serial_number='" + identify_Num + "'";
            }
            else if (txtbox_InputBarcode.Text.Any())
            {
                identify_Num = txtbox_InputBarcode.Text;
                queryString += "Barcode='" + identify_Num + "'";
            }
            MessageBox.Show("삭제됐습니다.");

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(conString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

                // The connection is automatically closed at
                // the end of the Using block.
            }
        }
    }
}
