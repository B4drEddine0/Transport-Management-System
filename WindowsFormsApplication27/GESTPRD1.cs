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
    public partial class GESTPRD1 : Form
    {
        private WindowsFormsApplication27.main mainForm;
        private Color panelColor;
        public GESTPRD1(WindowsFormsApplication27.main mainForm, Color panelColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.panelColor = panelColor;
            // Set the background color
            this.BackColor = panelColor;
        }
        Class1 c = new Class1();

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }


        public void vider()
        {
            txt_nature.Clear();
            txt_poids.Clear();
            txt_descrip.Clear();
           
            txt_nature.Focus();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                c.cn.Open();
                c.s = "insert into Produit values ('" + txt_nature.Text + "'," + txt_poids.Text + ",'" + txt_descrip.Text + "');";
                SqlCommand cmd = new SqlCommand(c.s, c.cn);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    showtoast("AJOUTER", "Produit ajouté avec succès!");
                    vider();
                    mainForm.LogAction("Ajouté un nouveau produit");

                    c.cn.Close();
                }
                else
                {
                    showError("ERROR","Erreur lors de l'ajout" );
                    
                }
            }
            catch (Exception ex)
            {
                showError("ERROR", "Error d'ajout produit: " + ex.Message);
            }
        }

        private void btn_retour_Click(object sender, EventArgs e)
        {
            GESTPRD P = new GESTPRD(mainForm);

            mainForm.openChildForm(P);
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
