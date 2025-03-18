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
    public partial class GESTRAPCAM2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int numRapp;
        private string matricule;
        private Color panelColor;
        public GESTRAPCAM2(WindowsFormsApplication27.main mainForm, int numRapp, DateTime dateRapp, string descriptionRapp, string matricule, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.numRapp = numRapp;
            this.matricule = matricule;

            date_rap.Value = dateRapp;
            txt_descript.Text = descriptionRapp;
            txt_num.Text = numRapp.ToString();

            LoadCamionsIntoComboBox();
            SetComboBoxSelectedValue();

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTRAPCAM2_Load(object sender, EventArgs e)
        {

        }

        private void SetComboBoxSelectedValue()
        {
            cb_cam.Text = matricule;
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTRAPCAM form = new GESTRAPCAM(mainForm);
            mainForm.openChildForm(form);
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
                        showError("ERROR","Erreur lors du chargement des camions : " + ex.Message );
                        
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
            if (DateTime.TryParse(date_rap.Value.ToString(), out DateTime dateRapp) &&
               !string.IsNullOrWhiteSpace(txt_descript.Text) &&
               int.TryParse(cb_cam.SelectedValue.ToString(), out int numCam))
            {
                string query = @"
                    UPDATE Rappelcam 
                    SET 
                        date_rapp = @date_rapp,
                        description_rapp = @description_rapp,
                        Num_Cam = @Num_Cam
                    WHERE 
                        Num_rapp = @Num_rapp";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Num_rapp", numRapp);
                        command.Parameters.AddWithValue("@date_rapp", dateRapp);
                        command.Parameters.AddWithValue("@description_rapp", txt_descript.Text);
                        command.Parameters.AddWithValue("@Num_Cam", numCam);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("MODIFIER", "Rappel modifié avec succès");
                            mainForm.LogAction("Modifié un rappel camion");

                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de la modification du rappel : " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez remplir tous les champs correctement.");
            }
        }

        private void cb_cam_SelectedIndexChanged(object sender, EventArgs e)
        {

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
