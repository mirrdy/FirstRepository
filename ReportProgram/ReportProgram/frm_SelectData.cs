using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgram
{
    public partial class frm_SelectData : Form
    {
        private string conString = "";
        private xml_Setting mySetting = new xml_Setting();

        //부모폼에게 데이터를 전달하기위한 delegate 이벤트 선언
        public delegate void sendSelectedDataDelegate(string data, string selModel);
        public event sendSelectedDataDelegate sendData;

        public frm_SelectData()
        {
            InitializeComponent();
        }

        private void frm_SelectData_Load(object sender, EventArgs e)
        {
            loadMySetting();
            addComboBox(conString);
        }

        private void loadMySetting()
        {
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);

            conString = "dsn=" + mySetting.Info_DBConnection;
        }

        private void addComboBox(string ConnectionString)
        {
            string querystring = "select * from model order by name asc";
            OdbcCommand command = new OdbcCommand(querystring);

            cbx_SelModel.Items.Clear();
            using (OdbcConnection connection = new OdbcConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    cbx_SelModel.Items.Add(dr["name"]);
                }

                if (cbx_SelModel.Items.Count > 0) cbx_SelModel.SelectedIndex = 0;
            }
            //MessageBox.Show(selectModelCB.Items[3].ToString());
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
            else if (rdb_SelOk.Checked)
            {
                queryString += "and Total_result='양품'";
            }
            else
            {
                queryString += "and Total_result='불량'";
            }

            if (cbx_SelModel.Text != "")
                queryString += "and model_name='" + cbx_SelModel.Text + "'";

            queryString += "order by Start_time asc";

            this.sendData(queryString, cbx_SelModel.Text);
            Close();
        }

        private void btn_CancleSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
