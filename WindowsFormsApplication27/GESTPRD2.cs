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
    public partial class GESTPRD2 : Form
    {
        int refProd;
        string natureProd;
        decimal poids;
        string descriptionProd;
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTPRD2(WindowsFormsApplication27.main mainForm, int refProd, string natureProd, decimal poids, string descriptionProd, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Fill the text boxes with the data
            cb_num.Text = refProd.ToString();
            txt_nature.Text = natureProd;
            txt_poids.Text = poids.ToString();
            txt_descrip.Text = descriptionProd;

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }
        Class1 c = new Class1();

        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                c.cn.Open();

                // Ensure the poids is a valid decimal
                if (!decimal.TryParse(txt_poids.Text, out decimal poids))
                {
                    showError("Attention", "Veuillez entrer un poids valide.");
                    
                    return;
                }

                // Ensure the Ref_Prod is a valid integer
                if (!int.TryParse(cb_num.Text, out int refProd))
                {
                    showError("Attention","Veuillez entrer un numéro de produit valide." );
               
                    return;
                }

                // Prepare the SQL update query
                c.s = "UPDATE Produit SET Nature_Prod = @Nature_Prod, Poids = @Poids, Description_prod = @Description WHERE Ref_Prod = @Ref_Prod";

                // Create a SqlCommand object with the update query and connection
                SqlCommand cmd = new SqlCommand(c.s, c.cn);

                // Set parameters for the update query
                cmd.Parameters.AddWithValue("@Nature_Prod", txt_nature.Text);
                cmd.Parameters.AddWithValue("@Poids", poids);
                cmd.Parameters.AddWithValue("@Description", txt_descrip.Text);
                cmd.Parameters.AddWithValue("@Ref_Prod", refProd);

                // Execute the update query
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if any rows were updated
                if (rowsAffected > 0)
                {
                    showtoast("MODIFIER", "Produit modifié avec succès");
                    mainForm.LogAction("Modifié un produit");

                }
                else
                {
                    showError("ERROR", "Aucun produit trouvé avec ce numéro.");
                   
                }
            }
            catch (Exception ex)
            {
                showError("ERROR", "Erreur lors de la modification du produit: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                c.cn.Close();
            }
        }


        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTPRD p = new GESTPRD(mainForm);

            mainForm.openChildForm(p);
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
