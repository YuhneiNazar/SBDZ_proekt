using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysBD_lab3
{
    public partial class Ordering : Form
    {
        private Avtoryzatsiya avtoryz;
        public Ordering(Avtoryzatsiya avtoryz)
        {
            this.avtoryz = avtoryz;
            InitializeComponent();
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            string login = avtoryz.GetLogin();
            label3.Text = login;
            avtoryz.getCarId();
            string markCar = avtoryz.CarMarka;
            string modCar = avtoryz.CarModel;
            label4.Text = markCar;
            label8.Text = modCar;
            DataTable posluhyData = avtoryz.GetPosluhyData();
            comboBox1.DisplayMember = "nazva";
            comboBox1.DataSource = posluhyData;
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now.AddDays(1).Date.Add(new TimeSpan(8, 0, 0));
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            textBox1.ReadOnly = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Ordering_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void GetidNazvPos()
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectpos = comboBox1.Text;
            string opyspos = avtoryz.GetOpsPosluhyData(selectpos);
            textBox1.Text = opyspos;
            avtoryz.SetIdPosluh(selectpos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;

            if (selectedDateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Оберіть будь-який інший день, крім неділі.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dateTimePicker1.Value = selectedDateTime.AddDays(1);
                return;
            }

            TimeSpan startTime = new TimeSpan(8, 0, 0); 
            TimeSpan endTime = new TimeSpan(17, 0, 0); 

            if (selectedDateTime.TimeOfDay < startTime || selectedDateTime.TimeOfDay > endTime)
            {
                MessageBox.Show("Оберіть час від 8:00 до 17:00.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker1.Value = selectedDateTime.Date.Add(startTime);
                return;
            }
            DateTime chaspriyzam = dateTimePicker1.Value;
            avtoryz.AddZamovlenya(chaspriyzam);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(-30);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(30);
        }
    }
}
