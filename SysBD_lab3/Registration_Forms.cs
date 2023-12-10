using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace SysBD_lab3
{
    public partial class Registration_Forms : Form
    {
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private NpgsqlCommandBuilder cmdBuilder;
        public Registration_Forms()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);

        }

        private void Regestration_button_Click(object sender, EventArgs e)
        {
            string name, email, phoneNumber, password, marka, model,vin;
            int rik_vipys = 0;
            name = textBox1.Text;
            email = textBox2.Text;
            phoneNumber = textBox3.Text;
            password = textBox4.Text;
            marka = textBox5.Text;
            model = textBox6.Text;
            vin = textBox8.Text;


            bool allFieldsFilled = true;

            System.Windows.Forms.TextBox[] textFields = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            foreach (TextBox field in textFields)
            {
                if (string.IsNullOrEmpty(field.Text))
                {
                    allFieldsFilled = false;
                    break;
                }
            }
            if (allFieldsFilled)
            {
                try
                {
                    rik_vipys = int.Parse(textBox7.Text);

                }
                catch (FormatException)
                {
                    MessageBox.Show("Невірний формат року випуску. Введіть ціле число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Regestration reguser = new Regestration();
                reguser.Registration_User(name, email, phoneNumber, password, marka, model, rik_vipys, vin);
                bool sucesfull = reguser.GetSucesfull();
                if (sucesfull)
                {
                    Avtoryzatsiya_Form avtor = new Avtoryzatsiya_Form();
                    avtor.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Не всі поля заповнені.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Registration_Forms_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Avtoryzatsiya_Form avtor = new Avtoryzatsiya_Form();
            avtor.Show();
            this.Hide();
        }
    }
}
