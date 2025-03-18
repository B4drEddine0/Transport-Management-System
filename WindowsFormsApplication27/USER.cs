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
    public partial class USER : Form
    {
        public USER()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();

        private void btn_sortie_Click(object sender, EventArgs e)
        {
            LOGIN l1 = new LOGIN();
            l1.Show();
            this.Hide();
        }
        public void vider()
        {
            txt_user.Clear();
            txt_password.Clear();
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_user.Text == "" || txt_password.Text == "")
            {
                showError("Attention", "Entrez d'abord les données de connexion");

            }
            else
            {
                try
                {
                    c.cn.Open();
                    c.s = "insert into Employés values ('" + txt_user.Text + "','" + txt_password.Text + "');";
                    SqlCommand cmd = new SqlCommand(c.s, c.cn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        showtoast("AJOUTER", "Utilisateur ajouté avec succès!");
                        vider();
                        c.cn.Close();
                    }
                    else
                    {
                        showError("ERROR", "Erreur lors de reset");
                    }
                }
                catch (Exception ex)
                {
                    showError("ERROR", "Error de reset mode de pass : " + ex.Message);
                }
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
