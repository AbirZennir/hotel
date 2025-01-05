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
    public partial class SearcheRoomForm : Form
    {
        public SearcheRoomForm()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string roomId = textBox_IdRoom.Text.Trim();
           

            if (string.IsNullOrEmpty(roomId) )
            {
                MessageBox.Show("Veuillez entrer un ou plusieurs critères pour rechercher.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Chaîne de connexion à la base de données
                string connectionString = "Data Source=DESKTOP-U5T5LIJ\\SQLEXPRESS;" +
                                          "Initial Catalog=HotelManagement;" +
                                          "Integrated Security=True;" +
                                          "Encrypt=False;";  // Remplacez par votre chaîne de connexion

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Requête SQL avec paramètres
                    string query = @"SELECT RoomId, RoomTypeId, RoomNumber, Status 
                             FROM Rooms
                             WHERE (@RoomId IS NULL OR RoomId LIKE '%' + @RoomId + '%')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ajout des paramètres
                        command.Parameters.AddWithValue("@RoomId", string.IsNullOrEmpty(roomId) ? (object)DBNull.Value : roomId);
                       

                        // Remplir un DataTable avec les résultats
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Afficher les résultats dans le DataGridView
                            dataGridView_rooms.DataSource = dataTable;

                            // Vérifier s'il n'y a pas de résultats
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Aucune chambre ne correspond à vos critères.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la recherche : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
