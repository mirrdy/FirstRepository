
namespace ReportProgram
{
    partial class frm_DetailData
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgv_DetailData = new System.Windows.Forms.DataGridView();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayChart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cht_DetailData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DetailData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_DetailData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DetailData
            // 
            this.dgv_DetailData.AllowUserToAddRows = false;
            this.dgv_DetailData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DetailData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Min,
            this.Avg,
            this.Max,
            this.displayChart});
            this.dgv_DetailData.Location = new System.Drawing.Point(12, 12);
            this.dgv_DetailData.Name = "dgv_DetailData";
            this.dgv_DetailData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_DetailData.RowTemplate.Height = 23;
            this.dgv_DetailData.Size = new System.Drawing.Size(1247, 292);
            this.dgv_DetailData.TabIndex = 0;
            this.dgv_DetailData.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_DetailData_CurrentCellDirtyStateChanged);
            // 
            // Min
            // 
            this.Min.HeaderText = "최소";
            this.Min.Name = "Min";
            this.Min.ReadOnly = true;
            // 
            // Avg
            // 
            this.Avg.HeaderText = "평균";
            this.Avg.Name = "Avg";
            this.Avg.ReadOnly = true;
            // 
            // Max
            // 
            this.Max.HeaderText = "최대";
            this.Max.Name = "Max";
            this.Max.ReadOnly = true;
            // 
            // displayChart
            // 
            this.displayChart.HeaderText = "차트에 표시";
            this.displayChart.Name = "displayChart";
            this.displayChart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.displayChart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cht_DetailData
            // 
            chartArea1.Name = "ChartArea1";
            this.cht_DetailData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cht_DetailData.Legends.Add(legend1);
            this.cht_DetailData.Location = new System.Drawing.Point(12, 310);
            this.cht_DetailData.Name = "cht_DetailData";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.cht_DetailData.Series.Add(series1);
            this.cht_DetailData.Size = new System.Drawing.Size(1247, 296);
            this.cht_DetailData.TabIndex = 1;
            this.cht_DetailData.Text = "chart1";
            this.cht_DetailData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cht_DetailData_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1154, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // frm_DetailData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 618);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cht_DetailData);
            this.Controls.Add(this.dgv_DetailData);
            this.Name = "frm_DetailData";
            this.Text = "frm_DetailData";
            this.Load += new System.EventHandler(this.frm_DetailData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DetailData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_DetailData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DetailData;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_DetailData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private System.Windows.Forms.DataGridViewCheckBoxColumn displayChart;
    }
}