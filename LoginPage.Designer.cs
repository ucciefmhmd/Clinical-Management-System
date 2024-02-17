namespace C_sharp_Project
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            pictureBox3 = new PictureBox();
            txtPassword = new TextBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            label1 = new Label();
            Role = new ComboBox();
            pictureBox4 = new PictureBox();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(95, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(213, 242, 238);
            txtUsername.ForeColor = SystemColors.ControlText;
            txtUsername.Location = new Point(94, 253);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(187, 41);
            txtUsername.TabIndex = 13;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(33, 253);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 41);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(213, 242, 238);
            txtPassword.ForeColor = SystemColors.ControlText;
            txtPassword.Location = new Point(94, 332);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(187, 41);
            txtPassword.TabIndex = 15;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(33, 332);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(101, 231);
            label2.Name = "label2";
            label2.Size = new Size(87, 18);
            label2.TabIndex = 17;
            label2.Text = "UserName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(96, 314);
            label3.Name = "label3";
            label3.Size = new Size(80, 18);
            label3.TabIndex = 18;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Rockwell", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(97, 452);
            label4.Name = "label4";
            label4.Size = new Size(58, 22);
            label4.TabIndex = 19;
            label4.Text = "Reset";
            label4.Click += label4_Click;
            // 
            // bunifuThinButton21
            // 
            bunifuThinButton21.ActiveBorderThickness = 1;
            bunifuThinButton21.ActiveCornerRadius = 20;
            bunifuThinButton21.ActiveFillColor = Color.SeaGreen;
            bunifuThinButton21.ActiveForecolor = Color.White;
            bunifuThinButton21.ActiveLineColor = Color.SeaGreen;
            bunifuThinButton21.BackColor = Color.FromArgb(191, 219, 248);
            bunifuThinButton21.BackgroundImage = (Image)resources.GetObject("bunifuThinButton21.BackgroundImage");
            bunifuThinButton21.ButtonText = "Login";
            bunifuThinButton21.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bunifuThinButton21.ForeColor = Color.SeaGreen;
            bunifuThinButton21.IdleBorderThickness = 1;
            bunifuThinButton21.IdleCornerRadius = 20;
            bunifuThinButton21.IdleFillColor = Color.White;
            bunifuThinButton21.IdleForecolor = Color.SeaGreen;
            bunifuThinButton21.IdleLineColor = Color.SeaGreen;
            bunifuThinButton21.Location = new Point(94, 392);
            bunifuThinButton21.Margin = new Padding(7, 6, 7, 6);
            bunifuThinButton21.Name = "bunifuThinButton21";
            bunifuThinButton21.Size = new Size(190, 49);
            bunifuThinButton21.TabIndex = 20;
            bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
            bunifuThinButton21.Click += bunifuThinButton21_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell Extra Bold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(12, 98);
            label1.Name = "label1";
            label1.Size = new Size(325, 21);
            label1.TabIndex = 21;
            label1.Text = "Clinical Management System";
            // 
            // Role
            // 
            Role.BackColor = Color.FromArgb(213, 242, 238);
            Role.Font = new Font("Rockwell", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Role.FormattingEnabled = true;
            Role.Items.AddRange(new object[] { "Admin ", "Doctor ", "Reciptionist" });
            Role.Location = new Point(95, 175);
            Role.Name = "Role";
            Role.Size = new Size(185, 28);
            Role.TabIndex = 112;
            Role.Text = "Role";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(33, 162);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 41);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 113;
            pictureBox4.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(311, 12);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(27, 27);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 143;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(191, 219, 248);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(350, 497);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox4);
            Controls.Add(Role);
            Controls.Add(label1);
            Controls.Add(bunifuThinButton21);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox3);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login ";
            Load += LoginPage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private PictureBox pictureBox3;
        private TextBox txtPassword;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Label label1;
        private ComboBox Role;
        private PictureBox pictureBox4;
        private PictureBox pictureBox7;
    }
}
