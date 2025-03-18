using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class GESTUSER2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int userId;
        private Color panelColor;
        public GESTUSER2(WindowsFormsApplication27.main mainForm, int userId, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.userId = userId;
            LoadUserData();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTUSER2_Load(object sender, EventArgs e)
        {

        }

        private void LoadUserData()
        {
            string query = "SELECT Utilisateur, mot_de_pass FROM Employés WHERE user_id = @userId";
            using (SqlConnection conn = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["Utilisateur"].ToString();
                            txtPassword.Text = reader["mot_de_pass"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors du chargement des données de l'utilisateur : " + ex.Message);
                        
                    }
                }
            }
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            string utilisateur = txtUsername.Text;
            string motDePasse = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(utilisateur) || string.IsNullOrWhiteSpace(motDePasse))
            {
                showError("Attention", "Veuillez entrer un nom d'utilisateur et un mot de passe.");
                return;
            }

            string query = "UPDATE Employés SET Utilisateur = @Utilisateur, mot_de_pass = @motDePasse WHERE user_id = @userId";
            using (SqlConnection conn = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Utilisateur", utilisateur);
                    cmd.Parameters.AddWithValue("@motDePasse", motDePasse);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        showtoast("MODIFIER", "Utilisateur modifié avec succès");
                        mainForm.LogAction("Modifié un utilisateur");

                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la mise à jour de l'utilisateur : " + ex.Message);
                        
                    }
                }
            }
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTUSER form = new GESTUSER(mainForm);
            mainForm.openChildForm(form);
        }

        private void btn_retour_Click_1(object sender, EventArgs e)
        {
            GESTUSER fr = new GESTUSER(mainForm);
            mainForm.openChildForm(fr);
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
