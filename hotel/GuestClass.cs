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
            
            string selectQuery = "SELECT DISTINCT GuestEmail FROM [Clients] WHERE GuestEmail IS NOT NULL";

           
            SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection());

          
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

           
            return table;
        }





       
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
