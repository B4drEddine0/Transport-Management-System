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
    public partial class GESTCHAUFF2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int numChauff;
        private Color panelColor;
        public GESTCHAUFF2(WindowsFormsApplication27.main mainForm, int numChauff, string nomChauff, string prenomChauff, string phone, string gender, int age, string adresse, DateTime dateAdhesion, string cin, string permis, string passport, string statusChauff, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.numChauff = numChauff;

            txt_nom.Text = nomChauff;
            txt_prenom.Text = prenomChauff;
            txt_phone.Text = phone;
            cb_gender.Text = gender;
            txt_age.Text = age.ToString();
            txt_adresse.Text = adresse;
            date_adh.Value = dateAdhesion;
            txt_cin.Text = cin;
            txt_permis.Text = permis;
            txt_passport.Text = passport;
            cb_status.Text = statusChauff;
            txt_num.Text = numChauff.ToString();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTCHAUFF form = new GESTCHAUFF(mainForm);
            mainForm.openChildForm(form);
        }

        private void btn_mod_Click(object sender, EventArgs e)
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
                    UPDATE Chauffeur 
                    SET 
                        Nom_Chauff = @Nom_Chauff,
                        Prenom_Chauff = @Prenom_Chauff,
                        phone = @phone,
                        Gender = @Gender,
                        age = @age,
                        adresse = @adresse,
                        date_adhésion = @date_adhésion,
                        CIN = @CIN,
                        Permis = @Permis,
                        passport = @passport,
                        status_chauff = @status_chauff
                    WHERE 
                        Num_Chauff = @Num_Chauff";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Num_Chauff", numChauff);
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
                            showtoast("MODIFIER", "Chauffeur modifié avec succès");
                            mainForm.LogAction("Modifié un chauffeur");
                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de la modification du chauffeur : " + ex.Message);
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
