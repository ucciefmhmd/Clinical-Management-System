namespace C_sharp_Project.RofidaMohamed
{
    partial class ReservationRel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationRel));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            editbtn = new Bunifu.Framework.UI.BunifuThinButton2();
            addbtn = new Bunifu.Framework.UI.BunifuThinButton2();
            delbtn = new Bunifu.Framework.UI.BunifuThinButton2();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dataGridView1 = new DataGridView();
            searchbtn = new Button();
            searchBox = new TextBox();
            dtpSearch = new DateTimePicker();
            label3 = new Label();
            SelSearchbox = new ComboBox();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox11 = new PictureBox();
            panel1 = new Panel();
            pictureBox12 = new PictureBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox10 = new PictureBox();
            bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            SuspendLayout();
            // 
            // editbtn
            // 
            editbtn.ActiveBorderThickness = 1;
            editbtn.ActiveCornerRadius = 20;
            editbtn.ActiveFillColor = Color.SeaGreen;
            editbtn.ActiveForecolor = Color.White;
            editbtn.ActiveLineColor = Color.SeaGreen;
            editbtn.BackColor = Color.FromArgb(224, 234, 249);
            editbtn.BackgroundImage = (Image)resources.GetObject("editbtn.BackgroundImage");
            editbtn.ButtonText = "Update";
            editbtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editbtn.ForeColor = Color.SeaGreen;
            editbtn.IdleBorderThickness = 1;
            editbtn.IdleCornerRadius = 20;
            editbtn.IdleFillColor = Color.Green;
            editbtn.IdleForecolor = Color.SeaShell;
            editbtn.IdleLineColor = Color.SeaGreen;
            editbtn.Location = new Point(724, 626);
            editbtn.Margin = new Padding(6, 5, 6, 5);
            editbtn.Name = "editbtn";
            editbtn.Size = new Size(159, 56);
            editbtn.TabIndex = 118;
            editbtn.TextAlign = ContentAlignment.MiddleCenter;
            editbtn.Click += editbtn_Click;
            // 
            // addbtn
            // 
            addbtn.ActiveBorderThickness = 1;
            addbtn.ActiveCornerRadius = 20;
            addbtn.ActiveFillColor = Color.SeaGreen;
            addbtn.ActiveForecolor = Color.White;
            addbtn.ActiveLineColor = Color.SeaGreen;
            addbtn.BackColor = Color.FromArgb(224, 234, 249);
            addbtn.BackgroundImage = (Image)resources.GetObject("addbtn.BackgroundImage");
            addbtn.ButtonText = "Add";
            addbtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addbtn.ForeColor = Color.SeaGreen;
            addbtn.IdleBorderThickness = 1;
            addbtn.IdleCornerRadius = 20;
            addbtn.IdleFillColor = SystemColors.WindowText;
            addbtn.IdleForecolor = Color.SeaShell;
            addbtn.IdleLineColor = Color.SeaShell;
            addbtn.Location = new Point(265, 126);
            addbtn.Margin = new Padding(6, 5, 6, 5);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(159, 56);
            addbtn.TabIndex = 117;
            addbtn.TextAlign = ContentAlignment.MiddleCenter;
            addbtn.Click += addbtn_Click;
            // 
            // delbtn
            // 
            delbtn.ActiveBorderThickness = 1;
            delbtn.ActiveCornerRadius = 20;
            delbtn.ActiveFillColor = Color.Brown;
            delbtn.ActiveForecolor = Color.Snow;
            delbtn.ActiveLineColor = Color.SeaGreen;
            delbtn.BackColor = Color.FromArgb(224, 234, 249);
            delbtn.BackgroundImage = (Image)resources.GetObject("delbtn.BackgroundImage");
            delbtn.ButtonText = "Delete";
            delbtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delbtn.ForeColor = Color.SeaGreen;
            delbtn.IdleBorderThickness = 1;
            delbtn.IdleCornerRadius = 20;
            delbtn.IdleFillColor = Color.FromArgb(192, 0, 0);
            delbtn.IdleForecolor = Color.Transparent;
            delbtn.IdleLineColor = Color.Sienna;
            delbtn.Location = new Point(929, 626);
            delbtn.Margin = new Padding(6, 5, 6, 5);
            delbtn.Name = "delbtn";
            delbtn.Size = new Size(159, 56);
            delbtn.TabIndex = 116;
            delbtn.TextAlign = ContentAlignment.MiddleCenter;
            delbtn.Click += delbtn_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(1070, 12);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(35, 40);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 111;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(-182, 732);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(62, 39);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 110;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(-193, 341);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(28, 37);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 109;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(-197, 434);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(37, 38);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 108;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(-199, 523);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(43, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 107;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-193, 264);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 29);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 106;
            pictureBox2.TabStop = false;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
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
            dataGridView1.Location = new Point(265, 314);
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
            dataGridView1.Size = new Size(840, 304);
            dataGridView1.TabIndex = 126;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // searchbtn
            // 
            searchbtn.Image = (Image)resources.GetObject("searchbtn.Image");
            searchbtn.Location = new Point(1070, 164);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(35, 35);
            searchbtn.TabIndex = 127;
            searchbtn.UseVisualStyleBackColor = true;
            searchbtn.Click += searchbtn_Click;
            // 
            // searchBox
            // 
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.Font = new Font("Segoe UI", 12F);
            searchBox.Location = new Point(778, 124);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(286, 34);
            searchBox.TabIndex = 128;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // dtpSearch
            // 
            dtpSearch.Font = new Font("Segoe UI", 10F);
            dtpSearch.Format = DateTimePickerFormat.Short;
            dtpSearch.Location = new Point(778, 169);
            dtpSearch.MinDate = new DateTime(2018, 6, 20, 0, 0, 0, 0);
            dtpSearch.Name = "dtpSearch";
            dtpSearch.ShowUpDown = true;
            dtpSearch.Size = new Size(286, 30);
            dtpSearch.TabIndex = 129;
            dtpSearch.Value = new DateTime(2024, 2, 13, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.System;
            label3.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(282, 40);
            label3.Name = "label3";
            label3.Size = new Size(192, 38);
            label3.TabIndex = 130;
            label3.Text = "Reservations :";
            // 
            // SelSearchbox
            // 
            SelSearchbox.Font = new Font("Segoe UI", 11F);
            SelSearchbox.FormattingEnabled = true;
            SelSearchbox.Location = new Point(602, 124);
            SelSearchbox.Name = "SelSearchbox";
            SelSearchbox.Size = new Size(151, 33);
            SelSearchbox.TabIndex = 131;
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(49, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(27, 627);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(62, 39);
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox11.TabIndex = 27;
            pictureBox11.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(134, 191, 243);
            panel1.Controls.Add(pictureBox12);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pictureBox8);
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(pictureBox10);
            panel1.Controls.Add(pictureBox11);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 696);
            panel1.TabIndex = 104;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox12
            // 
            pictureBox12.Cursor = Cursors.Hand;
            pictureBox12.Image = (Image)resources.GetObject("pictureBox12.Image");
            pictureBox12.Location = new Point(20, 371);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(49, 38);
            pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox12.TabIndex = 160;
            pictureBox12.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(89, 284);
            label4.Name = "label4";
            label4.Size = new Size(99, 28);
            label4.TabIndex = 159;
            label4.Text = "Doctors";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(83, 374);
            label1.Name = "label1";
            label1.Size = new Size(146, 28);
            label1.TabIndex = 158;
            label1.Text = "Reservation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(78, 460);
            label2.Name = "label2";
            label2.Size = new Size(153, 28);
            label2.TabIndex = 157;
            label2.Text = "Receptionist";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Cursor = Cursors.Hand;
            label5.Font = new Font("Rockwell", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(99, 199);
            label5.Name = "label5";
            label5.Size = new Size(91, 28);
            label5.TabIndex = 156;
            label5.Text = "Patient";
            label5.Click += label5_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.Cursor = Cursors.Hand;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(27, 275);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(28, 37);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 155;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Cursor = Cursors.Hand;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(21, 457);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(39, 41);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 154;
            pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Cursor = Cursors.Hand;
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(27, 198);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(43, 29);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 153;
            pictureBox10.TabStop = false;
            // 
            // bunifuThinButton21
            // 
            bunifuThinButton21.ActiveBorderThickness = 1;
            bunifuThinButton21.ActiveCornerRadius = 20;
            bunifuThinButton21.ActiveFillColor = Color.SeaGreen;
            bunifuThinButton21.ActiveForecolor = Color.White;
            bunifuThinButton21.ActiveLineColor = Color.SeaGreen;
            bunifuThinButton21.BackColor = Color.FromArgb(224, 234, 249);
            bunifuThinButton21.BackgroundImage = (Image)resources.GetObject("bunifuThinButton21.BackgroundImage");
            bunifuThinButton21.ButtonText = "Today";
            bunifuThinButton21.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bunifuThinButton21.ForeColor = Color.SeaGreen;
            bunifuThinButton21.IdleBorderThickness = 1;
            bunifuThinButton21.IdleCornerRadius = 20;
            bunifuThinButton21.IdleFillColor = SystemColors.WindowText;
            bunifuThinButton21.IdleForecolor = Color.SeaShell;
            bunifuThinButton21.IdleLineColor = Color.SeaShell;
            bunifuThinButton21.Location = new Point(946, 213);
            bunifuThinButton21.Margin = new Padding(6, 5, 6, 5);
            bunifuThinButton21.Name = "bunifuThinButton21";
            bunifuThinButton21.Size = new Size(159, 56);
            bunifuThinButton21.TabIndex = 132;
            bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
            bunifuThinButton21.Click += bunifuThinButton21_Click;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 70;
            bunifuElipse1.TargetControl = this;
            // 
            // ReservationRel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 234, 249);
            ClientSize = new Size(1127, 696);
            Controls.Add(bunifuThinButton21);
            Controls.Add(SelSearchbox);
            Controls.Add(label3);
            Controls.Add(dtpSearch);
            Controls.Add(searchBox);
            Controls.Add(searchbtn);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(editbtn);
            Controls.Add(pictureBox4);
            Controls.Add(addbtn);
            Controls.Add(pictureBox3);
            Controls.Add(delbtn);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReservationRel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReservationPage";
            Activated += ReservationRel_Activated;
            Load += ReservationRel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Bunifu.Framework.UI.BunifuThinButton2 editbtn;
        private Bunifu.Framework.UI.BunifuThinButton2 addbtn;
        private Bunifu.Framework.UI.BunifuThinButton2 delbtn;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView dataGridView1;
        private Button searchbtn;
        private TextBox searchBox;
        private DateTimePicker dtpSearch;
        private Label label3;
        private ComboBox SelSearchbox;
        private Label label6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox11;
        private Panel panel1;
        private PictureBox pictureBox12;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label5;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}