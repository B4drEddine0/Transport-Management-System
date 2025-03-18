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
    public partial class GESTRAPCAM : Form
    {
        private WindowsFormsApplication27.main mainForm;

        public GESTRAPCAM(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadData();
        }

        private void GESTRAPCAM_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string query = @"
                SELECT 
                    r.Num_rapp,
                    r.date_rapp,
                    r.description_rapp,
                    c.Matricule
                FROM 
                    Rappelcam r
                    INNER JOIN Camion c ON r.Num_Cam = c.Num_Cam";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_rapcam.DataSource = dt;
                }
                catch (Exception ex)
                {
                    showError("ERROR", "Erreur: " + ex.Message);
                   
                }
            }
        }


        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTRAPCAM1 form = new GESTRAPCAM1(mainForm, panelColor);
            mainForm.openChildForm(form);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_rapcam.SelectedRows.Count > 0)
            {
                int numRapp = Convert.ToInt32(dataGridView_rapcam.SelectedRows[0].Cells["Num_rapp"].Value);
                DateTime dateRapp = Convert.ToDateTime(dataGridView_rapcam.SelectedRows[0].Cells["date_rapp"].Value);
                string descriptionRapp = dataGridView_rapcam.SelectedRows[0].Cells["description_rapp"].Value.ToString();
                string matricule = dataGridView_rapcam.SelectedRows[0].Cells["Matricule"].Value.ToString();

                Color panelColor = GetPanelColor();
                GESTRAPCAM2 form = new GESTRAPCAM2(mainForm, numRapp, dateRapp, descriptionRapp, matricule, panelColor);
                mainForm.openChildForm(form);
            }
            else
            {
                showError("Attention","Veuillez sélectionner un rappel à modifier." );
               
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            if (dataGridView_rapcam.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce rappel ?", "Suppression Rappel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int numRapp = Convert.ToInt32(dataGridView_rapcam.SelectedRows[0].Cells["Num_rapp"].Value);
                    string query = "DELETE FROM Rappelcam WHERE Num_rapp = @Num_rapp";

                    using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Num_rapp", numRapp);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                showtoast("SUPPRIMER", "Rappel Camion supprimé avec succès.");
                                mainForm.LogAction("Supprimé un rappel camion");

                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                showError("ERROR", "Erreur lors de la suppression du rappel : " + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un rappel à supprimer.");
            }
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer le matricule pour la recherche.");
               
            }
            else
            {
                string searchQuery = @"
                    SELECT 
                        r.Num_rapp,
                        r.date_rapp,
                        r.description_rapp,
                        c.Matricule
                    FROM 
                        Rappelcam r
                        INNER JOIN Camion c ON r.Num_Cam = c.Num_Cam
                    WHERE 
                        c.Matricule LIKE @Matricule";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(searchQuery, connection);
                        cmd.Parameters.AddWithValue("@Matricule", "%" + txt_rech.Text + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable searchResult = new DataTable();
                        adapter.Fill(searchResult);

                        if (searchResult.Rows.Count > 0)
                        {
                            dataGridView_rapcam.DataSource = searchResult;
                        }
                        else
                        {
                            showError("ERROR", "Aucun résultat trouvé.");
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur: " + ex.Message);
                    }
                }
            }
        }

        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            LoadData();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_rapcam.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_rapcam.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_rapcam.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_rapcam.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_rapcam.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_rapcam.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Rappelcam vers Excel");
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
    }
}
