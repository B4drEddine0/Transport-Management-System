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
    public partial class GESTDEP1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;

        public GESTDEP1(WindowsFormsApplication27.main mainForm,Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            LoadVoyagesIntoComboBox();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
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

        private void GESTDEP1_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(date_dep.Value.ToString(), out DateTime dateDépense) &&
                decimal.TryParse(txt_carbur.Text, out decimal carburant) &&
                decimal.TryParse(txt_peage.Text, out decimal péages) &&
                decimal.TryParse(txt_maint.Text, out decimal maintenance) &&
                decimal.TryParse(txt_chauff.Text, out decimal chauffeurSal) &&
                decimal.TryParse(txt_transit.Text, out decimal transitaire) &&
                decimal.TryParse(txt_parking.Text, out decimal parkings) &&
                decimal.TryParse(txt_marche.Text, out decimal marché) &&
                int.TryParse(cb_vyge.SelectedValue.ToString(), out int numVoyage))
            {
                string query = @"
                    INSERT INTO Dépense 
                    (date_dépense, carburant, péages, maintenance, chauffeur_sal, transitaire, parkings, marché, Num_Voyage)
                    VALUES (@date_dépense, @carburant, @péages, @maintenance, @chauffeur_sal, @transitaire, @parkings, @marché, @Num_Voyage)";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date_dépense", dateDépense);
                        command.Parameters.AddWithValue("@carburant", carburant);
                        command.Parameters.AddWithValue("@péages", péages);
                        command.Parameters.AddWithValue("@maintenance", maintenance);
                        command.Parameters.AddWithValue("@chauffeur_sal", chauffeurSal);
                        command.Parameters.AddWithValue("@transitaire", transitaire);
                        command.Parameters.AddWithValue("@parkings", parkings);
                        command.Parameters.AddWithValue("@marché", marché);
                        command.Parameters.AddWithValue("@Num_Voyage", numVoyage);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("AJOUTER", "Dépense ajouté avec succès!");
                            mainForm.LogAction("Ajouté une nouvelle dépense");

                            vider();
                        }
                        catch (Exception ex)
                        {
                            
                            showError("ERROR", "Erreur lors de l'ajout de la dépense : " + ex.Message);
                        }
                    }
                }
            }
            else
            {
               
                showError("ERROR", "Veuillez remplir tous les champs correctement.");
            }
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        public void vider()
        {
            cb_vyge.SelectedIndex = -1;
            txt_carbur.Clear();
            txt_chauff.Clear();
            txt_maint.Clear();
            txt_marche.Clear();
            txt_parking.Clear();
            txt_peage.Clear();
            txt_transit.Clear();
            date_dep.Value = DateTime.Now;
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTDEP d = new GESTDEP(mainForm);
            mainForm.openChildForm(d);
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
