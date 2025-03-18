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
    public partial class GESTCAM2 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private int numCam;
        private Color panelColor;
        public GESTCAM2(WindowsFormsApplication27.main mainForm, int numCam, string modele, int matricule, string assurance,Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.numCam = numCam;

            txt_modele.Text = modele;
            txt_matricule.Text = matricule.ToString();
            txt_assurance.Text = assurance;
            txt_num.Text = numCam.ToString();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTCAM2_Load(object sender, EventArgs e)
        {

        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTCAM form = new GESTCAM(mainForm);
            mainForm.openChildForm(form);
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_modele.Text) &&
                int.TryParse(txt_matricule.Text, out int matricule) &&
                !string.IsNullOrWhiteSpace(txt_assurance.Text))
            {
                string query = @"
                    UPDATE Camion 
                    SET 
                        Modele = @Modele,
                        Matricule = @Matricule,
                        assurance = @assurance
                    WHERE 
                        Num_Cam = @Num_Cam";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Num_Cam", numCam);
                        command.Parameters.AddWithValue("@Modele", txt_modele.Text);
                        command.Parameters.AddWithValue("@Matricule", matricule);
                        command.Parameters.AddWithValue("@assurance", txt_assurance.Text);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("MODIFIER", "Camion modifié avec succès");
                            mainForm.LogAction("Modifié un camion");
                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de la modification du camion : " + ex.Message);
                            
                        }
                    }
                }
            }
            else
            {
                showError("Attention","Veuillez remplir tous les champs correctement." );
              
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
