using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.HashCodeHelper;

namespace WindowsFormsApplication27
{
    public partial class GESTDEP2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int dépenseNum;
        private Color panelColor;
        public GESTDEP2(WindowsFormsApplication27.main mainForm, int dépenseNum, DateTime dateDépense, decimal carburant, decimal péages, decimal maintenance, decimal chauffeurSal, decimal transitaire, decimal parkings, decimal marché, int numVoyage, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.dépenseNum = dépenseNum;

            date_dep.Value = dateDépense;
            txt_carbur.Text = carburant.ToString();
            txt_peage.Text = péages.ToString();
            txt_maint.Text = maintenance.ToString();
            txt_chauff.Text = chauffeurSal.ToString();
            txt_transit.Text = transitaire.ToString();
            txt_parking.Text = parkings.ToString();
            txt_marche.Text = marché.ToString();
            txt_num.Text=dépenseNum.ToString();
            cb_vyge.Text = numVoyage.ToString();
            LoadVoyagesIntoComboBox();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTDEP d = new GESTDEP(mainForm);
            mainForm.openChildForm(d);

            
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
                        showError("ERROR","Error loading voyages: " + ex.Message );
                       
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

        private void btn_mod_Click(object sender, EventArgs e)
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
                    UPDATE Dépense 
                    SET 
                        date_dépense = @date_dépense,
                        carburant = @carburant,
                        péages = @péages,
                        maintenance = @maintenance,
                        chauffeur_sal = @chauffeur_sal,
                        transitaire = @transitaire,
                        parkings = @parkings,
                        marché = @marché,
                        Num_Voyage = @Num_Voyage
                    WHERE 
                        dépense_num = @dépense_num";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dépense_num", dépenseNum);
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
                            showtoast("MODIFIER", "Dépense modifié avec succès");
                            mainForm.LogAction("Modifié une dépense");

                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de la modification de la dépense : " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                showError("ERROR", "Veuillez remplir tous les champs correctement.");
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
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
