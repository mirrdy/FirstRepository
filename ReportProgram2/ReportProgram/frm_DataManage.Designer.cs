﻿namespace ReportProgram
{
    partial class frm_DataManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.데이터ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.데이터조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.데이터수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.btn_CancleSelect = new System.Windows.Forms.Button();
            this.btn_ConfirmSelect = new System.Windows.Forms.Button();
            this.cbx_SelModel = new System.Windows.Forms.ComboBox();
            this.rdb_SelNg = new System.Windows.Forms.RadioButton();
            this.rdb_SelOk = new System.Windows.Forms.RadioButton();
            this.rdb_NoSel = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_InputBarcode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_CancleModify = new System.Windows.Forms.Button();
            this.btn_ConfirmModify = new System.Windows.Forms.Button();
            this.txtbox_InputSerialNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_ExportToExcel = new System.Windows.Forms.Button();
            this.btn_ImportToExcel = new System.Windows.Forms.Button();
            this.selectedDataView = new System.Windows.Forms.DataGridView();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.데이터ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 데이터ToolStripMenuItem
            // 
            this.데이터ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.데이터조회ToolStripMenuItem,
            this.데이터수정ToolStripMenuItem});
            this.데이터ToolStripMenuItem.Name = "데이터ToolStripMenuItem";
            this.데이터ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.데이터ToolStripMenuItem.Text = "데이터";
            // 
            // 데이터조회ToolStripMenuItem
            // 
            this.데이터조회ToolStripMenuItem.Name = "데이터조회ToolStripMenuItem";
            this.데이터조회ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.데이터조회ToolStripMenuItem.Text = "데이터 조회";
            // 
            // 데이터수정ToolStripMenuItem
            // 
            this.데이터수정ToolStripMenuItem.Name = "데이터수정ToolStripMenuItem";
            this.데이터수정ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.데이터수정ToolStripMenuItem.Text = "데이터 수정";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_EndDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtp_StartDate);
            this.groupBox1.Controls.Add(this.btn_CancleSelect);
            this.groupBox1.Controls.Add(this.btn_ConfirmSelect);
            this.groupBox1.Controls.Add(this.cbx_SelModel);
            this.groupBox1.Controls.Add(this.rdb_SelNg);
            this.groupBox1.Controls.Add(this.rdb_SelOk);
            this.groupBox1.Controls.Add(this.rdb_NoSel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 213);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이터 조회";
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.Location = new System.Drawing.Point(328, 34);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(200, 21);
            this.dtp_EndDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "~";
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.Location = new System.Drawing.Point(102, 34);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(200, 21);
            this.dtp_StartDate.TabIndex = 10;
            // 
            // btn_CancleSelect
            // 
            this.btn_CancleSelect.Location = new System.Drawing.Point(518, 184);
            this.btn_CancleSelect.Name = "btn_CancleSelect";
            this.btn_CancleSelect.Size = new System.Drawing.Size(75, 23);
            this.btn_CancleSelect.TabIndex = 9;
            this.btn_CancleSelect.Text = "취소";
            this.btn_CancleSelect.UseVisualStyleBackColor = true;
            // 
            // btn_ConfirmSelect
            // 
            this.btn_ConfirmSelect.Location = new System.Drawing.Point(442, 184);
            this.btn_ConfirmSelect.Name = "btn_ConfirmSelect";
            this.btn_ConfirmSelect.Size = new System.Drawing.Size(75, 23);
            this.btn_ConfirmSelect.TabIndex = 8;
            this.btn_ConfirmSelect.Text = "확인";
            this.btn_ConfirmSelect.UseVisualStyleBackColor = true;
            this.btn_ConfirmSelect.Click += new System.EventHandler(this.btn_ConfirmSelect_Click);
            // 
            // cbx_SelModel
            // 
            this.cbx_SelModel.FormattingEnabled = true;
            this.cbx_SelModel.Location = new System.Drawing.Point(127, 131);
            this.cbx_SelModel.Name = "cbx_SelModel";
            this.cbx_SelModel.Size = new System.Drawing.Size(121, 20);
            this.cbx_SelModel.TabIndex = 6;
            // 
            // rdb_SelNg
            // 
            this.rdb_SelNg.AutoSize = true;
            this.rdb_SelNg.Location = new System.Drawing.Point(442, 82);
            this.rdb_SelNg.Name = "rdb_SelNg";
            this.rdb_SelNg.Size = new System.Drawing.Size(47, 16);
            this.rdb_SelNg.TabIndex = 5;
            this.rdb_SelNg.Text = "불량";
            this.rdb_SelNg.UseVisualStyleBackColor = true;
            // 
            // rdb_SelOk
            // 
            this.rdb_SelOk.AutoSize = true;
            this.rdb_SelOk.Location = new System.Drawing.Point(289, 82);
            this.rdb_SelOk.Name = "rdb_SelOk";
            this.rdb_SelOk.Size = new System.Drawing.Size(47, 16);
            this.rdb_SelOk.TabIndex = 4;
            this.rdb_SelOk.Text = "양품";
            this.rdb_SelOk.UseVisualStyleBackColor = true;
            // 
            // rdb_NoSel
            // 
            this.rdb_NoSel.AutoSize = true;
            this.rdb_NoSel.Checked = true;
            this.rdb_NoSel.Location = new System.Drawing.Point(145, 82);
            this.rdb_NoSel.Name = "rdb_NoSel";
            this.rdb_NoSel.Size = new System.Drawing.Size(71, 16);
            this.rdb_NoSel.TabIndex = 3;
            this.rdb_NoSel.TabStop = true;
            this.rdb_NoSel.Text = "선택안함";
            this.rdb_NoSel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 13F);
            this.label3.Location = new System.Drawing.Point(26, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "모델";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 13F);
            this.label2.Location = new System.Drawing.Point(26, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "양품/불량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 13F);
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "기간";
            // 
            // btn_InputBarcode
            // 
            this.btn_InputBarcode.Location = new System.Drawing.Point(301, 471);
            this.btn_InputBarcode.Name = "btn_InputBarcode";
            this.btn_InputBarcode.Size = new System.Drawing.Size(86, 23);
            this.btn_InputBarcode.TabIndex = 7;
            this.btn_InputBarcode.Text = "바코드 검색";
            this.btn_InputBarcode.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_CancleModify);
            this.groupBox2.Controls.Add(this.btn_ConfirmModify);
            this.groupBox2.Controls.Add(this.txtbox_InputSerialNum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "데이터 수정";
            // 
            // btn_CancleModify
            // 
            this.btn_CancleModify.Location = new System.Drawing.Point(344, 57);
            this.btn_CancleModify.Name = "btn_CancleModify";
            this.btn_CancleModify.Size = new System.Drawing.Size(75, 23);
            this.btn_CancleModify.TabIndex = 10;
            this.btn_CancleModify.Text = "취소";
            this.btn_CancleModify.UseVisualStyleBackColor = true;
            // 
            // btn_ConfirmModify
            // 
            this.btn_ConfirmModify.Location = new System.Drawing.Point(263, 57);
            this.btn_ConfirmModify.Name = "btn_ConfirmModify";
            this.btn_ConfirmModify.Size = new System.Drawing.Size(75, 23);
            this.btn_ConfirmModify.TabIndex = 9;
            this.btn_ConfirmModify.Text = "확인";
            this.btn_ConfirmModify.UseVisualStyleBackColor = true;
            this.btn_ConfirmModify.Click += new System.EventHandler(this.btn_ConfirmModify_Click);
            // 
            // txtbox_InputSerialNum
            // 
            this.txtbox_InputSerialNum.Location = new System.Drawing.Point(136, 30);
            this.txtbox_InputSerialNum.Name = "txtbox_InputSerialNum";
            this.txtbox_InputSerialNum.Size = new System.Drawing.Size(274, 21);
            this.txtbox_InputSerialNum.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "시리얼 번호";
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.Location = new System.Drawing.Point(763, 86);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(146, 34);
            this.btn_ExportToExcel.TabIndex = 5;
            this.btn_ExportToExcel.Text = "엑셀로 내보내기";
            this.btn_ExportToExcel.UseVisualStyleBackColor = true;
            // 
            // btn_ImportToExcel
            // 
            this.btn_ImportToExcel.Location = new System.Drawing.Point(611, 86);
            this.btn_ImportToExcel.Name = "btn_ImportToExcel";
            this.btn_ImportToExcel.Size = new System.Drawing.Size(146, 34);
            this.btn_ImportToExcel.TabIndex = 6;
            this.btn_ImportToExcel.Text = "엑셀에서 가져오기";
            this.btn_ImportToExcel.UseVisualStyleBackColor = true;
            // 
            // selectedDataView
            // 
            this.selectedDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Model,
            this.Tester,
            this.Start_time,
            this.End_time,
            this.Serial_number,
            this.Barcode,
            this.Total_result});
            this.selectedDataView.Location = new System.Drawing.Point(611, 143);
            this.selectedDataView.Name = "selectedDataView";
            this.selectedDataView.RowTemplate.Height = 23;
            this.selectedDataView.Size = new System.Drawing.Size(567, 260);
            this.selectedDataView.TabIndex = 7;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            // 
            // Tester
            // 
            this.Tester.HeaderText = "Tester";
            this.Tester.Name = "Tester";
            // 
            // Start_time
            // 
            this.Start_time.HeaderText = "Start_time";
            this.Start_time.Name = "Start_time";
            // 
            // End_time
            // 
            this.End_time.HeaderText = "End_time";
            this.End_time.Name = "End_time";
            // 
            // Serial_number
            // 
            this.Serial_number.HeaderText = "Serial_number";
            this.Serial_number.Name = "Serial_number";
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            // 
            // Total_result
            // 
            this.Total_result.HeaderText = "Total_result";
            this.Total_result.Name = "Total_result";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 473);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 21);
            this.textBox1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(1, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 10);
            this.panel1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataGridView1.Location = new System.Drawing.Point(610, 447);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(567, 102);
            this.dataGridView1.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Model";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tester";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Start_time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "End_time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Serial_number";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Barcode";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Total_result";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 502);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(274, 21);
            this.textBox2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "시리얼번호 검색";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frm_DataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 570);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.selectedDataView);
            this.Controls.Add(this.btn_ImportToExcel);
            this.Controls.Add(this.btn_ExportToExcel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_InputBarcode);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DataManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ㅁㅁ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 데이터ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 데이터조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 데이터수정ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.Button btn_CancleSelect;
        private System.Windows.Forms.Button btn_ConfirmSelect;
        private System.Windows.Forms.Button btn_InputBarcode;
        private System.Windows.Forms.ComboBox cbx_SelModel;
        private System.Windows.Forms.RadioButton rdb_SelNg;
        private System.Windows.Forms.RadioButton rdb_SelOk;
        private System.Windows.Forms.RadioButton rdb_NoSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_CancleModify;
        private System.Windows.Forms.Button btn_ConfirmModify;
        private System.Windows.Forms.TextBox txtbox_InputSerialNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ExportToExcel;
        private System.Windows.Forms.Button btn_ImportToExcel;
        private System.Windows.Forms.DataGridView selectedDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tester;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_result;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}