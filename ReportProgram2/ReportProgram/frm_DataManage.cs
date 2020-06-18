using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgram
{
    public partial class frm_DataManage : Form
    {
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
                    comboBox1.Items.Add(dr["name"]);
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
                    comboBox1.Items.Add(dr["name"]);
                    
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = dateTimePicker1.Value.ToString("yyyyMMdd") + " ~ " + dateTimePicker2.Value.ToString("yyyyMMdd");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string serialNum = textBox1.Text;
            modifyData(Constring, serialNum);
        }
    }
}
