namespace WindowsFormsApplication27
{
    partial class GESTFACTURE
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.cbVoyage = new System.Windows.Forms.ComboBox();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.factureinternational3 = new WindowsFormsApplication27.factureinternational();
            this.factureinternational2 = new WindowsFormsApplication27.factureinternational();
            this.factureinternational1 = new WindowsFormsApplication27.factureinternational();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(900, 556);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Location = new System.Drawing.Point(25, 252);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(151, 31);
            this.btnLoadReport.TabIndex = 2;
            this.btnLoadReport.Text = "Rechercher";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // cbVoyage
            // 
            this.cbVoyage.FormattingEnabled = true;
            this.cbVoyage.Location = new System.Drawing.Point(60, 192);
            this.cbVoyage.Name = "cbVoyage";
            this.cbVoyage.Size = new System.Drawing.Size(66, 31);
            this.cbVoyage.TabIndex = 3;
            this.cbVoyage.SelectedIndexChanged += new System.EventHandler(this.cbVoyage_SelectedIndexChanged);
            // 
            // cbtype
            // 
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Items.AddRange(new object[] {
            "National",
            "International"});
            this.cbtype.Location = new System.Drawing.Point(21, 104);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(151, 31);
            this.cbtype.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type de Facture : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Num de Voyage : ";
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = 0;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.ReportSource = this.factureinternational3;
            this.crystalReportViewer2.Size = new System.Drawing.Size(900, 556);
            this.crystalReportViewer2.TabIndex = 1;
            this.crystalReportViewer2.Load += new System.EventHandler(this.crystalReportViewer2_Load);
            // 
            // GESTFACTURE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 556);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbtype);
            this.Controls.Add(this.cbVoyage);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.crystalReportViewer1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GESTFACTURE";
            this.Text = "GESTFACTURE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
      //  private facturenational facturenational1;
      //  private facturenational facturenational2;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.ComboBox cbVoyage;
       // private WindowsFormsApplication27.facturenational facturenational1;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private factureinternational factureinternational2;
        private factureinternational factureinternational1;
        private factureinternational factureinternational3;
        //  private factureinternational factureinternational1;
        //  private facturenational facturenational3;
    }
}