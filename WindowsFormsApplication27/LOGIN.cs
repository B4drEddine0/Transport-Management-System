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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApplication27
{
    public partial class LOGIN : Form
    {
      
        public LOGIN()
        {
            InitializeComponent();
            
        }
        Class1 c = new Class1();

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_user.Text == "" || txt_password.Text == "")
            {
                showError("Attention", "Entrez d'abord les données de connexion");
                
            }
            else if (txt_user.Text == "Admin" || txt_password.Text == "admin123")
            {
                    string username = "Badr (Admin)";
                    main m1 = new main(username); // drtha hna bach ndowozha L FORM lkhra on2afichiha
                    //m1.WindowState = FormWindowState.Maximized;
                    m1.MaximizeWithTaskbar();
                    LogAction("Utilisateur connecté");

                    m1.Show();
                    this.Hide();
            }
            else
            {
                string user = txt_user.Text;
                string pass = txt_password.Text;
                DataTable table = new DataTable();
                try
                {
                    c.cn.Open();
                    string query = "SELECT * FROM Employés WHERE Utilisateur=@Username AND mot_de_pass=@Password";
                    using (SqlCommand command = new SqlCommand(query, c.cn))
                    {
                        command.Parameters.AddWithValue("@Username", user);
                        command.Parameters.AddWithValue("@Password", pass);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    showError("ERROR", "Error: " + ex.Message);
                    
                }
                finally
                {
                    c.cn.Close();
                }

                if (table.Rows.Count > 0)
                {
                    string username = table.Rows[0]["Utilisateur"].ToString();//kanhezz  l username
                    main m1 = new main(username); // drtha hna bach ndowozha L FORM lkhra on2afichiha
                    //m1.WindowState = FormWindowState.Maximized;
                    m1.MaximizeWithTaskbar();
                    LogAction("Utilisateur connecté");

                    m1.Show();
                    this.Hide();

                }

                else
                {
                    showError("ERROR", "Your username and password are not exists");
                }
            }
        }



        


        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Transparent;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void forget_pass_Click(object sender, EventArgs e)
        {
            FORGET f1 = new FORGET();
            f1.Show();
            this.Hide();
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        public void LogAction(string action)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=BADREDDINE\SQLEXPRESS01;Initial Catalog=gestion_transport1;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO History (Utilisateur, Action, Timestamp) VALUES (@user, @action, @timestamp)", connection))
                {
                    command.Parameters.AddWithValue("@user", txt_user.Text);
                    command.Parameters.AddWithValue("@action", action);
                    command.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void showError(string type, string message)
        {
            ERRORFORM e = new ERRORFORM(type, message);
            e.Show();
        }
    }
}
