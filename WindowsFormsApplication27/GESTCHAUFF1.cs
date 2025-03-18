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
    public partial class GESTCHAUFF1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTCHAUFF1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_nom.Text) &&
               !string.IsNullOrWhiteSpace(txt_prenom.Text) &&
               !string.IsNullOrWhiteSpace(txt_phone.Text) &&
               !string.IsNullOrWhiteSpace(cb_gender.Text) &&
               int.TryParse(txt_age.Text, out int age) &&
               !string.IsNullOrWhiteSpace(txt_adresse.Text) &&
               DateTime.TryParse(date_adh.Value.ToString(), out DateTime dateAdhesion) &&
               !string.IsNullOrWhiteSpace(txt_cin.Text) &&
               !string.IsNullOrWhiteSpace(txt_permis.Text) &&
               !string.IsNullOrWhiteSpace(txt_passport.Text) &&
               !string.IsNullOrWhiteSpace(cb_status.Text))
            {
                string query = @"
                    INSERT INTO Chauffeur (Nom_Chauff, Prenom_Chauff, phone, Gender, age, adresse, date_adhésion, CIN, Permis, passport, status_chauff)
                    VALUES (@Nom_Chauff, @Prenom_Chauff, @phone, @Gender, @age, @adresse, @date_adhésion, @CIN, @Permis, @passport, @status_chauff)";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nom_Chauff", txt_nom.Text);
                        command.Parameters.AddWithValue("@Prenom_Chauff", txt_prenom.Text);
                        command.Parameters.AddWithValue("@phone", txt_phone.Text);
                        command.Parameters.AddWithValue("@Gender", cb_gender.Text);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@adresse", txt_adresse.Text);
                        command.Parameters.AddWithValue("@date_adhésion", dateAdhesion);
                        command.Parameters.AddWithValue("@CIN", txt_cin.Text);
                        command.Parameters.AddWithValue("@Permis", txt_permis.Text);
                        command.Parameters.AddWithValue("@passport", txt_passport.Text);
                        command.Parameters.AddWithValue("@status_chauff", cb_status.Text);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("AJOUTER", "Chauffeur ajouté avec succès!");
                            mainForm.LogAction("Ajouté un nouveau chauffeur");
                            vider();
                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de l'ajout du chauffeur : " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez remplir tous les champs correctement.");
            }
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        public void vider()
        {
            txt_nom.Clear();
            txt_prenom.Clear();
            txt_permis.Clear();
            txt_passport.Clear();
            txt_phone.Clear();
            txt_adresse.Clear();
            date_adh.Value = DateTime.Now;
            cb_gender.SelectedIndex = -1;
            cb_status.SelectedIndex = -1;
            txt_age.Clear();
            txt_cin.Clear();
            txt_nom.Focus();
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTCHAUFF f = new GESTCHAUFF(mainForm);
            mainForm.openChildForm(f);
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
