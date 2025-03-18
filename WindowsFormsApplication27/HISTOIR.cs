using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class HISTOIR : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private string initialUrl = "https://b4dreddine0.github.io/map-direction/";

        public HISTOIR(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webView21.Source = new Uri("https://b4dreddine0.github.io/map-direction/map1", UriKind.Absolute);
        }

        private void test_Load(object sender, EventArgs e)
        {
            LoadTrackingIntoComboBox();
            webView21.Source = new Uri(initialUrl, UriKind.Absolute);
        }

        private void cb_track_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can also handle changes here if needed
        }

        private void LoadTrackingIntoComboBox()
        {
            DataTable dtTrackingNumbers = LoadTrackingNumbers();
            if (dtTrackingNumbers != null)
            {
                var allowedTrackingNumbers = new List<string> { "Track12345", "Track45678", "Track56789", "Track34567" };
                var filteredRows = dtTrackingNumbers.AsEnumerable()
                    .Where(row => allowedTrackingNumbers.Contains(row.Field<string>("tracking_num")));

                if (filteredRows.Any())
                {
                    dtTrackingNumbers = filteredRows.CopyToDataTable();
                    cb_track.DataSource = dtTrackingNumbers;
                    cb_track.DisplayMember = "tracking_num";  // The column you want to display in the combobox
                    cb_track.ValueMember = "Num_Voyage";  // The actual value you want to retrieve (primary key)
                    cb_track.SelectedIndex = -1;
                }
                else
                {
                    cb_track.DataSource = null;
                }
            }
        }

        private DataTable LoadTrackingNumbers()
        {
            DataTable dtTrackingNumbers = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Num_Voyage, tracking_num FROM Voyage";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtTrackingNumbers);
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Error loading tracking numbers: " + ex.Message);
                      
                    }
                }
            }

            return dtTrackingNumbers;
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (cb_track.SelectedIndex == -1)
            {
                showError("Attention", "Veuillez sélectionner un numéro de suivi.");
                
                return;
            }

            string selectedTracking = cb_track.Text;
            int selectedVoyageId = (int)cb_track.SelectedValue;

            // Set the tracking number in the text box
            // txt_trackingNumber.Text = selectedTracking;

            LoadVoyageDetails(selectedVoyageId);
            UpdateWebView(selectedTracking);
        }

        private void LoadVoyageDetails(int voyageId)
        {
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = @"
                SELECT Ville_Dep, Ville_Arr, Statut 
                FROM Voyage 
                WHERE Num_Voyage = @Num_Voyage";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Num_Voyage", voyageId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txt_dep.Text = reader["Ville_Dep"].ToString();
                            txt_arr.Text = reader["Ville_Arr"].ToString();
                            txt_statut.Text = reader["Statut"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors du chargement des détails du voyage : " + ex.Message);
                        
                    }
                }
            }
        }

        private void UpdateWebView(string trackingNumber)
        {
            string url = initialUrl;

            switch (trackingNumber)
            {
                case "Track12345":
                    url = "https://b4dreddine0.github.io/map-direction/map1";
                    break;
                case "Track45678":
                    url = "https://b4dreddine0.github.io/map-direction/map2";
                    break;
                case "Track56789":
                    url = "https://b4dreddine0.github.io/map-direction/map3";
                    break;
                case "Track34567":
                    url = "https://b4dreddine0.github.io/map-direction/map4";
                    break;
                default:
                    // Handle default case, if any
                    break;
            }

            webView21.Source = new Uri(url, UriKind.Absolute);
        }

        private void btn_tous_Click(object sender, EventArgs e)
        {
            LoadTrackingIntoComboBox();
            webView21.Source = new Uri(initialUrl, UriKind.Absolute);
            ClearVoyageDetails();
        }

        private void ClearVoyageDetails()
        {
            txt_dep.Text = "";
            txt_arr.Text = "";
            txt_statut.Text = "";
        }

        public void showError(string type, string message)
        {
            ERRORFORM e = new ERRORFORM(type, message);
            e.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Minimized;
        }
    }
}
