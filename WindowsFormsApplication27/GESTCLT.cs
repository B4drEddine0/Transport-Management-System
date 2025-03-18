using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class GESTCLT : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public GESTCLT(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;


       
        }
        Class1 c = new Class1();

        // Method to connect and read data from the SQL database
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
                        showError("Error", "Error connecting to database: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }

        // Method to refresh data in the DataGridView
        private void RefreshData()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ConnectandReadList("select * from Client");
            dataGridView_clt.DataSource = bs;
            bs.ResetBindings(false);
        }

        private void GESTCLT_Load(object sender, EventArgs e)
        {
            c.cn.Open();
            c.s = "select * from Client";
            SqlCommand cmd = new SqlCommand(c.s, c.cn);
            c.dr = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(c.dr);
            dataGridView_clt.DataSource = t;
            c.dr.Close();
            c.cn.Close();

            dataGridView_clt.Columns[0].Width = 160;
            dataGridView_clt.Columns[1].Width = 160;
            dataGridView_clt.Columns[2].Width = 160;
            dataGridView_clt.Columns[3].Width = 160;
            dataGridView_clt.Columns[4].Width = 160;
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            // Suppression logic can be added here
        }

        private void btn_zid_Click(object sender, EventArgs e)
        {
            // Adding logic can be added here
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            // Modification logic can be added here
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // PictureBox1 logic can be added here
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // PictureBox2 logic can be added here
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // PictureBox3 logic can be added here
        }

        public Color GetPanelColor()
        {
            return panel1.BackColor;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Color panelColor = GetPanelColor();
            GESTCLT1 g1 = new GESTCLT1(mainForm, panelColor);
            mainForm.openChildForm(g1);
        }

        private void btn_mod_Click_1(object sender, EventArgs e)
        {
            if (dataGridView_clt.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_clt.SelectedRows[0];
                int numClt = Convert.ToInt32(selectedRow.Cells["Num_Clt"].Value);
                string nomClt = selectedRow.Cells["Nom_Clt"].Value.ToString();
                string adresse = selectedRow.Cells["Adresse"].Value.ToString();
                string email = selectedRow.Cells["email"].Value.ToString();
                string phone = selectedRow.Cells["phone"].Value.ToString();

                Color panelColor = GetPanelColor();
                GESTCLT2 g2 = new GESTCLT2(mainForm, numClt, nomClt, adresse, email, phone, panelColor);

                mainForm.openChildForm(g2);

                RefreshData();
            }
            else
            {
                showError("Erreur", "Veuillez sélectionner un client à modifier.");
            }
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView_clt.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet Client ?", "Suppression Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int numClt = Convert.ToInt32(dataGridView_clt.SelectedRows[0].Cells["Num_Clt"].Value);

                        c.cn.Open();

                        string query = "DELETE FROM Client WHERE Num_Clt = @Num_Clt";
                        using (SqlCommand cmd = new SqlCommand(query, c.cn))
                        {
                            cmd.Parameters.AddWithValue("@Num_Clt", numClt);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                mainForm.LogAction("Supprimé un client");
                                showtoast("SUPPRIMER", "Client supprimé avec succès.");
                            }
                            else
                            {
                                showError("Erreur", "Aucun client trouvé avec ce numéro.");
                            }
                        }

                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        showError("Erreur", "Erreur lors de la suppression du client: " + ex.Message);
                    }
                    finally
                    {
                        c.cn.Close();
                    }
                }
            }
            else
            {
                showError("Erreur", "Veuillez sélectionner un client à supprimer.");
            }
        }

        private void btn_tous_Click_1(object sender, EventArgs e)
        {
            txt_rech.Clear();
            RefreshData();
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_rech.Text))
            {
                showError("Attention", "Remplir le nom de Client pour la recherche");
            }
            else
            {
                c.cn.Open();
                c.s = "SELECT * FROM Client WHERE Nom_Clt LIKE '%" + txt_rech.Text + "%'";
                SqlCommand cmd = new SqlCommand(c.s, c.cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable t = new DataTable();
                adapter.Fill(t);

                if (t.Rows.Count > 0)
                {
                    dataGridView_clt.DataSource = t;
                }
                else
                {
                    showError("Confirmation", "Aucune résultat");
                }
                c.cn.Close();
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dataGridView_clt.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView_clt.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView_clt.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_clt.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_clt.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView_clt.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
                mainForm.LogAction("Exporté des données Client vers Excel");
                showtoast("EXPORTER", "Données exportées avec succès!");
            }
            else
            {
                showError("Erreur", "No records found!");
            }
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

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Minimized;
        }
    }
}
