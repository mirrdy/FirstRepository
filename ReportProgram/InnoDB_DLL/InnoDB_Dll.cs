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
            ER_Ect = 9999
        }

        private string DSN_Name = "";
        private string ErrorMessage = "";

        public InnoDB()
        {
        }

        public ErrorCode Open_DB(string Name)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            DSN_Name = "dsn=" + Name;
            R_Code = ErrorCode.Suecces;

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

        public ErrorCode Add_TestData(string Model_Name, string Test_User, DateTime Start_Time, DateTime End_Time, string Serial_Number, string BarcodeData, string Total_Result, string Test_Data)
        {
            ErrorCode R_Code = ErrorCode.ER_Ect;

            string tmpStartTime = Start_Time.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpEndTime = End_Time.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'", Model_Name, Test_User, tmpStartTime, tmpEndTime, Serial_Number, BarcodeData, Total_Result, Test_Data);
            string queryString = "INSERT INTO Test_Data (Model_name, Test_user, Start_time, End_time, Serial_number, Barcode, Total_result, Test_Data) Values(" + tmpValue + ")";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Con;
            }

            return R_Code;
        }
    }
}
