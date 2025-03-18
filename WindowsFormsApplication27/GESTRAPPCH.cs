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
    public partial class GESTRAPPCH : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTRAPPCH(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadRappelChauff();
        }


        private void LoadRappelChauff()
        {
            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = @"
                SELECT 
                    rc.Num_rapp, 
                    rc.date_rapp, 
                    rc.description_rapp, 
                    rc.Num_Chauff,
                    ch.Nom_Chauff 
                FROM 
                    Rappelchauff rc
                JOIN 
                    Chauffeur ch ON rc.Num_Chauff = ch.Num_Chauff";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView_rapch.DataSource = dt;
                        if (dataGridView_rapch.Columns["Num_Chauff"] != null)
                        {
                            dataGridView_rapch.Columns["Num_Chauff"].Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors du chargement des rappels : " + ex.Message);
                        
                    }
                }
            }
        }
        private void GESTRAPPCH_Load(object sender, EventArgs e)
        {

        }


        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            Color panelColor = GetPanelColor();
            GESTRAPCH1 form = new GESTRAPCH1(mainForm, panelColor);
            mainForm.openChildForm(form);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_rapch.SelectedRows.Count > 0)
            {
                int numRapp = Convert.ToInt32(dataGridView_rapch.SelectedRows[0].Cells["Num_rapp"].Value);
                DateTime dateRapp = Convert.ToDateTime(dataGridView_rapch.SelectedRows[0].Cells["date_rapp"].Value);
                string descriptionRapp = dataGridView_rapch.SelectedRows[0].Cells["description_rapp"].Value.ToString();
                int numChauff = Convert.ToInt32(dataGridView_rapch.SelectedRows[0].Cells["Num_Chauff"].Value);
                string nomChauff = dataGridView_rapch.SelectedRows[0].Cells["Nom_Chauff"].Value.ToString();

                Color panelColor = GetPanelColor();
                GESTRAPCH2 form = new GESTRAPCH2(mainForm, numRapp, dateRapp, descriptionRapp, numChauff, nomChauff, panelColor);
                mainForm.openChildForm(form);
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un rappel à modifier.");
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            if (dataGridView_rapch.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce rappel ?", "Suppression Rappel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int numRapp = Convert.ToInt32(dataGridView_rapch.SelectedRows[0].Cells["Num_rapp"].Value);
                        string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
                        string query = "DELETE FROM Rappelchauff WHERE Num_rapp = @Num_rapp";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Num_rapp", numRapp);
                                connection.Open();
                                command.ExecuteNonQuery();
                                showtoast("SUPPRIMER", "Rappel supprimé avec succès.");
                                mainForm.LogAction("Supprimé un rappel chauffeur");

                                LoadRappelChauff();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la suppression du rappel : " + ex.Message);
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
                showError("Attention", "Veuillez entrer le nom du chauffeur pour la recherche.");
                
            }
            else
            {
                string searchQuery = @"
            SELECT 
                r.Num_rapp,
                r.date_rapp,
                r.description_rapp,
                c.Nom_Chauff
            FROM 
                Rappelchauff r
                INNER JOIN Chauffeur c ON r.Num_Chauff = c.Num_Chauff
            WHERE 
                c.Nom_Chauff LIKE @Nom_Chauff";

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
                            dataGridView_rapch.DataSource = searchResult;
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
            LoadRappelChauff();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_rapch.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_rapch.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_rapch.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_rapch.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_rapch.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_rapch.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Rappelchauff vers Excel");
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
