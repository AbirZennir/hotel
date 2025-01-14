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
    public partial class MainForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U5T5LIJ\\SQLEXPRESS;" +  // Utilisation de l'instance de SQL Server
        "Initial Catalog=HotelManagement;" +          // Nom de la base de données
        "Integrated Security=True;" +                  // Utilisation de l'authentification Windows
        "Encrypt=False;");

        public MainForm()
        {
            InitializeComponent();
            CountRooms();
            CountGuest();
            CountReception();
        }

        private void CountRooms()
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Rooms", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                RoomsLbl.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void CountGuest()
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Clients", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GuestLbl.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void CountReception()
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Reservations", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ReceptionLbl.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_dashbord_Click(object sender, EventArgs e)
        {
            panel_slide.Height = button_dashbord.Height;
            panel_slide.Top = button_dashbord.Top;

        }

        private void button_guest_Click(object sender, EventArgs e)
        {
            panel_slide.Height = button_guest.Height;
            panel_slide.Top=button_guest.Top;

            this.Hide();
            GuestForm mainForm = new GuestForm();
            mainForm.Show();
        }

        private void button_reception_Click(object sender, EventArgs e)
        {
            panel_slide.Height=button_reception.Height;
            panel_slide.Top=button_reception.Top;
            this.Hide();
            ReservationForm resForm = new ReservationForm();
            resForm.Show();
        }

        private void button_room_Click(object sender, EventArgs e)
        {
            panel_slide.Height=button_room.Height;
            panel_slide.Top =button_room.Top;

            this.Hide();
            RoomForm roomForm = new RoomForm();
            roomForm.Show();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            panel_slide.Height=button_logout.Height;
            panel_slide.Top=button_logout.Top;

            this.Hide();
            loginForm LoginForm = new loginForm();
            LoginForm.Show();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmailForm emailForm = new EmailForm();
            emailForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExcelForm excelForm = new ExcelForm();
            excelForm.Show();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PdfForm pdfForm = new PdfForm();
            pdfForm.Show();
        }
    }
}
