namespace hotel
{
    partial class GuestForm
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuestForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_slide = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_room = new System.Windows.Forms.Button();
            this.button_reception = new System.Windows.Forms.Button();
            this.button_guest = new System.Windows.Forms.Button();
            this.button_dashbord = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_clean = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_first = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_last = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_city = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView_guest = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button_search = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_guest)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Id
            // 
            this.textBox_Id.Location = new System.Drawing.Point(423, 396);
            this.textBox_Id.Name = "textBox_Id";
            this.textBox_Id.Size = new System.Drawing.Size(197, 34);
            this.textBox_Id.TabIndex = 1;
            this.textBox_Id.TextChanged += new System.EventHandler(this.textBox_Id_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Guest :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel_slide
            // 
            this.panel_slide.BackColor = System.Drawing.Color.Khaki;
            this.panel_slide.Location = new System.Drawing.Point(201, 211);
            this.panel_slide.Name = "panel_slide";
            this.panel_slide.Size = new System.Drawing.Size(15, 119);
            this.panel_slide.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_logout);
            this.panel2.Controls.Add(this.button_room);
            this.panel2.Controls.Add(this.button_reception);
            this.panel2.Controls.Add(this.button_guest);
            this.panel2.Controls.Add(this.button_dashbord);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 680);
            this.panel2.TabIndex = 14;
            // 
            // button_logout
            // 
            this.button_logout.BackColor = System.Drawing.SystemColors.InfoText;
            this.button_logout.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_logout.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logout.ForeColor = System.Drawing.SystemColors.Info;
            this.button_logout.Image = ((System.Drawing.Image)(resources.GetObject("button_logout.Image")));
            this.button_logout.Location = new System.Drawing.Point(0, 554);
            this.button_logout.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(200, 125);
            this.button_logout.TabIndex = 7;
            this.button_logout.Text = "logout";
            this.button_logout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_logout.UseVisualStyleBackColor = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // button_room
            // 
            this.button_room.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_room.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_room.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_room.ForeColor = System.Drawing.SystemColors.Info;
            this.button_room.Image = ((System.Drawing.Image)(resources.GetObject("button_room.Image")));
            this.button_room.Location = new System.Drawing.Point(0, 434);
            this.button_room.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button_room.Name = "button_room";
            this.button_room.Size = new System.Drawing.Size(200, 120);
            this.button_room.TabIndex = 6;
            this.button_room.Text = "room";
            this.button_room.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_room.UseVisualStyleBackColor = true;
            this.button_room.Click += new System.EventHandler(this.button_room_Click);
            // 
            // button_reception
            // 
            this.button_reception.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_reception.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_reception.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reception.ForeColor = System.Drawing.SystemColors.Info;
            this.button_reception.Image = ((System.Drawing.Image)(resources.GetObject("button_reception.Image")));
            this.button_reception.Location = new System.Drawing.Point(0, 318);
            this.button_reception.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button_reception.Name = "button_reception";
            this.button_reception.Size = new System.Drawing.Size(200, 116);
            this.button_reception.TabIndex = 5;
            this.button_reception.Text = "reception";
            this.button_reception.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_reception.UseVisualStyleBackColor = true;
            this.button_reception.Click += new System.EventHandler(this.button_reception_Click);
            // 
            // button_guest
            // 
            this.button_guest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_guest.BackgroundImage")));
            this.button_guest.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_guest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_guest.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_guest.ForeColor = System.Drawing.SystemColors.Info;
            this.button_guest.Image = ((System.Drawing.Image)(resources.GetObject("button_guest.Image")));
            this.button_guest.Location = new System.Drawing.Point(0, 203);
            this.button_guest.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button_guest.Name = "button_guest";
            this.button_guest.Size = new System.Drawing.Size(200, 115);
            this.button_guest.TabIndex = 3;
            this.button_guest.Text = "guest";
            this.button_guest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_guest.UseVisualStyleBackColor = true;
            this.button_guest.Click += new System.EventHandler(this.button_guest_Click);
            // 
            // button_dashbord
            // 
            this.button_dashbord.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_dashbord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_dashbord.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dashbord.ForeColor = System.Drawing.SystemColors.Info;
            this.button_dashbord.Image = ((System.Drawing.Image)(resources.GetObject("button_dashbord.Image")));
            this.button_dashbord.Location = new System.Drawing.Point(0, 100);
            this.button_dashbord.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button_dashbord.Name = "button_dashbord";
            this.button_dashbord.Size = new System.Drawing.Size(200, 103);
            this.button_dashbord.TabIndex = 2;
            this.button_dashbord.Text = "dashbord";
            this.button_dashbord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_dashbord.UseVisualStyleBackColor = true;
            this.button_dashbord.Click += new System.EventHandler(this.button_dashbord_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_search);
            this.panel1.Controls.Add(this.button_clean);
            this.panel1.Controls.Add(this.button_delete);
            this.panel1.Controls.Add(this.button_update);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(200, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 126);
            this.panel1.TabIndex = 16;
            // 
            // button_clean
            // 
            this.button_clean.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_clean.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_clean.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_clean.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clean.ForeColor = System.Drawing.SystemColors.Info;
            this.button_clean.Image = ((System.Drawing.Image)(resources.GetObject("button_clean.Image")));
            this.button_clean.Location = new System.Drawing.Point(534, 0);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(183, 126);
            this.button_clean.TabIndex = 3;
            this.button_clean.Text = "clean";
            this.button_clean.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_clean.UseVisualStyleBackColor = false;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_delete.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.SystemColors.Info;
            this.button_delete.Image = ((System.Drawing.Image)(resources.GetObject("button_delete.Image")));
            this.button_delete.Location = new System.Drawing.Point(355, 0);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(179, 126);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "delete";
            this.button_delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_update.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_update.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update.ForeColor = System.Drawing.SystemColors.Info;
            this.button_update.Image = ((System.Drawing.Image)(resources.GetObject("button_update.Image")));
            this.button_update.Location = new System.Drawing.Point(172, 0);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(183, 126);
            this.button_update.TabIndex = 1;
            this.button_update.Text = "update";
            this.button_update.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_save.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_save.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.SystemColors.Info;
            this.button_save.Image = ((System.Drawing.Image)(resources.GetObject("button_save.Image")));
            this.button_save.Location = new System.Drawing.Point(0, 0);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(172, 126);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "save";
            this.button_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 28);
            this.label2.TabIndex = 18;
            this.label2.Text = "First Name :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_first
            // 
            this.textBox_first.Location = new System.Drawing.Point(423, 446);
            this.textBox_first.Name = "textBox_first";
            this.textBox_first.Size = new System.Drawing.Size(197, 34);
            this.textBox_first.TabIndex = 17;
            this.textBox_first.TextChanged += new System.EventHandler(this.textBox_first_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "Last Name :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox_last
            // 
            this.textBox_last.Location = new System.Drawing.Point(423, 496);
            this.textBox_last.Name = "textBox_last";
            this.textBox_last.Size = new System.Drawing.Size(197, 34);
            this.textBox_last.TabIndex = 19;
            this.textBox_last.TextChanged += new System.EventHandler(this.textBox_last_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(692, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 28);
            this.label4.TabIndex = 22;
            this.label4.Text = "Phone :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_phone
            // 
            this.textBox_phone.Location = new System.Drawing.Point(808, 396);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(197, 34);
            this.textBox_phone.TabIndex = 21;
            this.textBox_phone.TextChanged += new System.EventHandler(this.textBox_phone_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(692, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 28);
            this.label5.TabIndex = 24;
            this.label5.Text = "Email :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(808, 496);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(197, 34);
            this.textBox_email.TabIndex = 23;
            this.textBox_email.TextChanged += new System.EventHandler(this.textBox_email_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 452);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 28);
            this.label6.TabIndex = 26;
            this.label6.Text = "City :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox_city
            // 
            this.textBox_city.Location = new System.Drawing.Point(808, 446);
            this.textBox_city.Name = "textBox_city";
            this.textBox_city.Size = new System.Drawing.Size(197, 34);
            this.textBox_city.TabIndex = 25;
            this.textBox_city.TextChanged += new System.EventHandler(this.textBox_city_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label_exit);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(200, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(898, 97);
            this.panel4.TabIndex = 27;
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Snap ITC", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exit.Location = new System.Drawing.Point(843, 9);
            this.label_exit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(46, 42);
            this.label_exit.TabIndex = 16;
            this.label_exit.Text = "X";
            this.label_exit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(611, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 39);
            this.label8.TabIndex = 3;
            this.label8.Text = "Manage Guest";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Snap ITC", 28F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(135, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(451, 73);
            this.label7.TabIndex = 2;
            this.label7.Text = "Sunset Hotel";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView_guest);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(200, 97);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(898, 272);
            this.panel5.TabIndex = 28;
            // 
            // dataGridView_guest
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView_guest.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_guest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_guest.ColumnHeadersHeight = 4;
            this.dataGridView_guest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_guest.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_guest.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_guest.Location = new System.Drawing.Point(22, 0);
            this.dataGridView_guest.Name = "dataGridView_guest";
            this.dataGridView_guest.RowHeadersVisible = false;
            this.dataGridView_guest.RowHeadersWidth = 62;
            this.dataGridView_guest.RowTemplate.Height = 28;
            this.dataGridView_guest.Size = new System.Drawing.Size(875, 269);
            this.dataGridView_guest.TabIndex = 30;
            this.dataGridView_guest.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_guest.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridView_guest.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView_guest.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView_guest.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView_guest.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_guest.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_guest.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView_guest.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_guest.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_guest.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView_guest.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView_guest.ThemeStyle.HeaderStyle.Height = 4;
            this.dataGridView_guest.ThemeStyle.ReadOnly = false;
            this.dataGridView_guest.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_guest.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView_guest.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_guest.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView_guest.ThemeStyle.RowsStyle.Height = 28;
            this.dataGridView_guest.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_guest.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView_guest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_guest_CellClick);
            this.dataGridView_guest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_guest_CellContentClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gold;
            this.panel6.Location = new System.Drawing.Point(0, 106);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(16, 115);
            this.panel6.TabIndex = 29;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_search.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_search.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.ForeColor = System.Drawing.SystemColors.Info;
            this.button_search.Image = ((System.Drawing.Image)(resources.GetObject("button_search.Image")));
            this.button_search.Location = new System.Drawing.Point(717, 0);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(183, 126);
            this.button_search.TabIndex = 4;
            this.button_search.Text = "search";
            this.button_search.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1098, 680);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_city);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_phone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_last);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_first);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_slide);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Id);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuestForm";
            this.Load += new System.EventHandler(this.GuestForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_guest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_slide;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Button button_room;
        private System.Windows.Forms.Button button_reception;
        private System.Windows.Forms.Button button_guest;
        private System.Windows.Forms.Button button_dashbord;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_first;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_last;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_city;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView_guest;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Button button_search;
    }
}