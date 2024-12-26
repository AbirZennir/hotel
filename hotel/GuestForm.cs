using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace hotel
{
    public partial class GuestForm : Form

    {
        GuestClass guest = new GuestClass();
        public GuestForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox_Id.Clear();
            textBox_first.Clear();
            textBox_last.Clear();
            textBox_phone.Clear();
            textBox_email.Clear();
            textBox_city.Clear();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_city_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_last_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_first_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_Id.Text == "" || textBox_first.Text == "" || textBox_phone.Text == "")
            {
                MessageBox.Show("Required Field - Id no, first name and phone no:", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    string id = textBox_Id.Text;
                    string fname = textBox_first.Text;
                    string lname = textBox_last.Text;
                    string phone = textBox_phone.Text;
                    string city = textBox_city.Text;
                    string email = textBox_email.Text;

                    Boolean insertGuest = guest.InsertGuest(id, fname, lname, phone, city, email);
                    if (insertGuest)
                    {
                        MessageBox.Show("New guest save successfuly", "Guest Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTable();
                        button_clean.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("ERROR - guest not inserted", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button_dashbord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getTable()
        {
            dataGridView_guest.DataSource = guest.GetGuest();

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_Id.Text == "" || textBox_first.Text == "" || textBox_phone.Text == "")
            {
                MessageBox.Show("Required Field - Id no, first name and phone no:", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    string id = textBox_Id.Text;
                    string fname = textBox_first.Text;
                    string lname = textBox_last.Text;
                    string phone = textBox_phone.Text;
                    string city = textBox_city.Text;
                    string email = textBox_email.Text;

                    Boolean editGuest = guest.EditGuest(id, fname, lname, phone, city, email);
                    if (editGuest)
                    {
                        MessageBox.Show(" Guest update successfuly", "Guest updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTable();
                        button_clean.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("ERROR - guest not updated", "Error update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void dataGridView_guest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_guest_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox_Id.Text = dataGridView_guest.CurrentRow.Cells[0].Value.ToString();
            textBox_first.Text = dataGridView_guest.CurrentRow.Cells[1].Value.ToString();
            textBox_last.Text = dataGridView_guest.CurrentRow.Cells[2].Value.ToString();
            textBox_phone.Text = dataGridView_guest.CurrentRow.Cells[3].Value.ToString();
            textBox_city.Text = dataGridView_guest.CurrentRow.Cells[4].Value.ToString();
            textBox_email.Text = dataGridView_guest.CurrentRow.Cells[5].Value.ToString();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_Id.Text == "")
            {
                MessageBox.Show("Required Field - Id no :", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    string id = textBox_Id.Text;
                    Boolean deleteGuest = guest.RemoveGuest(id);
                    if (deleteGuest)
                    {
                        MessageBox.Show(" Guest remove successfuly", "Guest removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTable();
                        button_clean.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("ERROR - guest not removed", "Error remove", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } catch (Exception ex) {
                    MessageBox.Show($"Failed to delete {ex.Message}");
            }


            }
        }

        private void button_guest_Click(object sender, EventArgs e)
        {

        }

        private void button_reception_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.Show();
        }

        private void button_room_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomForm roomForm = new RoomForm();
            roomForm.Show();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm LoginForm = new loginForm();
            LoginForm.Show();
        }
    } }
