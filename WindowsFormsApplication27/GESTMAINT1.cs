using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class GESTMAINT1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTMAINT1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;


            LoadCamionsIntoComboBox();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTMAINT1_Load(object sender, EventArgs e)
        {
            
           
        }

        // Method to load Camion data
        private DataTable LoadCamions()
        {
            DataTable dtCamions = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Num_Cam, Matricule FROM Camion";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtCamions);
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Error loading camions: " + ex.Message);
                        
                    }
                }
            }

            return dtCamions;
        }

        private void LoadCamionsIntoComboBox()
        {
            DataTable dtCamions = LoadCamions();
            cb_cam.DataSource = dtCamions;
            cb_cam.DisplayMember = "Matricule";
            cb_cam.ValueMember = "Num_Cam";
            cb_cam.SelectedIndex = -1;
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            cb_cam.SelectedIndex = -1;
            cb_type.SelectedIndex = -1;
            date_maint.Value = DateTime.Now;
            txt_descrip.Clear();
            cb_statut.SelectedIndex = -1;
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cb_cam.SelectedIndex == -1 || cb_type.SelectedIndex == -1 || cb_statut.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_descrip.Text))
            {
                showError("Attention", "Veuillez remplir tous les champs obligatoires.");
                return;
            }

            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = @"
        INSERT INTO Maintenance (Num_Cam, MaintenanceType, MaintenanceDate, Description_main, statut_main)
        VALUES (@Num_Cam, @Type, @Date_Maint, @Description, @Statut)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Num_Cam", cb_cam.SelectedValue);
                    command.Parameters.AddWithValue("@Type", cb_type.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Date_Maint", date_maint.Value);
                    command.Parameters.AddWithValue("@Description", txt_descrip.Text);
                    command.Parameters.AddWithValue("@Statut", cb_statut.SelectedItem.ToString());

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            showtoast("AJOUTER", "Maintenence ajouté avec succès!");
                            mainForm.LogAction("Ajouté une nouvelle maintenance");

                            btn_vider_Click(sender, e);
                            cb_cam.SelectedValue = -1;
                        }
                        else
                        {
                            showError("ERROR", "Aucune maintenance ajoutée.");
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de l'ajout de la maintenance : " + ex.Message);
                    }
                }
            }
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTMAINT m = new GESTMAINT(mainForm);

            mainForm.openChildForm(m);
        }

        public void showtoast(string type, string message)
        {
            ToastForm t = new ToastForm(type, message);
            t.Show();
        }

        public void showError(string type, string message)
        {
            ERRORFORM e = new ERRORFORM(type, message);
            e.Show();
        }
    }
}
