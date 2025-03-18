namespace WindowsFormsApplication27
{
    partial class ERRORFORM
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
            this.pnl = new System.Windows.Forms.Panel();
            this.lbmsg = new System.Windows.Forms.Label();
            this.lbtype = new System.Windows.Forms.Label();
            this.btn_ok = new Guna.UI2.WinForms.Guna2Button();
            this.pctoast = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctoast)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Red;
            this.pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(400, 18);
            this.pnl.TabIndex = 0;
            // 
            // lbmsg
            // 
            this.lbmsg.AutoSize = true;
            this.lbmsg.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmsg.Location = new System.Drawing.Point(82, 64);
            this.lbmsg.Name = "lbmsg";
            this.lbmsg.Size = new System.Drawing.Size(97, 17);
            this.lbmsg.TabIndex = 6;
            this.lbmsg.Text = "Toast Message";
            // 
            // lbtype
            // 
            this.lbtype.AutoSize = true;
            this.lbtype.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtype.Location = new System.Drawing.Point(80, 31);
            this.lbtype.Name = "lbtype";
            this.lbtype.Size = new System.Drawing.Size(79, 33);
            this.lbtype.TabIndex = 5;
            this.lbtype.Text = "Type";
            // 
            // btn_ok
            // 
            this.btn_ok.AutoRoundedCorners = true;
            this.btn_ok.BorderRadius = 15;
            this.btn_ok.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ok.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ok.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ok.FillColor = System.Drawing.Color.OrangeRed;
            this.btn_ok.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(263, 162);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(121, 32);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "Compris";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pctoast
            // 
            this.pctoast.Image = global::WindowsFormsApplication27.Properties.Resources.attention_48;
            this.pctoast.Location = new System.Drawing.Point(30, 37);
            this.pctoast.Name = "pctoast";
            this.pctoast.Size = new System.Drawing.Size(53, 47);
            this.pctoast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctoast.TabIndex = 4;
            this.pctoast.TabStop = false;
            // 
            // ERRORFORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbmsg);
            this.Controls.Add(this.lbtype);
            this.Controls.Add(this.pctoast);
            this.Controls.Add(this.pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ERRORFORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERRORFORM";
            this.Load += new System.EventHandler(this.ERRORFORM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctoast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lbmsg;
        private System.Windows.Forms.Label lbtype;
        private System.Windows.Forms.PictureBox pctoast;
        private Guna.UI2.WinForms.Guna2Button btn_ok;
    }
}