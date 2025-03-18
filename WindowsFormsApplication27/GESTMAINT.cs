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
    public partial class GESTMAINT : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTMAINT(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        Class1 c = new Class1();    

        private void GESTMAINT_Load(object sender, EventArgs e)
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

        // methode katrefresh data f datagridview 
        private void RefreshData()
        {
            string query = @"
                SELECT 
                    m.maintenance_num, 
                    m.Num_Cam, 
                    c.Matricule, 
                    m.MaintenanceType, 
                    m.MaintenanceDate, 
                    m.Description_main, 
                    m.statut_main
                FROM 
                    Maintenance m
                    INNER JOIN Camion c ON m.Num_Cam = c.Num_Cam";

            DataTable dataTable = ConnectandReadList(query);

            if (dataTable != null)
            {
                BindingSource bs = new BindingSource
                {
                    DataSource = dataTable
                };
                dataGridView_maint.DataSource = bs;
                bs.ResetBindings(false);

                // Optionally, hide the Num_Cam column if you don't want to display it
                if (dataGridView_maint.Columns["Num_Cam"] != null)
                {
                    dataGridView_maint.Columns["Num_Cam"].Visible = false;
                }
            }
            else
            {
                showError("ERROR","No data found to display." );
                
            }
        }

        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            RefreshData();
        }

        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTMAINT1 m1 = new GESTMAINT1(mainForm, panelColor);

            mainForm.openChildForm(m1);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_maint.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_maint.SelectedRows[0];
                int maintenanceNum = Convert.ToInt32(selectedRow.Cells["maintenance_num"].Value);
                int numCam = Convert.ToInt32(selectedRow.Cells["Num_Cam"].Value);
                int matricule = Convert.ToInt32(selectedRow.Cells["Matricule"].Value);
                string maintenanceType = selectedRow.Cells["MaintenanceType"].Value.ToString();
                DateTime maintenanceDate = Convert.ToDateTime(selectedRow.Cells["MaintenanceDate"].Value);
                string descriptionMain = selectedRow.Cells["Description_main"].Value.ToString();
                string statutMain = selectedRow.Cells["statut_main"].Value.ToString();

                Color panelColor = GetPanelColor();
                GESTMAIN2 m2 = new GESTMAIN2(mainForm, maintenanceNum, numCam, matricule, maintenanceType, maintenanceDate, descriptionMain, statutMain, panelColor);
                mainForm.openChildForm(m2);

                RefreshData();
            }
            else
            {
                showError("Attention", "Veuillez sélectionner une maintenance à modifier.");
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row in the DataGridView
            if (dataGridView_maint.SelectedRows.Count > 0)
            {
                // Confirm the deletion with the user
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette maintenance ?", "Suppression Maintenance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Get the maintenance_num value from the selected row
                        int maintenanceNum = Convert.ToInt32(dataGridView_maint.SelectedRows[0].Cells["maintenance_num"].Value);

                        // Open the database connection
                        c.cn.Open();

                        // Create the delete SQL query
                        string query = "DELETE FROM Maintenance WHERE maintenance_num = @maintenance_num";
                        using (SqlCommand cmd = new SqlCommand(query, c.cn))
                        {
                            // Add the maintenance_num parameter to the query
                            cmd.Parameters.AddWithValue("@maintenance_num", maintenanceNum);

                            // Execute the delete command
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if any rows were deleted
                            if (rowsAffected > 0)
                            {
                                showtoast("SUPPRIMER", "Maintenence supprimé avec succès.");
                                mainForm.LogAction("Supprimé une maintenance");

                            }
                            else
                            {
                                showError("ERROR", "Aucune maintenance trouvée avec ce numéro.");
                            }
                        }

                        // Refresh the data in the DataGridView
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la suppression de la maintenance: " + ex.Message);
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
                showError("Attention", "Veuillez sélectionner une maintenance à supprimer.");
            }
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_maint.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_maint.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_maint.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_maint.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_maint.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_maint.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Maintenance vers Excel");
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

        private void btn_rech_Click_1(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer un statut de recherche pour la maintenance.");
                
            }
            else
            {
                string searchQuery = @"
        SELECT 
            Maintenance.maintenance_num,
            Maintenance.Num_Cam,
            Maintenance.MaintenanceType,
            Maintenance.MaintenanceDate,
            Maintenance.Description_main,
            Maintenance.statut_main,
            Camion.Matricule,
            Camion.Modele
        FROM 
            Maintenance
            INNER JOIN Camion ON Maintenance.Num_Cam = Camion.Num_Cam
        WHERE 
            Maintenance.statut_main LIKE '%" + txt_rech.Text + "%'";

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
                            dataGridView_maint.DataSource = searchResult;
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

        public void showError(string type, string message)
        {
            ERRORFORM e = new ERRORFORM(type, message);
            e.Show();
        }
    }
}
