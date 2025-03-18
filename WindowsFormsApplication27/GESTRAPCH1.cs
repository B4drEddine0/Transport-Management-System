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
    public partial class GESTRAPCH1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTRAPCH1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadChauffeursIntoComboBox();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTRAPCH1_Load(object sender, EventArgs e)
        {

        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        public void vider()
        {
            date_rap.Value=DateTime.Now;
            cb_chauff.SelectedIndex = -1;
            txt_descript.Clear();
            
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTRAPPCH form = new GESTRAPPCH(mainForm);
            mainForm.openChildForm(form);
        }

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
                        showError("ERROR", "Erreur lors du chargement des chauffeurs : " + ex.Message);
                       
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
            cb_chauff.SelectedIndex = -1;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(date_rap.Value.ToString(), out DateTime dateRapp) &&
              !string.IsNullOrWhiteSpace(txt_descript.Text) &&
              cb_chauff.SelectedValue != null)
            {
                string query = @"
                    INSERT INTO Rappelchauff (date_rapp, description_rapp, Num_Chauff) 
                    VALUES (@date_rapp, @description_rapp, @Num_Chauff)";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date_rapp", dateRapp);
                        command.Parameters.AddWithValue("@description_rapp", txt_descript.Text);
                        command.Parameters.AddWithValue("@Num_Chauff", cb_chauff.SelectedValue);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("AJOUTER", "Rappel Chauffeur ajouté avec succès!");
                            mainForm.LogAction("Ajouté un nouveau rappel chauffeur");

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
