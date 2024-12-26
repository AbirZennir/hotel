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
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace hotel
{
    public partial class EmailForm : Form
    {
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
                // Créer un nouveau message
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Nom d'affichage", textBox_from.Text));
                message.To.Add(new MailboxAddress("Destinataire", textBox_to.Text));
                message.Subject = textBox_subject.Text;
                message.Body = new TextPart("plain") { Text = richTextBox_content.Text };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                    // Utilisez le mot de passe d'application ici
                    await client.AuthenticateAsync(textBox_from.Text, "votre_mot_de_passe_d_application");

                    await client.SendAsync(message);
                }

                MessageBox.Show("Email has been sent successfully.");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid email format: " + ex.Message);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("SMTP error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        
    


        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
