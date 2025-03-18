using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class GESTCLT2 : Form
    {
        private int numClt;
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;

        public GESTCLT2(WindowsFormsApplication27.main mainForm, int numClt, string nomClt, string adresse, string email, string phone, Color panelColor)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            // Store the Num_Clt value for updating the database
            this.numClt = numClt;

            // Fill the text boxes with the data
            txt_nom.Text = nomClt;
            txt_adresse.Text = adresse;
            txt_email.Text = email;
            txt_phone.Text = phone;
            cb_clt.Items.Add(numClt);  // Populate ComboBox with the client number
            cb_clt.SelectedIndex = 0;

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
            cb_clt.ResetText();
            txt_nom.Focus();
        }

        

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            GESTCLT g = new GESTCLT(mainForm);
            mainForm.openChildForm(g);
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                string cbCltText = cb_clt.Text;

                if (int.TryParse(cbCltText, out int numClt))
                {
                    c.cn.Open();
                    c.s = "UPDATE Client SET Nom_Clt = @Nom_Clt, Adresse = @Adresse, email = @Email, phone = @Phone WHERE Num_Clt = @Num_Clt";

                    using (SqlCommand cmd = new SqlCommand(c.s, c.cn))
                    {
                        cmd.Parameters.AddWithValue("@Nom_Clt", txt_nom.Text);
                        cmd.Parameters.AddWithValue("@Adresse", txt_adresse.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                        cmd.Parameters.AddWithValue("@Phone", txt_phone.Text);
                        cmd.Parameters.AddWithValue("@Num_Clt", numClt);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            showtoast("MODIFIER", "Client modifié avec succès");
                            mainForm.LogAction("Modifié un client");
                        }
                        else
                        {
                            showError("Erreur", "Erreur lors de la modification");
                        }
                    }
                }
                else
                {
                    showError("Erreur", "Numéro de client invalide");
                }
            }
            catch (Exception ex)
            {
                showError("Erreur", "Erreur: " + ex.Message);
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
