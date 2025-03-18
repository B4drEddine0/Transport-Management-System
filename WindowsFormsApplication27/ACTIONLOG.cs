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
    public partial class ACTIONLOG : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public ACTIONLOG(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            LoadActionLog();
            this.mainForm = mainForm;
        }

        private void ACTIONLOG_Load(object sender, EventArgs e)
        {

        }

        private void LoadActionLog()
        {
            string query = "SELECT Utilisateur, Action,  Timestamp as Date FROM History ORDER BY Timestamp DESC";

            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch (Exception ex)
                {
                    showError("ERROR", $"Error loading action log: {ex.Message}");
                   
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
                mainForm.LogAction("Exporté des données Histoire vers Excel");
                LoadActionLog();
                showtoast("EXPORTER", "Données exporté avec succès!");
            }
            else
            {
                showError("ERROR", "No records found!");
               
            }
        }

        private void btn_rech_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_rech.Text))
            {
                showError("Attention", "Veuillez entrer le nom d'utilisateur pour la recherche.");
                
            }
            else
            {
                string searchQuery = "SELECT * FROM History WHERE Utilisateur LIKE @Utilisateur";

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
                            showError("ERROR","Aucun résultat trouvé." );
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        showError("ERROR", $"Error loading action log: {ex.Message}");
                       
                    }
                }
            }    }

        private void btn_tous_Click(object sender, EventArgs e)
        {
            txt_rech.Clear();
            LoadActionLog();
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
