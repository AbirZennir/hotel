using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data.SqlClient;


namespace hotel
{
    public partial class ExcelForm : Form
    {
        public ExcelForm()
        {
            InitializeComponent();
        }

        private void ExcelForm_Load(object sender, EventArgs e)
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
            using (SaveFileDialog file = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    try
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
                                    dataGridView1.DataSource = dataTable;

                                    if (dataTable.Rows.Count == 0)
                                    {
                                        MessageBox.Show("No data found in the 'rooms' table.");
                                        return;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while fetching data: {ex.Message}");
                            return;
                        }

                        try
                        {
                            using (XLWorkbook xwb = new XLWorkbook())
                            {
                                xwb.Worksheets.Add(dataTable, "Rooms");
                                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                string filePath = System.IO.Path.Combine(desktopPath, "RoomsData.xlsx");
                                xwb.SaveAs(filePath);

                                MessageBox.Show($"Data exported successfully to: {filePath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while exporting to Excel: {ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button_dashbord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm LoginForm = new loginForm();
            LoginForm.Show();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
