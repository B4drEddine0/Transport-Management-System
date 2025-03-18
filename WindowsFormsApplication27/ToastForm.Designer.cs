namespace WindowsFormsApplication27
{
    partial class ToastForm
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
            this.pnltoast = new System.Windows.Forms.Panel();
            this.lbtype = new System.Windows.Forms.Label();
            this.lbmsg = new System.Windows.Forms.Label();
            this.timertoast = new System.Windows.Forms.Timer(this.components);
            this.timerhide = new System.Windows.Forms.Timer(this.components);
            this.pctoast = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctoast)).BeginInit();
            this.SuspendLayout();
            // 
            // pnltoast
            // 
            this.pnltoast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(155)))), ((int)(((byte)(53)))));
            this.pnltoast.Location = new System.Drawing.Point(-13, -3);
            this.pnltoast.Name = "pnltoast";
            this.pnltoast.Size = new System.Drawing.Size(19, 69);
            this.pnltoast.TabIndex = 0;
            // 
            // lbtype
            // 
            this.lbtype.AutoSize = true;
            this.lbtype.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtype.Location = new System.Drawing.Point(46, 7);
            this.lbtype.Name = "lbtype";
            this.lbtype.Size = new System.Drawing.Size(57, 23);
            this.lbtype.TabIndex = 2;
            this.lbtype.Text = "Type";
            // 
            // lbmsg
            // 
            this.lbmsg.AutoSize = true;
            this.lbmsg.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmsg.Location = new System.Drawing.Point(48, 32);
            this.lbmsg.Name = "lbmsg";
            this.lbmsg.Size = new System.Drawing.Size(97, 17);
            this.lbmsg.TabIndex = 3;
            this.lbmsg.Text = "Toast Message";
            // 
            // timertoast
            // 
            this.timertoast.Enabled = true;
            this.timertoast.Interval = 10;
            this.timertoast.Tick += new System.EventHandler(this.timertoast_Tick);
            // 
            // timerhide
            // 
            this.timerhide.Interval = 10;
            this.timerhide.Tick += new System.EventHandler(this.timerhide_Tick);
            // 
            // pctoast
            // 
            this.pctoast.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_ok_48;
            this.pctoast.Location = new System.Drawing.Point(18, 12);
            this.pctoast.Name = "pctoast";
            this.pctoast.Size = new System.Drawing.Size(25, 25);
            this.pctoast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctoast.TabIndex = 1;
            this.pctoast.TabStop = false;
            this.pctoast.Click += new System.EventHandler(this.pctoast_Click);
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 59);
            this.Controls.Add(this.lbmsg);
            this.Controls.Add(this.lbtype);
            this.Controls.Add(this.pctoast);
            this.Controls.Add(this.pnltoast);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToastForm";
            this.Text = "ToastForm";
            this.Load += new System.EventHandler(this.ToastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctoast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnltoast;
        private System.Windows.Forms.PictureBox pctoast;
        private System.Windows.Forms.Label lbtype;
        private System.Windows.Forms.Label lbmsg;
        private System.Windows.Forms.Timer timertoast;
        private System.Windows.Forms.Timer timerhide;
    }
}