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
    public partial class RoomForm : Form
    {
        RoomClass room = new RoomClass();
        public RoomForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des champs obligatoires
                if (string.IsNullOrEmpty(textBox_Id.Text) || comboBox_roomType.SelectedValue == null)
                {
                    MessageBox.Show("Room ID and Room Type are required fields",
                                  "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int typeId = Convert.ToInt32(comboBox_roomType.SelectedValue);
                string number = textBox_number.Text.Trim();
                string status = radioButton_free.Checked ? "Free" : "Busy";

                // Vérification du type de chambre
                if (!room.RoomTypeExists(typeId))
                {
                    MessageBox.Show("The selected Room Type does not exist",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (room.AddRoom(typeId, number, status))
                {
                    MessageBox.Show("Room added successfully",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_clean.PerformClick();
                    getRoomList();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid data format. Please check your input.",
                              "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox_Id.Clear();
            textBox_number.Clear();
            comboBox_roomType.SelectedIndex = 0;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            comboBox_roomType.DataSource = room.GetRoomType();
            comboBox_roomType.DisplayMember = "Name";
            comboBox_roomType.ValueMember = "RoomTypeId";

            getRoomList();

            dataGridView_room.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void getRoomList()
        {
            dataGridView_room.DataSource = room.GetRoomList();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32( textBox_Id.Text);
            int type = Convert.ToInt32(comboBox_roomType.SelectedValue.ToString());
            string ph = textBox_number.Text;
            string status = radioButton_free.Checked ? "Free" : "Busy";

            try
            {
                if (room.EditRoom(no, type, ph, status))
                {
                    MessageBox.Show("Room Update Successfuly", "Update Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getRoomList();
                    button_clean.PerformClick();
                }
                else
                {
                    MessageBox.Show("Room Not Update", "Update Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView_room_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Id.Text = dataGridView_room.CurrentRow.Cells[0].Value.ToString();
            comboBox_roomType.SelectedValue = room.GetRoomTypeIdByName(dataGridView_room.CurrentRow.Cells[1].Value.ToString());
            textBox_number.Text = dataGridView_room.CurrentRow.Cells[2].Value.ToString();
            //for radio button
            string rButton = dataGridView_room.CurrentRow.Cells[3].Value.ToString();
            if (rButton.Equals("Free"))
            {
                radioButton_free.Checked = true;
            }
            else
            {
                radioButton_basy.Checked = true;
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérification si une chambre est sélectionnée
                if (string.IsNullOrEmpty(textBox_Id.Text))
                {
                    MessageBox.Show("Veuillez sélectionner une chambre à supprimer", 
                        "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int roomId = Convert.ToInt32(textBox_Id.Text);

                // Vérifier si la chambre existe
                if (!room.RoomExists(roomId))
                {
                    MessageBox.Show("Cette chambre n'existe pas", 
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Demander confirmation avant la suppression
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette chambre ?", 
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (room.RemoveRoom(roomId))
                    {
                        MessageBox.Show("Chambre supprimée avec succès", 
                            "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getRoomList();
                        button_clean.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Impossible de supprimer la chambre. Elle pourrait être liée à des réservations existantes.", 
                            "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format d'ID invalide", 
                    "Erreur de format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {

        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button_dashbord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button_guest_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestForm guestForm = new GuestForm();
            guestForm.Show();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm LoginForm = new loginForm();
            LoginForm.Show();
        }

        private void button_room_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomForm roomForm = new RoomForm();
            roomForm.Show();

        }

        private void button_reception_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.Show();
        }

        private void radioButton_free_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
