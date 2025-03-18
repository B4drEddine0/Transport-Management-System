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
using Guna.UI2.WinForms.Suite;

namespace WindowsFormsApplication27
{
    public partial class GESTVYGE1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTVYGE1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        } 

        private void GESTVYGE1_Load(object sender, EventArgs e)
        {
            LoadClientsIntoComboBox();
            LoadCamionsIntoComboBox();
            LoadProduitsIntoComboBox();
            LoadChauffeursIntoComboBox();
        }

        // Method to load Chauffeur data
        private DataTable LoadChauffeurs()
        {
            DataTable dtChauffeurs = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Num_Chauff, Nom_Chauff FROM Chauffeur";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtChauffeurs);
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Error loading chauffeurs: " + ex.Message);
                       
                    }
                }
            }

            return dtChauffeurs;
        }

        private void cb_chauff_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void LoadChauffeursIntoComboBox()
        {
            DataTable dtChauffeurs = LoadChauffeurs();
            cb_chauff.DataSource = dtChauffeurs;
            cb_chauff.DisplayMember = "Nom_Chauff";
            cb_chauff.ValueMember = "Num_Chauff";
        }

        // Method to load Client data
        private DataTable LoadClients()
        {
            DataTable dtClients = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Num_Clt, Nom_Clt FROM Client";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtClients);
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR","Error loading clients: " + ex.Message );
                        
                    }
                }
            }

            return dtClients;
        }

        private void LoadClientsIntoComboBox()
        {
            DataTable dtClients = LoadClients();
            cb_clt.DataSource = dtClients;
            cb_clt.DisplayMember = "Nom_Clt";
            cb_clt.ValueMember = "Num_Clt";
        }

        // Method to load Camion data
        private DataTable LoadCamions()
        {
            DataTable dtCamions = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Num_Cam, Modele FROM Camion";

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
            cb_cam.DisplayMember = "Modele";
            cb_cam.ValueMember = "Num_Cam";
        }

        // Method to load Produit data
        private DataTable LoadProduits()
        {
            DataTable dtProduits = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Ref_Prod, Nature_Prod FROM Produit";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtProduits);
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Error loading produits: " + ex.Message);
                    }
                }
            }

            return dtProduits;
        }

        private void LoadProduitsIntoComboBox()
        {
            DataTable dtProduits = LoadProduits();
            cb_prd.DataSource = dtProduits;
            cb_prd.DisplayMember = "Nature_Prod";
            cb_prd.ValueMember = "Ref_Prod";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string chauffeurStatusQuery = "SELECT COUNT(*) FROM Voyage WHERE Num_Chauff = @Num_Chauff AND Statut IN ('En attente', 'En cours', 'En retard')";
            string camionStatusQuery = "SELECT COUNT(*) FROM Voyage WHERE Num_Cam = @Num_Cam AND Statut IN ('En attente', 'En cours', 'En retard')";
            string chauffeurAvailabilityQuery = "SELECT COUNT(*) FROM Chauffeur WHERE Num_Chauff = @Num_Chauff AND status_chauff = 'unavailable'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Vérifier le statut du chauffeur
                    using (SqlCommand cmdCheckChauffeur = new SqlCommand(chauffeurStatusQuery, connection))
                    {
                        cmdCheckChauffeur.Parameters.AddWithValue("@Num_Chauff", cb_chauff.SelectedValue);
                        int chauffeurInActiveTripCount = (int)cmdCheckChauffeur.ExecuteScalar();
                        if (chauffeurInActiveTripCount > 0)
                        {
                            showError("ERROR", "Le chauffeur est déjà en voyage actif (En attente, En cours ou En retard).");
                          
                            return;
                        }
                    }

                    // Vérifier la disponibilité du chauffeur
                    using (SqlCommand cmdCheckChauffeurAvailability = new SqlCommand(chauffeurAvailabilityQuery, connection))
                    {
                        cmdCheckChauffeurAvailability.Parameters.AddWithValue("@Num_Chauff", cb_chauff.SelectedValue);
                        int unavailableChauffeurCount = (int)cmdCheckChauffeurAvailability.ExecuteScalar();
                        if (unavailableChauffeurCount > 0)
                        {
                            showError("ERROR", "Le chauffeur n'est pas disponible.");
                            return;
                        }
                    }

                    // Vérifier le statut du camion
                    using (SqlCommand cmdCheckCamion = new SqlCommand(camionStatusQuery, connection))
                    {
                        cmdCheckCamion.Parameters.AddWithValue("@Num_Cam", cb_cam.SelectedValue);
                        int camionInActiveTripCount = (int)cmdCheckCamion.ExecuteScalar();
                        if (camionInActiveTripCount > 0)
                        {
                            showError("ERROR", "Le camion est déjà en voyage actif (En attente, En cours ou En retard).");
                            return;
                        }
                    }

                    // Si toutes les vérifications passent, procéder à l'insertion
                    string insertQuery = "INSERT INTO Voyage (Date_Emission, Date_Réception, Ville_Dep, Ville_Arr, Statut, Num_Clt, Ref_Prod, Num_Cam, Num_Chauff, tracking_num) VALUES (@Date_Emission, @Date_Réception, @Ville_Dep, @Ville_Arr, @Statut, @Num_Clt, @Ref_Prod, @Num_Cam, @Num_Chauff, @tracking_num)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Date_Emission", date_emiss.Value);
                        command.Parameters.AddWithValue("@Date_Réception", date_recept.Value);
                        command.Parameters.AddWithValue("@Ville_Dep", txt_dep.Text);
                        command.Parameters.AddWithValue("@Ville_Arr", txt_arr.Text);
                        command.Parameters.AddWithValue("@Statut", txt_statut.Text);
                        command.Parameters.AddWithValue("@Num_Clt", cb_clt.SelectedValue);
                        command.Parameters.AddWithValue("@Ref_Prod", cb_prd.SelectedValue);
                        command.Parameters.AddWithValue("@Num_Cam", cb_cam.SelectedValue);
                        command.Parameters.AddWithValue("@Num_Chauff", cb_chauff.SelectedValue);
                        command.Parameters.AddWithValue("@tracking_num", txt_tracking.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                           
                            mainForm.LogAction("Ajouté un nouveau voyage");
                            showtoast("AJOUTER", "Voyage ajouté avec succès!");
                        }
                        else
                        {
                            showError("ERROR", "Erreur lors de l'ajout du voyage." );
                        }
                    }
                }
                catch (Exception ex)
                {
                    showError("ERROR","Erreur lors de l'ajout du voyage: " + ex.Message );
                    
                }
            }

        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            // Reset the text and selected index of each ComboBox
            cb_chauff.SelectedIndex = -1; // Clears the selection
            cb_chauff.Text = string.Empty; // Clears the displayed text

            cb_cam.SelectedIndex = -1;
            cb_cam.Text = string.Empty;

            cb_prd.SelectedIndex = -1;
            cb_prd.Text = string.Empty;

            cb_clt.SelectedIndex = -1;
            cb_clt.Text = string.Empty;

            txt_statut.SelectedIndex = -1;
            txt_statut.Text = string.Empty;

            // Reset the TextBox controls
            txt_dep.Clear();
            txt_arr.Clear();
            txt_tracking.Clear();

            // Reset the DateTimePicker controls
            date_emiss.Value = DateTime.Now;
            date_recept.Value = DateTime.Now;

        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTVOYAGE g = new GESTVOYAGE(mainForm);

            mainForm.openChildForm(g);
        }

        private void cb_clt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_num_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            GESTCHAUFF gc = new GESTCHAUFF(mainForm);

            mainForm.openChildForm(gc);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            GESTCAM gm = new GESTCAM(mainForm);

            mainForm.openChildForm(gm);
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
