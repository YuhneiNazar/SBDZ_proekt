namespace SysBD_lab3
{
    partial class Avtoryzatsiya_Form
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxLogin = new TextBox();
            textBoxPasword = new TextBox();
            button_vxid = new Button();
            button_regest = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(56, 11);
            label1.Name = "label1";
            label1.Size = new Size(231, 42);
            label1.TabIndex = 0;
            label1.Text = "Авторизація";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Book Antiqua", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(53, 85);
            label2.Name = "label2";
            label2.Size = new Size(71, 26);
            label2.TabIndex = 1;
            label2.Text = "Логін:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Book Antiqua", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(33, 139);
            label3.Name = "label3";
            label3.Size = new Size(91, 26);
            label3.TabIndex = 2;
            label3.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLogin.Location = new Point(121, 85);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(189, 29);
            textBoxLogin.TabIndex = 3;
            // 
            // textBoxPasword
            // 
            textBoxPasword.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPasword.Location = new Point(121, 139);
            textBoxPasword.Name = "textBoxPasword";
            textBoxPasword.Size = new Size(189, 29);
            textBoxPasword.TabIndex = 4;
            // 
            // button_vxid
            // 
            button_vxid.BackColor = Color.FromArgb(6, 112, 8);
            button_vxid.FlatAppearance.BorderColor = Color.White;
            button_vxid.FlatAppearance.BorderSize = 3;
            button_vxid.FlatStyle = FlatStyle.Flat;
            button_vxid.Font = new Font("Book Antiqua", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_vxid.ForeColor = Color.White;
            button_vxid.Location = new Point(0, 200);
            button_vxid.Name = "button_vxid";
            button_vxid.Size = new Size(335, 51);
            button_vxid.TabIndex = 5;
            button_vxid.Text = "Вхід";
            button_vxid.UseVisualStyleBackColor = false;
            button_vxid.Click += button_vxid_Click;
            // 
            // button_regest
            // 
            button_regest.BackColor = Color.FromArgb(112, 61, 6);
            button_regest.Dock = DockStyle.Bottom;
            button_regest.FlatAppearance.BorderColor = Color.White;
            button_regest.FlatAppearance.BorderSize = 3;
            button_regest.FlatStyle = FlatStyle.Flat;
            button_regest.Font = new Font("Book Antiqua", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_regest.ForeColor = Color.White;
            button_regest.Location = new Point(0, 248);
            button_regest.Name = "button_regest";
            button_regest.Size = new Size(335, 54);
            button_regest.TabIndex = 6;
            button_regest.Text = "Реєстрація";
            button_regest.UseVisualStyleBackColor = false;
            button_regest.Click += button_regist_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(6, 57, 112);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button_regest);
            panel1.Controls.Add(button_vxid);
            panel1.Controls.Add(textBoxLogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBoxPasword);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(10, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(339, 306);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 14, 27);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(335, 63);
            panel2.TabIndex = 7;
            // 
            // Avtoryzatsiya_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fon_sto1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(375, 354);
            Controls.Add(panel1);
            Name = "Avtoryzatsiya_Form";
            Text = "Авторизація";
            FormClosed += Avtoryzatsiya_Form_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxLogin;
        private TextBox textBoxPasword;
        private Button button_vxid;
        private Button button_regest;
        private Panel panel1;
        private Panel panel2;
    }
}