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
    public partial class GESTPAIM2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int paiementId;
        private DateTime datePaiement;
        private decimal montantTotal;
        private string paiementMethod;
        private string description;
        private string statut;
        private int numVoyage;
        private Color panelColor;
        public GESTPAIM2(WindowsFormsApplication27.main mainForm, int paiementId, DateTime datePaiement, decimal montantTotal, string paiementMethod, string description, string statut, int numVoyage, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

           
            this.paiementId = paiementId;
            this.datePaiement = datePaiement;
            this.montantTotal = montantTotal;
            this.paiementMethod = paiementMethod;
            this.description = description;
            this.statut = statut;
            this.numVoyage = numVoyage;

            // Remplir les champs avec les valeurs reçues
            date_paim.Value = datePaiement;
            txt_prix.Text = montantTotal.ToString();
            cb_methode.Text = paiementMethod;
            txt_descrip.Text = description;
            cb_statut.Text = statut;
            txt_num.Text = paiementId.ToString();

            LoadVoyagesIntoComboBox();
            SetComboBoxSelectedValues();

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        Class1 c = new Class1();

        private void GESTPAIM2_Load(object sender, EventArgs e)
        {

        }

        private void SetComboBoxSelectedValues()
        {
            // Set the selected value only if the value exists in the ComboBox
            if (cb_vyge.Items.Cast<DataRowView>().Any(item => (int)item["Num_Voyage"] == numVoyage))
            {
                cb_vyge.SelectedValue = numVoyage;
            }
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
                        showError("ERROR", "Erreur lors du chargement des voyages : " + ex.Message);
                    }
                }
            }

            return dtVoyages;
        }

        private void LoadVoyagesIntoComboBox()
        {
            DataTable dtVoyages = LoadVoyages();
            cb_vyge.DataSource = dtVoyages;
            cb_vyge.DisplayMember = "Num_Voyage";
            cb_vyge.ValueMember = "Num_Voyage";
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTPAIM p = new GESTPAIM(mainForm);
            mainForm.openChildForm(p);
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected value from the ComboBox
                if (cb_vyge.SelectedValue == null || !int.TryParse(cb_vyge.SelectedValue.ToString(), out numVoyage))
                {
                    showError("Attention", "Veuillez sélectionner un voyage valide.");
                    return;
                }

                // Open the database connection
                c.cn.Open();

                // Prepare the SQL update query
                string updateQuery = "UPDATE Paiements SET Date_Paiement = @Date_Paiement, Montant_Total = @Montant_Total, Paiement_Method = @Paiement_Method, Description = @Description, Statut = @Statut, Num_Voyage = @Num_Voyage WHERE Paiement_Id = @Paiement_Id";

                // Create a SqlCommand object with the update query and connection
                SqlCommand cmd = new SqlCommand(updateQuery, c.cn);

                // Set parameters for the update query
                cmd.Parameters.AddWithValue("@Date_Paiement", date_paim.Value);
                cmd.Parameters.AddWithValue("@Montant_Total", decimal.Parse(txt_prix.Text));
                cmd.Parameters.AddWithValue("@Paiement_Method", cb_methode.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Description", txt_descrip.Text);
                cmd.Parameters.AddWithValue("@Statut", cb_statut.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Num_Voyage", numVoyage);
                cmd.Parameters.AddWithValue("@Paiement_Id", paiementId);

                // Execute the update query
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if any rows were updated
                if (rowsAffected > 0)
                {
                    showtoast("MODIFIER", "Paiement modifié avec succès");
                    mainForm.LogAction("Modifié un paiement");

                }
                else
                {
                    showError("ERROR", "Aucun paiement trouvé avec ce numéro.");
                }
            }
            catch (Exception ex)
            {
                showError("ERROR", "Erreur lors de la modification du paiement: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                c.cn.Close();
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
