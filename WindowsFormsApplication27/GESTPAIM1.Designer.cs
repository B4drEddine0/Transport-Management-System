namespace WindowsFormsApplication27
{
    partial class GESTPAIM1
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
            this.date_paim = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cb_vyge = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cb_methode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cb_statut = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_prix = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_descrip = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox7 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox4 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox6 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_retour = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_vider = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_retour)).BeginInit();
            this.SuspendLayout();
            // 
            // date_paim
            // 
            this.date_paim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_paim.AutoRoundedCorners = true;
            this.date_paim.BorderRadius = 17;
            this.date_paim.Checked = true;
            this.date_paim.FillColor = System.Drawing.SystemColors.Control;
            this.date_paim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_paim.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.date_paim.Location = new System.Drawing.Point(360, 130);
            this.date_paim.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_paim.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_paim.Name = "date_paim";
            this.date_paim.Size = new System.Drawing.Size(217, 36);
            this.date_paim.TabIndex = 276;
            this.date_paim.Value = new System.DateTime(2024, 5, 31, 21, 56, 3, 62);
            // 
            // cb_vyge
            // 
            this.cb_vyge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_vyge.AutoRoundedCorners = true;
            this.cb_vyge.BackColor = System.Drawing.Color.Transparent;
            this.cb_vyge.BorderRadius = 17;
            this.cb_vyge.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_vyge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_vyge.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cb_vyge.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_vyge.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_vyge.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_vyge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_vyge.ItemHeight = 30;
            this.cb_vyge.Location = new System.Drawing.Point(360, 91);
            this.cb_vyge.Name = "cb_vyge";
            this.cb_vyge.Size = new System.Drawing.Size(217, 36);
            this.cb_vyge.TabIndex = 275;
            // 
            // cb_methode
            // 
            this.cb_methode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_methode.AutoRoundedCorners = true;
            this.cb_methode.BackColor = System.Drawing.Color.Transparent;
            this.cb_methode.BorderRadius = 17;
            this.cb_methode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_methode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_methode.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cb_methode.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_methode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_methode.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.cb_methode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_methode.ItemHeight = 30;
            this.cb_methode.Items.AddRange(new object[] {
            "Carte de Crédit",
            "Espèces",
            "Virement Bancaire",
            "Chèque",
            "Paiement Mobile"});
            this.cb_methode.Location = new System.Drawing.Point(360, 214);
            this.cb_methode.Name = "cb_methode";
            this.cb_methode.Size = new System.Drawing.Size(217, 36);
            this.cb_methode.TabIndex = 274;
            // 
            // cb_statut
            // 
            this.cb_statut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_statut.AutoRoundedCorners = true;
            this.cb_statut.BackColor = System.Drawing.Color.Transparent;
            this.cb_statut.BorderRadius = 17;
            this.cb_statut.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_statut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_statut.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cb_statut.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_statut.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_statut.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.cb_statut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_statut.ItemHeight = 30;
            this.cb_statut.Items.AddRange(new object[] {
            "Payé",
            "En Attente",
            "En Retard"});
            this.cb_statut.Location = new System.Drawing.Point(360, 295);
            this.cb_statut.Name = "cb_statut";
            this.cb_statut.Size = new System.Drawing.Size(217, 36);
            this.cb_statut.TabIndex = 273;
            // 
            // txt_prix
            // 
            this.txt_prix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_prix.AutoRoundedCorners = true;
            this.txt_prix.BorderRadius = 15;
            this.txt_prix.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_prix.DefaultText = "";
            this.txt_prix.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_prix.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_prix.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_prix.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_prix.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_prix.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_prix.FocusedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_prix.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.txt_prix.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_prix.Location = new System.Drawing.Point(360, 174);
            this.txt_prix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_prix.Name = "txt_prix";
            this.txt_prix.PasswordChar = '\0';
            this.txt_prix.PlaceholderText = "";
            this.txt_prix.SelectedText = "";
            this.txt_prix.Size = new System.Drawing.Size(217, 33);
            this.txt_prix.TabIndex = 271;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LawnGreen;
            this.label4.Location = new System.Drawing.Point(193, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 38);
            this.label4.TabIndex = 267;
            this.label4.Text = "Ajouter une Paiment";
            // 
            // txt_descrip
            // 
            this.txt_descrip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_descrip.AutoRoundedCorners = true;
            this.txt_descrip.BorderRadius = 15;
            this.txt_descrip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_descrip.DefaultText = "";
            this.txt_descrip.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_descrip.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_descrip.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_descrip.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_descrip.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_descrip.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_descrip.FocusedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txt_descrip.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.txt_descrip.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_descrip.Location = new System.Drawing.Point(360, 256);
            this.txt_descrip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_descrip.Name = "txt_descrip";
            this.txt_descrip.PasswordChar = '\0';
            this.txt_descrip.PlaceholderText = "";
            this.txt_descrip.SelectedText = "";
            this.txt_descrip.Size = new System.Drawing.Size(217, 33);
            this.txt_descrip.TabIndex = 283;
            // 
            // guna2TextBox7
            // 
            this.guna2TextBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox7.AutoRoundedCorners = true;
            this.guna2TextBox7.BorderRadius = 15;
            this.guna2TextBox7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox7.DefaultText = "Description";
            this.guna2TextBox7.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox7.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox7.Enabled = false;
            this.guna2TextBox7.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox7.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox7.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox7.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox7.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_description_64;
            this.guna2TextBox7.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox7.Location = new System.Drawing.Point(127, 256);
            this.guna2TextBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox7.Name = "guna2TextBox7";
            this.guna2TextBox7.PasswordChar = '\0';
            this.guna2TextBox7.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox7.PlaceholderText = "Poids";
            this.guna2TextBox7.SelectedText = "";
            this.guna2TextBox7.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox7.TabIndex = 284;
            this.guna2TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox4
            // 
            this.guna2TextBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox4.AutoRoundedCorners = true;
            this.guna2TextBox4.BorderRadius = 15;
            this.guna2TextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox4.DefaultText = "Statut";
            this.guna2TextBox4.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox4.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox4.Enabled = false;
            this.guna2TextBox4.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox4.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox4.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox4.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_statut_40;
            this.guna2TextBox4.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox4.Location = new System.Drawing.Point(127, 296);
            this.guna2TextBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox4.Name = "guna2TextBox4";
            this.guna2TextBox4.PasswordChar = '\0';
            this.guna2TextBox4.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox4.PlaceholderText = "Description";
            this.guna2TextBox4.SelectedText = "";
            this.guna2TextBox4.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox4.TabIndex = 282;
            this.guna2TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox6
            // 
            this.guna2TextBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox6.AutoRoundedCorners = true;
            this.guna2TextBox6.BorderRadius = 15;
            this.guna2TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox6.DefaultText = "Prix";
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
            this.guna2TextBox6.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_sac_d_argent_48;
            this.guna2TextBox6.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox6.Location = new System.Drawing.Point(127, 172);
            this.guna2TextBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox6.Name = "guna2TextBox6";
            this.guna2TextBox6.PasswordChar = '\0';
            this.guna2TextBox6.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox6.PlaceholderText = "Poids";
            this.guna2TextBox6.SelectedText = "";
            this.guna2TextBox6.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox6.TabIndex = 281;
            this.guna2TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.guna2TextBox3.Location = new System.Drawing.Point(127, 131);
            this.guna2TextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox3.Name = "guna2TextBox3";
            this.guna2TextBox3.PasswordChar = '\0';
            this.guna2TextBox3.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox3.PlaceholderText = "Description";
            this.guna2TextBox3.SelectedText = "";
            this.guna2TextBox3.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox3.TabIndex = 279;
            this.guna2TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox2.AutoRoundedCorners = true;
            this.guna2TextBox2.BorderRadius = 15;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "Methode";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox2.Enabled = false;
            this.guna2TextBox2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_carte_en_cours_d_utilisation_48;
            this.guna2TextBox2.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox2.Location = new System.Drawing.Point(127, 213);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox2.PlaceholderText = "Poids";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox2.TabIndex = 278;
            this.guna2TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2TextBox1.AutoRoundedCorners = true;
            this.guna2TextBox1.BorderRadius = 15;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "Voyage N°";
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
            this.guna2TextBox1.IconLeft = global::WindowsFormsApplication27.Properties.Resources.icons8_suivi_de_livraison_100;
            this.guna2TextBox1.IconLeftSize = new System.Drawing.Size(30, 30);
            this.guna2TextBox1.Location = new System.Drawing.Point(127, 92);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.guna2TextBox1.PlaceholderText = "Nature Produit";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(189, 33);
            this.guna2TextBox1.TabIndex = 277;
            this.guna2TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_retour
            // 
            this.btn_retour.BackColor = System.Drawing.Color.Transparent;
            this.btn_retour.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_retour_64;
            this.btn_retour.ImageRotate = 0F;
            this.btn_retour.Location = new System.Drawing.Point(2, 13);
            this.btn_retour.Name = "btn_retour";
            this.btn_retour.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_retour.Size = new System.Drawing.Size(90, 45);
            this.btn_retour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_retour.TabIndex = 270;
            this.btn_retour.TabStop = false;
            this.btn_retour.UseTransparentBackground = true;
            this.btn_retour.Click += new System.EventHandler(this.btn_retour_Click);
            // 
            // btn_vider
            // 
            this.btn_vider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_vider.AutoRoundedCorners = true;
            this.btn_vider.BorderRadius = 13;
            this.btn_vider.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_vider.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_vider.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_vider.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_vider.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_vider.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_vider.ForeColor = System.Drawing.Color.IndianRed;
            this.btn_vider.Image = global::WindowsFormsApplication27.Properties.Resources.icons8_effacer_48;
            this.btn_vider.Location = new System.Drawing.Point(419, 390);
            this.btn_vider.Name = "btn_vider";
            this.btn_vider.Size = new System.Drawing.Size(105, 29);
            this.btn_vider.TabIndex = 269;
            this.btn_vider.Text = "Vider";
            this.btn_vider.Click += new System.EventHandler(this.btn_vider_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btn_add.Location = new System.Drawing.Point(530, 390);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(105, 29);
            this.btn_add.TabIndex = 268;
            this.btn_add.Text = "Ajouter";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // GESTPAIM1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(661, 432);
            this.Controls.Add(this.guna2TextBox7);
            this.Controls.Add(this.txt_descrip);
            this.Controls.Add(this.guna2TextBox4);
            this.Controls.Add(this.guna2TextBox6);
            this.Controls.Add(this.guna2TextBox3);
            this.Controls.Add(this.guna2TextBox2);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.date_paim);
            this.Controls.Add(this.cb_vyge);
            this.Controls.Add(this.cb_methode);
            this.Controls.Add(this.cb_statut);
            this.Controls.Add(this.txt_prix);
            this.Controls.Add(this.btn_retour);
            this.Controls.Add(this.btn_vider);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GESTPAIM1";
            this.Text = "GESTPAIM1";
            this.Load += new System.EventHandler(this.GESTPAIM1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_retour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox4;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox6;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_paim;
        private Guna.UI2.WinForms.Guna2ComboBox cb_vyge;
        private Guna.UI2.WinForms.Guna2ComboBox cb_methode;
        private Guna.UI2.WinForms.Guna2ComboBox cb_statut;
        private Guna.UI2.WinForms.Guna2TextBox txt_prix;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btn_retour;
        private Guna.UI2.WinForms.Guna2Button btn_vider;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox7;
        private Guna.UI2.WinForms.Guna2TextBox txt_descrip;
    }
}