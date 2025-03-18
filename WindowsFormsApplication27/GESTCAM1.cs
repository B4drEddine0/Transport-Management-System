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
    public partial class GESTCAM1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTCAM1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;

        }

        private void GESTCAM1_Load(object sender, EventArgs e)
        {

        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTCAM form = new GESTCAM(mainForm);
            mainForm.openChildForm(form);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_modele.Text) &&
               int.TryParse(txt_matricule.Text, out int matricule) &&
               !string.IsNullOrWhiteSpace(txt_assurance.Text))
            {
                string query = @"
                    INSERT INTO Camion (Modele, Matricule, assurance)
                    VALUES (@Modele, @Matricule, @assurance)";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Modele", txt_modele.Text);
                        command.Parameters.AddWithValue("@Matricule", matricule);
                        command.Parameters.AddWithValue("@assurance", txt_assurance.Text);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            
                            mainForm.LogAction("Ajouté un nouveau camion");
                            showtoast("AJOUTER", "Camion ajouté avec succès!");
                            vider();
                        }
                        catch (Exception ex)
                        {
                            showError("ERROR","Erreur lors de l'ajout du camion : " + ex.Message );
                          
                        }
                    }
                }
            }
            else
            {
                showError("Attention","Veuillez remplir tous les champs correctement." );
                
            }
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        public void vider()
        {
            txt_modele.Clear();
            txt_assurance.Clear();
            txt_matricule.Clear();
            txt_modele.Focus();
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
