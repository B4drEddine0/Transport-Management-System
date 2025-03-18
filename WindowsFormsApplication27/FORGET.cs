using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class FORGET : Form
    {
        public FORGET()
        {
            InitializeComponent();
        }

        private void forget_pass_Click(object sender, EventArgs e)
        {
            LOGIN l1 = new LOGIN();
            l1.Show();
            this.Hide();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            string resetKey = "1234567"; // nbdlo kima bghit

            if (txt_key.Text == "")
            {
                showError("Attention", "Veuillez d'abord saisir la clé de réinitialisation.");
               
            }
            else if (txt_key.Text != resetKey)
            {
                showError("ERROR", "Invalid reset key.");
            }
            else
            {
                USER u1 = new USER();
                u1.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void showError(string type, string message)
        {
            ERRORFORM e = new ERRORFORM(type, message);
            e.Show();
        }
    }
}
