﻿using System;
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
    public partial class ReservationForm : Form
    {
        RoomClass room = new RoomClass();
        ReservationClass reservation = new ReservationClass();
        decimal totalAmount;
        private PaymentClass payment;
        public ReservationForm()
        {
            InitializeComponent();
            payment = new PaymentClass();

        }


        public ReservationForm(decimal totall)
        {
            InitializeComponent();
            this.totalAmount = totall;
        }



        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            comboBox_roomType.DataSource = room.GetRoomType();
            comboBox_roomType.DisplayMember = "Name";
            comboBox_roomType.ValueMember = "RoomTypeId";


            dataGridView_reserv.DefaultCellStyle.ForeColor = Color.Black;

            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ReservationId");
                dataTable.Columns.Add("ClientId");
                dataTable.Columns.Add("RoomId");
                dataTable.Columns.Add("CheckInDate");
                dataTable.Columns.Add("CheckOutDate");
                dataTable.Columns.Add("TotalAmount");
                dataTable.Columns.Add("ReservationDate");
                dataTable.Columns.Add("RoomTypeId");

                dataGridView_reserv.DataSource = dataTable;

                if (dataGridView_reserv.Columns["ReservationId"] != null)
                    dataGridView_reserv.Columns["ReservationId"].HeaderText = "ID Réservation";
                if (dataGridView_reserv.Columns["ClientId"] != null)
                    dataGridView_reserv.Columns["ClientId"].HeaderText = "ID Client";
                if (dataGridView_reserv.Columns["RoomId"] != null)
                    dataGridView_reserv.Columns["RoomId"].HeaderText = "ID Chambre";
                if (dataGridView_reserv.Columns["CheckInDate"] != null)
                    dataGridView_reserv.Columns["CheckInDate"].HeaderText = "Date d'Arrivée";
                if (dataGridView_reserv.Columns["CheckOutDate"] != null)
                    dataGridView_reserv.Columns["CheckOutDate"].HeaderText = "Date de Départ";
                if (dataGridView_reserv.Columns["TotalAmount"] != null)
                    dataGridView_reserv.Columns["TotalAmount"].HeaderText = "Montant Total";
                if (dataGridView_reserv.Columns["ReservationDate"] != null)
                    dataGridView_reserv.Columns["ReservationDate"].HeaderText = "Date de Réservation";
                if (dataGridView_reserv.Columns["RoomTypeId"] != null)
                    dataGridView_reserv.Columns["RoomTypeId"].HeaderText = "ID Type de Chambre";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            getReservTable();
        }

        private void comboBox_roomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_roomType.SelectedValue != null)
                {
                    int type = Convert.ToInt32(comboBox_roomType.SelectedValue.ToString());
                    comboBox_roomId.DataSource = reservation.roomByType(type);
                    comboBox_roomId.DisplayMember = "RoomId";
                    comboBox_roomId.ValueMember = "RoomId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getReservTable()
        {
            dataGridView_reserv.DataSource = reservation.getReserv();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_guestId.Text))
                {
                    MessageBox.Show("L'ID du client est obligatoire",
                        "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_roomId.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner une chambre",
                        "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_roomType.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un type de chambre",
                        "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string clientId = textBox_guestId.Text;
                int roomId = Convert.ToInt32(comboBox_roomId.SelectedValue);
                DateTime dIn = dateTimePicker_dateIn.Value;
                DateTime dOut = dateTimePicker_dateOut.Value;
                int roomTypeId = Convert.ToInt32(comboBox_roomType.SelectedValue);

                if (dIn < DateTime.Today)
                {
                    MessageBox.Show("La date d'arrivée doit être aujourd'hui ou après",
                        "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dOut <= dIn)
                {
                    MessageBox.Show("La date de départ doit être après la date d'arrivée",
                        "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int numberOfNights = (dOut - dIn).Days;

                decimal pricePerNight = GetPricePerNight(roomTypeId);

                decimal totalAmount = numberOfNights * pricePerNight;

                if (MessageBox.Show($"Voulez-vous confirmer cette réservation ?\n\nMontant total : {totalAmount:C}",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    if (reservation.addReserv(clientId, roomId, dIn, dOut, totalAmount, roomTypeId) &&
                        reservation.setReservRoom(roomId, "Busy"))
                    {
                        MessageBox.Show("Réservation ajoutée avec succès",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        getReservTable();

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Impossible d'ajouter la réservation. Veuillez vérifier les informations.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format de données invalide",
                    "Erreur de format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearFields()
        {
            textBox_Id.Clear();
            textBox_guestId.Clear();
            dateTimePicker_dateIn.Value = DateTime.Now;
            dateTimePicker_dateOut.Value = DateTime.Now;
            if (comboBox_roomType.Items.Count > 0)
                comboBox_roomType.SelectedIndex = 0;
        }


        private void button_clean_Click(object sender, EventArgs e)
        {
            ClearFields();


        }





        private void label_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_reserv.CurrentRow == null)
                {
                    MessageBox.Show("Veuillez sélectionner une réservation à modifier",
                        "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (string.IsNullOrEmpty(textBox_guestId.Text))
                {
                    MessageBox.Show("L'ID du client est obligatoire",
                        "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_roomId.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner une chambre",
                        "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int reservationId = Convert.ToInt32(dataGridView_reserv.CurrentRow.Cells["ReservationId"].Value);
                string clientId = textBox_guestId.Text;
                int roomId = Convert.ToInt32(comboBox_roomId.SelectedValue);
                DateTime dIn = dateTimePicker_dateIn.Value;
                DateTime dOut = dateTimePicker_dateOut.Value;

                
                if (dIn < DateTime.Today)
                {
                    MessageBox.Show("La date d'arrivée doit être aujourd'hui ou après",
                        "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dOut <= dIn)
                {
                    MessageBox.Show("La date de départ doit être après la date d'arrivée",
                        "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string currentRoomStatus = reservation.getRoomStatus(roomId);  
                if (currentRoomStatus == "Busy" && dIn != Convert.ToDateTime(dataGridView_reserv.CurrentRow.Cells["CheckInDate"].Value))
                {
                    MessageBox.Show("La chambre est déjà occupée à cette date.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Voulez-vous confirmer la modification de cette réservation ?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool isUpdated = reservation.editReserv(reservationId, clientId, roomId, dIn, dOut);

                    if (isUpdated)
                    {
                        bool isRoomUpdated = reservation.setReservRoom(roomId, "Free");                        if (isRoomUpdated)
                        {
                            MessageBox.Show("Réservation modifiée et statut de la chambre mis à jour avec succès",
                                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getReservTable();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Échec de la mise à jour du statut de la chambre.",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossible de modifier la réservation.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format de données invalide",
                    "Erreur de format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button_guest_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestForm guestForm = new GuestForm();
            guestForm.Show();
        }

        private void button_dashbord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }



        private void comboBox_roomType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                int type = Convert.ToInt32(comboBox_roomType.SelectedValue.ToString());
                comboBox_roomId.DataSource = reservation.roomByType(type);
                comboBox_roomId.DisplayMember = "RoomId";
                comboBox_roomId.ValueMember = "RoomId";
            }
            catch (Exception)
            {

            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérification de la sélection
                if (dataGridView_reserv.CurrentRow == null)
                {
                    MessageBox.Show("Veuillez sélectionner une réservation à supprimer",
                        "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Récupération de l'ID de la réservation
                int reservationId = Convert.ToInt32(dataGridView_reserv.CurrentRow.Cells["ReservationId"].Value);

                // Récupérer l'ID de la chambre associée à la réservation
                int roomId = Convert.ToInt32(dataGridView_reserv.CurrentRow.Cells["RoomId"].Value);

                // Demander confirmation
                if (MessageBox.Show("Voulez-vous vraiment supprimer cette réservation ?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Suppression du paiement associé à la réservation
                    bool isPaymentDeleted = payment.removePayment(reservationId);

                    if (isPaymentDeleted)
                    {
                        // Suppression de la réservation
                        bool isDeleted = reservation.removeReserv(reservationId);

                        if (isDeleted)
                        {
                            // Mise à jour du statut de la chambre à "Free"
                            bool isRoomUpdated = reservation.setReservRoom(roomId, "Free");

                            if (isRoomUpdated)
                            {
                                MessageBox.Show("Réservation et paiement supprimés avec succès, et la chambre est maintenant libre.",
                                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getReservTable();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Échec de la mise à jour du statut de la chambre.",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Impossible de supprimer la réservation.",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossible de supprimer le paiement associé à cette réservation.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format de données invalide",
                    "Erreur de format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        

        private void dataGridView_reserv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_reserv.Rows[e.RowIndex];
                textBox_guestId.Text = row.Cells["ClientId"].Value.ToString();

                // Mettre à jour le type de chambre d'abord
                int roomId = Convert.ToInt32(row.Cells["RoomId"].Value);
                int roomType = reservation.typeByRoomNo(roomId);
                comboBox_roomType.SelectedValue = roomType;

                // Ensuite mettre à jour la chambre
                comboBox_roomId.SelectedValue = roomId;

                // Mettre à jour les dates
                dateTimePicker_dateIn.Value = Convert.ToDateTime(row.Cells["CheckinDate"].Value);
                dateTimePicker_dateOut.Value = Convert.ToDateTime(row.Cells["CheckOutDate"].Value);

                // Mettre à jour les champs supplémentaires

                textBox_Id.Text = row.Cells["ReservationId"].Value.ToString();

                // Ajouter l'affichage de RoomId
                comboBox_roomId.Text = roomId.ToString();
            }

        }

        private void comboBox_roomId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_reserv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_reserv.CurrentRow == null || dataGridView_reserv.CurrentRow.Cells["ReservationId"].Value == null)
                {
                    MessageBox.Show("Veuillez sélectionner une réservation valide.",
                        "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int reservationId = Convert.ToInt32(dataGridView_reserv.CurrentRow.Cells["ReservationId"].Value);

                // Récupérer la date d'arrivée et de départ
                DateTime dateIn = Convert.ToDateTime(dataGridView_reserv.CurrentRow.Cells["CheckInDate"].Value);
                DateTime dateOut = Convert.ToDateTime(dataGridView_reserv.CurrentRow.Cells["CheckOutDate"].Value);

                // Récupérer le prix par nuit pour le type de chambre sélectionné
                int roomTypeId = Convert.ToInt32(dataGridView_reserv.CurrentRow.Cells["RoomTypeId"].Value);
                decimal pricePerNight = GetPricePerNight(roomTypeId);

                // Ouvrir le formulaire de paiement et lui passer les paramètres nécessaires
                PaymentForm paymentForm = new PaymentForm(reservationId, dateIn, dateOut, pricePerNight);
                getReservTable();
                paymentForm.Show();
                getReservTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Méthode pour récupérer le montant total à partir de la table Reservations
        private decimal GetReservationAmount(int reservationId)
        {
            string query = "SELECT TotalAmount FROM Reservations WHERE ReservationId = @ReservationId";
            DBConnect connect = new DBConnect();
            using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
            {
                // Ajouter le paramètre pour sécuriser la requête
                command.Parameters.AddWithValue("@ReservationId", reservationId);

                // Ouverture de la connexion
                connect.OpenCon();

                // Exécution de la requête et récupération du résultat
                object result = command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal totalAmount))
                {
                    return totalAmount;
                }
                else
                {
                    throw new Exception("Montant total introuvable pour cette réservation.");
                }
            }
        }

        private decimal GetPricePerNight(int roomTypeId)
        {
            string query = "SELECT PricePerNight FROM RoomTypes WHERE RoomTypeId = @RoomTypeId";
            DBConnect connect = new DBConnect();
            using (SqlCommand command = new SqlCommand(query, connect.GetConnection()))
            {
                // Ajout du paramètre pour la requête
                command.Parameters.AddWithValue("@RoomTypeId", roomTypeId);

                // Ouverture de la connexion
                connect.OpenCon();

                // Exécution de la requête et récupération du résultat
                object result = command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal pricePerNight))
                {
                    return pricePerNight;
                }
                else
                {
                    throw new Exception("Prix non trouvé pour ce type de chambre.");
                }
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
             
            SearchReservationForm searchForm = new SearchReservationForm();
            searchForm.Show();
        }
    }
    }

    

