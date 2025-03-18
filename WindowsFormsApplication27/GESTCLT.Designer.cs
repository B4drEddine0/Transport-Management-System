namespace WindowsFormsApplication27
{
    partial class GESTCLT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView_clt = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txt_rech = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_export = new Guna.UI2.WinForms.Guna2Button();
            this.btn_tous = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_rech = new Guna.UI2.WinForms.Guna2Button();
            this.btn_supprimer = new Guna.UI2.WinForms.Guna2Button();
            this.btn_mod = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tous)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_clt
            // 
            this.dataGridView_clt.AllowUserToAddRows = false;
            this.dataGridView_clt.AllowUserToDeleteRows = false;
            this.dataGridView_clt.AllowUserToResizeColumns = false;
            this.dataGridView_clt.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dataGridView_clt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_clt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_clt.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_clt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_clt.ColumnHeadersHeight = 30;
            this.dataGridView_clt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_clt.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView_clt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_clt.Location = new System.Drawing.Point(8, 178);
            this.dataGridView_clt.MultiSelect = false;
            this.dataGridView_clt.Name = "dataGridView_clt";
            this.dataGridView_clt.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_clt.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView_clt.RowHeadersVisible = false;
            this.dataGridView_clt.RowHeadersWidth = 51;
            this.dataGridView_clt.RowTemplate.Height = 24;
            this.dataGridView_clt.Size = new System.Drawing.Size(883, 378);
            this.dataGridView_clt.TabIndex = 173;
            this.dataGridView_clt.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_clt.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridView_clt.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView_clt.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView_clt.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView_clt.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_clt.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_clt.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView_clt.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_clt.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_clt.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView_clt.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView_clt.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridView_clt.ThemeStyle.ReadOnly = true;
            this.dataGridView_clt.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_clt.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView_clt.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_clt.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView_clt.ThemeStyle.RowsStyle.Height = 24;
            this.dataGridView_clt.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_clt.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            this.txt_rech.Location = new System.Drawing.Point(592, 99);
            this.txt_rech.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_rech.Name = "txt_rech";
            this.txt_rech.PasswordChar = '\0';
            this.txt_rech.PlaceholderText = "";
            this.txt_rech.SelectedText = "";
            this.txt_rech.Size = new System.Drawing.Size(128, 25);
            this.txt_rech.TabIndex = 175;
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
            this.btn_export.Location = new System.Drawing.Point(499, 129);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(141, 29);
            this.btn_export.TabIndex = 208;
            this.btn_export.Text = "Exporter";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_tous
            // 
            this.btn_tous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tous.BackColor = System.Drawing.Color.Transparent;
            this.btn_tous.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_refresh_button_64__1_;
            this.btn_tous.ImageRotate = 0F;
            this.btn_tous.Location = new System.Drawing.Point(547, 94);
            this.btn_tous.Name = "btn_tous";
            this.btn_tous.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_tous.Size = new System.Drawing.Size(35, 35);
            this.btn_tous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_tous.TabIndex = 203;
            this.btn_tous.TabStop = false;
            this.btn_tous.UseTransparentBackground = true;
            this.btn_tous.Click += new System.EventHandler(this.btn_tous_Click_1);
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
            this.btn_rech.Location = new System.Drawing.Point(733, 97);
            this.btn_rech.Name = "btn_rech";
            this.btn_rech.Size = new System.Drawing.Size(138, 29);
            this.btn_rech.TabIndex = 174;
            this.btn_rech.Text = "Recherche";
            this.btn_rech.Click += new System.EventHandler(this.btn_rech_Click);
            // 
            // btn_supprimer
            // 
            this.btn_supprimer.AutoRoundedCorners = true;
            this.btn_supprimer.BorderRadius = 13;
            this.btn_supprimer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_supprimer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_supprimer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_supprimer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_supprimer.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_supprimer.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_supprimer.ForeColor = System.Drawing.Color.Salmon;
            this.btn_supprimer.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_poubelle_48;
            this.btn_supprimer.ImageSize = new System.Drawing.Size(23, 23);
            this.btn_supprimer.Location = new System.Drawing.Point(325, 129);
            this.btn_supprimer.Name = "btn_supprimer";
            this.btn_supprimer.Size = new System.Drawing.Size(150, 29);
            this.btn_supprimer.TabIndex = 172;
            this.btn_supprimer.Text = "Supprimer";
            this.btn_supprimer.Click += new System.EventHandler(this.btn_supprimer_Click);
            // 
            // btn_mod
            // 
            this.btn_mod.AutoRoundedCorners = true;
            this.btn_mod.BorderRadius = 13;
            this.btn_mod.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_mod.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_mod.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_mod.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_mod.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_mod.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mod.ForeColor = System.Drawing.Color.Orange;
            this.btn_mod.Image = global::WindowsFormsApplication27.Properties.Resources.modify;
            this.btn_mod.Location = new System.Drawing.Point(185, 129);
            this.btn_mod.Name = "btn_mod";
            this.btn_mod.Size = new System.Drawing.Size(113, 29);
            this.btn_mod.TabIndex = 171;
            this.btn_mod.Text = "Modifier";
            this.btn_mod.Click += new System.EventHandler(this.btn_mod_Click_1);
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
            this.btn_add.Location = new System.Drawing.Point(45, 129);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(105, 29);
            this.btn_add.TabIndex = 170;
            this.btn_add.Text = "Ajouter";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(327, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gestion Des Client";
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 72);
            this.panel1.TabIndex = 84;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_ligne_horizontale_64;
            this.btnMinimize.ImageSize = new System.Drawing.Size(70, 70);
            this.btnMinimize.Location = new System.Drawing.Point(840, -10);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(66, 47);
            this.btnMinimize.TabIndex = 209;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click_1);
            // 
            // GESTCLT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 556);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_tous);
            this.Controls.Add(this.txt_rech);
            this.Controls.Add(this.btn_rech);
            this.Controls.Add(this.dataGridView_clt);
            this.Controls.Add(this.btn_supprimer);
            this.Controls.Add(this.btn_mod);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GESTCLT";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GESTCLT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tous)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2Button btn_mod;
        private Guna.UI2.WinForms.Guna2Button btn_supprimer;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView_clt;
        private Guna.UI2.WinForms.Guna2Button btn_rech;
        private Guna.UI2.WinForms.Guna2TextBox txt_rech;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btn_tous;
        private Guna.UI2.WinForms.Guna2Button btn_export;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
    }
}

