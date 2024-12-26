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
                // Créez un nouvel e-mail
                MailMessage mail = new MailMessage
                {
                    Subject = textBox_subject.Text,
                    Body = richTextBox_content.Text,
                    IsBodyHtml = false
                };

                // Exemple d'adresse e-mail de l'expéditeur
                string expéditeur = "rounalisa@gmail.com"; // Remplacez par votre adresse e-mail
                mail.From = new MailAddress(expéditeur); // Utilisez l'adresse de l'expéditeur

                mail.To.Add(textBox_to.Text); // Ajoutez le destinataire

                // Configurez le client SMTP
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true; // Activez SSL
                    smtp.Credentials = new NetworkCredential(expéditeur, "lxkp ugrm cjfv liep"); // Utilisez le mot de passe d'application

                    // Envoyez l'e-mail
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
    }
}
