namespace WindowsFormsApplication27
{
    partial class GESTRAPCAM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_rech = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridView_rapcam = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btn_export = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btn_tous = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_rech = new Guna.UI2.WinForms.Guna2Button();
            this.btn_supp = new Guna.UI2.WinForms.Guna2Button();
            this.btn_modifier = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rapcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tous)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(-22, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 72);
            this.panel1.TabIndex = 239;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(266, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(369, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gestion Des Rappel Camion";
            // 
            // txt_rech
            // 
            this.txt_rech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rech.AutoRoundedCorners = true;
            this.txt_rech.BorderRadius = 11;
            this.txt_rech.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_rech.DefaultText = "";
            this.txt_rech.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_rech.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_rech.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_rech.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_rech.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_rech.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_rech.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_rech.Location = new System.Drawing.Point(615, 112);
            this.txt_rech.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_rech.Name = "txt_rech";
            this.txt_rech.PasswordChar = '\0';
            this.txt_rech.PlaceholderText = "";
            this.txt_rech.SelectedText = "";
            this.txt_rech.Size = new System.Drawing.Size(128, 25);
            this.txt_rech.TabIndex = 245;
            // 
            // dataGridView_rapcam
            // 
            this.dataGridView_rapcam.AllowUserToAddRows = false;
            this.dataGridView_rapcam.AllowUserToDeleteRows = false;
            this.dataGridView_rapcam.AllowUserToResizeColumns = false;
            this.dataGridView_rapcam.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView_rapcam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_rapcam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_rapcam.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_rapcam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_rapcam.ColumnHeadersHeight = 30;
            this.dataGridView_rapcam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_rapcam.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_rapcam.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_rapcam.Location = new System.Drawing.Point(7, 184);
            this.dataGridView_rapcam.MinimumSize = new System.Drawing.Size(883, 373);
            this.dataGridView_rapcam.MultiSelect = false;
            this.dataGridView_rapcam.Name = "dataGridView_rapcam";
            this.dataGridView_rapcam.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_rapcam.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_rapcam.RowHeadersVisible = false;
            this.dataGridView_rapcam.RowHeadersWidth = 51;
            this.dataGridView_rapcam.RowTemplate.Height = 24;
            this.dataGridView_rapcam.Size = new System.Drawing.Size(884, 373);
            this.dataGridView_rapcam.TabIndex = 240;
            this.dataGridView_rapcam.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_rapcam.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridView_rapcam.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView_rapcam.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView_rapcam.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView_rapcam.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_rapcam.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_rapcam.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView_rapcam.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_rapcam.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_rapcam.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView_rapcam.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView_rapcam.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridView_rapcam.ThemeStyle.ReadOnly = true;
            this.dataGridView_rapcam.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_rapcam.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView_rapcam.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_rapcam.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView_rapcam.ThemeStyle.RowsStyle.Height = 24;
            this.dataGridView_rapcam.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_rapcam.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btn_export
            // 
            this.btn_export.AutoRoundedCorners = true;
            this.btn_export.BorderRadius = 13;
            this.btn_export.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_export.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_export.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_export.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_export.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_export.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_export.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_microsoft_excel_2019_48;
            this.btn_export.ImageSize = new System.Drawing.Size(23, 23);
            this.btn_export.Location = new System.Drawing.Point(485, 137);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(141, 29);
            this.btn_export.TabIndex = 247;
            this.btn_export.Text = "Exporter";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_ligne_horizontale_64;
            this.btnMinimize.ImageSize = new System.Drawing.Size(70, 70);
            this.btnMinimize.Location = new System.Drawing.Point(856, -9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(70, 45);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btn_tous
            // 
            this.btn_tous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tous.BackColor = System.Drawing.Color.Transparent;
            this.btn_tous.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_refresh_button_64__1_;
            this.btn_tous.ImageRotate = 0F;
            this.btn_tous.Location = new System.Drawing.Point(570, 107);
            this.btn_tous.Name = "btn_tous";
            this.btn_tous.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_tous.Size = new System.Drawing.Size(35, 35);
            this.btn_tous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_tous.TabIndex = 246;
            this.btn_tous.TabStop = false;
            this.btn_tous.UseTransparentBackground = true;
            this.btn_tous.Click += new System.EventHandler(this.btn_tous_Click);
            // 
            // btn_rech
            // 
            this.btn_rech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rech.AutoRoundedCorners = true;
            this.btn_rech.BorderRadius = 13;
            this.btn_rech.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_rech.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_rech.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_rech.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_rech.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_rech.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rech.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_rech.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_chercher_48;
            this.btn_rech.Location = new System.Drawing.Point(753, 110);
            this.btn_rech.Name = "btn_rech";
            this.btn_rech.Size = new System.Drawing.Size(138, 29);
            this.btn_rech.TabIndex = 244;
            this.btn_rech.Text = "Recherche";
            this.btn_rech.Click += new System.EventHandler(this.btn_rech_Click);
            // 
            // btn_supp
            // 
            this.btn_supp.AutoRoundedCorners = true;
            this.btn_supp.BorderRadius = 13;
            this.btn_supp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_supp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_supp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_supp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_supp.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_supp.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_supp.ForeColor = System.Drawing.Color.Salmon;
            this.btn_supp.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_poubelle_48;
            this.btn_supp.ImageSize = new System.Drawing.Size(23, 23);
            this.btn_supp.Location = new System.Drawing.Point(310, 137);
            this.btn_supp.Name = "btn_supp";
            this.btn_supp.Size = new System.Drawing.Size(150, 29);
            this.btn_supp.TabIndex = 243;
            this.btn_supp.Text = "Supprimer";
            this.btn_supp.Click += new System.EventHandler(this.btn_supp_Click);
            // 
            // btn_modifier
            // 
            this.btn_modifier.AutoRoundedCorners = true;
            this.btn_modifier.BorderRadius = 13;
            this.btn_modifier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_modifier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_modifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_modifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_modifier.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_modifier.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modifier.ForeColor = System.Drawing.Color.Orange;
            this.btn_modifier.Image = global::WindowsFormsApplication27.Properties.Resources.modify;
            this.btn_modifier.Location = new System.Drawing.Point(170, 137);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(113, 29);
            this.btn_modifier.TabIndex = 242;
            this.btn_modifier.Text = "Modifier";
            this.btn_modifier.Click += new System.EventHandler(this.btn_modifier_Click);
            // 
            // btn_add
            // 
            this.btn_add.AutoRoundedCorners = true;
            this.btn_add.BorderRadius = 13;
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_add.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.Green;
            this.btn_add.Image = global::WindowsFormsApplication27.Properties.Resources.add;
            this.btn_add.Location = new System.Drawing.Point(30, 137);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(105, 29);
            this.btn_add.TabIndex = 241;
            this.btn_add.Text = "Ajouter";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // GESTRAPCAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 556);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_tous);
            this.Controls.Add(this.txt_rech);
            this.Controls.Add(this.btn_rech);
            this.Controls.Add(this.btn_supp);
            this.Controls.Add(this.btn_modifier);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dataGridView_rapcam);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GESTRAPCAM";
            this.Text = "GESTRAPCAM";
            this.Load += new System.EventHandler(this.GESTRAPCAM_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rapcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tous)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btn_tous;
        private Guna.UI2.WinForms.Guna2TextBox txt_rech;
        private Guna.UI2.WinForms.Guna2Button btn_rech;
        private Guna.UI2.WinForms.Guna2Button btn_supp;
        private Guna.UI2.WinForms.Guna2Button btn_modifier;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView_rapcam;
        private Guna.UI2.WinForms.Guna2Button btn_export;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
    }
}