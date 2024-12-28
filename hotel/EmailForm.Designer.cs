namespace hotel
{
    partial class EmailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label_address = new System.Windows.Forms.Label();
            this.label_subject = new System.Windows.Forms.Label();
            this.label_content = new System.Windows.Forms.Label();
            this.textBox_subject = new System.Windows.Forms.TextBox();
            this.richTextBox_content = new System.Windows.Forms.RichTextBox();
            this.comboBox_email = new System.Windows.Forms.ComboBox();
            this.button_dashbord = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_logout);
            this.panel1.Controls.Add(this.button_clean);
            this.panel1.Controls.Add(this.button_dashbord);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 680);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 130);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_exit);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(190, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(908, 130);
            this.panel2.TabIndex = 1;
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Snap ITC", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exit.Location = new System.Drawing.Point(829, 19);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(46, 42);
            this.label_exit.TabIndex = 16;
            this.label_exit.Text = "X";
            this.label_exit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Snap ITC", 28F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(132, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(451, 73);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sunset Hotel";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(642, 91);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 39);
            this.label8.TabIndex = 17;
            this.label8.Text = "Manage Email";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(190, 545);
            this.panel4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(908, 135);
            this.panel4.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Desktop;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 144);
            this.button1.TabIndex = 0;
            this.button1.Text = "send";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(284, 196);
            this.label_address.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(193, 26);
            this.label_address.TabIndex = 21;
            this.label_address.Text = "To email address";
            this.label_address.Click += new System.EventHandler(this.label_address_Click);
            // 
            // label_subject
            // 
            this.label_subject.AutoSize = true;
            this.label_subject.Location = new System.Drawing.Point(284, 245);
            this.label_subject.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_subject.Name = "label_subject";
            this.label_subject.Size = new System.Drawing.Size(94, 26);
            this.label_subject.TabIndex = 22;
            this.label_subject.Text = "subject";
            // 
            // label_content
            // 
            this.label_content.AutoSize = true;
            this.label_content.Location = new System.Drawing.Point(284, 291);
            this.label_content.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_content.Name = "label_content";
            this.label_content.Size = new System.Drawing.Size(102, 26);
            this.label_content.TabIndex = 23;
            this.label_content.Text = "content";
            // 
            // textBox_subject
            // 
            this.textBox_subject.Location = new System.Drawing.Point(430, 242);
            this.textBox_subject.Name = "textBox_subject";
            this.textBox_subject.Size = new System.Drawing.Size(599, 32);
            this.textBox_subject.TabIndex = 26;
            // 
            // richTextBox_content
            // 
            this.richTextBox_content.Location = new System.Drawing.Point(430, 291);
            this.richTextBox_content.Name = "richTextBox_content";
            this.richTextBox_content.Size = new System.Drawing.Size(599, 183);
            this.richTextBox_content.TabIndex = 66;
            this.richTextBox_content.Text = "";
            // 
            // comboBox_email
            // 
            this.comboBox_email.FormattingEnabled = true;
            this.comboBox_email.Location = new System.Drawing.Point(558, 193);
            this.comboBox_email.Name = "comboBox_email";
            this.comboBox_email.Size = new System.Drawing.Size(375, 34);
            this.comboBox_email.TabIndex = 68;
            this.comboBox_email.SelectedIndexChanged += new System.EventHandler(this.comboBox_email_SelectedIndexChanged);
            // 
            // button_dashbord
            // 
            this.button_dashbord.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_dashbord.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_dashbord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_dashbord.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dashbord.ForeColor = System.Drawing.SystemColors.Info;
            this.button_dashbord.Image = ((System.Drawing.Image)(resources.GetObject("button_dashbord.Image")));
            this.button_dashbord.Location = new System.Drawing.Point(0, 130);
            this.button_dashbord.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button_dashbord.Name = "button_dashbord";
            this.button_dashbord.Size = new System.Drawing.Size(190, 126);
            this.button_dashbord.TabIndex = 4;
            this.button_dashbord.Text = "retour";
            this.button_dashbord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_dashbord.UseVisualStyleBackColor = false;
            this.button_dashbord.Click += new System.EventHandler(this.button_dashbord_Click);
            // 
            // button_clean
            // 
            this.button_clean.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_clean.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_clean.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_clean.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clean.ForeColor = System.Drawing.SystemColors.Info;
            this.button_clean.Image = ((System.Drawing.Image)(resources.GetObject("button_clean.Image")));
            this.button_clean.Location = new System.Drawing.Point(0, 256);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(190, 139);
            this.button_clean.TabIndex = 4;
            this.button_clean.Text = "clean";
            this.button_clean.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_clean.UseVisualStyleBackColor = false;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // button_logout
            // 
            this.button_logout.BackColor = System.Drawing.SystemColors.InfoText;
            this.button_logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_logout.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logout.ForeColor = System.Drawing.SystemColors.Info;
            this.button_logout.Image = ((System.Drawing.Image)(resources.GetObject("button_logout.Image")));
            this.button_logout.Location = new System.Drawing.Point(0, 538);
            this.button_logout.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(190, 142);
            this.button_logout.TabIndex = 9;
            this.button_logout.Text = "logout";
            this.button_logout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_logout.UseVisualStyleBackColor = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1098, 680);
            this.Controls.Add(this.comboBox_email);
            this.Controls.Add(this.richTextBox_content);
            this.Controls.Add(this.textBox_subject);
            this.Controls.Add(this.label_content);
            this.Controls.Add(this.label_subject);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Showcard Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "EmailForm";
            this.Text = "EmailForm";
            this.Load += new System.EventHandler(this.EmailForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label_subject;
        private System.Windows.Forms.Label label_content;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_subject;
        private System.Windows.Forms.RichTextBox richTextBox_content;
        private System.Windows.Forms.ComboBox comboBox_email;
        private System.Windows.Forms.Button button_dashbord;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Button button_logout;
    }
}