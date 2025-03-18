namespace WindowsFormsApplication27
{
    partial class GESTRAPCH2
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
            this.label4 = new System.Windows.Forms.Label();
            this.date_rap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cb_chauff = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_descript = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_num = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox6 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox5 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_mod = new Guna.UI2.WinForms.Guna2Button();
            this.btn_retour = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_retour)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(171, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 38);
            this.label4.TabIndex = 335;
            this.label4.Text = "Mettre à jour Rappel";
            // 
            // date_rap
            // 
            this.date_rap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_rap.AutoRoundedCorners = true;
            this.date_rap.BorderRadius = 17;
            this.date_rap.Checked = true;
            this.date_rap.FillColor = System.Drawing.SystemColors.Control;
            this.date_rap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_rap.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.date_rap.Location = new System.Drawing.Point(338, 110);
            this.date_rap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_rap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_rap.Name = "date_rap";
            this.date_rap.Size = new System.Drawing.Size(217, 36);
            this.date_rap.TabIndex = 341;
            this.date_rap.Value = new System.DateTime(2024, 5, 31, 21, 56, 3, 62);
            // 
            // cb_chauff
            // 
            this.cb_chauff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_chauff.AutoRoundedCorners = true;
            this.cb_chauff.BackColor = System.Drawing.Color.Transparent;
            this.cb_chauff.BorderRadius = 17;
            this.cb_chauff.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_chauff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_chauff.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cb_chauff.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_chauff.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_chauff.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_chauff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_chauff.ItemHeight = 30;
            this.cb_chauff.Location = new System.Drawing.Point(338, 152);
            this.cb_chauff.Name = "cb_chauff";
            this.cb_chauff.Size = new System.Drawing.Size(217, 36);
            this.cb_chauff.TabIndex = 340;
            this.cb_chauff.SelectedIndexChanged += new System.EventHandler(this.cb_chauff_SelectedIndexChanged);
            // 
            // txt_descript
            // 
            this.txt_descript.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_descript.AutoRoundedCorners = true;
            this.txt_descript.BorderRadius = 15;
            this.txt_descript.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_descript.DefaultText = "";
            this.txt_descript.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_descript.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_descript.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_descript.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_descript.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_descript.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_descript.FocusedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_descript.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.txt_descript.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_descript.Location = new System.Drawing.Point(338, 195);
            this.txt_descript.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_descript.Name = "txt_descript";
            this.txt_descript.PasswordChar = '\0';
            this.txt_descript.PlaceholderText = "";
            this.txt_descript.SelectedText = "";
            this.txt_descript.Size = new System.Drawing.Size(217, 33);
            this.txt_descript.TabIndex = 338;
            // 
            // txt_num
            // 
            this.txt_num.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_num.AutoRoundedCorners = true;
            this.txt_num.BorderRadius = 15;
            this.txt_num.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_num.DefaultText = "";
            this.txt_num.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_num.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_num.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_num.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_num.Enabled = false;
            this.txt_num.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_num.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_num.FocusedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_num.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.txt_num.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_num.Location = new System.Drawing.Point(338, 236);
            this.txt_num.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_num.Name = "txt_num";
            this.txt_num.PasswordChar = '\0';
            this.txt_num.PlaceholderText = "";
            this.txt_num.SelectedText = "";
            this.txt_num.Size = new System.Drawing.Size(217, 33);
            this.txt_num.TabIndex = 346;
            // 
            // guna2TextBox6
            // 
            this.guna2TextBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox6.AutoRoundedCorners = true;
            this.guna2TextBox6.BorderRadius = 15;
            this.guna2TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox6.DefaultText = "Description";
            this.guna2TextBox6.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox6.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox6.Enabled = false;
            this.guna2TextBox6.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox6.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox6.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox6.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_réservation_2_48;
            this.guna2TextBox6.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox6.Location = new System.Drawing.Point(109, 197);
            this.guna2TextBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox6.Name = "guna2TextBox6";
            this.guna2TextBox6.PasswordChar = '\0';
            this.guna2TextBox6.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox6.PlaceholderText = "Poids";
            this.guna2TextBox6.SelectedText = "";
            this.guna2TextBox6.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox6.TabIndex = 345;
            this.guna2TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox5
            // 
            this.guna2TextBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox5.AutoRoundedCorners = true;
            this.guna2TextBox5.BorderRadius = 15;
            this.guna2TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox5.DefaultText = "Num";
            this.guna2TextBox5.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox5.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox5.Enabled = false;
            this.guna2TextBox5.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox5.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox5.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox5.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_liste_48;
            this.guna2TextBox5.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox5.Location = new System.Drawing.Point(109, 238);
            this.guna2TextBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox5.Name = "guna2TextBox5";
            this.guna2TextBox5.PasswordChar = '\0';
            this.guna2TextBox5.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox5.PlaceholderText = "Numero";
            this.guna2TextBox5.SelectedText = "";
            this.guna2TextBox5.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox5.TabIndex = 344;
            this.guna2TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox3
            // 
            this.guna2TextBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox3.AutoRoundedCorners = true;
            this.guna2TextBox3.BorderRadius = 15;
            this.guna2TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox3.DefaultText = "Date";
            this.guna2TextBox3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox3.Enabled = false;
            this.guna2TextBox3.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox3.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_histoire_48;
            this.guna2TextBox3.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox3.Location = new System.Drawing.Point(109, 114);
            this.guna2TextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox3.Name = "guna2TextBox3";
            this.guna2TextBox3.PasswordChar = '\0';
            this.guna2TextBox3.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox3.PlaceholderText = "Description";
            this.guna2TextBox3.SelectedText = "";
            this.guna2TextBox3.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox3.TabIndex = 343;
            this.guna2TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox1.AutoRoundedCorners = true;
            this.guna2TextBox1.BorderRadius = 15;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "Chauffeur";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox1.Enabled = false;
            this.guna2TextBox1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_chauffeur_40;
            this.guna2TextBox1.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox1.Location = new System.Drawing.Point(109, 156);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox1.PlaceholderText = "Voyage N°";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox1.TabIndex = 342;
            this.guna2TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_mod
            // 
            this.btn_mod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mod.AutoRoundedCorners = true;
            this.btn_mod.BorderRadius = 18;
            this.btn_mod.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_mod.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_mod.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_mod.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_mod.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_mod.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mod.ForeColor = System.Drawing.Color.Orange;
            this.btn_mod.Image = global::WindowsFormsApplication27.Properties.Resources.modify;
            this.btn_mod.Location = new System.Drawing.Point(481, 320);
            this.btn_mod.Name = "btn_mod";
            this.btn_mod.Size = new System.Drawing.Size(138, 39);
            this.btn_mod.TabIndex = 337;
            this.btn_mod.Text = "Modifier";
            this.btn_mod.Click += new System.EventHandler(this.btn_mod_Click);
            // 
            // btn_retour
            // 
            this.btn_retour.BackColor = System.Drawing.Color.Transparent;
            this.btn_retour.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_retour_64;
            this.btn_retour.ImageRotate = 0F;
            this.btn_retour.Location = new System.Drawing.Point(11, 11);
            this.btn_retour.Name = "btn_retour";
            this.btn_retour.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_retour.Size = new System.Drawing.Size(90, 45);
            this.btn_retour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_retour.TabIndex = 336;
            this.btn_retour.TabStop = false;
            this.btn_retour.UseTransparentBackground = true;
            this.btn_retour.Click += new System.EventHandler(this.btn_retour_Click);
            // 
            // GESTRAPCH2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(643, 385);
            this.Controls.Add(this.txt_num);
            this.Controls.Add(this.guna2TextBox6);
            this.Controls.Add(this.guna2TextBox5);
            this.Controls.Add(this.guna2TextBox3);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.date_rap);
            this.Controls.Add(this.cb_chauff);
            this.Controls.Add(this.txt_descript);
            this.Controls.Add(this.btn_mod);
            this.Controls.Add(this.btn_retour);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GESTRAPCH2";
            this.Text = "GESTRAPCH2";
            this.Load += new System.EventHandler(this.GESTRAPCH2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_retour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_mod;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btn_retour;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox6;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox5;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_rap;
        private Guna.UI2.WinForms.Guna2ComboBox cb_chauff;
        private Guna.UI2.WinForms.Guna2TextBox txt_descript;
        private Guna.UI2.WinForms.Guna2TextBox txt_num;
    }
}