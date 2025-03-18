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
    public partial class GESTPAIM : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTPAIM(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        Class1 c = new Class1();

        private void GESTPAIM_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private DataTable ConnectandReadList(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Error connecting to database: " + ex.Message);
                      
                    }
                }
            }

            return dataTable;
        }

        // Method to refresh data in DataGridView
        private void RefreshData()
        {
            string query = @"
                SELECT 
                    p.Paiement_Id, 
                    p.Date_Paiement, 
                    p.Montant_Total, 
                    p.Paiement_Method, 
                    p.Description, 
                    p.Statut, 
                    p.Num_Voyage,
                    v.Ville_Dep, 
                    v.Ville_Arr
                FROM 
                    Paiements p
                    INNER JOIN Voyage v ON p.Num_Voyage = v.Num_Voyage";

            DataTable dataTable = ConnectandReadList(query);

            if (dataTable != null)
            {
                BindingSource bs = new BindingSource
                {
                    DataSource = dataTable
                };
                dataGridView_paim.DataSource = bs;
                bs.ResetBindings(false);

                // Optionally, hide the Num_Voyage column if you don't want to display it
                if (dataGridView_paim.Columns["Num_Voyage"] != null)
                {
                    dataGridView_paim.Columns["Num_Voyage"].Visible = false;
                }
            }
            else
            {
                showError("ERROR", "No data found to display.");
               
            }
        }

        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            RefreshData();
        }

     

      
       

        private void btn_rech_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btn_rech_Click_1(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer un statut de recherche pour le paiement.");
               
            }
            else
            {
                string searchQuery = @"
         SELECT 
             p.Paiement_Id, 
             p.Date_Paiement, 
             p.Montant_Total, 
             p.Paiement_Method, 
             p.Description, 
             p.Statut, 
             p.Num_Voyage,
             v.Ville_Dep, 
             v.Ville_Arr
         FROM 
             Paiements p
             INNER JOIN Voyage v ON p.Num_Voyage = v.Num_Voyage
         WHERE 
             p.Statut LIKE '%" + txt_rech.Text + "%'";

                using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(searchQuery, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable searchResult = new DataTable();
                        adapter.Fill(searchResult);

                        if (searchResult.Rows.Count > 0)
                        {
                            dataGridView_paim.DataSource = searchResult;
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

        private void btn_tous_Click_1(object sender, EventArgs e)
        {
            txt_rech.Clear();
            RefreshData();
        }


        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTPAIM1 p1 = new GESTPAIM1(mainForm, panelColor);
            mainForm.openChildForm(p1);
        }

        private void btn_modifier_Click_1(object sender, EventArgs e)
        {
            if (dataGridView_paim.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_paim.SelectedRows[0];
                int paiementId = Convert.ToInt32(selectedRow.Cells["Paiement_Id"].Value);
                DateTime datePaiement = Convert.ToDateTime(selectedRow.Cells["Date_Paiement"].Value);
                decimal montantTotal = Convert.ToDecimal(selectedRow.Cells["Montant_Total"].Value);
                string paiementMethod = selectedRow.Cells["Paiement_Method"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                string statut = selectedRow.Cells["Statut"].Value.ToString();
                int numVoyage = Convert.ToInt32(selectedRow.Cells["Num_Voyage"].Value);

                Color panelColor = GetPanelColor();
                GESTPAIM2 p2 = new GESTPAIM2(mainForm, paiementId, datePaiement, montantTotal, paiementMethod, description, statut, numVoyage, panelColor);
                mainForm.openChildForm(p2);

                RefreshData();
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un paiement à modifier.");
            }
        }

        private void btn_supp_Click_1(object sender, EventArgs e)
        {
            // Check if there is a selected row in the DataGridView
            if (dataGridView_paim.SelectedRows.Count > 0)
            {
                // Confirm the deletion with the user
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce paiement ?", "Suppression Paiement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Get the Paiement_Id value from the selected row
                        int paiementId = Convert.ToInt32(dataGridView_paim.SelectedRows[0].Cells["Paiement_Id"].Value);

                        // Open the database connection
                        c.cn.Open();

                        // Create the delete SQL query
                        string query = "DELETE FROM Paiements WHERE Paiement_Id = @Paiement_Id";
                        using (SqlCommand cmd = new SqlCommand(query, c.cn))
                        {
                            // Add the Paiement_Id parameter to the query
                            cmd.Parameters.AddWithValue("@Paiement_Id", paiementId);

                            // Execute the delete command
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if any rows were deleted
                            if (rowsAffected > 0)
                            {
                                showtoast("SUPPRIMER", "Paiement supprimé avec succès.");
                                mainForm.LogAction("Supprimé un paiement");

                            }
                            else
                            {
                                showError("ERROR", "Aucun paiement trouvé avec ce numéro.");
                            }
                        }

                        // Refresh the data in the DataGridView
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la suppression du paiement: " + ex.Message);
                    }
                    finally
                    {
                        // Close the database connection
                        c.cn.Close();
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un paiement à supprimer.");
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_paim.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_paim.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_paim.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_paim.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_paim.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_paim.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Paiements vers Excel");
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
