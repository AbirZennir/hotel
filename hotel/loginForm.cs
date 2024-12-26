using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace hotel
{
    public partial class loginForm : Form
    {
        // Connexion à la base de données SQL Server
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-U5T5LIJ\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True;Encrypt=False");

        public loginForm()
        {
            InitializeComponent();
        }

        // Tester la connexion à la base de données
        private bool TestDatabaseConnection()
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Événement au survol de la souris pour changer la couleur du texte de fermeture
        private void Label_exit_MouseEnter(object sender, EventArgs e)
        {
            Label_exit.ForeColor = Color.LightBlue;
        }

        private void Label_exit_MouseLeave(object sender, EventArgs e)
        {
            Label_exit.ForeColor = Color.Black;
        }

        // Fermer l'application en cliquant sur "Exit"
        private void Label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Événement de chargement du formulaire
        private void loginForm_Load(object sender, EventArgs e)
        {
            // Test de la connexion à la base de données au chargement
            if (!TestDatabaseConnection())
            {
                MessageBox.Show("Cannot connect to the database. Please check your connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // Fonction de connexion à la base de données lors du clic sur le bouton "Login"
        private void Button_login_Click(object sender, EventArgs e)
        {
            // Vérification des champs vides
            if (TextBox_username.Text.Trim().Equals("") || TextBox_password.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter your username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Ouvrir la connexion à la base de données
                conn.Open();

                // Configuration de la requête SQL
                string query = @"
    SELECT COUNT(1) 
    FROM [Users] 
    WHERE [UserName] = @username 
    AND [PasswordHash] = HASHBYTES('SHA2_256', CONVERT(VARCHAR(100), @password))";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Ajout des paramètres avec les types SQL appropriés
                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = TextBox_username.Text.Trim();
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = TextBox_password.Text;

                    // Exécution de la requête et récupération du résultat
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        // Authentification réussie
                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    else
                    {
                        // Authentification échouée
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Fermer la connexion après utilisation
                conn.Close();
            }
        }
    }
}
