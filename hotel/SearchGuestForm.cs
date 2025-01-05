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
    public partial class SearchGuestForm : Form
    {
        public SearchGuestForm()
        {
            InitializeComponent();
        }

        private void dataGridView_guest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string firstName = textBox_first.Text.Trim();
            string lastName = textBox_last.Text.Trim();

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Veuillez entrer un prénom, un nom ou les deux pour rechercher.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Chaîne de connexion à la base de données
                string connectionString = "Data Source=DESKTOP-U5T5LIJ\\SQLEXPRESS;" +  // Utilisation de l'instance de SQL Server
        "Initial Catalog=HotelManagement;" +          // Nom de la base de données
        "Integrated Security=True;" +                  // Utilisation de l'authentification Windows
        "Encrypt=False;"; // Remplacez par votre chaîne de connexion

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Requête SQL avec paramètres
                    string query = @"SELECT GuestId, GuestFirstName, GuestLastName, GuestPhone, GuestCity, GuestEmail 
                                     FROM Clients
                                     WHERE (@FirstName IS NULL OR GuestFirstName LIKE '%' + @FirstName + '%')
                                     AND (@LastName IS NULL OR GuestLastName LIKE '%' + @LastName + '%')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ajout des paramètres
                        command.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(firstName) ? (object)DBNull.Value : firstName);
                        command.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(lastName) ? (object)DBNull.Value : lastName);

                        // Remplir un DataTable avec les résultats
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Afficher les résultats dans le DataGridView
                            dataGridView_guest.DataSource = dataTable;
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
