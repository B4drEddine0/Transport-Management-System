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
    public partial class GESTDEP : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTDEP(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        Class1 c = new Class1();
        private void GESTDEP_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private DataTable ConnectAndReadList(string query)
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
                        showError("ERROR","Error connecting to database: " + ex.Message );
                   
                    }
                }
            }

            return dataTable;
        }

        private void RefreshData()
        {
            string query = @"
                SELECT 
                    d.dépense_num,
                    d.date_dépense,
                    d.carburant,
                    d.péages,
                    d.maintenance,
                    d.chauffeur_sal,
                    d.transitaire,
                    d.parkings,
                    d.marché,
                    d.Num_Voyage,
                    v.Ville_Dep,
                    v.Ville_Arr
                FROM 
                    Dépense d
                    INNER JOIN Voyage v ON d.Num_Voyage = v.Num_Voyage";

            DataTable dataTable = ConnectAndReadList(query);

            if (dataTable != null)
            {
                BindingSource bs = new BindingSource
                {
                    DataSource = dataTable
                };
                dataGridView_dep.DataSource = bs;
                bs.ResetBindings(false);

                if (dataGridView_dep.Columns["Num_Voyage"] != null)
                {
                    dataGridView_dep.Columns["Num_Voyage"].Visible = false;
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
            GESTDEP1 d1 = new GESTDEP1(mainForm, panelColor);
            mainForm.openChildForm(d1);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_dep.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_dep.SelectedRows[0];
                int dépenseNum = Convert.ToInt32(selectedRow.Cells["dépense_num"].Value);
                DateTime dateDépense = Convert.ToDateTime(selectedRow.Cells["date_dépense"].Value);
                decimal carburant = Convert.ToDecimal(selectedRow.Cells["carburant"].Value);
                decimal péages = Convert.ToDecimal(selectedRow.Cells["péages"].Value);
                decimal maintenance = Convert.ToDecimal(selectedRow.Cells["maintenance"].Value);
                decimal chauffeurSal = Convert.ToDecimal(selectedRow.Cells["chauffeur_sal"].Value);
                decimal transitaire = Convert.ToDecimal(selectedRow.Cells["transitaire"].Value);
                decimal parkings = Convert.ToDecimal(selectedRow.Cells["parkings"].Value);
                decimal marché = Convert.ToDecimal(selectedRow.Cells["marché"].Value);
                int numVoyage = Convert.ToInt32(selectedRow.Cells["Num_Voyage"].Value);

                Color panelColor = GetPanelColor();
                GESTDEP2 d2 = new GESTDEP2(mainForm, dépenseNum, dateDépense, carburant, péages, maintenance, chauffeurSal, transitaire, parkings, marché, numVoyage, panelColor);
                mainForm.openChildForm(d2);

                RefreshData();
            }
            else
            {
                showError("ERROR", "Veuillez sélectionner une dépense à modifier.");
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            if (dataGridView_dep.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette dépense ?", "Suppression Dépense", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int dépenseNum = Convert.ToInt32(dataGridView_dep.SelectedRows[0].Cells["dépense_num"].Value);

                        c.cn.Open();

                        string query = "DELETE FROM Dépense WHERE dépense_num = @dépense_num";
                        using (SqlCommand cmd = new SqlCommand(query, c.cn))
                        {
                            cmd.Parameters.AddWithValue("@dépense_num", dépenseNum);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                showtoast("SUPPRIMER", "Dépense supprimé avec succès.");
                                mainForm.LogAction("Supprimé une dépense");

                            }
                            else
                            {
                                showError("ERROR", "Aucune dépense trouvée avec ce numéro.");
                            }
                        }

                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la suppression de la dépense: " + ex.Message);
                    }
                    finally
                    {
                        c.cn.Close();
                    }
                }
            }
            else
            {
                showError("Attention", "Veuillez sélectionner une dépense à supprimer.");
            }
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Veuillez entrer ville de deppart pour la recherche.");
               
            }
            else
            {
                string searchQuery = @"
                    SELECT 
                        d.dépense_num,
                        d.date_dépense,
                        d.carburant,
                        d.péages,
                        d.maintenance,
                        d.chauffeur_sal,
                        d.transitaire,
                        d.parkings,
                        d.marché,
                        d.Num_Voyage,
                        v.Ville_Dep,
                        v.Ville_Arr
                    FROM 
                        Dépense d
                        INNER JOIN Voyage v ON d.Num_Voyage = v.Num_Voyage
                    WHERE 
                         v.Ville_Dep LIKE '%" + txt_rech.Text + "%'";

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
                            dataGridView_dep.DataSource = searchResult;
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
            if (dataGridView_dep.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_dep.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_dep.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_dep.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_dep.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_dep.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Dépense vers Excel");
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
