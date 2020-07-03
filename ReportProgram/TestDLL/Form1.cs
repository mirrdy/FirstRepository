using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InnoDB_DLL;

namespace TestDLL
{
    public partial class Form1 : Form
    {
        InnoDB myDB = new InnoDB();
        int SerialNumber = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myDB.Open_DB("MariaDB");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            myDB.Close_DB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDB.Add_TestData("CN7", "ABC", DateTime.Now, DateTime.Now.AddMinutes(0.5), SerialNumber++.ToString("0000"), "1231242314", "양품", "OK; OK;3.5;43.0;");
        }
    }
}
