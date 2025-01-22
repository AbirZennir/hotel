using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace hotel
{
    public partial class loginForm : Form
    {
      
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-U5T5LIJ\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True;Encrypt=False");

        public loginForm()
        {
            InitializeComponent();
        }

        
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

       
        private void Label_exit_MouseEnter(object sender, EventArgs e)
        {
            Label_exit.ForeColor = Color.LightBlue;
        }

        private void Label_exit_MouseLeave(object sender, EventArgs e)
        {
            Label_exit.ForeColor = Color.Black;
        }

        
        private void Label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void loginForm_Load(object sender, EventArgs e)
        {
            
            if (!TestDatabaseConnection())
            {
                MessageBox.Show("Cannot connect to the database. Please check your connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        
        private void Button_login_Click(object sender, EventArgs e)
        {
           
            if (TextBox_username.Text.Trim().Equals("") || TextBox_password.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter your username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                conn.Open();

                
                string query = @"
    SELECT COUNT(1) 
    FROM [Users] 
    WHERE [UserName] = @username 
    AND [PasswordHash] = HASHBYTES('SHA2_256', CONVERT(VARCHAR(100), @password))";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                  
                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = TextBox_username.Text.Trim();
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = TextBox_password.Text;

                   
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {

                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    else
                    {
                      
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
                
                conn.Close();
            }
        }
    }
}
