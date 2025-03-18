using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class GESTUSER : Form
    {
        private WindowsFormsApplication27.main mainForm;

        public GESTUSER(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadUsers();
        }

        private void GESTUSER_Load(object sender, EventArgs e)
        {

        }

        private void LoadUsers()
        {
            string query = "SELECT * FROM Employés";

            using (SqlConnection conn = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    showError("ERROR", "Erreur lors du chargement des utilisateurs : " + ex.Message);
                   
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
            GESTUSER1 form = new GESTUSER1(mainForm, panelColor);
            mainForm.openChildForm(form);
            LoadUsers(); // Refresh users list after adding a new user
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Color panelColor = GetPanelColor();
                int userId = (int)dataGridView1.SelectedRows[0].Cells["user_id"].Value;
                GESTUSER2 form = new GESTUSER2(mainForm, userId, panelColor);
                mainForm.openChildForm(form);
                LoadUsers(); // Refresh users list after modifying a user
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un utilisateur à modifier.");
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = (int)dataGridView1.SelectedRows[0].Cells["user_id"].Value;

                var confirmResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?",
                                                    "Confirmer la suppression",
                                                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM Employés WHERE user_id = @userId";

                    using (SqlConnection conn = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                            showtoast("SUPPRIMER", "Utilisateur supprimé avec succès.");
                            mainForm.LogAction("Supprimé un utilisateur");

                            LoadUsers(); // Refresh users list after deleting a user
                        }
                        catch (Exception ex)
                        {
                            showError("ERROR", "Erreur lors de la suppression de l'utilisateur : " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un utilisateur à supprimer.");
            }
        }

        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            LoadUsers();
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer le nom du utilisateur pour la recherche.");
              
            }
            else
            {
                string searchQuery = @"
            SELECT 
                *
            FROM 
                Employés
               
            WHERE 
               Utilisateur LIKE @Utilisateur";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(searchQuery, connection);
                        cmd.Parameters.AddWithValue("@Utilisateur", "%" + txt_rech.Text + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable searchResult = new DataTable();
                        adapter.Fill(searchResult);

                        if (searchResult.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = searchResult;
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

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Utilisateur vers Excel");
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
