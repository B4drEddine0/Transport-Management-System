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
    public partial class GESTPRD : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTPRD(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;


            
        }
        Class1 c = new Class1();

       

       

        private void GESTPRD_Load(object sender, EventArgs e)
        {
            c.cn.Open();
            c.s = "select * from Produit";
            SqlCommand cmd = new SqlCommand(c.s, c.cn);
            c.dr = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(c.dr);
            dataGridView_prd.DataSource = t;
            c.dr.Close();
            c.cn.Close();
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
            BindingSource bs = new BindingSource();
            bs.DataSource = ConnectandReadList("select * from Produit");
            dataGridView_prd.DataSource = bs;
            bs.ResetBindings(false);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
           
        }

        
        
       

       
        private void dataGridView_prd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTPRD1 p1 = new GESTPRD1(mainForm, panelColor);

            mainForm.openChildForm(p1);
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
           
                // Check if a row is selected in the DataGridView
                if (dataGridView_prd.SelectedRows.Count > 0)
                {
                    // Get the data from the selected row
                    DataGridViewRow selectedRow = dataGridView_prd.SelectedRows[0];
                    int refProd = Convert.ToInt32(selectedRow.Cells["Ref_Prod"].Value);
                    string natureProd = selectedRow.Cells["Nature_Prod"].Value.ToString();
                    decimal poids = Convert.ToDecimal(selectedRow.Cells["Poids"].Value);
                    string descriptionProd = selectedRow.Cells["Description_prod"].Value.ToString();

                Color panelColor = GetPanelColor();
                GESTPRD2 p2 = new GESTPRD2(mainForm, refProd, natureProd, poids, descriptionProd, panelColor);
                    mainForm.openChildForm(p2);


              
                }
                else
                {
                showError("Attention","Veuillez sélectionner un produit." );
               
                }
            
        }

        private void btn_supp_Click_1(object sender, EventArgs e)
        {
            // Check if there is a selected row in the DataGridView
            if (dataGridView_prd.SelectedRows.Count > 0)
            {
                // Confirm the deletion with the user
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce produit ?", "Suppression Produit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Get the Ref_Prod value from the selected row
                        int refProd = Convert.ToInt32(dataGridView_prd.SelectedRows[0].Cells["Ref_Prod"].Value);

                        // Define the connection string (replace with your actual connection string)
                        string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";

                        // Open the database connection
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Create the delete SQL query
                            string query = "DELETE FROM Produit WHERE Ref_Prod = @Ref_Prod";
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                // Add the Ref_Prod parameter to the query
                                cmd.Parameters.AddWithValue("@Ref_Prod", refProd);

                                // Execute the delete command
                                int rowsAffected = cmd.ExecuteNonQuery();

                                // Check if any rows were deleted
                                if (rowsAffected > 0)
                                {
                                    showtoast("SUPPRIMER", "Produit supprimé avec succès.");
                                    mainForm.LogAction("Supprimé un produit");

                                }
                                else
                                {
                                    showError("ERROR", "Aucun produit trouvé avec ce numéro.");
                                }
                            }
                        }

                        // Refresh the data in the DataGridView
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la suppression du produit: " + ex.Message);
                    }
                }
            }
            else
            {
                showError("Attention","Veuillez sélectionner un produit à supprimer." );
              
            }
        }

        private void btn_rech_Click_1(object sender, EventArgs e)
        {

            if (txt_rech.Text == "")
            {
                showError("Attention", "Remplir le nature de Produit pour la recherche");
               
            }
            else
            {
                c.cn.Open();
                c.s = "SELECT * FROM Produit WHERE Nature_Prod LIKE '%" + txt_rech.Text + "%'";
                SqlCommand cmd = new SqlCommand(c.s, c.cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable t = new DataTable();
                adapter.Fill(t);

                if (t.Rows.Count > 0)
                {
                    dataGridView_prd.DataSource = t;
                }
                else
                    showError("ERROR", "Aucune resultat");
                c.cn.Close();
            }
        }

        private void btn_tous_Click_1(object sender, EventArgs e)
        {
            txt_rech.Clear();
            RefreshData();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_prd.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_prd.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_prd.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_prd.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_prd.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_prd.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Produit vers Excel");
                showtoast("EXPORTER", "Données exporté avec succès!");
            }
            else
            {
                showError("ERROR", "No records found!" );
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
