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

    public partial class GESTMAIN2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int maintenanceNum;
        private int numCam;
        private int matricule;
        private string maintenanceType;
        private DateTime maintenanceDate;
        private string descriptionMain;
        private string statutMain;
        private Color panelColor;
        public GESTMAIN2(WindowsFormsApplication27.main mainForm, int maintenanceNum, int numCam, int matricule, string maintenanceType, DateTime maintenanceDate, string descriptionMain, string statutMain, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.maintenanceNum = maintenanceNum;
            this.numCam = numCam;
            this.matricule = matricule;
            this.maintenanceType = maintenanceType;
            this.maintenanceDate = maintenanceDate;
            this.descriptionMain = descriptionMain;
            this.statutMain = statutMain;

            // Optionally set these values in the form controls
            
            cb_type.Text = maintenanceType;
            date_maint.Value = maintenanceDate;
            txt_descrip.Text = descriptionMain;
            cb_statut.Text = statutMain;
            txt_num.Text = numCam.ToString();

           


            

            LoadCamionsIntoComboBox();

            this.matricule = matricule;

            SetComboBoxSelectedValues();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;

        }
        Class1 c = new Class1();    

        private void GESTMAIN2_Load(object sender, EventArgs e)
        {

        }

        private void SetComboBoxSelectedValues()
        {
            // Set the selected value only if the value exists in the ComboBox
            if (cb_cam.Items.Cast<DataRowView>().Any(item => (int)item["Num_Cam"] == numCam))
            {
                cb_cam.SelectedValue = numCam;
            }

            
            cb_statut.Text = statutMain;
            

           
            cb_type.Text = maintenanceType;

        }

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
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected value from the ComboBox
                if (cb_cam.SelectedValue == null || !int.TryParse(cb_cam.SelectedValue.ToString(), out numCam))
                {
                    showError("Attention", "Veuillez sélectionner un camion valide.");
                    return;
                }

                // Open the database connection
                c.cn.Open();

                // Prepare the SQL update query
                string updateQuery = "UPDATE Maintenance SET Num_Cam = @Num_Cam, MaintenanceType = @MaintenanceType, MaintenanceDate = @MaintenanceDate, Description_main = @Description_main, statut_main = @statut_main WHERE maintenance_num = @maintenance_num";

                // Create a SqlCommand object with the update query and connection
                SqlCommand cmd = new SqlCommand(updateQuery, c.cn);

                // Set parameters for the update query
                cmd.Parameters.AddWithValue("@Num_Cam", numCam);
                cmd.Parameters.AddWithValue("@MaintenanceType", cb_type.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@MaintenanceDate", date_maint.Value);
                cmd.Parameters.AddWithValue("@Description_main", txt_descrip.Text);
                cmd.Parameters.AddWithValue("@statut_main", cb_statut.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@maintenance_num", maintenanceNum);

                // Execute the update query
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if any rows were updated
                if (rowsAffected > 0)
                {
                    showtoast("MODIFIER", "Maintenence modifié avec succès");
                    mainForm.LogAction("Modifié une maintenance");

                }
                else
                {
                    showError("ERROR", "Aucune maintenance trouvée avec ce numéro.");
                }
            }
            catch (Exception ex)
            {
                showError("ERROR", "Erreur lors de la modification de la maintenance: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                c.cn.Close();
            }
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTMAINT g = new GESTMAINT(mainForm);
            mainForm.openChildForm(g);
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
