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
using Guna.UI2.WinForms;

namespace WindowsFormsApplication27
{
    public partial class GESTVYGE2 : Form
    {
        private int numVoyage;
        private int nomClt;
        private int natureProd;
        private int modeleCamion;
        private int nomChauff;
        private string statut;
        private Color panelColor;

        private WindowsFormsApplication27.main mainForm;

        public GESTVYGE2(WindowsFormsApplication27.main mainForm, int numVoyage, DateTime dateEmission, DateTime dateReception, string villeDep, string villeArr, string statut, int nomClt, int natureProd, int modeleCamion, int nomChauff, string trackingNum, Color panelColor)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;




            // Fill the form fields with the data
            date_emiss.Value = dateEmission;
            date_recept.Value = dateReception;
            txt_dep.Text = villeDep;
            txt_arr.Text = villeArr;
            txt_statut.Text = statut;
            txt_num.Text = numVoyage.ToString();
            txt_tracking.Text = trackingNum.ToString();


            // Load and set ComboBox values
            LoadClientsIntoComboBox();
            LoadProduitsIntoComboBox();
            LoadCamionsIntoComboBox();
            LoadChauffeursIntoComboBox();

            // Store the names
            this.nomClt = nomClt;
            this.natureProd = natureProd;
            this.modeleCamion = modeleCamion;
            this.nomChauff = nomChauff;
            

            // Set the initial selected values for ComboBoxes
            SetComboBoxSelectedValues();

            
        }

        Class1 c = new Class1();

        private void GESTVYGE2_Load(object sender, EventArgs e)
        {
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTVOYAGE g = new GESTVOYAGE(mainForm);
            mainForm.openChildForm(g);
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
                        showError("ERROR", "Error loading clients: " + ex.Message);
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

        private void SetComboBoxSelectedValues()
        {
            // Set the selected value only if the value exists in the ComboBox
            if (cb_clt.Items.Cast<DataRowView>().Any(item => (int)item["Num_Clt"] == nomClt))
            {
                cb_clt.SelectedValue = nomClt;
            }

            if (cb_prd.Items.Cast<DataRowView>().Any(item => (int)item["Ref_Prod"] == natureProd))
            {
                cb_prd.SelectedValue = natureProd;
            }

            if (cb_cam.Items.Cast<DataRowView>().Any(item => (int)item["Num_Cam"] == modeleCamion))
            {
                cb_cam.SelectedValue = modeleCamion;
            }

            if (cb_chauff.Items.Cast<DataRowView>().Any(item => (int)item["Num_Chauff"] == nomChauff))
            {
                cb_chauff.SelectedValue = nomChauff;
            }
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            // Retrieve the modified data from the input controls
            if (!int.TryParse(txt_num.Text, out int numVoyage))
            {
                showError("ERROR", "Le numéro de voyage est invalide.");
                return;
            }

            DateTime dateEmission = date_emiss.Value;
            DateTime dateReception = date_recept.Value;
            string villeDep = txt_dep.Text;
            string villeArr = txt_arr.Text;
            string statut = txt_statut.Text;
            string trackingNum = txt_tracking.Text;

            if (string.IsNullOrEmpty(statut))
            {
                showError("Attention", "Veuillez sélectionner un statut.");
                return;
            }

            // Ensure that the ComboBox values are correctly retrieved as integers
            if (cb_clt.SelectedValue == null || cb_prd.SelectedValue == null ||
                cb_cam.SelectedValue == null || cb_chauff.SelectedValue == null)
            {
                showError("Attention", "Veuillez sélectionner des valeurs valides pour le client, produit, camion et chauffeur.");
                return;
            }

            // Convert selected values to integers
            int numClt = Convert.ToInt32(cb_clt.SelectedValue);
            int refProd = Convert.ToInt32(cb_prd.SelectedValue);
            int numCam = Convert.ToInt32(cb_cam.SelectedValue);
            int numChauff = Convert.ToInt32(cb_chauff.SelectedValue);

            // Update the data in the database
            try
            {
                c.cn.Open();
                string query = @"UPDATE Voyage 
                         SET Date_Emission = @Date_Emission, 
                             Date_Réception = @Date_Réception, 
                             Ville_Dep = @Ville_Dep, 
                             Ville_Arr = @Ville_Arr, 
                             Statut = @Statut,
                             Num_Clt = @Num_Clt,
                             Ref_Prod = @Ref_Prod,
                             Num_Cam = @Num_Cam,
                             Num_Chauff = @Num_Chauff,
                             tracking_num = @tracking_num
                         WHERE Num_Voyage = @Num_Voyage";
                using (SqlCommand cmd = new SqlCommand(query, c.cn))
                {
                    cmd.Parameters.AddWithValue("@Date_Emission", dateEmission);
                    cmd.Parameters.AddWithValue("@Date_Réception", dateReception);
                    cmd.Parameters.AddWithValue("@Ville_Dep", villeDep);
                    cmd.Parameters.AddWithValue("@Ville_Arr", villeArr);
                    cmd.Parameters.AddWithValue("@Statut", statut);
                    cmd.Parameters.AddWithValue("@Num_Clt", numClt);
                    cmd.Parameters.AddWithValue("@Ref_Prod", refProd);
                    cmd.Parameters.AddWithValue("@Num_Cam", numCam);
                    cmd.Parameters.AddWithValue("@Num_Chauff", numChauff);
                    cmd.Parameters.AddWithValue("@tracking_num", trackingNum);
                    cmd.Parameters.AddWithValue("@Num_Voyage", numVoyage);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                       
                        mainForm.LogAction("Modifié un voyage");
                        showtoast("MODIFIER", "voyage modifié avec succès");
                    }
                    else
                    {
                        showError("ERROR", "Aucun voyage trouvé avec ce numéro.");
                    }
                }
            }
            catch (Exception ex)
            {
                showError("ERROR", "Erreur lors de la mise à jour du voyage: " + ex.Message);
            }
            finally
            {
                c.cn.Close();
            }
        }

        public void vider()
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

        private void cb_clt_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cb_prd_SelectedIndexChanged(object sender, EventArgs e)
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