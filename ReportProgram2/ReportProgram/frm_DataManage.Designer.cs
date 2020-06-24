namespace ReportProgram
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
            this.btn_InputBarcode = new System.Windows.Forms.Button();
            this.cbx_SelModel = new System.Windows.Forms.ComboBox();
            this.rdb_SelNg = new System.Windows.Forms.RadioButton();
            this.rdb_SelOk = new System.Windows.Forms.RadioButton();
            this.rdb_NoSel = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_DeleteData = new System.Windows.Forms.Button();
            this.txtbox_InputBarcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_CancleSearch = new System.Windows.Forms.Button();
            this.btn_SearchData = new System.Windows.Forms.Button();
            this.txtbox_InputSerialNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchedDataView = new System.Windows.Forms.DataGridView();
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
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchedDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.데이터ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1257, 24);
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
            this.groupBox1.Controls.Add(this.btn_InputBarcode);
            this.groupBox1.Controls.Add(this.cbx_SelModel);
            this.groupBox1.Controls.Add(this.rdb_SelNg);
            this.groupBox1.Controls.Add(this.rdb_SelOk);
            this.groupBox1.Controls.Add(this.rdb_NoSel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 143);
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
            // btn_InputBarcode
            // 
            this.btn_InputBarcode.Location = new System.Drawing.Point(28, 172);
            this.btn_InputBarcode.Name = "btn_InputBarcode";
            this.btn_InputBarcode.Size = new System.Drawing.Size(86, 23);
            this.btn_InputBarcode.TabIndex = 7;
            this.btn_InputBarcode.Text = "바코드 입력";
            this.btn_InputBarcode.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_DeleteData);
            this.groupBox2.Controls.Add(this.txtbox_InputBarcode);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btn_CancleSearch);
            this.groupBox2.Controls.Add(this.btn_SearchData);
            this.groupBox2.Controls.Add(this.txtbox_InputSerialNum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 165);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "데이터 수정";
            // 
            // btn_DeleteData
            // 
            this.btn_DeleteData.Location = new System.Drawing.Point(437, 135);
            this.btn_DeleteData.Name = "btn_DeleteData";
            this.btn_DeleteData.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteData.TabIndex = 13;
            this.btn_DeleteData.Text = "삭제";
            this.btn_DeleteData.UseVisualStyleBackColor = true;
            this.btn_DeleteData.Click += new System.EventHandler(this.btn_DeleteData_Click);
            // 
            // txtbox_InputBarcode
            // 
            this.txtbox_InputBarcode.Location = new System.Drawing.Point(127, 77);
            this.txtbox_InputBarcode.Name = "txtbox_InputBarcode";
            this.txtbox_InputBarcode.Size = new System.Drawing.Size(274, 21);
            this.txtbox_InputBarcode.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "바코드";
            // 
            // btn_CancleSearch
            // 
            this.btn_CancleSearch.Location = new System.Drawing.Point(518, 135);
            this.btn_CancleSearch.Name = "btn_CancleSearch";
            this.btn_CancleSearch.Size = new System.Drawing.Size(75, 23);
            this.btn_CancleSearch.TabIndex = 10;
            this.btn_CancleSearch.Text = "취소";
            this.btn_CancleSearch.UseVisualStyleBackColor = true;
            // 
            // btn_SearchData
            // 
            this.btn_SearchData.Location = new System.Drawing.Point(356, 135);
            this.btn_SearchData.Name = "btn_SearchData";
            this.btn_SearchData.Size = new System.Drawing.Size(75, 23);
            this.btn_SearchData.TabIndex = 9;
            this.btn_SearchData.Text = "검색";
            this.btn_SearchData.UseVisualStyleBackColor = true;
            this.btn_SearchData.Click += new System.EventHandler(this.btn_SearchData_Click);
            // 
            // txtbox_InputSerialNum
            // 
            this.txtbox_InputSerialNum.Location = new System.Drawing.Point(127, 32);
            this.txtbox_InputSerialNum.Name = "txtbox_InputSerialNum";
            this.txtbox_InputSerialNum.Size = new System.Drawing.Size(274, 21);
            this.txtbox_InputSerialNum.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "시리얼 번호";
            // 
            // searchedDataView
            // 
            this.searchedDataView.AllowUserToAddRows = false;
            this.searchedDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchedDataView.Location = new System.Drawing.Point(611, 434);
            this.searchedDataView.Name = "searchedDataView";
            this.searchedDataView.RowTemplate.Height = 23;
            this.searchedDataView.Size = new System.Drawing.Size(567, 165);
            this.searchedDataView.TabIndex = 13;
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.Location = new System.Drawing.Point(763, 86);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(146, 34);
            this.btn_ExportToExcel.TabIndex = 5;
            this.btn_ExportToExcel.Text = "엑셀로 내보내기";
            this.btn_ExportToExcel.UseVisualStyleBackColor = true;
            this.btn_ExportToExcel.Click += new System.EventHandler(this.btn_ExportToExcel_Click);
            // 
            // btn_ImportToExcel
            // 
            this.btn_ImportToExcel.Location = new System.Drawing.Point(611, 86);
            this.btn_ImportToExcel.Name = "btn_ImportToExcel";
            this.btn_ImportToExcel.Size = new System.Drawing.Size(146, 34);
            this.btn_ImportToExcel.TabIndex = 6;
            this.btn_ImportToExcel.Text = "엑셀에서 가져오기";
            this.btn_ImportToExcel.UseVisualStyleBackColor = true;
            this.btn_ImportToExcel.Click += new System.EventHandler(this.btn_ImportToExcel_Click);
            // 
            // selectedDataView
            // 
            this.selectedDataView.AllowUserToAddRows = false;
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
            this.selectedDataView.Size = new System.Drawing.Size(567, 278);
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
            // frm_DataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1257, 628);
            this.Controls.Add(this.searchedDataView);
            this.Controls.Add(this.selectedDataView);
            this.Controls.Add(this.btn_ImportToExcel);
            this.Controls.Add(this.btn_ExportToExcel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.searchedDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).EndInit();
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
        private System.Windows.Forms.Button btn_CancleSearch;
        private System.Windows.Forms.Button btn_SearchData;
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
        private System.Windows.Forms.DataGridView searchedDataView;
        private System.Windows.Forms.TextBox txtbox_InputBarcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_DeleteData;
    }
}