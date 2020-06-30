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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.targetInputBox = new System.Windows.Forms.TextBox();
            this.fdbr = new System.Windows.Forms.FolderBrowserDialog();
            this.infoDBConInputBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loadPathTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "목표 수량";
            // 
            // targetInputBox
            // 
            this.targetInputBox.Location = new System.Drawing.Point(18, 337);
            this.targetInputBox.Name = "targetInputBox";
            this.targetInputBox.Size = new System.Drawing.Size(100, 21);
            this.targetInputBox.TabIndex = 9;
            // 
            // infoDBConInputBox
            // 
            this.infoDBConInputBox.Location = new System.Drawing.Point(18, 393);
            this.infoDBConInputBox.Name = "infoDBConInputBox";
            this.infoDBConInputBox.Size = new System.Drawing.Size(100, 21);
            this.infoDBConInputBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "DB 연결 정보";
            // 
            // loadPathTextBox
            // 
            this.loadPathTextBox.Location = new System.Drawing.Point(18, 510);
            this.loadPathTextBox.Name = "loadPathTextBox";
            this.loadPathTextBox.Size = new System.Drawing.Size(220, 21);
            this.loadPathTextBox.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 481);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "불러오기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 591);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.infoDBConInputBox);
            this.Controls.Add(this.loadPathTextBox);
            this.Controls.Add(this.targetInputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Movable = false;
            this.Name = "frm_Set";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Set";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox targetInputBox;
        private System.Windows.Forms.FolderBrowserDialog fdbr;
        private System.Windows.Forms.TextBox infoDBConInputBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loadPathTextBox;
        private System.Windows.Forms.Button button2;
    }
}