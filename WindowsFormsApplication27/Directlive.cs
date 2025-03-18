using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class Directlive : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private string initialUrl = "https://b4dreddine0.github.io/map-direction/";
        private Timer timer;
        
        public Directlive(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Directlive_Load(object sender, EventArgs e)
        {
            LoadTrackingIntoComboBox();
            webView21.Source = new Uri(initialUrl, UriKind.Absolute);
        }

        private void LoadTrackingIntoComboBox()
        {
            // Here you can manually add the trucking number
            cb_track.Items.Add("Track23456");
            cb_track.SelectedIndex = -1;
        }

        private void btn_rech_Click_1(object sender, EventArgs e)
        {
            if (cb_track.SelectedIndex == -1)
            {
                showError("Attention", "Veuillez sélectionner un numéro de suivi.");
               
                return;
            }

            // Get the selected tracking number
            string selectedTracking = cb_track.Text;
            // Update the web view with the specified URL
            UpdateWebView(selectedTracking);

            // Display the specified URL for 25 seconds
            timer = new Timer();
            timer.Interval = 25000; // 25 seconds
            timer.Tick += Timer_Tick;
            timer.Start(); // Start the timer

            // Load and display voyage details
            LoadVoyageDetails(selectedTracking);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!webView21.IsDisposed)
            {
                webView21.Source = new Uri(initialUrl, UriKind.Absolute);
            }
            timer.Stop(); // Stop the timer
            timer.Dispose(); // Dispose the timer
        }

        private void vider()
        {
            txt_arr1.Text = "";
            txt_dep1.Text = "";
            txt_statut1.Text = "";
        }

        private void UpdateWebView(string trackingNumber)
        {
            if (webView21.IsDisposed)
            {
                showError("ERROR", "WebView2 instance is disposed. Cannot update the View.");
                return;
            }

            string url = initialUrl;

            switch (trackingNumber)
            {
                case "Track23456":
                    url = "https://b4dreddine0.github.io/mapanime/";
                    break;
                // Add more cases for different tracking numbers if needed
                default:
                    // Handle default case, if any
                    break;
            }

            webView21.Source = new Uri(url, UriKind.Absolute);
        }

        private void btn_tous_Click(object sender, EventArgs e)
        {
            cb_track.Items.Clear(); // Clear existing items in the combo box
            LoadTrackingIntoComboBox();
            if (!webView21.IsDisposed)
            {
                webView21.Source = new Uri(initialUrl, UriKind.Absolute);
            }
            vider();
        }

        private void LoadVoyageDetails(string trackingNumber)
        {
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = @"
                SELECT Ville_Dep, Ville_Arr, Statut 
                FROM Voyage 
                WHERE tracking_num = @tracking_num";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tracking_num", trackingNumber);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Display voyage details in text boxes
                            txt_dep1.Text = reader["Ville_Dep"].ToString();
                            txt_arr1.Text = reader["Ville_Arr"].ToString();
                            txt_statut1.Text = reader["Statut"].ToString();
                        }
                        else
                        {
                            // Clear text boxes if no details found
                            vider();
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR","Erreur lors du chargement des détails du voyage : " + ex.Message );
                        
                    }
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (timer != null)
            {
                timer.Dispose();
            }
            if (!webView21.IsDisposed)
            {
                webView21.Dispose();
            }
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
