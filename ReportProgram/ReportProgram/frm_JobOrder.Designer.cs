namespace ReportProgram
{
    partial class frm_JobOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_JobOrder));
            this.pnl_SlideShow_State = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbx_JobOrder = new System.Windows.Forms.PictureBox();
            this.tmr_JobOrder = new System.Windows.Forms.Timer(this.components);
            this.pbx_Control = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_JobOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Control)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_SlideShow_State
            // 
            this.pnl_SlideShow_State.BackColor = System.Drawing.Color.LightGreen;
            this.pnl_SlideShow_State.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_SlideShow_State.Location = new System.Drawing.Point(0, 0);
            this.pnl_SlideShow_State.Name = "pnl_SlideShow_State";
            this.pnl_SlideShow_State.Size = new System.Drawing.Size(800, 3);
            this.pnl_SlideShow_State.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbx_Control);
            this.panel1.Controls.Add(this.pbx_JobOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 559);
            this.panel1.TabIndex = 14;
            // 
            // pbx_JobOrder
            // 
            this.pbx_JobOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_JobOrder.Image = global::ReportProgram.Properties.Resources.default_image;
            this.pbx_JobOrder.Location = new System.Drawing.Point(0, 0);
            this.pbx_JobOrder.Name = "pbx_JobOrder";
            this.pbx_JobOrder.Size = new System.Drawing.Size(800, 559);
            this.pbx_JobOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_JobOrder.TabIndex = 0;
            this.pbx_JobOrder.TabStop = false;
            this.pbx_JobOrder.Click += new System.EventHandler(this.pbx_JobOrder_Click);
            this.pbx_JobOrder.MouseLeave += new System.EventHandler(this.pbx_JobOrder_MouseLeave);
            this.pbx_JobOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbx_JobOrder_MouseMove);
            // 
            // tmr_JobOrder
            // 
            this.tmr_JobOrder.Interval = 10;
            this.tmr_JobOrder.Tick += new System.EventHandler(this.tmr_JobOrder_Tick);
            // 
            // pbx_Control
            // 
            this.pbx_Control.BackColor = System.Drawing.SystemColors.Control;
            this.pbx_Control.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Control.Image")));
            this.pbx_Control.Location = new System.Drawing.Point(364, 243);
            this.pbx_Control.Name = "pbx_Control";
            this.pbx_Control.Size = new System.Drawing.Size(72, 72);
            this.pbx_Control.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_Control.TabIndex = 1;
            this.pbx_Control.TabStop = false;
            this.pbx_Control.Visible = false;
            this.pbx_Control.Click += new System.EventHandler(this.pbx_JobOrder_Click);
            this.pbx_Control.MouseLeave += new System.EventHandler(this.pbx_JobOrder_MouseLeave);
            this.pbx_Control.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbx_JobOrder_MouseMove);
            // 
            // frm_JobOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_SlideShow_State);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_JobOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_JogOrder";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_JobOrder_FormClosed);
            this.Load += new System.EventHandler(this.frm_JobOrder_Load);
            this.Resize += new System.EventHandler(this.frm_JobOrder_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_JobOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Control)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_SlideShow_State;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbx_JobOrder;
        private System.Windows.Forms.Timer tmr_JobOrder;
        private System.Windows.Forms.PictureBox pbx_Control;
    }
}