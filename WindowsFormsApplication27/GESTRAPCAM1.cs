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
    public partial class GESTRAPCAM1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;

        public GESTRAPCAM1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadCamionsIntoComboBox();

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        public void vider()
        {
            date_rap.Value = DateTime.Now;
            cb_cam.SelectedIndex = -1;
            txt_descript.Clear();

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
                        showError("ERROR", "Erreur lors du chargement des camions : " + ex.Message);
                        
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(date_rap.Value.ToString(), out DateTime dateRapp) &&
                !string.IsNullOrWhiteSpace(txt_descript.Text) &&
                int.TryParse(cb_cam.SelectedValue.ToString(), out int numCam))
            {
                string query = @"
                    INSERT INTO Rappelcam (date_rapp, description_rapp, Num_Cam)
                    VALUES (@date_rapp, @description_rapp, @Num_Cam)";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date_rapp", dateRapp);
                        command.Parameters.AddWithValue("@description_rapp", txt_descript.Text);
                        command.Parameters.AddWithValue("@Num_Cam", numCam);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("AJOUTER", "Rappel ajouté avec succès!");
                            mainForm.LogAction("Ajouté un nouveau rappel camion");

                            vider();
                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de l'ajout du rappel : " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez remplir tous les champs correctement.");
            }
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
