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
    public partial class GESTCHAUFF : Form
    {
        private WindowsFormsApplication27.main mainForm;

        public GESTCHAUFF(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadData();
        }
        Class1 c = new Class1();


        private void GESTCHAUFF_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string query = "SELECT * FROM Chauffeur";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_chauff.DataSource = dt;

                    // Set font size and style
                    dataGridView_chauff.DefaultCellStyle.Font = new Font("Cambria", 8, FontStyle.Bold); // Adjust the font size as needed
                    dataGridView_chauff.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 10, FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    showError("ERROR", "Erreur: " + ex.Message);
                }
            }
        }


        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            LoadData();
        }


        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTCHAUFF1 form = new GESTCHAUFF1(mainForm, panelColor);
            mainForm.openChildForm(form);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_chauff.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_chauff.SelectedRows[0];
                int numChauff = Convert.ToInt32(selectedRow.Cells["Num_Chauff"].Value);
                string nomChauff = selectedRow.Cells["Nom_Chauff"].Value.ToString();
                string prenomChauff = selectedRow.Cells["Prenom_Chauff"].Value.ToString();
                string phone = selectedRow.Cells["phone"].Value.ToString();
                string gender = selectedRow.Cells["Gender"].Value.ToString();
                int age = Convert.ToInt32(selectedRow.Cells["age"].Value);
                string adresse = selectedRow.Cells["adresse"].Value.ToString();
                DateTime dateAdhesion = Convert.ToDateTime(selectedRow.Cells["date_adhésion"].Value);
                string cin = selectedRow.Cells["CIN"].Value.ToString();
                string permis = selectedRow.Cells["Permis"].Value.ToString();
                string passport = selectedRow.Cells["passport"].Value.ToString();
                string statusChauff = selectedRow.Cells["status_chauff"].Value.ToString();

                Color panelColor = GetPanelColor();
                GESTCHAUFF2 form = new GESTCHAUFF2(mainForm, numChauff, nomChauff, prenomChauff, phone, gender, age, adresse, dateAdhesion, cin, permis, passport, statusChauff, panelColor);
                mainForm.openChildForm(form);
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un chauffeur à modifier.");
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            if (dataGridView_chauff.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce chauffeur ?", "Suppression Chauffeur", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int numChauff = Convert.ToInt32(dataGridView_chauff.SelectedRows[0].Cells["Num_Chauff"].Value);
                    string query = "DELETE FROM Chauffeur WHERE Num_Chauff = @Num_Chauff";

                    using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Num_Chauff", numChauff);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                showtoast("SUPPRIMER", "Chauffeur supprimé avec succès.");
                                mainForm.LogAction("Supprimé un chauffeur");
                                LoadData();
                            }
                            catch (SqlException sqlEx) when (sqlEx.Number == 547) // Foreign Key violation
                            {
                                showError("Attention", "Vous devez supprimer les enregistrements liés dans les tables Rappel Chauffeur et Voyage avant de pouvoir supprimer ce chauffeur.");
                            }
                            catch (Exception ex)
                            {
                                showError("ERROR", "Erreur lors de la suppression du chauffeur : " + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un chauffeur à supprimer.");
            }
        }


        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer le nom du chauffeur pour la recherche.");

            }
            else
            {
                string searchQuery = "SELECT * FROM Chauffeur WHERE Nom_Chauff LIKE @Nom_Chauff";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(searchQuery, connection);
                        cmd.Parameters.AddWithValue("@Nom_Chauff", "%" + txt_rech.Text + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable searchResult = new DataTable();
                        adapter.Fill(searchResult);

                        if (searchResult.Rows.Count > 0)
                        {
                            dataGridView_chauff.DataSource = searchResult;
                        }
                        else
                        {
                            MessageBox.Show("Aucun résultat trouvé.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur: " + ex.Message);
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
            if (dataGridView_chauff.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_chauff.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_chauff.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_chauff.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_chauff.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_chauff.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Chauffeur vers Excel");
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

        private void dataGridView_chauff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
