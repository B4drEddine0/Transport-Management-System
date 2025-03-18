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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApplication27
{
    public partial class GESTVOYAGE : Form
    {
        private WindowsFormsApplication27.main mainForm;

        
        public GESTVOYAGE(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
          


        }
        Class1 c = new Class1();
        private void GESTVOYAGE_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True";
            string query = @"
    SELECT 
        Voyage.Num_Voyage,
        Voyage.Date_Emission,
        Voyage.Date_Réception,
        Voyage.Ville_Dep,
        Voyage.Ville_Arr,
        Voyage.Statut,
        Voyage.tracking_num, -- Include tracking number
        Client.Num_Clt, -- Include IDs
        Client.Nom_Clt AS NomClient,
        Produit.Ref_Prod, -- Include IDs
        Produit.Nature_Prod AS NatureProduit,
        Camion.Num_Cam, -- Include IDs
        Camion.Modele AS ModeleCamion,
        Chauffeur.Num_Chauff, -- Include IDs
        Chauffeur.Nom_Chauff AS NomChauffeur
    FROM 
        Voyage
        INNER JOIN Client ON Voyage.Num_Clt = Client.Num_Clt
        INNER JOIN Produit ON Voyage.Ref_Prod = Produit.Ref_Prod
        INNER JOIN Camion ON Voyage.Num_Cam = Camion.Num_Cam
        INNER JOIN Chauffeur ON Voyage.Num_Chauff = Chauffeur.Num_Chauff";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView_vyge.DataSource = dataTable;

                    // Set font size and style
                    dataGridView_vyge.DefaultCellStyle.Font = new Font("Cambria", 9, FontStyle.Bold); // Adjust the font size as needed
                    dataGridView_vyge.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 10, FontStyle.Bold);

                    // Hide ID columns (optional)
                    dataGridView_vyge.Columns["Num_Clt"].Visible = false;
                    dataGridView_vyge.Columns["Ref_Prod"].Visible = false;
                    dataGridView_vyge.Columns["Num_Cam"].Visible = false;
                    dataGridView_vyge.Columns["Num_Chauff"].Visible = false;
                }
                catch (Exception ex)
                {
                    showError("ERROR","Error: " + ex.Message );
                    
                }
            }



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
                    Voyage.Num_Voyage,
                    Voyage.Date_Emission,
                    Voyage.Date_Réception,
                    Voyage.Ville_Dep,
                    Voyage.Ville_Arr,
                    Voyage.Statut,
                    Voyage.tracking_num, -- Include tracking number
                    Client.Num_Clt, -- Include IDs
                    Client.Nom_Clt AS NomClient,
                    Produit.Ref_Prod, -- Include IDs
                    Produit.Nature_Prod AS NatureProduit,
                    Camion.Num_Cam, -- Include IDs
                    Camion.Modele AS ModeleCamion,
                    Chauffeur.Num_Chauff, -- Include IDs
                    Chauffeur.Nom_Chauff AS NomChauffeur
                FROM 
                    Voyage
                    INNER JOIN Client ON Voyage.Num_Clt = Client.Num_Clt
                    INNER JOIN Produit ON Voyage.Ref_Prod = Produit.Ref_Prod
                    INNER JOIN Camion ON Voyage.Num_Cam = Camion.Num_Cam
                    INNER JOIN Chauffeur ON Voyage.Num_Chauff = Chauffeur.Num_Chauff";

            BindingSource bs = new BindingSource();
            bs.DataSource = ConnectandReadList(query);
            dataGridView_vyge.DataSource = bs;
            bs.ResetBindings(false);
        }











        // Method to get the color of panel1
        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }







        private void btn_add_Click_1(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTVYGE1 v1 = new GESTVYGE1(mainForm, panelColor);
            mainForm.openChildForm(v1);
        }



        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            RefreshData();
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (txt_rech.Text == "")
            {
                showError("Attention", "Remplir le statut de voyage pour la recherche");
                
            }
            else
            {
                string searchQuery = @"
            SELECT 
                Voyage.Num_Voyage,
                Voyage.Date_Emission,
                Voyage.Date_Réception,
                Voyage.Ville_Dep,
                Voyage.Ville_Arr,
                Voyage.Statut,
                Voyage.tracking_num, -- Include tracking number
                Client.Num_Clt, -- Include IDs
                Client.Nom_Clt AS NomClient,
                Produit.Ref_Prod, -- Include IDs
                Produit.Nature_Prod AS NatureProduit,
                Camion.Num_Cam, -- Include IDs
                Camion.Modele AS ModeleCamion,
                Chauffeur.Num_Chauff, -- Include IDs
                Chauffeur.Nom_Chauff AS NomChauffeur
            FROM 
                Voyage
                INNER JOIN Client ON Voyage.Num_Clt = Client.Num_Clt
                INNER JOIN Produit ON Voyage.Ref_Prod = Produit.Ref_Prod
                INNER JOIN Camion ON Voyage.Num_Cam = Camion.Num_Cam
                INNER JOIN Chauffeur ON Voyage.Num_Chauff = Chauffeur.Num_Chauff
            WHERE 
                Voyage.Statut LIKE '%" + txt_rech.Text + "%'";

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
                            dataGridView_vyge.DataSource = searchResult;
                        }
                        else
                        {
                            showError("ERROR", "Aucune resultat");
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Error: " + ex.Message);
                    }
                }
            }
        }


        private void btn_supp_Click_1(object sender, EventArgs e)
        {
            // Check if there is a selected row in the DataGridView
            if (dataGridView_vyge.SelectedRows.Count > 0)
            {
                // Confirm the deletion with the user
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce voyage ?", "Suppression Voyage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Get the Num_Voyage value from the selected row
                        int numVoyage = Convert.ToInt32(dataGridView_vyge.SelectedRows[0].Cells["Num_Voyage"].Value);

                        // Open the database connection
                        c.cn.Open();

                        // Create the delete SQL query
                        string query = "DELETE FROM Voyage WHERE Num_Voyage = @Num_Voyage";
                        using (SqlCommand cmd = new SqlCommand(query, c.cn))
                        {
                            // Add the Num_Voyage parameter to the query
                            cmd.Parameters.AddWithValue("@Num_Voyage", numVoyage);

                            try
                            {
                                // Execute the delete command
                                int rowsAffected = cmd.ExecuteNonQuery();

                                // Check if any rows were deleted
                                if (rowsAffected > 0)
                                {
                                    
                                   
                                    mainForm.LogAction("Supprimé un voyage");
                                    showtoast("SUPPRIMER", "Voyage supprimé avec succès.");
                                }
                                else
                                {
                                    showError("ERROR", "Aucun voyage trouvé avec ce numéro.");
                                }
                            }
                            catch (SqlException sqlEx) when (sqlEx.Number == 547) // Foreign Key violation
                            {
                                showError("ERROR", "Vous devez supprimer les enregistrements liés dans les tables Dépense, Facture et Paiements avant de pouvoir supprimer ce voyage.\", \"Erreur de contrainte de clé étrangère");
                                

                            }
                        }

                        // Refresh the data in the DataGridView
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", "Erreur lors de la suppression du voyage: " + ex.Message);
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
                showError("Attention", "Veuillez sélectionner un voyage à supprimer.");
            }
        }

      


        private void btn_modifier_Click_1(object sender, EventArgs e)
        {
            if (dataGridView_vyge.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_vyge.SelectedRows[0];
                int numVoyage = Convert.ToInt32(selectedRow.Cells["Num_Voyage"].Value);
                DateTime dateEmission = Convert.ToDateTime(selectedRow.Cells["Date_Emission"].Value);
                DateTime dateReception = Convert.ToDateTime(selectedRow.Cells["Date_Réception"].Value);
                string villeDep = selectedRow.Cells["Ville_Dep"].Value.ToString();
                string villeArr = selectedRow.Cells["Ville_Arr"].Value.ToString();
                string statut = selectedRow.Cells["Statut"].Value.ToString();
                string trackingNum = selectedRow.Cells["tracking_num"].Value.ToString(); // Include tracking number

                int numClt = Convert.ToInt32(selectedRow.Cells["Num_Clt"].Value);
                int refProd = Convert.ToInt32(selectedRow.Cells["Ref_Prod"].Value);
                int numCam = Convert.ToInt32(selectedRow.Cells["Num_Cam"].Value);
                int numChauff = Convert.ToInt32(selectedRow.Cells["Num_Chauff"].Value);

                Color panelColor = GetPanelColor();
                GESTVYGE2 G2 = new GESTVYGE2(mainForm, numVoyage, dateEmission, dateReception, villeDep, villeArr, statut, numClt, refProd, numCam, numChauff, trackingNum, panelColor);
                mainForm.openChildForm(G2);

                RefreshData();
            }
            else
            {
                showError("Attention", "Veuillez sélectionner un voyage à modifier.");
            }
        
    }

        private void dataGridView_vyge_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_vyge.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_vyge.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_vyge.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_vyge.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_vyge.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_vyge.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données vers Excel");
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
