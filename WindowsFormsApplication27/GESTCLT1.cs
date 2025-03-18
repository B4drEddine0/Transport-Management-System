using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class GESTCLT1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;

        public GESTCLT1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }

        Class1 c = new Class1();

        public void vider()
        {
            txt_nom.Clear();
            txt_email.Clear();
            txt_phone.Clear();
            txt_adresse.Clear();
            txt_nom.Focus();
        }

        private void GESTCLT1_Load(object sender, EventArgs e)
        {
            // Load logic can be added here
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTCLT g = new GESTCLT(mainForm);
            mainForm.openChildForm(g);
        }

        private void btn_vider_Click_1(object sender, EventArgs e)
        {
            vider();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                c.cn.Open();
                c.s = "insert into Client values (@Nom, @Adresse, @Email, @Phone)";
                using (SqlCommand cmd = new SqlCommand(c.s, c.cn))
                {
                    cmd.Parameters.AddWithValue("@Nom", txt_nom.Text);
                    cmd.Parameters.AddWithValue("@Adresse", txt_adresse.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Phone", txt_phone.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        vider();
                        mainForm.LogAction("Ajouté un nouveau client");
                        showtoast("AJOUTER", "Client ajouté avec succès!");
                    }
                    else
                    {
                        showError("Erreur", "Erreur lors de l'ajout");
                    }
                }
            }
            catch (Exception ex)
            {
                showError("Erreur", "Erreur d'ajout client: " + ex.Message);
            }
            finally
            {
                c.cn.Close();
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
    }
}
