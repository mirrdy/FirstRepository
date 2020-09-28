namespace TestDLL
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btn_AddModel = new System.Windows.Forms.Button();
            this.tbx_Model_Name = new System.Windows.Forms.TextBox();
            this.tbx_Model_UpdateUser = new System.Windows.Forms.TextBox();
            this.tbx_Model_Header = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_GetModelList = new System.Windows.Forms.Button();
            this.cbb_ModelList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_AddModel
            // 
            this.btn_AddModel.Location = new System.Drawing.Point(10, 93);
            this.btn_AddModel.Name = "btn_AddModel";
            this.btn_AddModel.Size = new System.Drawing.Size(169, 23);
            this.btn_AddModel.TabIndex = 1;
            this.btn_AddModel.Text = "Add Model";
            this.btn_AddModel.UseVisualStyleBackColor = true;
            this.btn_AddModel.Click += new System.EventHandler(this.btn_AddModel_Click);
            // 
            // tbx_Model_Name
            // 
            this.tbx_Model_Name.Location = new System.Drawing.Point(79, 12);
            this.tbx_Model_Name.Name = "tbx_Model_Name";
            this.tbx_Model_Name.Size = new System.Drawing.Size(100, 21);
            this.tbx_Model_Name.TabIndex = 2;
            this.tbx_Model_Name.Text = "CN7";
            // 
            // tbx_Model_UpdateUser
            // 
            this.tbx_Model_UpdateUser.Location = new System.Drawing.Point(79, 39);
            this.tbx_Model_UpdateUser.Name = "tbx_Model_UpdateUser";
            this.tbx_Model_UpdateUser.Size = new System.Drawing.Size(100, 21);
            this.tbx_Model_UpdateUser.TabIndex = 3;
            this.tbx_Model_UpdateUser.Text = "홍길동";
            // 
            // tbx_Model_Header
            // 
            this.tbx_Model_Header.Location = new System.Drawing.Point(79, 66);
            this.tbx_Model_Header.Name = "tbx_Model_Header";
            this.tbx_Model_Header.Size = new System.Drawing.Size(694, 21);
            this.tbx_Model_Header.TabIndex = 4;
            this.tbx_Model_Header.Text = "소비전류;소비전류Min;소비전류Max;소비전류 결과;전압검사;전압검사Min;전압검사Max;전압검사 결과;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "모델이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "관리자";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "헤더";
            // 
            // btn_GetModelList
            // 
            this.btn_GetModelList.Location = new System.Drawing.Point(10, 122);
            this.btn_GetModelList.Name = "btn_GetModelList";
            this.btn_GetModelList.Size = new System.Drawing.Size(169, 23);
            this.btn_GetModelList.TabIndex = 8;
            this.btn_GetModelList.Text = "Get Model List";
            this.btn_GetModelList.UseVisualStyleBackColor = true;
            this.btn_GetModelList.Click += new System.EventHandler(this.btn_GetModelList_Click);
            // 
            // cbb_ModelList
            // 
            this.cbb_ModelList.FormattingEnabled = true;
            this.cbb_ModelList.Location = new System.Drawing.Point(185, 125);
            this.cbb_ModelList.Name = "cbb_ModelList";
            this.cbb_ModelList.Size = new System.Drawing.Size(121, 20);
            this.cbb_ModelList.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbb_ModelList);
            this.Controls.Add(this.btn_GetModelList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Model_Header);
            this.Controls.Add(this.tbx_Model_UpdateUser);
            this.Controls.Add(this.tbx_Model_Name);
            this.Controls.Add(this.btn_AddModel);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_AddModel;
        private System.Windows.Forms.TextBox tbx_Model_Name;
        private System.Windows.Forms.TextBox tbx_Model_UpdateUser;
        private System.Windows.Forms.TextBox tbx_Model_Header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_GetModelList;
        private System.Windows.Forms.ComboBox cbb_ModelList;
    }
}

