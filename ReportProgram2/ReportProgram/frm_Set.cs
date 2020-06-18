using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgram
{
    public partial class frm_Set : Form
    {
        private string Constring = "dsn=MariaDB";
        public frm_Set()
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

                while(dr.Read())
                {
                    selectModelCB.Items.Add(dr["name"]);
                }
            }
            //MessageBox.Show(selectModelCB.Items[3].ToString());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string modelCheck;
            int targetQuantity;
            DateTime targetDate = targetCalendar.SelectionStart;
            string dateFormat = "yyyyMMdd";

            if (selectModelCB.SelectedItem != null)
                modelCheck = selectModelCB.SelectedItem.ToString();
            else
            {
                MessageBox.Show("모델을 선택해주세요.");
                return;
            }

            if (targetInputBox.Text.Equals(""))
            {
                MessageBox.Show("목표수량을 입력해주세요.");
                return;
            }
            else if (!int.TryParse(targetInputBox.Text, out _))
            {
                MessageBox.Show("목표 수량에는 정수만 입력해야 합니다.");
                return;
            }
            else
            {
                targetQuantity = Convert.ToInt32(targetInputBox.Text);
            }

            MessageBox.Show(targetQuantity.ToString());


            if(Directory.Exists("d:\\targetSaveFolder\\" + targetDate.ToString(dateFormat)) == false)
            {
                Directory.CreateDirectory("d:\\targetSaveFolder\\" + targetDate.ToString(dateFormat));
            }

            StreamWriter saveFile = new StreamWriter(new FileStream("d:\\targetSaveFolder\\"+targetDate.ToString(dateFormat)+"\\"+selectModelCB.SelectedItem.ToString()+".txt", FileMode.Create));

            saveFile.WriteLine(targetInputBox.Text);

            saveFile.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(fdbr.ShowDialog() == DialogResult.OK)
            {
                loadPathTextBox.Text = fdbr.SelectedPath;
            }
        }
    }
}
