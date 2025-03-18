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
    public partial class GESTFRIGO1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTFRIGO1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadCamionsIntoComboBox();


            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        private void GESTFRIGO1_Load(object sender, EventArgs e)
        {

        }

        private void LoadCamionsIntoComboBox()
        {
            DataTable dtCamions = LoadCamions();
            cb_num_camion.DataSource = dtCamions;
            cb_num_camion.DisplayMember = "Matricule";
            cb_num_camion.ValueMember = "Num_Cam";
            cb_num_camion.SelectedIndex = -1;
        }

        private DataTable LoadCamions()
        {
            DataTable dtCamions = new DataTable();
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = "SELECT Num_Cam, Matricule FROM Camion";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtCamions);
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors du chargement des camions : " + ex.Message);
                       
                    }
                }
            }

            return dtCamions;
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTFRIGO form = new GESTFRIGO(mainForm);
            mainForm.openChildForm(form);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_capacity.Text, out decimal capacity) &&
               int.TryParse(txt_matricule.Text, out int matriculeFrigo) &&
               cb_num_camion.SelectedIndex != -1)
            {
                int numCam = (int)cb_num_camion.SelectedValue;
                string query = @"
                    INSERT INTO Frigo (capacity, Matricule_frig, Num_Cam)
                    VALUES (@capacity, @Matricule_frig, @Num_Cam)";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@capacity", capacity);
                        command.Parameters.AddWithValue("@Matricule_frig", matriculeFrigo);
                        command.Parameters.AddWithValue("@Num_Cam", numCam);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            showtoast("AJOUTER", "Frigo ajouté avec succès!");
                            mainForm.LogAction("Ajouté un nouveau frigo");
                            vider();
                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de l'ajout du frigo : " + ex.Message);
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
            txt_capacity.Clear();
            txt_matricule.Clear();
            cb_num_camion.SelectedIndex = -1;
            txt_capacity.Focus();
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
