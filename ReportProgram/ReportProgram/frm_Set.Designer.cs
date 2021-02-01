﻿namespace ReportProgram
{
    partial class frm_Set
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Set));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.targetInputBox = new System.Windows.Forms.TextBox();
            this.fdbr = new System.Windows.Forms.FolderBrowserDialog();
            this.infoDBConInputBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_Size_H = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbx_Size_W = new System.Windows.Forms.TextBox();
            this.tbx_Location_Y = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbx_Location_X = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbb_StartViewIndex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_JobOrder_File_List = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_SlideShow_Time = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.odlg_ImgFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_BasicDisplay = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_JobOrder_File_List)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BasicDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 29);
            this.label1.TabIndex = 13;
            // 
            // btn_Apply
            // 
            this.btn_Apply.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Apply.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Apply.Image = ((System.Drawing.Image)(resources.GetObject("btn_Apply.Image")));
            this.btn_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Apply.Location = new System.Drawing.Point(66, 374);
            this.btn_Apply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(167, 42);
            this.btn_Apply.TabIndex = 6;
            this.btn_Apply.Text = "적 용";
            this.btn_Apply.UseVisualStyleBackColor = false;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(49, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "목표 수량";
            // 
            // targetInputBox
            // 
            this.targetInputBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.targetInputBox.Location = new System.Drawing.Point(148, 188);
            this.targetInputBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.targetInputBox.Name = "targetInputBox";
            this.targetInputBox.Size = new System.Drawing.Size(100, 25);
            this.targetInputBox.TabIndex = 9;
            // 
            // infoDBConInputBox
            // 
            this.infoDBConInputBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.infoDBConInputBox.Location = new System.Drawing.Point(148, 221);
            this.infoDBConInputBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoDBConInputBox.Name = "infoDBConInputBox";
            this.infoDBConInputBox.Size = new System.Drawing.Size(100, 25);
            this.infoDBConInputBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(49, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "DB 연결 정보";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(252, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "EA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_Size_H);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbx_Size_W);
            this.groupBox1.Controls.Add(this.tbx_Location_Y);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbx_Location_X);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbb_StartViewIndex);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_Apply);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.targetInputBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.infoDBConInputBox);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 424);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "프로그램 옵션 설정";
            // 
            // tbx_Size_H
            // 
            this.tbx_Size_H.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbx_Size_H.Location = new System.Drawing.Point(182, 142);
            this.tbx_Size_H.Name = "tbx_Size_H";
            this.tbx_Size_H.Size = new System.Drawing.Size(73, 21);
            this.tbx_Size_H.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(160, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 17);
            this.label13.TabIndex = 43;
            this.label13.Text = "H";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(26, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 17);
            this.label14.TabIndex = 42;
            this.label14.Text = "W";
            // 
            // tbx_Size_W
            // 
            this.tbx_Size_W.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbx_Size_W.Location = new System.Drawing.Point(53, 142);
            this.tbx_Size_W.Name = "tbx_Size_W";
            this.tbx_Size_W.Size = new System.Drawing.Size(73, 21);
            this.tbx_Size_W.TabIndex = 41;
            // 
            // tbx_Location_Y
            // 
            this.tbx_Location_Y.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbx_Location_Y.Location = new System.Drawing.Point(182, 75);
            this.tbx_Location_Y.Name = "tbx_Location_Y";
            this.tbx_Location_Y.Size = new System.Drawing.Size(73, 21);
            this.tbx_Location_Y.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(160, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 39;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(26, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "X";
            // 
            // tbx_Location_X
            // 
            this.tbx_Location_X.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbx_Location_X.Location = new System.Drawing.Point(53, 75);
            this.tbx_Location_X.Name = "tbx_Location_X";
            this.tbx_Location_X.Size = new System.Drawing.Size(73, 21);
            this.tbx_Location_X.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(10, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "프로그램 크기";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(10, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "프로그램 시작 위치";
            // 
            // cbb_StartViewIndex
            // 
            this.cbb_StartViewIndex.FormattingEnabled = true;
            this.cbb_StartViewIndex.Items.AddRange(new object[] {
            "모니터링 화면",
            "데이터 관리 화면",
            "환경설정",
            "작업지시서 화면"});
            this.cbb_StartViewIndex.Location = new System.Drawing.Point(109, 313);
            this.cbb_StartViewIndex.Name = "cbb_StartViewIndex";
            this.cbb_StartViewIndex.Size = new System.Drawing.Size(179, 29);
            this.cbb_StartViewIndex.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(10, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "시작 화면선택";
            // 
            // dgv_JobOrder_File_List
            // 
            this.dgv_JobOrder_File_List.AllowUserToAddRows = false;
            this.dgv_JobOrder_File_List.AllowUserToDeleteRows = false;
            this.dgv_JobOrder_File_List.AllowUserToResizeColumns = false;
            this.dgv_JobOrder_File_List.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_JobOrder_File_List.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_JobOrder_File_List.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_JobOrder_File_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_JobOrder_File_List.ColumnHeadersHeight = 25;
            this.dgv_JobOrder_File_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_JobOrder_File_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ModelPath});
            this.dgv_JobOrder_File_List.EnableHeadersVisualStyles = false;
            this.dgv_JobOrder_File_List.Location = new System.Drawing.Point(6, 64);
            this.dgv_JobOrder_File_List.MultiSelect = false;
            this.dgv_JobOrder_File_List.Name = "dgv_JobOrder_File_List";
            this.dgv_JobOrder_File_List.ReadOnly = true;
            this.dgv_JobOrder_File_List.RowHeadersVisible = false;
            this.dgv_JobOrder_File_List.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgv_JobOrder_File_List.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_JobOrder_File_List.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgv_JobOrder_File_List.RowTemplate.Height = 20;
            this.dgv_JobOrder_File_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_JobOrder_File_List.Size = new System.Drawing.Size(393, 309);
            this.dgv_JobOrder_File_List.TabIndex = 1;
            this.dgv_JobOrder_File_List.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_JobOrder_File_List_CellDoubleClick);
            this.dgv_JobOrder_File_List.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_JobOrder_File_List_KeyDown);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 40;
            // 
            // ModelPath
            // 
            this.ModelPath.HeaderText = "작업지시서 경로";
            this.ModelPath.MinimumWidth = 6;
            this.ModelPath.Name = "ModelPath";
            this.ModelPath.ReadOnly = true;
            this.ModelPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModelPath.Width = 250;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbx_SlideShow_Time);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dgv_JobOrder_File_List);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(374, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 409);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "작업지시서 설정";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(9, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "슬라이드 쇼 시간";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(228, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Sec";
            // 
            // tbx_SlideShow_Time
            // 
            this.tbx_SlideShow_Time.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbx_SlideShow_Time.Location = new System.Drawing.Point(124, 29);
            this.tbx_SlideShow_Time.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_SlideShow_Time.Name = "tbx_SlideShow_Time";
            this.tbx_SlideShow_Time.Size = new System.Drawing.Size(100, 25);
            this.tbx_SlideShow_Time.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(6, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 26);
            this.label6.TabIndex = 2;
            this.label6.Text = "* 이미지 파일만 등록 가능 (*.jpg, *.bmp, *.png)\r\n* 삭제 : \"Delete\"키";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_BasicDisplay);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(803, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 567);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "기본 데이터 표시";
            // 
            // dgv_BasicDisplay
            // 
            this.dgv_BasicDisplay.AllowUserToAddRows = false;
            this.dgv_BasicDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BasicDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BasicDisplay.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_BasicDisplay.Location = new System.Drawing.Point(6, 26);
            this.dgv_BasicDisplay.Name = "dgv_BasicDisplay";
            this.dgv_BasicDisplay.RowHeadersWidth = 30;
            this.dgv_BasicDisplay.RowTemplate.Height = 23;
            this.dgv_BasicDisplay.Size = new System.Drawing.Size(481, 533);
            this.dgv_BasicDisplay.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "표시";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "너비";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "이름";
            this.Column3.Name = "Column3";
            this.Column3.Width = 140;
            // 
            // frm_Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1421, 594);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_Set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Set";
            this.Load += new System.EventHandler(this.frm_Set_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_JobOrder_File_List)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BasicDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox targetInputBox;
        private System.Windows.Forms.FolderBrowserDialog fdbr;
        private System.Windows.Forms.TextBox infoDBConInputBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_StartViewIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_JobOrder_File_List;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog odlg_ImgFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_SlideShow_Time;
        private System.Windows.Forms.TextBox tbx_Size_H;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbx_Size_W;
        private System.Windows.Forms.TextBox tbx_Location_Y;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbx_Location_X;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_BasicDisplay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}