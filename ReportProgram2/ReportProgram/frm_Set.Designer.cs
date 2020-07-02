namespace ReportProgram
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.targetInputBox = new System.Windows.Forms.TextBox();
            this.fdbr = new System.Windows.Forms.FolderBrowserDialog();
            this.infoDBConInputBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_StartViewIndex = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
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
            this.btn_Apply.Location = new System.Drawing.Point(66, 250);
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
            this.label2.Location = new System.Drawing.Point(49, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "목표 수량";
            // 
            // targetInputBox
            // 
            this.targetInputBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.targetInputBox.Location = new System.Drawing.Point(148, 64);
            this.targetInputBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.targetInputBox.Name = "targetInputBox";
            this.targetInputBox.Size = new System.Drawing.Size(100, 25);
            this.targetInputBox.TabIndex = 9;
            // 
            // infoDBConInputBox
            // 
            this.infoDBConInputBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.infoDBConInputBox.Location = new System.Drawing.Point(148, 97);
            this.infoDBConInputBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoDBConInputBox.Name = "infoDBConInputBox";
            this.infoDBConInputBox.Size = new System.Drawing.Size(100, 25);
            this.infoDBConInputBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(49, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "DB 연결 정보";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(252, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "EA";
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(298, 305);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "프로그램 옵션 설정";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(10, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "시작 화면선택";
            // 
            // cbb_StartViewIndex
            // 
            this.cbb_StartViewIndex.FormattingEnabled = true;
            this.cbb_StartViewIndex.Items.AddRange(new object[] {
            "모니터링 화면",
            "데이터 관리 화면"});
            this.cbb_StartViewIndex.Location = new System.Drawing.Point(109, 189);
            this.cbb_StartViewIndex.Name = "cbb_StartViewIndex";
            this.cbb_StartViewIndex.Size = new System.Drawing.Size(179, 29);
            this.cbb_StartViewIndex.TabIndex = 18;
            // 
            // frm_Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1047, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_Set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Set";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}