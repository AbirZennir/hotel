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

            int numberOfNights = (dateOut.Date - dateIn.Date).Days;

            decimal totalAmount = numberOfNights * pricePerNight;


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
                decimal totalAmount = (dateOut.Date - dateIn.Date).Days * pricePerNight;


                string query = "INSERT INTO Payments (ReservationId, PaymentDate, Amount, PaymentMethod) " +
                               "VALUES (@ReservationId, @PaymentDate, @TotalAmount, @PaymentMethod)";


                DBConnect connect = new DBConnect();

                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {

                    command.Parameters.AddWithValue("@ReservationId", reservationId);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);  
                    command.Parameters.AddWithValue("@PaymentMethod", comboBox1.SelectedItem.ToString());  


                    connect.OpenCon();
                    command.ExecuteNonQuery();
                    connect.CloseCon();

                    return true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erreur lors de l'enregistrement du paiement : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {

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

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez sélectionner une méthode de paiement.",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                decimal totalAmount = (dateOut.Date - dateIn.Date).Days * pricePerNight;

                string query = "UPDATE Payments SET Amount = @TotalAmount, PaymentMethod = @PaymentMethod WHERE ReservationId = @ReservationId";

                DBConnect connect = new DBConnect();

                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PaymentMethod", comboBox1.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@ReservationId", reservationId);

                    connect.OpenCon();
                    command.ExecuteNonQuery();
                    connect.CloseCon();

                    MessageBox.Show("Paiement mis à jour avec succès.",
                                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour du paiement : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}