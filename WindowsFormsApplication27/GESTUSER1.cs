using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class GESTUSER1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTUSER1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTUSER1_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string utilisateur = txtUsername.Text;
            string motDePasse = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(utilisateur) || string.IsNullOrWhiteSpace(motDePasse))
            {
                showError("Attention", "Veuillez entrer un nom d'utilisateur et un mot de passe.");
                
                return;
            }

            string query = "INSERT INTO Employés (Utilisateur, mot_de_pass) VALUES (@Utilisateur, @motDePasse)";
            using (SqlConnection conn = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Utilisateur", utilisateur);
                    cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        showtoast("AJOUTER", "Utilisateur ajouté avec succès!");
                        mainForm.LogAction("Ajouté un nouvel utilisateur");

                        vider();
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de l'ajout de l'utilisateur : " + ex.Message);
                    }
                }
            }
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        public void vider()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
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
