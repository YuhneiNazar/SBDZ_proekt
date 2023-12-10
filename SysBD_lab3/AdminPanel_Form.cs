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
    public partial class AdminPanel_Form : Form
    {
        private Avtoryzatsiya avtoryz;
        public AdminPanel_Form(Avtoryzatsiya avtoryz)
        {
            InitializeComponent();
            string login = avtoryz.GetLogin();
            label3.Text = login;
            this.avtoryz = avtoryz;
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPratsivnika_Form adpr = new AddPratsivnika_Form(avtoryz);
            adpr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewZamovlenya_Form viewzamform = new ViewZamovlenya_Form(avtoryz);
            viewzamform.Show();
            this.Hide();
        }
    }
}
