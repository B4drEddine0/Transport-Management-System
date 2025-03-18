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
    public partial class GESTCAM : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTCAM(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadData();
        }
        Class1 c = new Class1();

        private void GESTCAM_Load(object sender, EventArgs e)
        {
          
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Camion";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_camions.DataSource = dt;
                }
                catch (Exception ex)
                {
                    showError("ERROR", "Erreur: " + ex.Message);
                }
            }
        }

        public void vider()
        {
           
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        

        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            
        }

        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTCAM1 form = new GESTCAM1(mainForm, panelColor);
            mainForm.openChildForm(form);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_camions.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_camions.SelectedRows[0];
                int numCam = Convert.ToInt32(selectedRow.Cells["Num_Cam"].Value);
                string modele = selectedRow.Cells["Modele"].Value.ToString();
                int matricule = Convert.ToInt32(selectedRow.Cells["Matricule"].Value);
                string assurance = selectedRow.Cells["assurance"].Value.ToString();

                Color panelColor = GetPanelColor();
                GESTCAM2 form = new GESTCAM2(mainForm, numCam, modele, matricule, assurance, panelColor);
                mainForm.openChildForm(form);
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un camion à modifier.");
               
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            if (dataGridView_camions.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce camion ?", "Suppression Camion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int numCam = Convert.ToInt32(dataGridView_camions.SelectedRows[0].Cells["Num_Cam"].Value);
                    string query = "DELETE FROM Camion WHERE Num_Cam = @Num_Cam";

                    using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Num_Cam", numCam);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                
                                mainForm.LogAction("Supprimé un camion");
                                showtoast("SUPPRIMER", "Camion supprimé avec succès.");
                                LoadData();
                            }
                            catch (SqlException sqlEx) when (sqlEx.Number == 547) // Foreign Key violation
                            {
                                showError("ERROR","Vous devez supprimer les enregistrements liés dans les tables Frigo, Rappel Camion, et Maintenance avant de pouvoir supprimer ce camion.");
                               
                            }
                            catch (Exception ex)
                            {
                                showError("ERROR","Erreur lors de la suppression du camion : " + ex.Message );
                               
                            }
                        }
                    }
                }
            }
            else
            {
                showError("Attention","Veuillez sélectionner un camion à supprimer." );
               
            }
        }


        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer le modèle du camion pour la recherche.");
                
            }
            else
            {
                string searchQuery = "SELECT * FROM Camion WHERE Modele LIKE @Modele";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(searchQuery, connection);
                        cmd.Parameters.AddWithValue("@Modele", "%" + txt_rech.Text + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable searchResult = new DataTable();
                        adapter.Fill(searchResult);

                        if (searchResult.Rows.Count > 0)
                        {
                            dataGridView_camions.DataSource = searchResult;
                        }
                        else
                        {
                            showError("Attention","Aucun résultat trouvé." );
                          
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR","Erreur: " + ex.Message );
                     
                    }
                }
            }
        }

        private void btn_tous_Click_1(object sender, EventArgs e)
        {
            txt_rech.Clear();
            LoadData();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_camions.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_camions.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_camions.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_camions.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_camions.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_camions.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Camion vers Excel");
                showtoast("EXPORTER", "Données exporté avec succès!");
            }
            else
            {
                showError("ERROR", "No records found!");
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Minimized;
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

        private void dataGridView_camions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
