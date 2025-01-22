using System.Data.SqlClient;
using System.Data;
using System;

public class DBConnect
{
    private readonly SqlConnection connection = new SqlConnection(
        "Data Source=DESKTOP-U5T5LIJ\\SQLEXPRESS;" +  
        "Initial Catalog=HotelManagement;" +          
        "Integrated Security=True;" +                  
        "Encrypt=False;"                               
    );

    public SqlConnection GetConnection()
    {
        return connection;
    }

    public void OpenCon()
    {
        try
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        catch (SqlException ex)
        {
            throw new Exception($"Erreur de connexion à la base de données: {ex.Message} (Code erreur: {ex.Number})");
        }
    }

    public void CloseCon()
    {
        try
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        catch (SqlException ex)
        {
            throw new Exception($"Erreur lors de la fermeture de la connexion: {ex.Message} (Code erreur: {ex.Number})");
        }
    }
}
