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
    public partial class ERRORFORM : Form
    {
        private Color borderColor;
        public ERRORFORM(string type, string message)
        {
            InitializeComponent();
            lbtype.Text = type;
            lbmsg.Text = FormatMessageByWords(message, 5);



            switch (type)
            {
                case "ERROR":
                    pnl.BackColor = Color.FromArgb(255, 0, 0);
                    pctoast.Image = Properties.Resources.annuler_48;
                    btn_ok.FillColor = Color.FromArgb(255, 0, 0);
                    borderColor = Color.FromArgb(255, 0, 0);
                    break;
                case "Attention":
                    pnl.BackColor = Color.FromArgb(255, 255, 173, 1);
                    pctoast.Image = Properties.Resources.attention_48;
                    btn_ok.FillColor = Color.FromArgb(255, 255, 173, 1);
                    borderColor = Color.FromArgb(255, 255, 173, 1);
                    break;
                default:
                    borderColor = Color.Black;
                    break;

            }

            this.Padding = new Padding(5);

        }

        private string FormatMessageByWords(string message, int wordsPerLine)
        {
            var words = message.Split(' ');
            var formattedMessage = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0 && i % wordsPerLine == 0)
                {
                    formattedMessage.AppendLine();
                }
                formattedMessage.Append(words[i] + " ");
            }
            return formattedMessage.ToString().TrimEnd();
        }

        private void ERRORFORM_Load(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Override the OnPaint method to draw a border with dynamic color
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw border with the selected color
            using (Pen pen = new Pen(borderColor, 3))
            {
                e.Graphics.DrawRectangle(pen, this.ClientRectangle);
            }
        }
    }
}
