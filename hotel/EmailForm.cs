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

                mail.To.Add(comboBox_email.Text); // Ajoutez le destinataire

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

        private void comboBox_email_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtenir tous les emails et les afficher dans la ComboBox
                DataTable emailsTable = guest.getAllGuestEmails(); // Appeler la méthode backend

                if (emailsTable.Rows.Count > 0)
                {
                    // Lier les données à la ComboBox
                    comboBox_email.DataSource = emailsTable;

                    // Afficher les emails dans la ComboBox
                    comboBox_email.DisplayMember = "GuestEmail";  // Nom de la colonne dans le DataTable
                    comboBox_email.ValueMember = "GuestEmail";    // Utiliser l'email comme valeur de la ComboBox

                    // Vous pouvez utiliser l'email comme valeur
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
                // Obtenir tous les emails et les afficher dans la ComboBox
                DataTable emailsTable = guest.getAllGuestEmails(); // Appeler la méthode backend

                if (emailsTable.Rows.Count > 0)
                {
                    // Lier les données à la ComboBox pour afficher les emails
                    comboBox_email.DataSource = emailsTable;
                    comboBox_email.DisplayMember = "GuestEmail";  // Afficher les emails dans la ComboBox
                    comboBox_email.ValueMember = "GuestEmail";    // Utiliser l'email comme valeur

                    // Optionnel : si vous voulez afficher aussi le nom et prénom dans la ComboBox, vous pouvez concaténer
                    // comboBox_email.DisplayMember = "FullName";  // Par exemple, si vous avez créé une colonne "FullName"
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
    } }        
    

