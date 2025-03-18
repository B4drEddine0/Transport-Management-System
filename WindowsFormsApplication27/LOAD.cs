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
    public partial class LOAD : Form
    {
        public LOAD()
        {
            InitializeComponent();
        }


        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 2;
            progressBar1.Value = startpoint;
            if (startpoint > 90)
            {
                LOGIN l1 = new LOGIN();
                l1.Show();
                timer1.Stop();
                this.Hide();
            }
        }

        private void LOAD_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        

        
    }
}
