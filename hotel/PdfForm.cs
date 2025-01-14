using iText.Kernel.Pdf;
using iText.Layout.Properties;
using iText.Layout;
using iText.Layout.Element;
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
    public partial class PdfForm : Form
    {
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
            string connectionString = "Server=DESKTOP-U5T5LIJ\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True;";
            string query = "SELECT * FROM Rooms";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog() { Filter = "PDF File|*.pdf" })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = fileDialog.FileName;

                    try
                    {
                        // Fetch data from database
                        DataTable dataTable = FetchRoomsData();

                        if (dataTable == null || dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No data found in the 'Rooms' table.");
                            return;
                        }

                        // Create and write to PDF
                        ExportToPdf(dataTable, fileName);

                        MessageBox.Show($"Data successfully exported to: {fileName}");
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
            string connectionString = "Server=DESKTOP-U5T5LIJ\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True;";
            string query = "SELECT * FROM Rooms";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}");
            }

            return dataTable;
        }

        private void ExportToPdf(DataTable dataTable, string fileName)
        {
            try
            {
                using (PdfWriter writer = new PdfWriter(fileName))
                {
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Define fonts
                    var font = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                    var boldFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                    document.SetFont(font);

                    // Create table
                    iText.Layout.Element.Table table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(dataTable.Columns.Count)).UseAllAvailableWidth();

                    // Add table headers
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName).SetFont(boldFont)));
                    }

                    // Add table rows
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            string cellValue = row[column] != DBNull.Value ? row[column].ToString() : string.Empty;
                            table.AddCell(new Cell().Add(new Paragraph(cellValue).SetFont(font)));
                        }
                    }

                    // Add table to document
                    document.Add(table);
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while exporting to PDF: {ex.Message}");
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
