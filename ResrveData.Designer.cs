namespace C_sharp_Project.RofidaMohamed
{
    partial class ResrveData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResrveData));
            label1 = new Label();
            PatientBox = new ComboBox();
            drBox = new ComboBox();
            dtp1 = new DateTimePicker();
            priceTextBox = new TextBox();
            StateBox = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            okbtn = new Button();
            CancelBtn = new Button();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // PatientBox
            // 
            resources.ApplyResources(PatientBox, "PatientBox");
            PatientBox.FormattingEnabled = true;
            PatientBox.Name = "PatientBox";
            // 
            // drBox
            // 
            resources.ApplyResources(drBox, "drBox");
            drBox.FormattingEnabled = true;
            drBox.Name = "drBox";
            // 
            // dtp1
            // 
            resources.ApplyResources(dtp1, "dtp1");
            dtp1.Format = DateTimePickerFormat.Time;
            dtp1.MinDate = new DateTime(2022, 1, 25, 0, 0, 0, 0);
            dtp1.Name = "dtp1";
            // 
            // priceTextBox
            // 
            resources.ApplyResources(priceTextBox, "priceTextBox");
            priceTextBox.Name = "priceTextBox";
            // 
            // StateBox
            // 
            resources.ApplyResources(StateBox, "StateBox");
            StateBox.FormattingEnabled = true;
            StateBox.Name = "StateBox";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // okbtn
            // 
            okbtn.BackColor = Color.SeaGreen;
            okbtn.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(okbtn, "okbtn");
            okbtn.ForeColor = SystemColors.ButtonHighlight;
            okbtn.Name = "okbtn";
            okbtn.UseVisualStyleBackColor = false;
            okbtn.Click += okbtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Brown;
            resources.ApplyResources(CancelBtn, "CancelBtn");
            CancelBtn.ForeColor = Color.White;
            CancelBtn.Name = "CancelBtn";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 30;
            bunifuElipse1.TargetControl = okbtn;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 30;
            bunifuElipse2.TargetControl = CancelBtn;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 50;
            bunifuElipse3.TargetControl = this;
            // 
            // ResrveData
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 234, 249);
            Controls.Add(CancelBtn);
            Controls.Add(okbtn);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(StateBox);
            Controls.Add(priceTextBox);
            Controls.Add(dtp1);
            Controls.Add(drBox);
            Controls.Add(PatientBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResrveData";
            Load += ResrveData_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox PatientBox;
        private ComboBox drBox;
        private DateTimePicker dtp1;
        private TextBox priceTextBox;
        private ComboBox StateBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button okbtn;
        private Button CancelBtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
    }
}