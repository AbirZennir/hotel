using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hotel
{
    // This class handles reservation functionality
    class ReservationClass
    {
        DBConnect connect = new DBConnect();

        public DataTable roomByType(int type)
        {
            string selectQuery = "SELECT * FROM [Rooms] WHERE [RoomTypeId]=@type AND [status]='Free'";
            SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection());
            command.Parameters.Add("@type", SqlDbType.Int).Value = type;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // To get room type by room number
        public int typeByRoomNo(int roomId)
        {
            string selectQuery = "SELECT [RoomTypeId] FROM [Rooms] WHERE [RoomId]=@roomId";
            SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection());
            command.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0]["RoomTypeId"]);
        }

        // To get the reservation table
        public DataTable getReserv()
        {
            string selectQuery = "SELECT * FROM [Reservations]";
            SqlCommand command = new SqlCommand(selectQuery, connect.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Change room status when reserved
        public bool setReservRoom(int roomId, string status)
        {
            string updateQuery = "UPDATE [Rooms] SET [Status]=@status WHERE [RoomId]=@roomId";
            SqlCommand command = new SqlCommand(updateQuery, connect.GetConnection());
            command.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;

            connect.OpenCon();
            bool success = command.ExecuteNonQuery() == 1;
            connect.CloseCon();
            return success;
        }

        // Add a reservation
        public bool addReserv(string clientId, int roomId, DateTime checkinDate, DateTime checkoutDate, decimal totalAmount, int roomTypeId)
        {
            string insertQuery = @"INSERT INTO Reservations 
                                (ClientId, RoomId, CheckinDate, CheckOutDate, TotalAmount, ReservationDate, RoomTypeId)
                                VALUES 
                                (@clientId, @roomId, @checkinDate, @checkoutDate, @totalAmount, GETDATE(), @roomTypeId)";
            
            try
            {
                SqlCommand command = new SqlCommand(insertQuery, connect.GetConnection());
                
                command.Parameters.Add("@clientId", SqlDbType.NVarChar).Value = clientId;
                command.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                command.Parameters.Add("@checkinDate", SqlDbType.DateTime).Value = checkinDate;
                command.Parameters.Add("@checkoutDate", SqlDbType.DateTime).Value = checkoutDate;
                command.Parameters.Add("@totalAmount", SqlDbType.Decimal).Value = totalAmount;
                command.Parameters.Add("@roomTypeId", SqlDbType.Int).Value = roomTypeId;

                connect.OpenCon();
                int result = command.ExecuteNonQuery();
                connect.CloseCon();
                
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Delete a reservation
        public bool removeReserv(int reservationId)
        {
            string deleteQuery = "DELETE FROM [Reservations] WHERE [ReservationId]=@reservId";
            SqlCommand command = new SqlCommand(deleteQuery, connect.GetConnection());
            command.Parameters.Add("@reservId", SqlDbType.Int).Value = reservationId;

            connect.OpenCon();
            bool success = command.ExecuteNonQuery() == 1;
            connect.CloseCon();
            return success;
        }

        // Edit a reservation
        public bool editReserv(int reservationId, string clientId, int roomId, DateTime checkinDate, DateTime checkoutDate)
        {
            string updateQuery = @"UPDATE [Reservations] 
                SET [ClientId]=@clientId, 
                    [RoomId]=@roomId, 
                    [CheckinDate]=@checkin, 
                    [CheckOutDate]=@checkout,
                    [RoomTypeId]=(SELECT RoomTypeId FROM Rooms WHERE RoomId = @roomId)
                WHERE [ReservationId]=@reservId";

            SqlCommand command = new SqlCommand(updateQuery, connect.GetConnection());
            command.Parameters.Add("@reservId", SqlDbType.Int).Value = reservationId;
            command.Parameters.Add("@clientId", SqlDbType.NVarChar).Value = clientId;
            command.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
            command.Parameters.Add("@checkin", SqlDbType.DateTime).Value = checkinDate;
            command.Parameters.Add("@checkout", SqlDbType.DateTime).Value = checkoutDate;

            connect.OpenCon();
            bool success = command.ExecuteNonQuery() == 1;
            connect.CloseCon();
            return success;
        }
    }
}
