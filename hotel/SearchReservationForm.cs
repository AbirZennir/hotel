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
    public partial class SearchReservationForm : Form
    {
        public SearchReservationForm()
        {
            InitializeComponent();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string guestId = textBox_IdGuest.Text.Trim();
            string roomId = textBox_Room.Text.Trim();

            if (string.IsNullOrEmpty(guestId) && string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Veuillez entrer un ID client, un ID de chambre ou les deux pour rechercher.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Chaîne de connexion à la base de données
                string connectionString = "Data Source=DESKTOP-U5T5LIJ\\SQLEXPRESS;" +  // Instance de SQL Server
                    "Initial Catalog=HotelManagement;" +          // Nom de la base de données
                    "Integrated Security=True;" +                  // Authentification Windows
                    "Encrypt=False;";                              // Remplacez par votre propre chaîne de connexion

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Requête SQL avec paramètres
                    string query = @"SELECT ReservationId, ClientId, RoomId, CheckInDate, CheckOutDate, TotalAmount, ReservationDate, RoomTypeId 
                         FROM Reservations
                         WHERE (@GuestId IS NULL OR ClientId LIKE '%' + @GuestId + '%')
                         AND (@RoomId IS NULL OR RoomId LIKE '%' + @RoomId + '%')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ajout des paramètres
                        command.Parameters.AddWithValue("@GuestId", string.IsNullOrEmpty(guestId) ? (object)DBNull.Value : guestId);
                        command.Parameters.AddWithValue("@RoomId", string.IsNullOrEmpty(roomId) ? (object)DBNull.Value : roomId);

                        // Remplir un DataTable avec les résultats
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Afficher les résultats dans le DataGridView
                            dataGridView_reservation.DataSource = dataTable;

                            dataGridView_reservation.Columns["ReservationId"].HeaderText = "ID Réservation";
                            dataGridView_reservation.Columns["ClientId"].HeaderText = "ID Client";
                            dataGridView_reservation.Columns["RoomId"].HeaderText = "ID Chambre";
                            dataGridView_reservation.Columns["CheckInDate"].HeaderText = "Date d'Arrivée";
                            dataGridView_reservation.Columns["CheckOutDate"].HeaderText = "Date de Départ";
                            dataGridView_reservation.Columns["TotalAmount"].HeaderText = "Montant Total";
                            dataGridView_reservation.Columns["ReservationDate"].HeaderText = "Date de Réservation";
                            dataGridView_reservation.Columns["RoomTypeId"].HeaderText = "ID Type de Chambre";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la recherche : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
