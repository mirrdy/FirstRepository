namespace ReportProgram
{
    partial class frm_ModifyData
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
            this.searchedDataView = new System.Windows.Forms.DataGridView();
            this.btn_ConfirmDeleteData = new System.Windows.Forms.Button();
            this.txtbox_InputBarcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_CancleSearch = new System.Windows.Forms.Button();
            this.btn_SearchData = new System.Windows.Forms.Button();
            this.txtbox_InputSerialNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.btn_CancleDelete = new System.Windows.Forms.Button();
            this.btn_ConfirmDelete = new System.Windows.Forms.Button();
            this.cbx_SelModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.searchedDataView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchedDataView
            // 
            this.searchedDataView.AllowUserToAddRows = false;
            this.searchedDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchedDataView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchedDataView.Location = new System.Drawing.Point(0, 223);
            this.searchedDataView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchedDataView.Name = "searchedDataView";
            this.searchedDataView.RowTemplate.Height = 23;
            this.searchedDataView.Size = new System.Drawing.Size(1241, 206);
            this.searchedDataView.TabIndex = 14;
            // 
            // btn_ConfirmDeleteData
            // 
            this.btn_ConfirmDeleteData.Location = new System.Drawing.Point(348, 101);
            this.btn_ConfirmDeleteData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ConfirmDeleteData.Name = "btn_ConfirmDeleteData";
            this.btn_ConfirmDeleteData.Size = new System.Drawing.Size(75, 29);
            this.btn_ConfirmDeleteData.TabIndex = 13;
            this.btn_ConfirmDeleteData.Text = "삭제";
            this.btn_ConfirmDeleteData.UseVisualStyleBackColor = true;
            this.btn_ConfirmDeleteData.Click += new System.EventHandler(this.btn_ConfirmDeleteData_Click);
            // 
            // txtbox_InputBarcode
            // 
            this.txtbox_InputBarcode.Location = new System.Drawing.Point(171, 60);
            this.txtbox_InputBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbox_InputBarcode.Name = "txtbox_InputBarcode";
            this.txtbox_InputBarcode.Size = new System.Drawing.Size(274, 23);
            this.txtbox_InputBarcode.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "바코드";
            // 
            // btn_CancleSearch
            // 
            this.btn_CancleSearch.Location = new System.Drawing.Point(429, 101);
            this.btn_CancleSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_CancleSearch.Name = "btn_CancleSearch";
            this.btn_CancleSearch.Size = new System.Drawing.Size(75, 29);
            this.btn_CancleSearch.TabIndex = 10;
            this.btn_CancleSearch.Text = "취소";
            this.btn_CancleSearch.UseVisualStyleBackColor = true;
            // 
            // btn_SearchData
            // 
            this.btn_SearchData.Location = new System.Drawing.Point(267, 101);
            this.btn_SearchData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SearchData.Name = "btn_SearchData";
            this.btn_SearchData.Size = new System.Drawing.Size(75, 29);
            this.btn_SearchData.TabIndex = 9;
            this.btn_SearchData.Text = "검색";
            this.btn_SearchData.UseVisualStyleBackColor = true;
            this.btn_SearchData.Click += new System.EventHandler(this.btn_SearchData_Click);
            // 
            // txtbox_InputSerialNum
            // 
            this.txtbox_InputSerialNum.Location = new System.Drawing.Point(171, 22);
            this.txtbox_InputSerialNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbox_InputSerialNum.Name = "txtbox_InputSerialNum";
            this.txtbox_InputSerialNum.Size = new System.Drawing.Size(274, 23);
            this.txtbox_InputSerialNum.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "시리얼 번호";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_CancleSearch);
            this.panel1.Controls.Add(this.btn_ConfirmDeleteData);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtbox_InputBarcode);
            this.panel1.Controls.Add(this.btn_SearchData);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtbox_InputSerialNum);
            this.panel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 134);
            this.panel1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_EndDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtp_StartDate);
            this.groupBox1.Controls.Add(this.btn_CancleDelete);
            this.groupBox1.Controls.Add(this.btn_ConfirmDelete);
            this.groupBox1.Controls.Add(this.cbx_SelModel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(611, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 159);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "기간별 삭제";
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.Location = new System.Drawing.Point(320, 36);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(200, 23);
            this.dtp_EndDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "~";
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.Location = new System.Drawing.Point(94, 36);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(200, 23);
            this.dtp_StartDate.TabIndex = 10;
            // 
            // btn_CancleDelete
            // 
            this.btn_CancleDelete.Location = new System.Drawing.Point(509, 127);
            this.btn_CancleDelete.Name = "btn_CancleDelete";
            this.btn_CancleDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_CancleDelete.TabIndex = 9;
            this.btn_CancleDelete.Text = "취소";
            this.btn_CancleDelete.UseVisualStyleBackColor = true;
            this.btn_CancleDelete.Click += new System.EventHandler(this.btn_CancleDelete_Click);
            // 
            // btn_ConfirmDelete
            // 
            this.btn_ConfirmDelete.Location = new System.Drawing.Point(433, 127);
            this.btn_ConfirmDelete.Name = "btn_ConfirmDelete";
            this.btn_ConfirmDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_ConfirmDelete.TabIndex = 8;
            this.btn_ConfirmDelete.Text = "삭제";
            this.btn_ConfirmDelete.UseVisualStyleBackColor = true;
            this.btn_ConfirmDelete.Click += new System.EventHandler(this.btn_ConfirmDelete_Click);
            // 
            // cbx_SelModel
            // 
            this.cbx_SelModel.FormattingEnabled = true;
            this.cbx_SelModel.Location = new System.Drawing.Point(118, 74);
            this.cbx_SelModel.Name = "cbx_SelModel";
            this.cbx_SelModel.Size = new System.Drawing.Size(121, 23);
            this.cbx_SelModel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "모델";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "기간";
            // 
            // frm_ModifyData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchedDataView);
            this.Name = "frm_ModifyData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ModifyData";
            this.Load += new System.EventHandler(this.frm_ModifyData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchedDataView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView searchedDataView;
        private System.Windows.Forms.Button btn_ConfirmDeleteData;
        private System.Windows.Forms.TextBox txtbox_InputBarcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_CancleSearch;
        private System.Windows.Forms.Button btn_SearchData;
        private System.Windows.Forms.TextBox txtbox_InputSerialNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.Button btn_CancleDelete;
        private System.Windows.Forms.Button btn_ConfirmDelete;
        private System.Windows.Forms.ComboBox cbx_SelModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}