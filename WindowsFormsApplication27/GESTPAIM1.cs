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
    public partial class GESTPAIM1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTPAIM1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            LoadVoyagesIntoComboBox();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTPAIM1_Load(object sender, EventArgs e)
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
            cb_vyge.DataSource = dtVoyages;
            cb_vyge.DisplayMember = "Num_Voyage";
            cb_vyge.ValueMember = "Num_Voyage";
            cb_vyge.SelectedIndex = -1;
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTPAIM m = new GESTPAIM(mainForm);
            mainForm.openChildForm(m);
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        public void vider()
        {
            cb_vyge.SelectedIndex = -1;
            date_paim.Value = DateTime.Now;
            txt_prix.Clear();
            txt_descrip.Clear();
            cb_statut.SelectedIndex = -1;
            cb_methode.SelectedIndex = -1;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cb_vyge.SelectedIndex == -1 || cb_methode.SelectedIndex == -1 || cb_statut.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_prix.Text) || string.IsNullOrWhiteSpace(txt_descrip.Text))
            {
                showError("Attention", "Veuillez remplir tous les champs obligatoires.");
                
                return;
            }

            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = @"
                INSERT INTO Paiements (Date_Paiement, Montant_Total, Paiement_Method, Description, Statut, Num_Voyage)
                VALUES (@Date_Paiement, @Montant_Total, @Paiement_Method, @Description, @Statut, @Num_Voyage)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date_Paiement", date_paim.Value);
                    command.Parameters.AddWithValue("@Montant_Total", decimal.Parse(txt_prix.Text));
                    command.Parameters.AddWithValue("@Paiement_Method", cb_methode.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Description", txt_descrip.Text);
                    command.Parameters.AddWithValue("@Statut", cb_statut.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Num_Voyage", cb_vyge.SelectedValue);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            showtoast("AJOUTER", "Paiement ajouté avec succès!");
                            mainForm.LogAction("Ajouté un nouveau paiement");

                            // Optionally, clear the form fields after successful insertion
                            vider();
                            cb_vyge.SelectedIndex = -1;
                        }
                        else
                        {
                            showError("ERROR","Aucun paiement ajouté." );
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de l'ajout du paiement : " + ex.Message);
                    }
                }



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
