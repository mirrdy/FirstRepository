using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ReportProgram
{
    public partial class frm_Main : Form
    {
        private frm_Monitor child_Monitor = null;
        private frm_DataManage child_DataManage = null;
        private frm_Set child_Set = null;

        private string ConString = "dsn=MariaDB";

        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Monitor_Click(object sender, EventArgs e)
        {
            /*if (Console.CapsLock)
                MessageBox.Show("CapsLock ON", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("CapsLock OFF");*/


            if (child_Monitor != null)
            {
                return;
            }
            else if (child_DataManage != null)
            {
                child_DataManage.Close();
                child_DataManage.Dispose();
                child_DataManage = null;
            }
            else if (child_Set != null)
            {
                child_Set.Close();
                child_Set.Dispose();
                child_Set = null;
            }
            

            child_Monitor = new frm_Monitor();
            child_Monitor.TopLevel = false;
            child_Monitor.TopMost = true;
            child_Monitor.WindowState = FormWindowState.Maximized;
            child_Monitor.StartPosition = FormStartPosition.CenterParent;
            child_Monitor.Parent = pnl_Center;
            child_Monitor.Show();
            child_Monitor.Controls.Find("chart1", true);
            
            

            
        }

        private void btn_DataManage_Click(object sender, EventArgs e)
        {
            if (child_Monitor != null)
            {
                child_Monitor.Close();
                child_Monitor.Dispose();
                child_Monitor = null;
            }
            else if (child_DataManage != null)
            {
                return;
            }
            else if (child_Set != null)
            {
                child_Set.Close();
                child_Set.Dispose();
                child_Set = null;
            }
            child_DataManage = new frm_DataManage();
            child_DataManage.TopLevel = false;
            child_DataManage.TopMost = true;
            child_DataManage.WindowState = FormWindowState.Maximized;
            child_DataManage.StartPosition = FormStartPosition.CenterParent;
            child_DataManage.Parent = pnl_Center;
            child_DataManage.Show();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (child_Monitor != null)
            {
                child_Monitor.Close();
                child_Monitor.Dispose();
                child_Monitor = null;
            }
            else if (child_DataManage != null)
            {
                child_DataManage.Close();
                child_DataManage.Dispose();
                child_DataManage = null;
            }
            else if (child_Set != null)
            {
                return;
            }
            child_Set = new frm_Set();
            child_Set.TopLevel = false;
            child_Set.TopMost = true;
            child_Set.WindowState = FormWindowState.Maximized;
            child_Set.StartPosition = FormStartPosition.CenterParent;
            child_Set.Parent = pnl_Center;
            child_Set.Show();
        }

    }
}
