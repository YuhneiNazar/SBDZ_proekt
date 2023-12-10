using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SysBD_lab3
{
    public partial class Add_table_form : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=sto;Username=postgres;Password=56789012345";
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private NpgsqlCommandBuilder cmdBuilder;
        public List<string> ColumnNames { get; set; }
        public string NameTable { get; set; }
        public string colval1 { get; set; }
        public string colval2 { get; set; }
        public string colval3 { get; set; }
        public string colval4 { get; set; }
        public string colval5 { get; set; }
        public string colval6 { get; set; }
        public string colval7 { get; set; }
        public string colval8 { get; set; }
        public string nameoperat { get; set; }
        public int idtab { get; set; }


        public Add_table_form()
        {
            InitializeComponent();

        }

        public void SetLabels()
        {
            int countcolum = ColumnNames.Count();

            if (ColumnNames != null && ColumnNames.Count > 0)
            {
                // Встановлення значень для Label на основі списку назв
                for (int i = 0; i < ColumnNames.Count; i++)
                {
                    Label label = new Label();
                    label.Text = ColumnNames[i];
                    label.Location = new Point(10, 30 * i); // Змініть координати за потребою
                    this.Controls.Add(label);
                }
            }
            if (countcolum < 7)
            {
                textBox8.Visible = false;
                textBox7.Visible = false;
                textBox6.Visible = false;
                textBox5.Visible = false;

            }
            if (countcolum < 4)
            {
                textBox8.Visible = false;
                textBox7.Visible = false;
                textBox6.Visible = false;
                textBox5.Visible = false;
                textBox4.Visible = false;

            }

        }

        public void DataUpdate()
        {
            textBox1.Text = colval1;
            textBox2.Text = colval2;
            textBox3.Text = colval3;
            textBox4.Text = colval4;
            textBox5.Text = colval5;
            textBox6.Text = colval6;
            textBox7.Text = colval7;
            textBox8.Text = colval8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ScanTextBox())
            {
                string t1, t2, t3, t4, t5, t6, t7,t8;
                t1 = textBox1.Text;
                t2 = textBox2.Text;
                t3 = textBox3.Text;
                t4 = textBox4.Text;
                t5 = textBox5.Text;
                t6 = textBox6.Text;
                t7 = textBox7.Text;
                t8 = textBox8.Text;
                ViewTable viewtab = new ViewTable();
                viewtab.addData(t1, t2, t3, t4, t5, t6, t7, t8, NameTable);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ScanTextBox())
            {
                string t1, t2, t3, t4, t5, t6, t7,t8;
                t1 = textBox1.Text;
                t2 = textBox2.Text;
                t3 = textBox3.Text;
                t4 = textBox4.Text;
                t5 = textBox5.Text;
                t6 = textBox6.Text;
                t7 = textBox7.Text;
                t8 = textBox8.Text;
                ViewTable viewtab = new ViewTable();
                viewtab.UpdateData(t1, t2, t3, t4, t5, t6, t7, t8, NameTable, idtab);
            }
        }

        public bool ScanTextBox()
        {
            if (NameTable == "zamovlennya")
            {
                TextBox[] textBoxesToCheck = { textBox1, textBox2, textBox3, textBox4 };
                foreach (TextBox textBox in textBoxesToCheck)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("Будь ласка, заповніть всі TextBox.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else if (NameTable == "pratsivnyky")
            {
                TextBox[] textBoxesToCheck = { textBox1, textBox2, textBox3 };
                foreach (TextBox textBox in textBoxesToCheck)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("Будь ласка, заповніть всі TextBox.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else if (NameTable == "kliyenty")
            {
                TextBox[] textBoxesToCheck = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
                foreach (TextBox textBox in textBoxesToCheck)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("Будь ласка, заповніть всі TextBox.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void Add_table_form_Load(object sender, EventArgs e)
        {
            if (nameoperat == "add")
            {
                button1.Visible = true;
                button2.Visible = false;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = true;
            }
        }
    }
}
