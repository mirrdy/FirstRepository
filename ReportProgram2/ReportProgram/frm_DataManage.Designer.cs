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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DataManage));
            this.btn_DeleteData = new System.Windows.Forms.Button();
            this.btn_SelectData = new System.Windows.Forms.Button();
            this.btn_ExportToExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectedDataView = new System.Windows.Forms.DataGridView();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_DeleteData
            // 
            this.btn_DeleteData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_DeleteData.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_DeleteData.Image = ((System.Drawing.Image)(resources.GetObject("btn_DeleteData.Image")));
            this.btn_DeleteData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteData.Location = new System.Drawing.Point(3, 58);
            this.btn_DeleteData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_DeleteData.Name = "btn_DeleteData";
            this.btn_DeleteData.Size = new System.Drawing.Size(219, 51);
            this.btn_DeleteData.TabIndex = 8;
            this.btn_DeleteData.Text = "   데이터 삭제";
            this.btn_DeleteData.UseVisualStyleBackColor = false;
            this.btn_DeleteData.Click += new System.EventHandler(this.btn_DeleteData_Click);
            // 
            // btn_SelectData
            // 
            this.btn_SelectData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_SelectData.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_SelectData.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectData.Image")));
            this.btn_SelectData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectData.Location = new System.Drawing.Point(3, 4);
            this.btn_SelectData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SelectData.Name = "btn_SelectData";
            this.btn_SelectData.Size = new System.Drawing.Size(219, 51);
            this.btn_SelectData.TabIndex = 7;
            this.btn_SelectData.Text = "   데이터 조회";
            this.btn_SelectData.UseVisualStyleBackColor = false;
            this.btn_SelectData.Click += new System.EventHandler(this.btn_SelectData_Click);
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ExportToExcel.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_ExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ExportToExcel.Image")));
            this.btn_ExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExportToExcel.Location = new System.Drawing.Point(3, 111);
            this.btn_ExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(219, 51);
            this.btn_ExportToExcel.TabIndex = 6;
            this.btn_ExportToExcel.Text = "   엑셀로 내보내기";
            this.btn_ExportToExcel.UseVisualStyleBackColor = false;
            this.btn_ExportToExcel.Click += new System.EventHandler(this.btn_ExportToExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_DeleteData);
            this.panel1.Controls.Add(this.btn_SelectData);
            this.panel1.Controls.Add(this.btn_ExportToExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 935);
            this.panel1.TabIndex = 15;
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
            this.selectedDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedDataView.Location = new System.Drawing.Point(234, 0);
            this.selectedDataView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectedDataView.Name = "selectedDataView";
            this.selectedDataView.RowTemplate.Height = 23;
            this.selectedDataView.Size = new System.Drawing.Size(1023, 935);
            this.selectedDataView.TabIndex = 16;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 935);
            this.ControlBox = false;
            this.Controls.Add(this.selectedDataView);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_DataManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_DeleteData;
        private System.Windows.Forms.Button btn_SelectData;
        private System.Windows.Forms.Button btn_ExportToExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView selectedDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tester;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_result;
    }
}