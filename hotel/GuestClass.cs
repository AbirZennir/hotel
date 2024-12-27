using hotel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace hotel
{
    class GuestClass
    {
        DBConnect connect = new DBConnect();

        public DataTable getAllGuestEmails()
        {
            // Requête SQL pour récupérer tous les emails des invités
            string selectQuery = "SELECT DISTINCT GuestEmail FROM [Clients] WHERE GuestEmail IS NOT NULL";

            // Préparer la commande SQL
            SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection());

            // Adapter pour remplir les données
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Retourner les emails sous forme de DataTable
            return table;
        }





        // Insérer un nouveau client
        public bool InsertGuest(string id, string fname, string lname, string phone, string city, string email)
        {
            string insertQuery = "INSERT INTO clients (GuestId, GuestFirstName, GuestLastName, GuestPhone, GuestCity, GuestEmail) VALUES(@id, @fname, @lname, @ph, @ct, @em)";
            using (SqlCommand command = new SqlCommand(insertQuery, connect.GetConnection()))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@ph", phone);
                command.Parameters.AddWithValue("@ct", city);
                command.Parameters.AddWithValue("@em", email);

                connect.OpenCon();
                bool success = command.ExecuteNonQuery() == 1;
                connect.CloseCon();
                return success;
            }
        }

        // Obtenir la liste des clients
        public DataTable GetGuest()
        {
            string selectQuery = "SELECT * FROM Clients";
            using (SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }



        // Modifier un client
        public bool EditGuest(string id, string fname, string lname, string phone, string city, string email)
        {
            string editQuery = "UPDATE clients SET GuestFirstName = @fname, GuestLastName = @lname, GuestPhone = @ph, GuestCity = @ct, GuestEmail = @em WHERE GuestId = @id";
            using (SqlCommand command = new SqlCommand(editQuery, connect.GetConnection()))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@ph", phone);
                command.Parameters.AddWithValue("@ct", city);
                command.Parameters.AddWithValue("@em", email);

                connect.OpenCon();
                bool success = command.ExecuteNonQuery() == 1;
                connect.CloseCon();
                return success;
            }
        }

        // Supprimer un client
        public bool RemoveGuest(string id)
        {
            string deleteQuery = "DELETE FROM clients WHERE GuestId = @id";
            using (SqlCommand command = new SqlCommand(deleteQuery, connect.GetConnection()))
            {
                command.Parameters.AddWithValue("@id", id);
                connect.OpenCon();
                bool success = command.ExecuteNonQuery() == 1;
                connect.CloseCon();
                return success;
            }
        }


    }
}
