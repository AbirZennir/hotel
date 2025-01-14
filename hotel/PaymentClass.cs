using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace hotel
{
    internal class PaymentClass
    {
        DBConnect connect = new DBConnect();


        // Calculate the total amount for a reservation
        private decimal GetTotalAmount(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            try
            {
                if (checkOutDate <= checkInDate)
                {
                    MessageBox.Show("La date de départ doit être après la date d'arrivée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                decimal pricePerNight = GetPricePerNight(roomId);
                int totalNights = (checkOutDate - checkInDate).Days;

                if (totalNights <= 0)
                {
                    MessageBox.Show("Durée de séjour invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                return pricePerNight * totalNights;
            }
            catch (Exception ex)
            {
               // HandleException(ex);
                return 0;
            }
        }

        // Get the price per night for a given room
        private decimal GetPricePerNight(int roomId)
        {
            try
            {
                string query = "SELECT PricePerNight FROM [Rooms] WHERE [RoomId] = @RoomId";
                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {
                    command.Parameters.Add("@RoomId", SqlDbType.Int).Value = roomId;

                    connect.OpenCon();
                    object result = command.ExecuteScalar();
                    connect.CloseCon();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal pricePerNight))
                    {
                        return pricePerNight;
                    }
                    else
                    {
                        MessageBox.Show("Impossible de récupérer le prix par nuit pour cette chambre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
               // HandleException(ex);
                return 0;
            }
        }
        public bool removePayment(int reservationId)
        {
            string deleteQuery = "DELETE FROM [Payments] WHERE [ReservationId] = @reservationId";
            SqlCommand command = new SqlCommand(deleteQuery, connect.GetConnection());
            command.Parameters.Add("@reservationId", SqlDbType.Int).Value = reservationId;

            try
            {
                connect.OpenCon();
                bool success = command.ExecuteNonQuery() == 1;
                connect.CloseCon();
                return success;
            }
            catch (Exception ex)
            {
                //HandleException(ex);
                return false;
            }
        }

    }
}
