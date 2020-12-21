﻿//using Excel = Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Org.BouncyCastle.Bcpg;
using System.Collections.Concurrent;
//using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Diagnostics;
using NPOI.SS.Formula.Functions;
using System.Drawing;

namespace ReportProgram
{
    public partial class frm_DataManage : Form
    {
        frm_SelectData frmSelectData = new frm_SelectData();
        frm_ModifyData frmModifyData = new frm_ModifyData();
        private ConvertFunc myConvert = new ConvertFunc();
        private xml_Setting mySetting = new xml_Setting(); 

        public frm_DataManage()
        {
            InitializeComponent();
            loadMySetting();
            frmSelectData.sendData += new frm_SelectData.sendSelectedDataDelegate(display_SelectedData);           
        }

        private void loadMySetting()
        {
            selectedDataView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10, FontStyle.Bold);
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);
        }

        private void display_SelectedData(string queryString, string selModel)
        {
            string tmpDSN = "dsn=" + mySetting.Info_DBConnection;
            OdbcCommand command = new OdbcCommand(queryString);

            selectedDataView.Columns.Clear();
            selectedDataView.Rows.Clear();
            create_SelectedDgv(tmpDSN, selModel);
            using (OdbcConnection connection = new OdbcConnection(tmpDSN))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();
                int tmpCount = 1;
                while (dr.Read())
                {
                    List<string> readRow = new List<string>();

                    readRow.Add(tmpCount++.ToString());
                    readRow.Add(dr["Model_name"].ToString());
                    readRow.Add(dr["Test_user"].ToString());
                    readRow.Add(dr["Start_time"].ToString());
                    readRow.Add(dr["End_time"].ToString());
                    //readRow.Add(dr["Serial_number"].ToString());
                    readRow.Add(dr["Barcode"].ToString());
                    readRow.Add(dr["Total_result"].ToString());

                    if (selModel == "")
                    {
                        readRow.Add(dr["Test_Data"].ToString());
                    }
                    else
                    {
                        List<string> parsedStrings = new List<string>();
                        parsedStrings.AddRange(dr["Test_Data"].ToString().Split(';'));

                        foreach (string parsedStr in parsedStrings)
                        {
                            if (parsedStr.Equals(""))
                                readRow.Add("-");
                            else
                                readRow.Add(parsedStr);
                        }
                    }
                    selectedDataView.Rows.Add(readRow.ToArray());
                    if (readRow[6].Equals("양품")) selectedDataView[6, selectedDataView.Rows.Count - 1].Style.BackColor = Color.Lime;
                    //else if (readRow[6].Equals("불량")) selectedDataView[6, selectedDataView.Rows.Count - 1].Style.BackColor = Color.Red;
                }
            }
            selectedDataView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10, FontStyle.Bold);


            // 행번호 붙이기
            int rowNumber = 1;
            foreach(DataGridViewRow row in selectedDataView.Rows)
            {
                if (row.IsNewRow)
                    continue;
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber = rowNumber + 1;
            }
            /*selectedDataView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            selectedDataView.AutoResizeColumns();
            selectedDataView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);*/
        }

        private void create_SelectedDgv(string ConnectionString, string model_name)
        {
            selectedDataView.Columns.Add("Number", "번호");
            selectedDataView.Columns.Add("Model", "모델");
            selectedDataView.Columns.Add("Tester", "작업자");
            selectedDataView.Columns.Add("Start_time", "작업날짜"); // 은성 임시 수정
            selectedDataView.Columns.Add("End_time", "시작시각"); //은성 임시 수정
            //selectedDataView.Columns.Add("Serial_number", "시리얼 번호"); // ETT28 기준 바코드에 LOT정보가 있어서 시리얼과 중복됨
            selectedDataView.Columns.Add("Barcode", "바코드");
            selectedDataView.Columns.Add("Total_result", "최종결과");

            selectedDataView.Columns[0].Width = 50;
            selectedDataView.Columns[1].Width = 160;
            selectedDataView.Columns[2].Width = 60;
            selectedDataView.Columns[3].Width = 80;
            selectedDataView.Columns[4].Width = 75;
            selectedDataView.Columns[5].Width = 100;
            selectedDataView.Columns[6].Width = 70;
            //selectedDataView.Columns[7].Width = 70;

            selectedDataView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                    selectedDataView.Columns.Add(parsingStr, parsingStr);
                    selectedDataView.Columns[selectedDataView.Columns.Count - 1].Width = 70;
                    selectedDataView.Columns[selectedDataView.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            // 열 너비 맞춤
            selectedDataView.Columns[7].Width = 50;
            selectedDataView.Columns[8].Width = 50;
            selectedDataView.Columns[13].Width = 90;
            selectedDataView.ColumnHeadersHeight = 40;

            // 특정 열 가운데정렬
            selectedDataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            selectedDataView.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //selectedDataView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        

        private void btn_ExportToExcel_Click(object sender, EventArgs e)
        {
            sdlg_Excel.Filter = "Excel (*.xls) | *.xls";

            if (sdlg_Excel.ShowDialog() == DialogResult.OK)
            {
                SaveExcelFile(sdlg_Excel.FileName);
            }
        }

        private void SaveExcelFile(string FilePath)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("DataFromReportProgram");

            // dgv에서 column 참조해서 나중에 재설정할것
            var columns = new[] { "ID", "Name" };
            var headers = new[] { "ID", "Name" };

            var headerRow = sheet.CreateRow(0);

            var font = workbook.CreateFont();

            var headerFont = workbook.CreateFont();
            headerFont.FontHeightInPoints = 11;
            headerFont.FontName = "맑은 고딕";
            headerFont.IsBold = true;
            headerFont.Color = IndexedColors.White.Index;

            var dataFont = workbook.CreateFont();
            dataFont.FontHeightInPoints = 11;
            dataFont.FontName = "맑은 고딕";
            dataFont.IsBold = false;
            dataFont.Color = IndexedColors.Black.Index;

            ICellStyle HeaderStyle = workbook.CreateCellStyle();
            HeaderStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Double;
            HeaderStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            HeaderStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            HeaderStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            HeaderStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            HeaderStyle.FillForegroundColor = IndexedColors.DarkBlue.Index;
            HeaderStyle.FillPattern = FillPattern.SolidForeground;
            HeaderStyle.SetFont(headerFont);

            ICellStyle DefaultStyle_Odd = workbook.CreateCellStyle();
            DefaultStyle_Odd.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Odd.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Odd.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Odd.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Odd.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            DefaultStyle_Odd.FillForegroundColor = IndexedColors.White.Index;
            DefaultStyle_Odd.FillPattern = FillPattern.SolidForeground;
            DefaultStyle_Odd.SetFont(dataFont);

            ICellStyle DefaultStyle_Even = workbook.CreateCellStyle();
            DefaultStyle_Even.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Even.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Even.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Even.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle_Even.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            DefaultStyle_Even.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            DefaultStyle_Even.FillPattern = FillPattern.SolidForeground;
            DefaultStyle_Even.SetFont(dataFont);


            /*
            ICellStyle cellStyle1 = workbook.CreateCellStyle();
            cellStyle1.FillForegroundColor = IndexedColors.White.Index;
            cellStyle1.FillPattern = FillPattern.SolidForeground;
            cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle1.SetFont(dataFont);

            ICellStyle cellStyle2 = workbook.CreateCellStyle();
            cellStyle2.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cellStyle2.FillPattern = FillPattern.SolidForeground;
            cellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle2.SetFont(dataFont);
            */

            //Below loop is create header  
            for (int i = 0; i < selectedDataView.ColumnCount; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(selectedDataView.Columns[i].HeaderText);
                cell.CellStyle = HeaderStyle;
            }

            //Below loop is fill content  
            for (int i = 0; i < selectedDataView.RowCount; i++)
            {
                var row = sheet.CreateRow(i + 1);

                for (int j = 0; j < selectedDataView.ColumnCount; j++)
                {
                    var cell = row.CreateCell(j);
                    cell.SetCellValue(selectedDataView.Rows[i].Cells[j].Value.ToString());
                    if (i % 2 == 0)
                        cell.CellStyle = DefaultStyle_Even;
                    else
                        cell.CellStyle = DefaultStyle_Odd;
                }
            }

            // 셀 크기 조정
            for (int i = 0; i < selectedDataView.ColumnCount; i++)
            {
                // 너비 자동조정
                sheet.AutoSizeColumn(i);
                // 자동 조정하면 너무 빡빡해서 여백을 약간 줌
                sheet.SetColumnWidth(i, sheet.GetColumnWidth(i) + 512);
            }
            // 셀 높이 조정 (기본 Height 255)
            /*for(int i=0; i<dgv.RowCount; i++)
            {
                sheet.GetRow(i).Height = 300;
            }*/

            // Declare one MemoryStream variable for write file in stream  
            var stream = new MemoryStream();
            workbook.Write(stream);

            //Write to file using file stream  
            FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            stream.WriteTo(file);
            file.Close();
            stream.Close();

            stopwatch.Stop();

            MessageBox.Show("time : " + stopwatch.ElapsedMilliseconds + "ms");
            #region 어플리케이션에 셀 하나씩 직접 대입
            /* string filePath = "D:\\SavedExcelFolder\\"+string.Format("Test {0}.xls", DateTime.Now.ToString("yyyy-MM-dd"));

             Excel._Application app = new Excel.Application();
             Excel.Workbook workbook;
             Excel.Worksheet worksheet;

             workbook = app.Workbooks.Add(Type.Missing);

             app.Visible = false;

             worksheet = workbook.Sheets["Sheet1"];
             worksheet = workbook.ActiveSheet;

             worksheet.Name = sheetName;
             int colIndex = 0;

             //// storing header part in Excel   
             //for (int i = 1; i < dgv.Columns.Count + 1; i++)  
             //{  
             //    if (dgv.Columns[i - 1].Visible == true)  
             //    {  
             //        colIndex += 1;  
             //        worksheet.Cells[1, colIndex] = dgv.Columns[i - 1].HeaderText;  
             //    }               
             //}  
             //// storing Each row and column value to excel sheet  
             //for (int i = 0; i < dgv.Rows.Count - 1; i++)  
             //{  
             //    colIndex = 0;  
             //    for (int j = 0; j < dgv.Columns.Count; j++)  
             //    {  
             //        if (dgv.Columns[j].Visible == true)  
             //        {  
             //            colIndex += 1;  
             //            worksheet.Cells[i + 2, colIndex] = dgv.Rows[i].Cells[j].Value == null ? "" : dgv.Rows[i].Cells[j].Value.ToString() ?? "";  
             //        }  
             //    }  
             //}  

             // storing header part in Excel   
             for (int i = 0; i < dgv.ColumnCount; i++)
             {
                 if (dgv.Columns[i].Visible == true)
                 {
                     colIndex += 1;
                     worksheet.Cells[1, colIndex] = dgv.Columns[i].HeaderText;
                 }
             }
             // storing Each row and column value to excel sheet
             for (int i = 0; i < dgv.Rows.Count; i++)
             {
                 colIndex = 0;
                 for (int j = 0; j < dgv.ColumnCount; j++)
                 {
                     if (dgv.Columns[j].Visible == true)
                     {
                         colIndex += 1;
                         worksheet.Cells[i + 2, colIndex] = dgv.Rows[i].Cells[j].Value == null ? "" : dgv.Rows[i].Cells[j].Value.ToString() ?? "";


                     }
                 }
             }

             Excel.Range usedRange;
             usedRange = worksheet.UsedRange;

             Excel.Range rangeStart = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[usedRange.Row, usedRange.Column];
             Excel.Range rangeEnd = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[usedRange.Row + usedRange.Rows.Count, usedRange.Column + usedRange.Columns.Count];

             string usedStartPos = rangeStart.Address;
             string usedEndPos = rangeEnd.Address;

             //// BackColor 설정  
             //((Excel.Range)excelWorksheet.get_Range("A1", "J1")).Interior.Color = ColorTranslator.ToOle(Color.Navy);  
             //((Excel.Range)excelWodrksheet.get_Range("A2", "J2")).Interior.Color = ColorTranslator.ToOle(Color.RoyalBlue);  

             //// Font Color 설정  
             //((Excel.Range)excelWorksheet.get_Range("A1", "J1")).Font.Color = ColorTranslator.ToOle(Color.White);  
             //((Excel.Range)excelWorksheet.get_Range("A2", "J2")).Font.Color = ColorTranslator.ToOle(Color.White);  

             // 상단 첫번째 Row 타이틀 볼드
             SetHeaderBold(worksheet, 1);

             // 자동 넓이 지정  
             for (int i = 0; i < usedRange.Columns.Count; i++)
             {
                 AutoFitColumn(worksheet, i+1);
             }

             // 타이틀 색상  
             for (int i = 0; i < usedRange.Columns.Count; i++)
             {
                 //worksheet.Cells[1, i+1].Interior.Color = Excel.XlRgbColor.rgbGrey;
                 worksheet.Cells[1, i + 1].Interior.ColorIndex = 16;
             }
             // 행마다 배경색 번갈아가면서 넣기
             for (int i= 1; i< usedRange.Rows.Count; i++)
             {
                 *//*if (i % 2 == 0)
                     worksheet.Cells.Rows[i + 1].Interior.ColorIndex = 15;
                 else
                     worksheet.Cells.Rows[i + 1].Interior.ColorIndex = 0;*//*
                 for (int j = 1; j < usedRange.Columns.Count; j++)
                 {
                     if (i % 2 == 0)
                         worksheet.Cells[i + 1, j].Interior.ColorIndex = 15;
                     else
                         worksheet.Cells[i + 1, j].Interior.ColorIndex = 0;
                 }


             }

             // 선그리기  
             usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
             usedRange.Borders.ColorIndex = 1;

             // 정렬  
             usedRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
             workbook.SaveAs(filePath, XlFileFormat.xlWorkbookNormal);
             workbook.Close();
             app.Quit();*/
            #endregion

            #region 엑셀에 차트 넣기
            /*//차트화할 셀의영역  
            Excel.Range chartArea = worksheet.get_Range("A1", "B30");

            //차트생성  
            Excel.ChartObjects chart = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);

            //차트위치  
            Excel.ChartObject mychart = (Excel.ChartObject)chart.Add(100, 40, 800, 400);

            //차트 할당  
            Excel.Chart chartPage = mychart.Chart;

            //차트의 데이터 셋팅  
            chartPage.SetSourceData(chartArea, Excel.XlRowCol.xlColumns);

            //차트의 형태  
            //chartPage.ChartType = Excel.XlChartType.xlCylinderColClustered;  
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            app.DisplayAlerts = false;

            // 작업관리자 프로세스 해제  
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);*/
            #endregion
        }

        /*
        //Here is how to set the column Width
        public void SetHeaderBold(Excel.Worksheet worksheet, int row)
        {
            ((Excel.Range)worksheet.Cells[row, 1]).EntireRow.Font.Bold = true;
        }

        //Here is how to set the column Width  
        public void SetColumnWidth(Excel.Worksheet worksheet, int col, int width)
        {
            ((Excel.Range)worksheet.Cells[1, col]).EntireColumn.ColumnWidth = width;
        }

        // Apply the setting so that it would autofit to contents  
        public void AutoFitColumn(Excel.Worksheet worksheet, int col)
        {
            ((Excel.Range)worksheet.Cells[1, col]).EntireColumn.AutoFit();
        }

        private IWorkbook CreateWorkbook(string version)
        {
            if ("xls".Equals(version))
                return new HSSFWorkbook();
            else if ("xlsx".Equals(version))
                return new XSSFWorkbook();
            throw new NotSupportedException();
        }
        */
        private IRow GetRow(ISheet sheet, int rownum)
        {
            var row = sheet.GetRow(rownum);
            if(row==null)
            {
                row = sheet.CreateRow(rownum);
            }
            return row;
        }

        private ICell GetCell(IRow row, int cellnum)        {
            var cell = row.GetCell(cellnum);
            if(cell==null)
            {
                cell = row.CreateCell(cellnum);
            }
            return cell;
        }
        private ICell GetCell(ISheet sheet, int rownum, int cellnum)
        {
            var row = GetRow(sheet, rownum);
            return GetCell(row, cellnum);
        }
        private void WriteExcel(IWorkbook workbook, string filepath)
        {
            using (var file = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
            }
        }

        private void btn_SelectData_Click(object sender, EventArgs e)
        {
            frmSelectData.ShowDialog();
        }

        private void btn_DeleteData_Click(object sender, EventArgs e)
        {
            frmModifyData.ShowDialog();
        }
    }
}
