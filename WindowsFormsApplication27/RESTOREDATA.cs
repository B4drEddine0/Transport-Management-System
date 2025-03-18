using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace WindowsFormsApplication27
{
    public partial class RESTOREDATA : Form
    {
        private WindowsFormsApplication27.main mainForm;
        public RESTOREDATA(WindowsFormsApplication27.main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            
        }
        DB_General cl = new DB_General();

        private void RESTOREDATA_Load(object sender, EventArgs e)
        {
            // Initialize as needed
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "Backup Files (*.bak)|*.bak";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbackpath.Text = saveFileDialog1.FileName;

                // Open the folder containing the selected backup file
                string selectedFilePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                if (Directory.Exists(selectedFilePath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select," + saveFileDialog1.FileName);
                }
                else
                {
                    showError("ERROR", "Le dossier sélectionné n'existe pas.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string backupFilePath = txtbackpath.Text;

            if (string.IsNullOrEmpty(backupFilePath))
            {
                showError("Attention", "Veuillez sélectionner un chemin pour sauvegarder le fichier.");
               
                return;
            }

            string query = $"BACKUP DATABASE gestion_transport1 TO DISK='{backupFilePath}'";

            try
            {
                cl.general_query(query);
                showtoast("EXPORTER", "Sauvegarder data avec succès!");
                mainForm.LogAction("Sauvegardé les données");
            }
            catch (Exception ex)
            {
                showError("ERROR", $"Erreur lors de la sauvegarde : {ex.Message}");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Restore Files (*.bak)|*.bak";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtrestorepath.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string restoreFilePath = txtrestorepath.Text;

            if (string.IsNullOrEmpty(restoreFilePath))
            {
                showError("Attention", "Veuillez sélectionner un chemin pour restaurer le fichier.");
               
                return;
            }

            string query = $"USE master; ALTER DATABASE gestion_transport1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE gestion_transport1 FROM DISK='{restoreFilePath}' WITH REPLACE";

            try
            {
                cl.general_query(query);
                showtoast("AJOUTER", "Restauré Data avec succès!");
                mainForm.LogAction("Restauré les données");

            }
            catch (Exception ex)
            {
                showError("ERROR", $"Erreur lors de la restauration : {ex.Message}");
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Minimized;
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
