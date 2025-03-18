using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApplication27
{
    public partial class GESTFACTURE : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTFACTURE(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void GESTFACTURE_Load(object sender, EventArgs e)
        {
            
        }

        private DataTable LoadVoyages()
        {
            DataTable dtVoyages = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Num_Voyage FROM Voyage";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtVoyages);
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Error loading voyages: " + ex.Message);
                    }
                }
            }

            return dtVoyages;
        }

        private void LoadVoyagesIntoComboBox()
        {
            DataTable dtVoyages = LoadVoyages();
            cbVoyage.DataSource = dtVoyages;
            cbVoyage.DisplayMember = "Num_Voyage";
            cbVoyage.ValueMember = "Num_Voyage";
            cbVoyage.SelectedIndex = -1;
        }

        public void showError(string type, string message)
        {
            ERRORFORM e = new ERRORFORM(type, message);
            e.Show();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if (cbVoyage.SelectedIndex == -1)
            {
                showError("Attention", "Veuillez sélectionner un numéro de voyage.");
                return;
            }

            if (cbtype.SelectedIndex == -1)
            {
                showError("Attention", "Veuillez sélectionner un type de facture.");
                return;
            }

            // Get the selected voyage number from ComboBox
            string selectedVoyageNumber = cbVoyage.SelectedValue.ToString();
            string selectedType = cbtype.SelectedItem.ToString();

            


            // Load the appropriate Crystal Report based on the selected type
            LoadReport(selectedVoyageNumber, selectedType);
        }

        private void LoadReport(string voyageNumber, string factureType)
        {
            // Create a new instance of the report
            var report = new ReportDocument();
            string reportPath;

            // Determine the report path based on the selected facture type
            if (factureType == "National")
            {
                reportPath = "C:\\Users\\badrd\\OneDrive\\Documents\\Visual Studio 2022\\Templates\\project\\WindowsFormsApplication27\\WindowsFormsApplication27\\facturenational - Copy.rpt";
            }
            else if (factureType == "International")
            {
                reportPath = "C:\\Users\\badrd\\OneDrive\\Documents\\Visual Studio 2022\\Templates\\project\\WindowsFormsApplication27\\WindowsFormsApplication27\\facturenational.rpt";
            }
            else
            {
                showError("Attention", "Type de facture inconnu.");
                return;
            }

            report.Load(reportPath);

           


            // Set the parameter for the report
            report.SetParameterValue("ParameterNumVoyage", voyageNumber);

          


            // Set the report source for the CrystalReportViewer
            crystalReportViewer2.ReportSource = report;
            crystalReportViewer2.Refresh();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            LoadVoyagesIntoComboBox();
        }

        private void cbVoyage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
