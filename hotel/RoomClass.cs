using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hotel
{
    class RoomClass
    {
        DBConnect connect = new DBConnect();

        public bool setReservRoom(int roomId, string status)
        {

            // Votre requête SQL
            string query = "UPDATE Rooms SET Status = @status WHERE RoomId = @roomId";

            // Obtenez la connexion de votre classe DBConnect
            SqlConnection connection = connect.GetConnection();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@roomId", roomId);

            try
            {
                connect.OpenCon(); // Ouvrir la connexion
                int result = command.ExecuteNonQuery(); // Exécuter la requête
                return result > 0; // Retourner true si au moins une ligne est mise à jour
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur si une exception est levée
                MessageBox.Show($"Erreur lors de la mise à jour de la chambre : {ex.Message}");
                return false;
            }
            finally
            {
                connect.CloseCon(); // Fermer la connexion
            }
        }

        


        // Vérifier si un RoomTypeId existe dans la table RoomTypes
        public bool RoomTypeExists(int typeId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM RoomTypes WHERE RoomTypeId = @typeId";
                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {
                    command.Parameters.Add("@typeId", SqlDbType.Int).Value = typeId;
                    connect.OpenCon();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            finally
            {
                connect.CloseCon();
            }
        }

        // Obtenir une liste des types de chambres
        public DataTable GetRoomType()
        {
            string selectQuery = "SELECT * FROM RoomTypes";
            SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        // Ajouter une nouvelle chambre
        public bool AddRoom(int type, string number, string status)
        {
            try
            {
                string insertQuery = "INSERT INTO Rooms (RoomTypeId, RoomNumber, status) " +
                                   "VALUES (@typeId, @number, @status)";

                using (SqlCommand command = new SqlCommand(insertQuery, connect.GetConnection()))
                {
                    command.Parameters.Add("@typeId", SqlDbType.Int).Value = type;
                    command.Parameters.Add("@number", SqlDbType.VarChar, 25).Value = 
                        string.IsNullOrEmpty(number) ? (object)DBNull.Value : number;
                    command.Parameters.Add("@status", SqlDbType.VarChar, 25).Value = 
                        string.IsNullOrEmpty(status) ? (object)DBNull.Value : status;

                    connect.OpenCon();
                    int result = command.ExecuteNonQuery();
                    connect.CloseCon();

                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Erreur SQL : {ex.Message}\nCode d'erreur : {ex.Number}", 
                               "Erreur d'insertion", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connect.CloseCon();
            }
        }

        // Obtenir une liste des chambres
        public DataTable GetRoomList()
        {
            string selectQuery = @"
                SELECT 
                    R.RoomId,
                    RT.Name AS 'Room Type',
                    R.RoomNumber AS 'Room Number',
                    R.status AS 'Status'
                FROM Rooms R
                LEFT JOIN RoomTypes RT ON R.RoomTypeId = RT.RoomTypeId
                ORDER BY R.RoomId";

            using (SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        // Modifier une chambre
        public bool EditRoom(int no, int type, string number, string status)
        {
            try
            {
                string editQuery = "UPDATE Rooms SET RoomTypeId = @type, RoomNumber = @nb, status = @sts WHERE RoomId = @no";
                using (SqlCommand command = new SqlCommand(editQuery, connect.GetConnection()))
                {
                    command.Parameters.Add("@no", SqlDbType.Int).Value = no;
                    command.Parameters.Add("@type", SqlDbType.Int).Value = type;
                    command.Parameters.Add("@nb", SqlDbType.VarChar, 25).Value = 
                        string.IsNullOrEmpty(number) ? (object)DBNull.Value : number;
                    command.Parameters.Add("@sts", SqlDbType.VarChar, 25).Value = 
                        string.IsNullOrEmpty(status) ? (object)DBNull.Value : status;

                    connect.OpenCon();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}\nError Code: {ex.Number}", 
                               "Update Error", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connect.CloseCon();
            }
        }

        // Supprimer une chambre
        public bool RemoveRoom(int id)
        {
            string deleteQuery = "DELETE FROM Rooms WHERE RoomId = @id";
            SqlCommand command = new SqlCommand(deleteQuery, connect.GetConnection());

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                connect.OpenCon();
                if (command.ExecuteNonQuery() == 1)
                {
                    connect.CloseCon();
                    return true;
                }
                else
                {
                    connect.CloseCon();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                connect.CloseCon();
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Vérifier si une chambre existe déjà avec cet ID
        public bool RoomExists(int roomId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Rooms WHERE RoomId = @roomId";
                using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
                {
                    command.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                    connect.OpenCon();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            finally
            {
                connect.CloseCon();
            }
        }

        // Vérifier si une chambre existe déjà avec ce numéro
        public bool RoomNumberExists(string roomNumber)
        {
            string query = "SELECT COUNT(*) FROM Rooms WHERE RoomNumber = @number";
            SqlCommand command = new SqlCommand(query, connect.GetConnection());
            command.Parameters.Add("@number", SqlDbType.VarChar).Value = roomNumber;

            connect.OpenCon();
            int count = (int)command.ExecuteScalar();
            connect.CloseCon();

            return count > 0;
        }

        public int GetRoomTypeIdByName(string name)
        {
            string query = "SELECT RoomTypeId FROM RoomTypes WHERE Name = @name";
            using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
            {
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                connect.OpenCon();
                var result = command.ExecuteScalar();
                connect.CloseCon();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}
