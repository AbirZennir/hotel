using System.Data.SqlClient;
using System.Data;
using System;

public class DBConnect
{
    private readonly SqlConnection connection = new SqlConnection(
        "Data Source=DESKTOP-U5T5LIJ\\SQLEXPRESS;" +  // Utilisation de l'instance de SQL Server
        "Initial Catalog=HotelManagement;" +          // Nom de la base de données
        "Integrated Security=True;" +                  // Utilisation de l'authentification Windows
        "Encrypt=False;"                               // Désactive le cryptage (peut être ajusté en fonction de votre configuration)
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
