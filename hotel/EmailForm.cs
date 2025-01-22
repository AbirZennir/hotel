using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;

namespace hotel
{
    public partial class EmailForm : Form
    {
        GuestClass guest = new GuestClass();
        public EmailForm()
        {
            InitializeComponent();
        }

        private void label_e_pass_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                MailMessage mail = new MailMessage
                {
                    Subject = textBox_subject.Text,
                    Body = richTextBox_content.Text,
                    IsBodyHtml = false
                };

                
                string expéditeur = "rounalisa@gmail.com"; 
                mail.From = new MailAddress(expéditeur); 

                mail.To.Add(comboBox_email.Text); 

               
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true; 
                    smtp.Credentials = new NetworkCredential(expéditeur, "lxkp ugrm cjfv liep"); 

                    
                    await smtp.SendMailAsync(mail);
                    MessageBox.Show("Email envoyé avec succès !");
                }
            }
            catch (SmtpException ex)
            {
                MessageBox.Show($"Erreur SMTP : {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}");
            }




        }





        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label_address_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_email_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                DataTable emailsTable = guest.getAllGuestEmails(); 

                if (emailsTable.Rows.Count > 0)
                {
                    
                    comboBox_email.DataSource = emailsTable;

                    
                    comboBox_email.DisplayMember = "GuestEmail";  
                    comboBox_email.ValueMember = "GuestEmail";   

                   
                }
                else
                {
                    MessageBox.Show("Aucun email trouvé dans la base de données.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void EmailForm_Load(object sender, EventArgs e)
        {
            try
            {
               
                DataTable emailsTable = guest.getAllGuestEmails(); 

                if (emailsTable.Rows.Count > 0)
                {
                    
                    comboBox_email.DataSource = emailsTable;
                    comboBox_email.DisplayMember = "GuestEmail";  
                    comboBox_email.ValueMember = "GuestEmail";   

                  
                }
                else
                {
                    MessageBox.Show("Aucun email trouvé dans la base de données.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clean_Click(object sender, EventArgs e)
        {

            textBox_subject.Clear();
            richTextBox_content.Clear();
            comboBox_email.SelectedIndex = 0;
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm LoginForm = new loginForm();
            LoginForm.Show();
        }

        private void button_dashbord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    } }        
    

