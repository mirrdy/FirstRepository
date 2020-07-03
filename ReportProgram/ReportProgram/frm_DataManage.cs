// 엑셀 관련
using Excel = Microsoft.Office.Interop.Excel;
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
using Microsoft.Office.Interop.Excel;
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
            mySetting.Setting_Load_Xml(Const.SYSTEM_PATH);
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

                    if (selModel == "")
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
            selectedDataView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void create_SelectedDgv(string ConnectionString, string model_name)
        {
            selectedDataView.Columns.Add("Model", "모델");
            selectedDataView.Columns.Add("Tester", "작업자");
            selectedDataView.Columns.Add("Start_time", "시작시간");
            selectedDataView.Columns.Add("End_time", "종료시간");
            selectedDataView.Columns.Add("Serial_number", "시리얼 번호");
            selectedDataView.Columns.Add("Barcode", "바코드");
            selectedDataView.Columns.Add("Total_result", "최종 결과");

            selectedDataView.Columns[0].Width = 100;
            selectedDataView.Columns[1].Width = 80;
            selectedDataView.Columns[2].Width = 130;
            selectedDataView.Columns[3].Width = 130;
            selectedDataView.Columns[4].Width = 110;
            selectedDataView.Columns[5].Width = 100;
            selectedDataView.Columns[6].Width = 100;

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
                }
            }
        }
        

        private void btn_ExportToExcel_Click(object sender, EventArgs e)
        {
            string ExcelLogPath = "D:\\SavedExcelFolder\\"+DateTime.Now.ToString("yyyy-MM-dd HHmmss") + "_TestFile.xls";
            int Step = 5;
            SaveExcelFile(ExcelLogPath, Step);
        }

        private void SaveExcelFile(string FilePath, int Step)
        {
            
            SendDataToExcel(selectedDataView, "test_data");
            
            #region 엑셀 실패
            /* var version = "xls";
             // Workbook 생성
             var workbook = CreateWorkbook(version);
             HSSFWorkbook hssfwb;
             using (FileStream Read_File = new FileStream("D:\\SavedExcelFolder\\ReportSample.xls", FileMode.Open, FileAccess.Read))
             {
                 hssfwb = new HSSFWorkbook(Read_File);
             }
             ISheet sheet = hssfwb.GetSheet("색출 방법");
             // Workbook 안에 Sheet 생성

             // Sheet에서 Cell 가져오기
             var cell = GetCell(sheet, 0, 0);



             WriteExcel(workbook, "D:\\SavedExcelFolder\\test1." + version);*/
            #endregion
            #region 엑셀 참고용 코드;
            /*int[] FactorNGCount = {
             * 0, 0, 0 };
            bool[,] Factor_Freq_Result = new bool[selectedDataView.RowCount, selectedDataView.ColumnCount];
            Array.Clear(Factor_Freq_Result, 0, Factor_Freq_Result.Length);


            // 레포트 샘플 파일 읽어오기
            HSSFWorkbook hssfwb;
            using (FileStream Read_File = new FileStream("D:\\SavedExcelFolder\\ReportSample.xls", FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(Read_File);
            }
            ISheet sheet = hssfwb.GetSheet("색출 방법");

            // 그리드 Row 갯수만큼 엑셀 파일 Row를 생성
            int MaxCount = selectedDataView.RowCount - 1;
            for (int i = 0; i < MaxCount; i++)
            {
                sheet.CopyRow(2, i + 3);
                IRow tmpRow = sheet.GetRow(i + 3);
                tmpRow.HeightInPoints = sheet.GetRow(2).HeightInPoints;
            }
            
            ICellStyle NonActiveStyle = hssfwb.CreateCellStyle();
            NonActiveStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            NonActiveStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            NonActiveStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            NonActiveStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            NonActiveStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            NonActiveStyle.FillForegroundColor = IndexedColors.White.Index;
            NonActiveStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle ActiveStyle = hssfwb.CreateCellStyle();
            ActiveStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            ActiveStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            ActiveStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            ActiveStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            ActiveStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            ActiveStyle.FillForegroundColor = IndexedColors.SkyBlue.Index;
            ActiveStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle DefaultStyle = hssfwb.CreateCellStyle();
            DefaultStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            DefaultStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            DefaultStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            DefaultStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle TopLeftMediumStyle = hssfwb.CreateCellStyle();
            TopLeftMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            TopLeftMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            TopLeftMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            TopLeftMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            TopLeftMediumStyle.BottomBorderColor = IndexedColors.Black.Index;
            TopLeftMediumStyle.LeftBorderColor = IndexedColors.Red.Index;
            TopLeftMediumStyle.RightBorderColor = IndexedColors.Black.Index;
            TopLeftMediumStyle.TopBorderColor = IndexedColors.Red.Index;
            TopLeftMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            TopLeftMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            TopLeftMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle TopRightMediumStyle = hssfwb.CreateCellStyle();
            TopRightMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            TopRightMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            TopRightMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            TopRightMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            TopRightMediumStyle.BottomBorderColor = IndexedColors.Black.Index;
            TopRightMediumStyle.LeftBorderColor = IndexedColors.Black.Index;
            TopRightMediumStyle.RightBorderColor = IndexedColors.Red.Index;
            TopRightMediumStyle.TopBorderColor = IndexedColors.Red.Index;
            TopRightMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            TopRightMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            TopRightMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle BottomLeftMediumStyle = hssfwb.CreateCellStyle();
            BottomLeftMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            BottomLeftMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            BottomLeftMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            BottomLeftMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            BottomLeftMediumStyle.BottomBorderColor = IndexedColors.Red.Index;
            BottomLeftMediumStyle.LeftBorderColor = IndexedColors.Red.Index;
            BottomLeftMediumStyle.RightBorderColor = IndexedColors.Black.Index;
            BottomLeftMediumStyle.TopBorderColor = IndexedColors.Black.Index;
            BottomLeftMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            BottomLeftMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            BottomLeftMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle BottomRightMediumStyle = hssfwb.CreateCellStyle();
            BottomRightMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            BottomRightMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            BottomRightMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            BottomRightMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            BottomRightMediumStyle.BottomBorderColor = IndexedColors.Red.Index;
            BottomRightMediumStyle.LeftBorderColor = IndexedColors.Black.Index;
            BottomRightMediumStyle.RightBorderColor = IndexedColors.Red.Index;
            BottomRightMediumStyle.TopBorderColor = IndexedColors.Black.Index;
            BottomRightMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            BottomRightMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            BottomRightMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle TopMediumStyle = hssfwb.CreateCellStyle();
            TopMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            TopMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            TopMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            TopMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            TopMediumStyle.BottomBorderColor = IndexedColors.Black.Index;
            TopMediumStyle.LeftBorderColor = IndexedColors.Black.Index;
            TopMediumStyle.RightBorderColor = IndexedColors.Black.Index;
            TopMediumStyle.TopBorderColor = IndexedColors.Red.Index;
            TopMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            TopMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            TopMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle BottomMediumStyle = hssfwb.CreateCellStyle();
            BottomMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            BottomMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            BottomMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            BottomMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            BottomMediumStyle.BottomBorderColor = IndexedColors.Red.Index;
            BottomMediumStyle.LeftBorderColor = IndexedColors.Black.Index;
            BottomMediumStyle.RightBorderColor = IndexedColors.Black.Index;
            BottomMediumStyle.TopBorderColor = IndexedColors.Black.Index;
            BottomMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            BottomMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            BottomMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle LeftMediumStyle = hssfwb.CreateCellStyle();
            LeftMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            LeftMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            LeftMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            LeftMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            LeftMediumStyle.BottomBorderColor = IndexedColors.Black.Index;
            LeftMediumStyle.LeftBorderColor = IndexedColors.Red.Index;
            LeftMediumStyle.RightBorderColor = IndexedColors.Black.Index;
            LeftMediumStyle.TopBorderColor = IndexedColors.Black.Index;
            LeftMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            LeftMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            LeftMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle RightMediumStyle = hssfwb.CreateCellStyle();
            RightMediumStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            RightMediumStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            RightMediumStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            RightMediumStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            RightMediumStyle.BottomBorderColor = IndexedColors.Black.Index;
            RightMediumStyle.LeftBorderColor = IndexedColors.Black.Index;
            RightMediumStyle.RightBorderColor = IndexedColors.Red.Index;
            RightMediumStyle.TopBorderColor = IndexedColors.Black.Index;
            RightMediumStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            RightMediumStyle.FillForegroundColor = IndexedColors.LightOrange.Index;
            RightMediumStyle.FillPattern = FillPattern.SolidForeground;

            ICellStyle NGStyle = hssfwb.CreateCellStyle();
            NGStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            NGStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            NGStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            NGStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            NGStyle.BottomBorderColor = IndexedColors.Red.Index;
            NGStyle.LeftBorderColor = IndexedColors.Red.Index;
            NGStyle.RightBorderColor = IndexedColors.Red.Index;
            NGStyle.TopBorderColor = IndexedColors.Red.Index;
            NGStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            NGStyle.FillForegroundColor = IndexedColors.Red.Index;
            NGStyle.FillPattern = FillPattern.SolidForeground;

            // 데이터 넣기
            for (int i = 0; i < selectedDataView.RowCount; i++)
            {
                IRow tmpRow = sheet.GetRow(i + 2);
                for (int j = 0; j < selectedDataView.ColumnCount; j++)
                {
                    if (j == 0)
                    {
                        if ((i == selectedDataView.RowCount - 1) || (i == selectedDataView.RowCount - 2) || (i == selectedDataView.RowCount - 3) || (i == selectedDataView.RowCount - 4) || (i == selectedDataView.RowCount - 5))
                        {
                            tmpRow.Cells[j].SetCellValue(selectedDataView.Rows[i].HeaderCell.Value.ToString());
                        }
                        else
                        {
                            tmpRow.Cells[j].SetCellValue(myConvert.StrToFlotDef(selectedDataView.Rows[i].HeaderCell.Value.ToString(), 0));
                        }
                    }
                    else if (j < selectedDataView.ColumnCount-1)
                    {
                        tmpRow.Cells[j].SetCellValue(myConvert.StrToFlotDef(selectedDataView[j, i].Value.ToString(), 0));

                        // 검사 구간만 표시
                       *//* if ((myConvert.StrToFlotDef(selectedDataView.Rows[i].HeaderCell.Value.ToString(), 0) > TSpec.Motor_Start_Time[Step]) &&
                           (myConvert.StrToFlotDef(selectedDataView.Rows[i].HeaderCell.Value.ToString(), 0) <= TSpec.Motor_End_Time[Step]))
                        {
                            tmpRow.Cells[j].CellStyle = ActiveStyle;
                        }
                        else
                        {
                            tmpRow.Cells[j].CellStyle = NonActiveStyle;
                        }*//*
                    }
                    else
                    {
                        tmpRow.Cells[j].SetCellValue("");
                    }

                    if (i == selectedDataView.RowCount - 5)
                    {
                        if (j == 0) tmpRow.Cells[j].CellStyle = TopLeftMediumStyle;
                        else if (j == 37) tmpRow.Cells[j].CellStyle = TopRightMediumStyle;
                        else tmpRow.Cells[j].CellStyle = TopMediumStyle;
                    }
                    else if (i == selectedDataView.RowCount - 1)
                    {
                        if (j == 0) tmpRow.Cells[j].CellStyle = BottomLeftMediumStyle;
                        else if (j == 37) tmpRow.Cells[j].CellStyle = BottomRightMediumStyle;
                        else tmpRow.Cells[j].CellStyle = BottomMediumStyle;
                    }
                    else if ((i == selectedDataView.RowCount - 2) || (i == selectedDataView.RowCount - 3) || (i == selectedDataView.RowCount - 4))
                    {
                        if (j == 0) tmpRow.Cells[j].CellStyle = LeftMediumStyle;
                        else if (j == 37) tmpRow.Cells[j].CellStyle = RightMediumStyle;
                        else tmpRow.Cells[j].CellStyle = DefaultStyle;
                    }

                    // 불량 부분 표시
                    *//*if (j > 0 && j < 37)
                    {
                        if (i == selectedDataView.RowCount - 3)   // Sound Factor
                        {
                            if (Factor_Freq_Result[0, j] == false)
                            {
                                tmpRow.Cells[j].CellStyle = NGStyle;
                                FactorNGCount[0]++;
                            }
                        }
                        else if (i == selectedDataView.RowCount - 2)   // Crest Factor
                        {
                            if (Factor_Freq_Result[1, j] == false)
                            {
                                tmpRow.Cells[j].CellStyle = NGStyle;
                                FactorNGCount[1]++;
                            }
                        }
                        else if (i == selectedDataView.RowCount - 1)   // Modulation Factor
                        {
                            if (Factor_Freq_Result[2, j] == false)
                            {
                                tmpRow.Cells[j].CellStyle = NGStyle;
                                FactorNGCount[2]++;
                            }
                        }
                    }*//*
                    else if (j == 37)
                    {
                        if (i == selectedDataView.RowCount - 3)   // Sound Factor
                        {
                            tmpRow.Cells[j].SetCellValue("불량 : " + FactorNGCount[0].ToString());
                        }
                        else if (i == selectedDataView.RowCount - 2)   // Crest Factor
                        {
                            tmpRow.Cells[j].SetCellValue("불량 : " + FactorNGCount[1].ToString());
                        }
                        else if (i == selectedDataView.RowCount - 1)   // Modulation Factor
                        {
                            tmpRow.Cells[j].SetCellValue("불량 : " + FactorNGCount[2].ToString());
                        }
                    }
                }
            }

            // Declare one MemoryStream variable for write file in stream  
            var stream = new MemoryStream();
            hssfwb.Write(stream);

            //Write to file using file stream  
            FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            stream.WriteTo(file);
            file.Close();
            stream.Close();*/
            #endregion
        }

        public void SendDataToExcel(DataGridView dgv, string sheetName)
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

            var dataFont = workbook.CreateFont();
            dataFont.FontHeightInPoints = 11;


            ICellStyle cellStyle_Header = workbook.CreateCellStyle();
            cellStyle_Header.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            cellStyle_Header.FillForegroundColor = IndexedColors.BrightGreen.Index;
            cellStyle_Header.FillPattern = FillPattern.SolidForeground;
            cellStyle_Header.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle_Header.SetFont(headerFont);



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

            //Below loop is create header  
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(dgv.Columns[i].HeaderText);
                cell.CellStyle = cellStyle_Header;
            }

            //Below loop is fill content  
            for (int i = 0; i < dgv.RowCount; i++)
            {
                var row = sheet.CreateRow(i+1);

                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    var cell = row.CreateCell(j);
                    cell.SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());
                    if (i % 2 == 0)
                        cell.CellStyle = cellStyle1;
                    else
                        cell.CellStyle = cellStyle2;
                }
            }
            
            // 셀 크기 조정
            for(int i=0; i<dgv.ColumnCount; i++)
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

            string FilePath = @"D:\ABC.xls";

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
