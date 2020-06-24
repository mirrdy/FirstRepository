namespace ReportProgram
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.btn_DataManage = new System.Windows.Forms.Button();
            this.btn_Monitor = new System.Windows.Forms.Button();
            this.btn_Set = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Center = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_DataManage
            // 
            this.btn_DataManage.Image = ((System.Drawing.Image)(resources.GetObject("btn_DataManage.Image")));
            this.btn_DataManage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_DataManage.Location = new System.Drawing.Point(114, 3);
            this.btn_DataManage.Name = "btn_DataManage";
            this.btn_DataManage.Size = new System.Drawing.Size(105, 66);
            this.btn_DataManage.TabIndex = 2;
            this.btn_DataManage.Text = "검사 데이터 관리";
            this.btn_DataManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_DataManage.UseVisualStyleBackColor = true;
            this.btn_DataManage.Click += new System.EventHandler(this.btn_DataManage_Click);
            // 
            // btn_Monitor
            // 
            this.btn_Monitor.Image = ((System.Drawing.Image)(resources.GetObject("btn_Monitor.Image")));
            this.btn_Monitor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Monitor.Location = new System.Drawing.Point(3, 3);
            this.btn_Monitor.Name = "btn_Monitor";
            this.btn_Monitor.Size = new System.Drawing.Size(105, 66);
            this.btn_Monitor.TabIndex = 3;
            this.btn_Monitor.Text = "공정 모니터링";
            this.btn_Monitor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Monitor.UseVisualStyleBackColor = true;
            this.btn_Monitor.Click += new System.EventHandler(this.btn_Monitor_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.Image = ((System.Drawing.Image)(resources.GetObject("btn_Set.Image")));
            this.btn_Set.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Set.Location = new System.Drawing.Point(225, 3);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(105, 66);
            this.btn_Set.TabIndex = 4;
            this.btn_Set.Text = "환경설정";
            this.btn_Set.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Monitor);
            this.panel1.Controls.Add(this.btn_Set);
            this.panel1.Controls.Add(this.btn_DataManage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 72);
            this.panel1.TabIndex = 5;
            // 
            // pnl_Center
            // 
            this.pnl_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Center.Location = new System.Drawing.Point(0, 72);
            this.pnl_Center.Name = "pnl_Center";
            this.pnl_Center.Size = new System.Drawing.Size(1305, 634);
            this.pnl_Center.TabIndex = 6;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 706);
            this.Controls.Add(this.pnl_Center);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Main";
            this.Text = "Inno Report - by innocontact";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.Resize += new System.EventHandler(this.frm_Main_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_DataManage;
        private System.Windows.Forms.Button btn_Monitor;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Center;
    }
}

