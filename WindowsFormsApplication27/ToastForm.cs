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
    public partial class ToastForm : Form
    {
        int toastX, toastY;
        public ToastForm(string type, string message)
        {
            InitializeComponent();
            lbtype.Text = type;
            lbmsg.Text = message;
            switch (type) 
            {
                case "AJOUTER":
                    pnltoast.BackColor = Color.FromArgb(57,155,53);
                    pctoast.Image = Properties.Resources.icons8_ok_48;
                    break;
                case "SUPPRIMER":
                    pnltoast.BackColor = Color.FromArgb(227, 50, 45);
                    pctoast.Image = Properties.Resources.icons8_poubelle_48;
                    break;
                case "MODIFIER":
                    pnltoast.BackColor = Color.FromArgb(18, 136, 191);
                    pctoast.Image = Properties.Resources.modify;
                    break;
                case "EXPORTER":
                    pnltoast.BackColor = Color.FromArgb(245, 171, 35);
                    pctoast.Image = Properties.Resources.csv_48;
                    break;
            }
        }

        private void ToastForm_Load(object sender, EventArgs e)
        {
            position();
        }

        private void timertoast_Tick(object sender, EventArgs e)
        {
            toastY -= 10;
            this.Location=new Point(toastX, toastY);
            if (toastY <= 760)
            {
                timertoast.Stop();
                timerhide.Start();
            }
        }
        int y = 100;
        private void timerhide_Tick(object sender, EventArgs e)
        {
            y--;
            if(y <= 0)
            {
                toastY += 1;
                this.Location=new Point(toastX, toastY+=10);
                if(toastY >800)
                {
                    timerhide.Stop();
                    y = 300;
                    this.Close();
                }
            }
        }

        private void pctoast_Click(object sender, EventArgs e)
        {

        }

        private void position()
        {
            int screenwidth=Screen.PrimaryScreen.WorkingArea.Width;
            int screenheight=Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenwidth - this.Width-5;
            toastY = screenheight - this.Height+70;

            this.Location = new Point(toastX,toastY);
        }
    }
}
