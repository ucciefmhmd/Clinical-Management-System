namespace C_sharp_Project
{
    partial class DoctorPage
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorPage));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label10 = new Label();
            updatebtn = new Bunifu.Framework.UI.BunifuThinButton2();
            addbtn = new Bunifu.Framework.UI.BunifuThinButton2();
            deletebtn = new Bunifu.Framework.UI.BunifuThinButton2();
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            DoctorAddress = new TextBox();
            label9 = new Label();
            DoctorBirthofdate = new DateTimePicker();
            Doctorspecialation = new ComboBox();
            DoctorGender = new ComboBox();
            label8 = new Label();
            Doctorphone = new TextBox();
            label7 = new Label();
            Doctorname = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox12 = new PictureBox();
            label2 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox7 = new PictureBox();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            label11 = new Label();
            Doctorpassword = new TextBox();
            label12 = new Label();
            DoctorExperiance = new TextBox();
            searchbtn = new Bunifu.Framework.UI.BunifuThinButton2();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Rockwell", 10.2F, FontStyle.Bold);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(906, 93);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 120;
            label10.Text = "Address";
            // 
            // updatebtn
            // 
            updatebtn.ActiveBorderThickness = 1;
            updatebtn.ActiveCornerRadius = 20;
            updatebtn.ActiveFillColor = Color.SeaGreen;
            updatebtn.ActiveForecolor = Color.White;
            updatebtn.ActiveLineColor = Color.SeaGreen;
            updatebtn.BackColor = SystemColors.Control;
            updatebtn.BackgroundImage = (Image)resources.GetObject("updatebtn.BackgroundImage");
            updatebtn.ButtonText = "Update";
            updatebtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            updatebtn.ForeColor = Color.SeaGreen;
            updatebtn.IdleBorderThickness = 1;
            updatebtn.IdleCornerRadius = 20;
            updatebtn.IdleFillColor = Color.Green;
            updatebtn.IdleForecolor = Color.SeaShell;
            updatebtn.IdleLineColor = Color.SeaGreen;
            updatebtn.Location = new Point(306, 270);
            updatebtn.Margin = new Padding(6, 5, 6, 5);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(159, 56);
            updatebtn.TabIndex = 118;
            updatebtn.TextAlign = ContentAlignment.MiddleCenter;
            updatebtn.Click += updatebtn_Click;
            // 
            // addbtn
            // 
            addbtn.ActiveBorderThickness = 1;
            addbtn.ActiveCornerRadius = 20;
            addbtn.ActiveFillColor = Color.SeaGreen;
            addbtn.ActiveForecolor = Color.White;
            addbtn.ActiveLineColor = Color.SeaGreen;
            addbtn.BackColor = SystemColors.Control;
            addbtn.BackgroundImage = (Image)resources.GetObject("addbtn.BackgroundImage");
            addbtn.ButtonText = "Add";
            addbtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addbtn.ForeColor = Color.SeaGreen;
            addbtn.IdleBorderThickness = 1;
            addbtn.IdleCornerRadius = 20;
            addbtn.IdleFillColor = SystemColors.WindowText;
            addbtn.IdleForecolor = Color.SeaShell;
            addbtn.IdleLineColor = Color.SeaShell;
            addbtn.Location = new Point(523, 270);
            addbtn.Margin = new Padding(6, 5, 6, 5);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(159, 56);
            addbtn.TabIndex = 117;
            addbtn.TextAlign = ContentAlignment.MiddleCenter;
            addbtn.Click += bunifuThinButton22_Click;
            // 
            // deletebtn
            // 
            deletebtn.ActiveBorderThickness = 1;
            deletebtn.ActiveCornerRadius = 20;
            deletebtn.ActiveFillColor = Color.Brown;
            deletebtn.ActiveForecolor = Color.Snow;
            deletebtn.ActiveLineColor = Color.SeaGreen;
            deletebtn.BackColor = SystemColors.Control;
            deletebtn.BackgroundImage = (Image)resources.GetObject("deletebtn.BackgroundImage");
            deletebtn.ButtonText = "Delete";
            deletebtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deletebtn.ForeColor = Color.SeaGreen;
            deletebtn.IdleBorderThickness = 1;
            deletebtn.IdleCornerRadius = 20;
            deletebtn.IdleFillColor = Color.FromArgb(192, 0, 0);
            deletebtn.IdleForecolor = Color.Transparent;
            deletebtn.IdleLineColor = Color.Sienna;
            deletebtn.Location = new Point(743, 270);
            deletebtn.Margin = new Padding(6, 5, 6, 5);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(159, 56);
            deletebtn.TabIndex = 116;
            deletebtn.TextAlign = ContentAlignment.MiddleCenter;
            deletebtn.Click += deletebtn_Click;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 25;
            bunifuElipse2.TargetControl = this;
            // 
            // DoctorAddress
            // 
            DoctorAddress.Location = new Point(906, 116);
            DoctorAddress.Multiline = true;
            DoctorAddress.Name = "DoctorAddress";
            DoctorAddress.Size = new Size(191, 94);
            DoctorAddress.TabIndex = 119;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Rockwell", 10.2F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(297, 169);
            label9.Name = "label9";
            label9.Size = new Size(50, 20);
            label9.TabIndex = 114;
            label9.Text = "DOB";
            // 
            // DoctorBirthofdate
            // 
            DoctorBirthofdate.CalendarForeColor = SystemColors.ActiveCaption;
            DoctorBirthofdate.CalendarMonthBackground = SystemColors.HotTrack;
            DoctorBirthofdate.CalendarTitleBackColor = Color.FromArgb(28, 121, 202);
            DoctorBirthofdate.CalendarTitleForeColor = Color.Silver;
            DoctorBirthofdate.Cursor = Cursors.Hand;
            DoctorBirthofdate.Location = new Point(297, 192);
            DoctorBirthofdate.Name = "DoctorBirthofdate";
            DoctorBirthofdate.Size = new Size(143, 27);
            DoctorBirthofdate.TabIndex = 113;
            // 
            // Doctorspecialation
            // 
            Doctorspecialation.Font = new Font("Rockwell", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Doctorspecialation.FormattingEnabled = true;
            Doctorspecialation.Items.AddRange(new object[] { "Anesthesiology", "Cardiology", "Dermatology", "Emergency Medicine", "Family Medicine", "Forensic Pathology", "General Surgery", "Hospital Medicine" });
            Doctorspecialation.Location = new Point(611, 107);
            Doctorspecialation.Name = "Doctorspecialation";
            Doctorspecialation.Size = new Size(133, 28);
            Doctorspecialation.TabIndex = 112;
            Doctorspecialation.Text = "specialation";
            // 
            // DoctorGender
            // 
            DoctorGender.Font = new Font("Rockwell", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DoctorGender.FormattingEnabled = true;
            DoctorGender.Items.AddRange(new object[] { "male", "female" });
            DoctorGender.Location = new Point(457, 107);
            DoctorGender.Name = "DoctorGender";
            DoctorGender.Size = new Size(133, 28);
            DoctorGender.TabIndex = 111;
            DoctorGender.Text = "Gender";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Rockwell", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(483, 167);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 110;
            label8.Text = "Phone";
            // 
            // Doctorphone
            // 
            Doctorphone.Location = new Point(483, 185);
            Doctorphone.Multiline = true;
            Doctorphone.Name = "Doctorphone";
            Doctorphone.Size = new Size(143, 34);
            Doctorphone.TabIndex = 109;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Rockwell", 10.2F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(285, 84);
            label7.Name = "label7";
            label7.Size = new Size(121, 20);
            label7.TabIndex = 108;
            label7.Text = "Doctor Name";
            // 
            // Doctorname
            // 
            Doctorname.Location = new Point(285, 107);
            Doctorname.Multiline = true;
            Doctorname.Name = "Doctorname";
            Doctorname.Size = new Size(160, 28);
            Doctorname.TabIndex = 107;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Rockwell", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(519, 15);
            label5.Name = "label5";
            label5.Size = new Size(311, 28);
            label5.TabIndex = 106;
            label5.Text = "Clinic Managment System";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Rockwell Extra Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(104, 642);
            label6.Name = "label6";
            label6.Size = new Size(95, 24);
            label6.TabIndex = 22;
            label6.Text = "Logout";
            label6.Click += label6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(86, 253);
            label4.Name = "label4";
            label4.Size = new Size(99, 28);
            label4.TabIndex = 21;
            label4.Text = "Doctors";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(80, 343);
            label3.Name = "label3";
            label3.Size = new Size(146, 28);
            label3.TabIndex = 20;
            label3.Text = "Reservation";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(82, 429);
            label1.Name = "label1";
            label1.Size = new Size(153, 28);
            label1.TabIndex = 19;
            label1.Text = "Receptionist";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(134, 191, 243);
            panel1.Controls.Add(pictureBox12);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 700);
            panel1.TabIndex = 104;
            // 
            // pictureBox12
            // 
            pictureBox12.Cursor = Cursors.Hand;
            pictureBox12.Image = (Image)resources.GetObject("pictureBox12.Image");
            pictureBox12.Location = new Point(18, 337);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(49, 38);
            pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox12.TabIndex = 153;
            pictureBox12.TabStop = false;
            pictureBox12.Click += pictureBox12_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Rockwell", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(96, 168);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
            label2.TabIndex = 18;
            label2.Text = "Patient";
            label2.Click += label2_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(35, 635);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(62, 39);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 6;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(24, 244);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(28, 37);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 5;
            pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(18, 426);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(43, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(24, 167);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 29);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(52, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(1101, 14);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(36, 29);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 105;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 50;
            bunifuElipse1.TargetControl = this;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Rockwell", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(656, 167);
            label11.Name = "label11";
            label11.Size = new Size(91, 20);
            label11.TabIndex = 122;
            label11.Text = "Password";
            // 
            // Doctorpassword
            // 
            Doctorpassword.Location = new Point(656, 185);
            Doctorpassword.Multiline = true;
            Doctorpassword.Name = "Doctorpassword";
            Doctorpassword.Size = new Size(143, 34);
            Doctorpassword.TabIndex = 121;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Rockwell", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(757, 92);
            label12.Name = "label12";
            label12.Size = new Size(106, 20);
            label12.TabIndex = 124;
            label12.Text = "Experiance";
            // 
            // DoctorExperiance
            // 
            DoctorExperiance.Location = new Point(757, 110);
            DoctorExperiance.Multiline = true;
            DoctorExperiance.Name = "DoctorExperiance";
            DoctorExperiance.Size = new Size(143, 25);
            DoctorExperiance.TabIndex = 123;
            // 
            // searchbtn
            // 
            searchbtn.ActiveBorderThickness = 1;
            searchbtn.ActiveCornerRadius = 20;
            searchbtn.ActiveFillColor = Color.FromArgb(128, 128, 255);
            searchbtn.ActiveForecolor = Color.Snow;
            searchbtn.ActiveLineColor = Color.SeaGreen;
            searchbtn.BackColor = SystemColors.Control;
            searchbtn.BackgroundImage = (Image)resources.GetObject("searchbtn.BackgroundImage");
            searchbtn.ButtonText = "Search";
            searchbtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbtn.ForeColor = Color.SeaGreen;
            searchbtn.IdleBorderThickness = 1;
            searchbtn.IdleCornerRadius = 20;
            searchbtn.IdleFillColor = Color.Blue;
            searchbtn.IdleForecolor = Color.Transparent;
            searchbtn.IdleLineColor = Color.Sienna;
            searchbtn.Location = new Point(949, 270);
            searchbtn.Margin = new Padding(6, 5, 6, 5);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(159, 56);
            searchbtn.TabIndex = 125;
            searchbtn.TextAlign = ContentAlignment.MiddleCenter;
            searchbtn.Click += searchbtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(73, 151, 229);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(73, 151, 229);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Azure;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(272, 342);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(134, 191, 243);
            dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(134, 191, 243);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 20;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(865, 346);
            dataGridView1.TabIndex = 127;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick_1;
            // 
            // DoctorPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 700);
            Controls.Add(dataGridView1);
            Controls.Add(searchbtn);
            Controls.Add(label12);
            Controls.Add(DoctorExperiance);
            Controls.Add(label11);
            Controls.Add(Doctorpassword);
            Controls.Add(label10);
            Controls.Add(updatebtn);
            Controls.Add(addbtn);
            Controls.Add(deletebtn);
            Controls.Add(DoctorAddress);
            Controls.Add(label9);
            Controls.Add(DoctorBirthofdate);
            Controls.Add(Doctorspecialation);
            Controls.Add(DoctorGender);
            Controls.Add(label8);
            Controls.Add(Doctorphone);
            Controls.Add(label7);
            Controls.Add(Doctorname);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(pictureBox7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoctorPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoctorPage";
            Load += DoctorPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private Bunifu.Framework.UI.BunifuThinButton2 updatebtn;
        private Bunifu.Framework.UI.BunifuThinButton2 addbtn;
        private Bunifu.Framework.UI.BunifuThinButton2 deletebtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private TextBox DoctorAddress;
        private Label label9;
        private DateTimePicker DoctorBirthofdate;
        private ComboBox Doctorspecialation;
        private ComboBox DoctorGender;
        private Label label8;
        private TextBox Doctorphone;
        private Label label7;
        private TextBox Doctorname;
        private Label label5;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox7;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Label label12;
        private TextBox DoctorExperiance;
        private Label label11;
        private TextBox Doctorpassword;
        private Bunifu.Framework.UI.BunifuThinButton2 searchbtn;
        private PictureBox pictureBox12;
        private DataGridView dataGridView1;
    }
}