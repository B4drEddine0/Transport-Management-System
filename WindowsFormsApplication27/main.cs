using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication27
{
    public partial class main : Form
    {
        private string username;
        private Color selectedColor;
        public main(string username)
        {
            InitializeComponent();
            customizeDesign(); //bach kykhlli lmenu msdoud
            UpdateRecordCounts(); //bach kayupdater les valeur 
            this.username = username;
            label_user.Text = username; //n2afichi user f label
            LoadReminders();

            InitializeDateTimeLabel();
            // Set the date to French
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");

            // Initialize the minimize button
            Button btnMinimize = new Button();
            btnMinimize.Text = "_";
            btnMinimize.Size = new System.Drawing.Size(30, 30);
            btnMinimize.Location = new System.Drawing.Point(this.Width - 50, 10); // Adjust the location as needed
            btnMinimize.Click += new EventHandler(btnMinimize_Click);

            // Add the minimize button to the form
            this.Controls.Add(btnMinimize);


            cb_color.SelectedItem = "Navy"; // Set initial value

            // Initialize selectedColor
            selectedColor = Color.FromName(cb_color.SelectedItem.ToString());

            // Set the initial color of panel1 based on the combobox value
            panel2.BackColor = selectedColor;

            label10.ForeColor = Color.FromArgb(0, 81, 200);
            label8.ForeColor = Color.FromArgb(0, 81, 200);


            
            panel_slide.BorderStyle = BorderStyle.FixedSingle; // or BorderStyle.Fixed3D
            panel_slide.Padding = new Padding(7); // Adjust padding as needed
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Padding = new Padding(7);

            this.DoubleBuffered = true;

            this.Refresh();

        }
        Class1 c = new Class1();
        private void customizeDesign()
        {
            panel_tables.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            btn_retour.Visible = false;
            label_setting.Visible = false;
            pictureBox_settings.Visible = false;
            btn_chauff.Visible = false;
            btn_cam.Visible = false;
            btn_frigo.Visible = false;
            panel12.Visible = false;
            btn_user.Visible = false;
            btn_backup.Visible = false;
            btn_theme.Visible = false;
            panel_theme.Visible = false;
            cb_color.Visible = false;
            btn_histoire.Visible = false;
            
        }


        private void InitializeDateTimeLabel()
        {
            timerDateTime.Interval = 1000; // 1 second interval
            timerDateTime.Tick += new EventHandler(timerDateTime_Tick);
            timerDateTime.Start();

            lblDateTime.Text = DateTime.Now.ToString("f", CultureInfo.CurrentCulture);
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("f", CultureInfo.CurrentCulture); // "f" format shows full date and time
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       


       

        private void hideSubmenu()
        {
            if (panel_tables.Visible == true)
                panel_tables.Visible = false;

            if (panel3.Visible == true)
                panel3.Visible = false;

            if (panel5.Visible == true)
                panel5.Visible = false;

            if (panel_theme.Visible == true)
                panel_theme.Visible = false;

        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }



        
        #region tables
        private void btn_clt_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_prd_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadReminders()
        {
            string query = @"
                SELECT 
                    'Chauffeur' AS Type,
                    C.Nom_Chauff AS Concerne,
                    R.date_rapp AS Date,
                    R.description_rapp AS Description
                FROM 
                    Rappelchauff R
                JOIN 
                    Chauffeur C ON R.Num_Chauff = C.Num_Chauff
                UNION ALL
                SELECT 
                    'Camion' AS Type,
                    CAST(M.Matricule AS VARCHAR(50)) AS Concerne,
                    R.date_rapp AS Date,
                    R.description_rapp AS Description
                FROM 
                    Rappelcam R
                JOIN 
                    Camion M ON R.Num_Cam = M.Num_Cam;";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        #endregion tables

        //show forms in main one 
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            

              // Update colors for the child form's panels
              foreach (Control control in childForm.Controls)
              {
                  if (control is Panel panel && panel.Name == "panel1") // Adjust panel name as needed
                  {
                      // Update panel color here based on selected color index
                      panel.BackColor = selectedColor;
                  }
              }


            childForm.BringToFront();
            childForm.Show();

            
        }


        public void MaximizeWithTaskbar()
        {
            // Get the working area of the screen (excluding taskbar)
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            // Set the form's size and position
            this.Location = workingArea.Location;
            this.Size = workingArea.Size;
        }


        private void btn_home_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
            UpdateRecordCounts();
            LoadReminders();
       

        }

        //methode bach ntle3 l count f labels 
        private void UpdateRecordCounts()
        {
           
                try
                {
                    c.cn.Open();

                    // Get the total number of voyages except those with 'annuler' status
                    SqlCommand cmdVoyages = new SqlCommand("SELECT COUNT(*) FROM Voyage WHERE Statut <> 'Annulé'", c.cn);
                    int voyagesCount = (int)cmdVoyages.ExecuteScalar();
                    labelVoyages.Text = voyagesCount.ToString();

                    // Get the total amount from the paiment table
                    SqlCommand cmdTotalPaiement = new SqlCommand("SELECT SUM(Montant_Total) FROM Paiements", c.cn);
                    object totalPaiementResult = cmdTotalPaiement.ExecuteScalar();
                    decimal totalPaiement = (totalPaiementResult != DBNull.Value) ? (decimal)totalPaiementResult : 0;
                    labelPaiement.Text = totalPaiement.ToString("C", new CultureInfo("fr-MA"));

                    // Get the total amount of all specified expenses
                    SqlCommand cmdTotalDepense = new SqlCommand(@"
            SELECT 
                ISNULL(SUM(marché), 0) +
                ISNULL(SUM(parkings), 0) +
                ISNULL(SUM(transitaire), 0) +
                ISNULL(SUM(chauffeur_sal), 0) +
                ISNULL(SUM(maintenance), 0) +
                ISNULL(SUM(péages), 0) +
                ISNULL(SUM(carburant), 0) 
            FROM Dépense", c.cn);
                    object totalDepenseResult = cmdTotalDepense.ExecuteScalar();
                    decimal totalDepense = (totalDepenseResult != DBNull.Value) ? (decimal)totalDepenseResult : 0;
                    labelDepense.Text = totalDepense.ToString("C", new CultureInfo("fr-MA"));

                    // Calculate the profit
                    decimal profit = totalPaiement - totalDepense;
                    labelProfit.Text = profit.ToString("C", new CultureInfo("fr-MA"));

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating record counts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    c.cn.Close();
                }
            
        }

        private void btn_sortie_Click(object sender, EventArgs e)
        {
            LOGIN l1 = new LOGIN();
            l1.Show();
            this.Hide();
        }

        private void btn_prnt_Click(object sender, EventArgs e)
        {
            
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void label_user_Click(object sender, EventArgs e)
        {

        }

        private void btn_gst_Click_1(object sender, EventArgs e)
        {
          
            openChildForm(new GESTCLT(this));
            hideSubmenu();
         
        }

        

        private void btn_voyage_Click_1(object sender, EventArgs e)
        {
          
            openChildForm(new GESTVOYAGE(this));
            hideSubmenu();
           
        }

        private void btn_Produit_Click(object sender, EventArgs e)
        {
           
            openChildForm(new GESTPRD(this));
            hideSubmenu();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_tables);
         

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new HISTOIR(this));
            hideSubmenu();
         
        }

        private void btn_finance_Click(object sender, EventArgs e)
        {
            showSubmenu(panel3);
           
       

        }

        private void btn_rappel_Click(object sender, EventArgs e)
        {
            showSubmenu(panel5);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Directlive(this));
            hideSubmenu();
        }

        private void btn_revenu_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTPAIM(this));
            hideSubmenu();
            
        }

        private void btn_dépenses_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTDEP(this));
            hideSubmenu();
        }

        private void btn_chauffrap_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTRAPPCH(this));
            hideSubmenu();
        }

        private void btn_camrap_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTRAPCAM(this));
            hideSubmenu();
        }

        private void btn_maintenence_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTMAINT(this));
            hideSubmenu();
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            


        }

        private void btn_chauff_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTCHAUFF(this));
            hideSubmenu();
            
        }

        private void btn_cam_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTCAM(this));
            hideSubmenu();
          
        }

        private void btn_frigo_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTFRIGO(this));
            hideSubmenu();
           
        }


        public void LogAction(string action)
        {
            string query = "INSERT INTO History (Utilisateur, Action) VALUES (@Utilisateur, @Action)";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Utilisateur", username);
                        command.Parameters.AddWithValue("@Action", action);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging action: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            customizeDesign();


            btn_gst.Visible = true;
            btn_Produit.Visible = true;


            btn_voyage.Visible = true;
            button2.Visible = true;
            btn_maintenence.Visible = true;
            btn_rappel.Visible = true;
            btn_finance.Visible = true;
            btn_facture.Visible = true;
            btn_home.Visible = true;
            pictureBox1.Visible = true;
            label2.Visible = true;
            panel_logo.Visible = true;
            
            
            /*label_setting.Visible = false;
            pictureBox_settings.Visible = false;
            btn_chauff.Visible = false;
            btn_cam.Visible = false;
            btn_frigo.Visible = false;
            panel12.Visible = false;
            btn_user.Visible = false;
            btn_backup.Visible = false;
            btn_theme.Visible = false;
            panel_theme.Visible = false;
            cb_color.Visible = false;
            btn_histoire.Visible = false;
            btn_retour.Visible = false;*/
        }

        private void btn_settingsssss_Click(object sender, EventArgs e)
        {
            hideSubmenu();
          


            btn_gst.Visible = false;
            btn_Produit.Visible = false;


            btn_voyage.Visible = false;
            button2.Visible = false;
            btn_maintenence.Visible = false;
            btn_rappel.Visible = false;
            btn_finance.Visible = false;
            btn_home.Visible = false;
            btn_facture.Visible = false;
            pictureBox1.Visible = false;
            label2.Visible = false;
            panel_logo.Visible = false;
            btn_retour.Visible = true;
            label_setting.Visible = true;
            pictureBox_settings.Visible = true;
            btn_chauff.Visible = true;
            btn_cam.Visible = true;
            btn_frigo.Visible = true;
            panel12.Visible = true;
            btn_user.Visible = true;
            btn_backup.Visible = true;
            btn_theme.Visible = true;
            cb_color.Visible = true;
            btn_histoire.Visible = true;


            // Use BringToFront() to ensure correct z-order
            btn_retour.BringToFront();
            panel12.BringToFront();
            label_setting.BringToFront();
            pictureBox_settings.BringToFront();
            btn_chauff.BringToFront();
            btn_cam.BringToFront();
            btn_frigo.BringToFront();
            
            btn_user.BringToFront();
            btn_backup.BringToFront();
            btn_theme.BringToFront();
            panel_theme.BringToFront();
            cb_color.BringToFront();
            btn_histoire.BringToFront();

            

            // Refresh form to apply changes
            this.Refresh();
        }

        //nkhbe3 marks lidrt 7da btns
        

        private void btn_out_Click(object sender, EventArgs e)
        {
            LogAction("Utilisateur déconnecté");
            LOGIN l1 = new LOGIN();
            l1.Show();
            this.Hide();
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
             openChildForm(new info(this));
             hideSubmenu();
            
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTUSER(this));
            hideSubmenu();
           
        }

        private void panel_cover_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            openChildForm(new RESTOREDATA(this));
            hideSubmenu();
            
        }

        private void cb_color_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_color_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Store the selected color in the class-level variable
            string selectedColorName = cb_color.SelectedItem.ToString();
            selectedColor = Color.FromName(selectedColorName);

            // Update the control colors for the main form
            UpdateControlColors(this, selectedColor);

            // Update the child forms' colors
            UpdateChildFormsColors(selectedColor);

            this.Refresh();
           
        }



        private void UpdateControlColors(Control control, Color newColor)
        {
            foreach (Control childControl in control.Controls)
            {
                switch (childControl)
                {
                    case Panel panel:
                        if (panel.Name == "panel_slide" || panel.Name == "panel_theme"  || panel.Name == "panel12" || panel.Name == "panel2" || panel.Name == "panel_logo" || panel.Name == "panel_btns")
                        {
                            panel.BackColor = newColor; // Update background color of specified panels
                        }
                        break;

                    case Button button:
                        button.BackColor = newColor; // Update background color of all buttons
                        break;

                    case Label label:
                        if (  label.Name == "label10" || label.Name == "label8")
                        {
                            label.ForeColor = newColor; // Update background color of specified labels
                        }
                        break;

                    case Form childForm:
                        // Recursively update colors for controls within the child form
                        UpdateControlColors(childForm, newColor);
                        break;
                }

                // Recursively process child controls
                UpdateControlColors(childControl, newColor);
            }






        }


        private void UpdateChildFormsColors(Color newColor)
        {
            // Find GESTVOYAGE1 and GESTVOYAGE2 forms in the list of open forms
            foreach (Form form in Application.OpenForms)
            {
                if (form is GESTVYGE1 || form is GESTVYGE2)
                {
                    form.BackColor = newColor; // Update background color of GESTVOYAGE1 and GESTVOYAGE2 forms
                }
            }
        }

        private void btn_theme_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
            UpdateRecordCounts();
            showSubmenu(panel_theme);
          
        }

        private void panel777_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_histoire_Click(object sender, EventArgs e)
        {
            openChildForm(new ACTIONLOG(this));
            hideSubmenu();
          
        }

        private void btn_facture_Click(object sender, EventArgs e)
        {
            openChildForm(new GESTFACTURE(this));
            hideSubmenu();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
