using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace SysBD_lab3
{
    public partial class Avtoryzatsiya_Form : Form
    {
        internal Avtoryzatsiya avtoryz;
        public Avtoryzatsiya_Form()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);

        }

        private void button_regist_Click(object sender, EventArgs e)
        {
            Registration_Forms regform = new Registration_Forms();
            regform.Show();
            this.Hide();
        }

        private void button_vxid_Click(object sender, EventArgs e)
        {
            string login, password;
            login = textBoxLogin.Text;
            password = textBoxPasword.Text;

            bool allFieldsFilled = true;
            System.Windows.Forms.TextBox[] textFields = { textBoxLogin, textBoxPasword };
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
                Avtoryzatsiya avtoryz = new Avtoryzatsiya();
                avtoryz.avtorization_user(login, password);
                string role = avtoryz.GetRole();
                if (role == "administrator")
                {
                    AdminPanel_Form adminPanel = new AdminPanel_Form(avtoryz);
                    adminPanel.Show();
                    this.Hide();
                }
                else if (role == "user")
                {
                    Ordering ordering = new Ordering(avtoryz);
                    ordering.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Не всі sполя заповнені.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Avtoryzatsiya_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
