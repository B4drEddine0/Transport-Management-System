namespace WindowsFormsApplication27
{
    partial class USER
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel_cover = new System.Windows.Forms.Panel();
            this.btn_vider = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_sortie = new System.Windows.Forms.Button();
            this.panel_slide = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel_cover.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel_logo.SuspendLayout();
            this.panel_slide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 69);
            this.panel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(470, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(402, 27);
            this.label10.TabIndex = 1;
            this.label10.Text = "Réinitialiser le nouveau mot de passe";
            // 
            // panel_cover
            // 
            this.panel_cover.Controls.Add(this.btn_vider);
            this.panel_cover.Controls.Add(this.btn_add);
            this.panel_cover.Controls.Add(this.pictureBox2);
            this.panel_cover.Controls.Add(this.label4);
            this.panel_cover.Controls.Add(this.label3);
            this.panel_cover.Controls.Add(this.txt_password);
            this.panel_cover.Controls.Add(this.txt_user);
            this.panel_cover.Controls.Add(this.panel1);
            this.panel_cover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cover.Location = new System.Drawing.Point(0, 0);
            this.panel_cover.Name = "panel_cover";
            this.panel_cover.Size = new System.Drawing.Size(1132, 603);
            this.panel_cover.TabIndex = 0;
            // 
            // btn_vider
            // 
            this.btn_vider.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_vider.BackColor = System.Drawing.Color.Orange;
            this.btn_vider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vider.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_vider.ForeColor = System.Drawing.Color.White;
            this.btn_vider.Location = new System.Drawing.Point(544, 426);
            this.btn_vider.Name = "btn_vider";
            this.btn_vider.Size = new System.Drawing.Size(106, 33);
            this.btn_vider.TabIndex = 91;
            this.btn_vider.Text = "Vider";
            this.btn_vider.UseVisualStyleBackColor = false;
            this.btn_vider.Click += new System.EventHandler(this.btn_vider_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.BackColor = System.Drawing.Color.Green;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(709, 426);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(106, 33);
            this.btn_add.TabIndex = 90;
            this.btn_add.Text = "Ajouter";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(536, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Mot De Pass :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(536, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Utilisateur :";
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(540, 339);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(275, 31);
            this.txt_password.TabIndex = 17;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Location = new System.Drawing.Point(540, 263);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(275, 31);
            this.txt_user.TabIndex = 16;
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.panel_cover);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1132, 603);
            this.panel_main.TabIndex = 5;
            // 
            // panel_logo
            // 
            this.panel_logo.BackColor = System.Drawing.Color.Navy;
            this.panel_logo.Controls.Add(this.label2);
            this.panel_logo.Controls.Add(this.pictureBox1);
            this.panel_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_logo.Location = new System.Drawing.Point(0, 0);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(214, 131);
            this.panel_logo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trans BadrEddine";
            // 
            // btn_sortie
            // 
            this.btn_sortie.BackColor = System.Drawing.Color.Navy;
            this.btn_sortie.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_sortie.FlatAppearance.BorderSize = 0;
            this.btn_sortie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sortie.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sortie.ForeColor = System.Drawing.Color.White;
            this.btn_sortie.Location = new System.Drawing.Point(0, 131);
            this.btn_sortie.Name = "btn_sortie";
            this.btn_sortie.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_sortie.Size = new System.Drawing.Size(214, 52);
            this.btn_sortie.TabIndex = 11;
            this.btn_sortie.Text = "Sortie";
            this.btn_sortie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sortie.UseVisualStyleBackColor = false;
            this.btn_sortie.Click += new System.EventHandler(this.btn_sortie_Click);
            // 
            // panel_slide
            // 
            this.panel_slide.AutoScroll = true;
            this.panel_slide.BackColor = System.Drawing.Color.Navy;
            this.panel_slide.Controls.Add(this.btn_sortie);
            this.panel_slide.Controls.Add(this.panel_logo);
            this.panel_slide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_slide.Location = new System.Drawing.Point(0, 0);
            this.panel_slide.Name = "panel_slide";
            this.panel_slide.Size = new System.Drawing.Size(214, 603);
            this.panel_slide.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication27.Properties.Resources.camion_de_marchandises;
            this.pictureBox1.Location = new System.Drawing.Point(-16, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication27.Properties.Resources.recuperation_de_donnees__1_;
            this.pictureBox2.Location = new System.Drawing.Point(588, 98);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // USER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 603);
            this.Controls.Add(this.panel_slide);
            this.Controls.Add(this.panel_main);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "USER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USER";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_cover.ResumeLayout(false);
            this.panel_cover.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            this.panel_logo.PerformLayout();
            this.panel_slide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel_cover;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_sortie;
        private System.Windows.Forms.Panel panel_slide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_vider;
    }
}