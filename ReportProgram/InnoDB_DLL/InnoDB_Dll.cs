/*******************************************************************************
 * 
 * 테이블 네임 : model, test_data
 * 
 * ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Odbc;

namespace InnoDB_DLL
{
    public class InnoDB
    {
        public enum ErrorCode
        {
            Suecces = 0,
            ER_Con = 1,
            ER_Add_Model = 2,
            ER_Add_TestData = 3,
            ER_Delete_Model = 4,
            ER_Delete_TestData = 5,
            ER_NOT_FIND_MODEL_TABLE = 6,
            ER_NOT_FIND_TESTDATA_TABLE = 7,
            ER_Ect = 9999
        }

        private string DSN_Name = "";
        private string TableName_Model = "model";
        private string TableName_TestData = "test_data";
        private string ErrorMessage = "";

        public InnoDB()
        {
        }

        public ErrorCode Open_DB(string Name)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            DSN_Name = "dsn=" + Name;

            List<string> TableList = new List<string>();
            string queryString = "show tables";
            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        TableList.Add(dr[0].ToString());
                    }
                }

                R_Code = ErrorCode.Suecces;
                int tmpindex = TableList.FindIndex(x => x.CompareTo(TableName_Model) == 0);
                if (tmpindex == -1) R_Code = ErrorCode.ER_NOT_FIND_MODEL_TABLE;
                tmpindex = TableList.FindIndex(x => x.CompareTo(TableName_TestData) == 0);
                if (tmpindex == -1) R_Code = ErrorCode.ER_NOT_FIND_TESTDATA_TABLE;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return R_Code;
        }

        public void Close_DB()
        {
            DSN_Name = "";
        }

        public string Get_ErrorMessage()
        {
            return ErrorMessage;
        }

        public ErrorCode Add_Model(string Model_Name, DateTime Update_Date, string Update_User, string Data_Header)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            string tmpCreateDate = Update_Date.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpValue = string.Format("'{0}','{1}','{2}','{3}'", Model_Name, tmpCreateDate, Update_User, Data_Header);
            string queryString = "INSERT INTO " + TableName_Model + " (name, update_date, update_user, data_header) Values(" + tmpValue + ")";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Add_Model;
            }

            return R_Code;
        }

        public ErrorCode Delete_Model(string Model_Name)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            string queryString = "DELETE FROM "+ TableName_Model + " WHERE name='" + Model_Name + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_Model;
            }

            return R_Code;
        }


        public List<string> Get_ModelList()
        {
            List<string> ModelList = new List<string>();

            string queryString = "select * from " + TableName_Model + " order by name asc";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        ModelList.Add(dr["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return ModelList;
        }

        public ErrorCode Add_TestData(string Model_Name, string Test_User, DateTime Start_Time, DateTime End_Time, string Serial_Number, string BarcodeData, string Total_Result, string Test_Data)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            string tmpStartTime = Start_Time.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpEndTime = End_Time.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'", Model_Name, Test_User, tmpStartTime, tmpEndTime, Serial_Number, BarcodeData, Total_Result, Test_Data);
            string queryString = "INSERT INTO " + TableName_TestData + " (model_name, test_user, start_time, end_time, serial_number, barcode, total_result, test_Data) Values(" + tmpValue + ")";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Add_TestData;
            }

            return R_Code;
        }

        public ErrorCode Delete_TestData_by_model_name(string Model_Name)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            string queryString = "DELETE FROM " + TableName_TestData + " where model_name='" + Model_Name + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_TestData;
            }

            return R_Code;
        }

        public ErrorCode Delete_TestData_by_barcode(string Barcode)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            string queryString = "DELETE FROM " + TableName_TestData + " where barcode='" + Barcode + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_TestData;
            }

            return R_Code;
        }

        public ErrorCode Delete_TestData_by_serial_number(string SerialNumber)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            string queryString = "DELETE FROM " + TableName_TestData + " where serial_number='" + SerialNumber + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_TestData;
            }

            return R_Code;
        }
    }
}
