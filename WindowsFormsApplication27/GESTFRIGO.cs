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
    public partial class GESTFRIGO : Form
    {
        private WindowsFormsApplication27.main mainForm;
        
        public GESTFRIGO(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadData();
        }

        private void GESTFRIGO_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string query = @"
                SELECT 
                    f.Num_frig, 
                    f.capacity, 
                    f.Matricule_frig, 
                    c.Matricule AS Matricule_Camion 
                FROM 
                    Frigo f
                    INNER JOIN Camion c ON f.Num_Cam = c.Num_Cam";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_frigos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    showError("ERROR","Erreur: " + ex.Message );
                    
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
            GESTFRIGO1 form = new GESTFRIGO1(mainForm, panelColor);
            mainForm.openChildForm(form);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_frigos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_frigos.SelectedRows[0];
                int numFrigo = Convert.ToInt32(selectedRow.Cells["Num_frig"].Value);
                decimal capacity = Convert.ToDecimal(selectedRow.Cells["capacity"].Value);
                int matriculeFrigo = Convert.ToInt32(selectedRow.Cells["Matricule_frig"].Value);
                int numCam = GetNumCamByMatricule(selectedRow.Cells["Matricule_Camion"].Value.ToString());

                Color panelColor = GetPanelColor();
                GESTFRIGO2 form = new GESTFRIGO2(mainForm, numFrigo, capacity, matriculeFrigo, numCam, panelColor);
                mainForm.openChildForm(form);
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un frigo à modifier.");
            }
        }

        private int GetNumCamByMatricule(string matricule)
        {
            int numCam = -1;
            string query = "SELECT Num_Cam FROM Camion WHERE Matricule = @Matricule";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Matricule", matricule);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            numCam = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la récupération du Num_Cam : " + ex.Message);
                    }
                }
            }

            return numCam;
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            if (dataGridView_frigos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce frigo ?", "Suppression Frigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int numFrigo = Convert.ToInt32(dataGridView_frigos.SelectedRows[0].Cells["Num_frig"].Value);
                    string query = "DELETE FROM Frigo WHERE Num_frig = @Num_frig";

                    using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Num_frig", numFrigo);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                showtoast("SUPPRIMER", "Frigo supprimé avec succès.");
                                mainForm.LogAction("Supprimé un frigo");
                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                showError("ERROR", "Erreur lors de la suppression du frigo : " + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un frigo à supprimer.");
            }
        }

        public void LogAction(string username, string action, string tableName)
        {
            string query = "INSERT INTO History (Username, Action, TableName) VALUES (@Username, @Action, @TableName)";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Action", action);
                cmd.Parameters.AddWithValue("@TableName", tableName);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    showError("ERROR", $"Error logging action: {ex.Message}");
                }
            }
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer le matricule du frigo pour la recherche.");
               
            }
            else
            {
                string searchQuery = @"
                    SELECT 
                        f.Num_frig, 
                        f.capacity, 
                        f.Matricule_frig, 
                        c.Matricule AS Matricule_Camion 
                    FROM 
                        Frigo f
                        INNER JOIN Camion c ON f.Num_Cam = c.Num_Cam
                    WHERE 
                        f.Matricule_frig LIKE @Matricule_frig";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(searchQuery, connection);
                        cmd.Parameters.AddWithValue("@Matricule_frig", "%" + txt_rech.Text + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable searchResult = new DataTable();
                        adapter.Fill(searchResult);

                        if (searchResult.Rows.Count > 0)
                        {
                            dataGridView_frigos.DataSource = searchResult;
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
            if (dataGridView_frigos.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_frigos.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_frigos.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_frigos.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_frigos.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_frigos.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Frigo vers Excel");
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
