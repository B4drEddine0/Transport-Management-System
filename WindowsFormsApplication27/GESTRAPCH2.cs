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
    public partial class GESTRAPCH2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int numRapp;
        private int numChauff;
        private string nomChauff;
        private Color panelColor;

        public GESTRAPCH2(WindowsFormsApplication27.main mainForm, int numRapp, DateTime dateRapp, string descriptionRapp, int numChauff, string nomChauff, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.numRapp = numRapp;
            this.numChauff = numChauff;
            this.nomChauff = nomChauff;

            date_rap.Value = dateRapp;
            txt_descript.Text = descriptionRapp;
            txt_num.Text = numRapp.ToString();

            LoadChauffeursIntoComboBox();
            SetComboBoxSelectedValue();

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTRAPCH2_Load(object sender, EventArgs e)
        {
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
        }

        private void SetComboBoxSelectedValue()
        {
            if (cb_chauff.Items.Count > 0)
            {
                cb_chauff.SelectedValue = numChauff;
               
            }
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(date_rap.Value.ToString(), out DateTime dateRapp) &&
               !string.IsNullOrWhiteSpace(txt_descript.Text) &&
               cb_chauff.SelectedValue != null)
            {
                int numChauff = (int)cb_chauff.SelectedValue;

                string query = @"
                    UPDATE Rappelchauff 
                    SET 
                        date_rapp = @date_rapp,
                        description_rapp = @description_rapp,
                        Num_Chauff = @Num_Chauff
                    WHERE 
                        Num_rapp = @Num_rapp";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Num_rapp", numRapp);
                        command.Parameters.AddWithValue("@date_rapp", dateRapp);
                        command.Parameters.AddWithValue("@description_rapp", txt_descript.Text);
                        command.Parameters.AddWithValue("@Num_Chauff", numChauff);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("MODIFIER", "Rappel Chauffeur modifié avec succès");
                            mainForm.LogAction("Modifié un rappel chauffeur");

                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de la modification du rappel : " + ex.Message);
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

        private void cb_chauff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
