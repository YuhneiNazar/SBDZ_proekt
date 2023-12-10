namespace SysBD_lab3
{
    partial class AddPratsivnika_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPratsivnika_Form));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            label6 = new Label();
            textBox4 = new TextBox();
            button3 = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(14, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 187);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(221, 69);
            label1.Name = "label1";
            label1.Size = new Size(48, 23);
            label1.TabIndex = 1;
            label1.Text = "ПІБ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 60);
            label2.Name = "label2";
            label2.Size = new Size(60, 23);
            label2.TabIndex = 2;
            label2.Text = "Фото:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(269, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 29);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(190, 111);
            label3.Name = "label3";
            label3.Size = new Size(79, 23);
            label3.TabIndex = 4;
            label3.Text = "Посада:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(269, 105);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(166, 29);
            textBox2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(202, 150);
            label4.Name = "label4";
            label4.Size = new Size(103, 23);
            label4.TabIndex = 6;
            label4.Text = "Примітки:";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(202, 176);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(233, 111);
            textBox3.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(112, 6, 110);
            button1.FlatAppearance.BorderSize = 3;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(14, 276);
            button1.Name = "button1";
            button1.Size = new Size(170, 42);
            button1.TabIndex = 8;
            button1.Text = "Обрати фото";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(112, 6, 110);
            button2.FlatAppearance.BorderSize = 3;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(202, 293);
            button2.Name = "button2";
            button2.Size = new Size(233, 48);
            button2.TabIndex = 9;
            button2.Text = "Додати в БД";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Book Antiqua", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(37, 11);
            label5.Name = "label5";
            label5.Size = new Size(374, 32);
            label5.TabIndex = 10;
            label5.Text = "Інформація про працівника:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(5, 422);
            label6.Name = "label6";
            label6.Size = new Size(162, 23);
            label6.TabIndex = 11;
            label6.Text = " ПІБ працівника:";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(173, 422);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(262, 29);
            textBox4.TabIndex = 12;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(112, 6, 110);
            button3.FlatAppearance.BorderSize = 3;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Book Antiqua", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(173, 458);
            button3.Name = "button3";
            button3.Size = new Size(262, 52);
            button3.TabIndex = 13;
            button3.Text = "Знайти дані в БД";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(6, 57, 112);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 520);
            panel1.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 14, 27);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(pictureBox2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(444, 55);
            panel3.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Book Antiqua", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(95, 11);
            label7.Name = "label7";
            label7.Size = new Size(303, 32);
            label7.TabIndex = 10;
            label7.Text = "Додавання працівника";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(51, 45);
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 14, 27);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(0, 350);
            panel2.Name = "panel2";
            panel2.Size = new Size(448, 55);
            panel2.TabIndex = 15;
            // 
            // AddPratsivnika_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.imgbackg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(465, 540);
            Controls.Add(panel1);
            Name = "AddPratsivnika_Form";
            Text = "AddPratsivnika";
            FormClosed += AddPratsivnika_Form_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Label label5;
        private Label label6;
        private TextBox textBox4;
        private Button button3;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Panel panel3;
        private Label label7;
    }
}