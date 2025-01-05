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
            int numberOfNights = (dateOut - dateIn).Days;

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
            try
            {
                // Appeler la méthode pour enregistrer le montant dans la table Reservations
                SaveTotalAmountToReservation();

                MessageBox.Show("Paiement confirmé et montant enregistré avec succès.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fermer le formulaire après confirmation
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void SaveTotalAmountToReservation()
        {
            string query = "UPDATE Reservations SET TotalAmount = @TotalAmount WHERE ReservationId = @ReservationId";

            // Calculer le montant total
            decimal totalAmount = (dateOut - dateIn).Days * pricePerNight;
            DBConnect connect = new DBConnect();
            
                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@ReservationId", reservationId);

                    connect.OpenCon();
                    command.ExecuteNonQuery(); // Enregistrer le montant dans la base de données
                    connect.CloseCon();
                }
            }
        }
    }

