using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;





namespace hotel
{
    public partial class PdfForm : Form
    {
        private const string ConnectionString = "Server=DESKTOP-U5T5LIJ\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True;";
        public PdfForm()
        {
            InitializeComponent();
        }

        private void PdfForm_Load(object sender, EventArgs e)
        {
            LoadRoomsData();
        }

        private void LoadRoomsData()
        {
            string query = "SELECT * FROM Rooms";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog file = new SaveFileDialog() { Filter = "PDF File|*.pdf" })
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string connectionString = "Server=DESKTOP-U5T5LIJ\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True;";
                        string query = "SELECT * FROM Rooms";
                        DataTable dataTable = new DataTable();

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                                dataAdapter.Fill(dataTable);

                                if (dataTable.Rows.Count == 0)
                                {
                                    MessageBox.Show("No data found in the 'rooms' table.");
                                    return;
                                }

                                // Créer un document PDF
                                using (FileStream stream = new FileStream(file.FileName, FileMode.Create))
                                {
                                    // Utiliser iTextSharp
                                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
                                    iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();

                                    // Ajouter du contenu au PDF
                                    PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);

                                    // Ajouter les en-têtes
                                    foreach (DataColumn column in dataTable.Columns)
                                    {
                                        pdfTable.AddCell(new Phrase(column.ColumnName));
                                    }

                                    // Ajouter les données
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        foreach (var item in row.ItemArray)
                                        {
                                            pdfTable.AddCell(new Phrase(item.ToString()));
                                        }
                                    }

                                    pdfDoc.Add(pdfTable);
                                    pdfDoc.Close();
                                }

                                MessageBox.Show("Data exported to PDF successfully!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        private DataTable FetchRoomsData()
        {
            string query = "SELECT * FROM Rooms";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}");
            }

            return dataTable;
        }

        private void ExportToPdf(DataTable dataTable, string fileName)
        {

            
        }

        private void LogError(Exception ex)
        {
            // Log error to the console for debugging
            Console.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm LoginForm = new loginForm();
            LoginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button_dashbord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
