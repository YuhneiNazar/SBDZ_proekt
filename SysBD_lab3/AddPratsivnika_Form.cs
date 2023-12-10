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
    public partial class AddPratsivnika_Form : Form
    {
        private Avtoryzatsiya avtoryz;
        private byte[] img;
        public AddPratsivnika_Form(Avtoryzatsiya avtoryz)
        {
            InitializeComponent();
            this.avtoryz = avtoryz;
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "ImageFiles(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = GetPhoto(open_dialog.FileName);
                    button1.BackColor = Color.Chartreuse;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox1.Image = Image.FromFile(open_dialog.FileName);
                }
                catch (Exception n)
                {
                    DialogResult rezult = MessageBox.Show(n.Message, n.Source,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public static byte[] GetPhoto(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open,
            FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] photo = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return photo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name, posada, notes;

            name = textBox1.Text;
            posada = textBox2.Text;
            notes = textBox3.Text;

            bool allFieldsFilled = true;
            System.Windows.Forms.TextBox[] textFields = { textBox1, textBox2, textBox3 };
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
                AddPratsivnika addPrat = new AddPratsivnika();
                addPrat.addPratsivnika(name, posada, notes, img);
                bool sucesfull = addPrat.GetSucesfull();
                if (sucesfull)
                {
                    button2.BackColor = Color.Chartreuse;
                }
            }
            else
            {
                MessageBox.Show("Не всі поля заповнені.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name;
            string bdname, bdposada, bdnotes;
            byte[] bdimgs;

            name = textBox4.Text;

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Ви не ввели ПІБ працівника.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddPratsivnika addPrat = new AddPratsivnika();
                addPrat.SearchPratsivnika(name);

                bool sucesfull = addPrat.GetSucesfull();

                if (sucesfull)
                {
                    bdname = addPrat.BdName;
                    bdposada = addPrat.BdPosada;
                    bdnotes = addPrat.BdNotes;
                    bdimgs = addPrat.BdImg;

                    textBox1.Text = bdname;
                    textBox2.Text = bdposada;
                    textBox3.Text = bdnotes;
                    if (bdimgs != null && bdimgs.Length > 0) {
                        using (MemoryStream ms = new MemoryStream(bdimgs))
                        {
                            Bitmap image = new Bitmap(ms);
                            pictureBox1.Image = image;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void AddPratsivnika_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminPanel_Form admpan = new AdminPanel_Form(avtoryz);
            admpan.Show();
            this.Hide();
        }
    }
}
