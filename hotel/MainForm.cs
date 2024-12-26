using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
    }
}
