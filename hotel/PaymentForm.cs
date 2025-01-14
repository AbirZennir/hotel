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

namespace hotel
{
    public partial class PaymentForm : Form
    {
        private int reservationId;
        private DateTime dateIn;
        private DateTime dateOut;
        private decimal pricePerNight;


        public PaymentForm(int reservationId, DateTime dateIn, DateTime dateOut, decimal pricePerNight)
        {
            InitializeComponent();
            this.reservationId = reservationId;
            this.dateIn = dateIn;
            this.dateOut = dateOut;
            this.pricePerNight = pricePerNight;

            CalculateAndDisplayTotalAmount();
        }

        private void CalculateAndDisplayTotalAmount()
        {
            // Calculer la durée du séjour
            int numberOfNights = (dateOut.Date - dateIn.Date).Days;

            // Calculer le montant total (nombre de nuits * prix par nuit)
            decimal totalAmount = numberOfNights * pricePerNight;


            // Afficher le montant total sur le formulaire
            montant.Text = $"Montant total : {totalAmount:C}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void montant_Click(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.AddRange(new string[] { "Espèces", "Carte Bancaire", "Virement Bancaire" });
         
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean SaveTotalAmountToReservation()
        {
            string query = "UPDATE Reservations SET TotalAmount = @TotalAmount WHERE ReservationId = @ReservationId";

            // Calculer le montant total
            decimal totalAmount = (dateOut.Date - dateIn.Date).Days * pricePerNight;
            DBConnect connect = new DBConnect();

            using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
            {
                command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                command.Parameters.AddWithValue("@ReservationId", reservationId);

                connect.OpenCon();
                command.ExecuteNonQuery();
                connect.CloseCon();
                return true;
            }
            return false;
        }


        private Boolean SavePay()
        {
            try
            {
                // Calculer le montant total
                decimal totalAmount = (dateOut.Date - dateIn.Date).Days * pricePerNight;

                // Requête SQL pour insérer un paiement
                string query = "INSERT INTO Payments (ReservationId, PaymentDate, Amount, PaymentMethod) " +
                               "VALUES (@ReservationId, @PaymentDate, @TotalAmount, @PaymentMethod)";

                // Connexion à la base de données
                DBConnect connect = new DBConnect();

                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {
                    // Ajouter les paramètres à la requête SQL
                    command.Parameters.AddWithValue("@ReservationId", reservationId);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);  // Date du paiement
                    command.Parameters.AddWithValue("@PaymentMethod", comboBox1.SelectedItem.ToString());  // Méthode de paiement sélectionnée

                    // Ouvrir la connexion et exécuter la requête
                    connect.OpenCon();
                    command.ExecuteNonQuery();
                    connect.CloseCon();

                    // Retourner vrai si l'insertion a réussi
                    return true;
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, afficher un message d'erreur et retourner faux
                MessageBox.Show($"Erreur lors de l'enregistrement du paiement : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                // Appeler la méthode pour enregistrer le montant dans la table Reservations
                if (SaveTotalAmountToReservation() == true)
                {
                    if (SavePay() == true)
                    {
                        MessageBox.Show("Paiement confirmé et montant enregistré avec succès.",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Paiement errone.",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si la méthode de paiement a été sélectionnée
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez sélectionner une méthode de paiement.",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculer le montant total (au cas où il y a un changement dans les dates)
                decimal totalAmount = (dateOut.Date - dateIn.Date).Days * pricePerNight;

                // Requête SQL pour mettre à jour le montant et la méthode de paiement
                string query = "UPDATE Payments SET Amount = @TotalAmount, PaymentMethod = @PaymentMethod WHERE ReservationId = @ReservationId";

                // Connexion à la base de données
                DBConnect connect = new DBConnect();

                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {
                    // Ajouter les paramètres à la requête SQL
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PaymentMethod", comboBox1.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@ReservationId", reservationId);

                    // Ouvrir la connexion et exécuter la requête
                    connect.OpenCon();
                    command.ExecuteNonQuery();
                    connect.CloseCon();

                    // Informer l'utilisateur que la mise à jour a réussi
                    MessageBox.Show("Paiement mis à jour avec succès.",
                                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, afficher un message d'erreur
                MessageBox.Show($"Erreur lors de la mise à jour du paiement : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}