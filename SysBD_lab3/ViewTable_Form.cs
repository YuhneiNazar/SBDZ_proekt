using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SysBD_lab3
{
    public partial class ViewZamovlenya_Form : Form
    {
        private Avtoryzatsiya avtoryz;
        private string connectionString = "Host=localhost;Port=5432;Database=sto;Username=postgres;Password=56789012345";
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private NpgsqlCommandBuilder cmdBuilder;
        List<string> columnNames = new List<string>();
        public string nametab;
        public string colval1, colval2, colval3, colval4, colval5, colval6, colval7, colval8;
        public int idtab;
        private byte[] img;

        public ViewZamovlenya_Form(Avtoryzatsiya avtoryz)
        {
            InitializeComponent();
            this.avtoryz = avtoryz;
            connection = new NpgsqlConnection(connectionString);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
        }

        private void ViewZamovlenya_Form_Load(object sender, EventArgs e)
        {

            dataAdapter = new NpgsqlDataAdapter("SELECT * FROM zamovlennya", connection);
            dataTable = new DataTable();
            nametab = "zamovlennya";

            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            pictureBox7.Visible = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel_Form admpan = new AdminPanel_Form(avtoryz);
            admpan.Show();
            this.Hide();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            pictureBox7.Visible = false;
            button2.Enabled = false;
            pictureBox6.Image = null;
            if (radioButton1.Checked = true)
            {

                dataAdapter = new NpgsqlDataAdapter("SELECT * FROM zamovlennya", connection);
                dataTable = new DataTable();
                nametab = "zamovlennya";

                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            pictureBox7.Visible = true;
            button2.Enabled = true;
            if (radioButton2.Checked = true)
            {

                dataAdapter = new NpgsqlDataAdapter("SELECT id, name, posada, notes FROM pratsivnyky", connection);
                dataTable = new DataTable();
                nametab = "pratsivnyky";

                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;


                cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            button2.Enabled = false;
            pictureBox6.Image = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton4.Checked = false;
            radioButton3.Checked = true;
            if (radioButton3.Checked = true)
            {

                dataAdapter = new NpgsqlDataAdapter("SELECT kliyenty.id, kliyenty.name, kliyenty.email, kliyenty.phone, kliyenty.password, cars.marka, cars.model, cars.vin, cars.rik_vypusku FROM kliyenty JOIN cars ON kliyenty.id = cars.vlasnyk_id;", connection);
                dataTable = new DataTable();
                nametab = "kliyenty";

                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            }
        }

        private void ViewZamovlenya_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            columnNames.Clear();
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                string columnName = dataGridView1.Columns[i].HeaderText;
                columnNames.Add(columnName);
            }
            Add_table_form adtab = new Add_table_form();
            adtab.ColumnNames = columnNames;
            adtab.NameTable = nametab;
            adtab.SetLabels();
            adtab.nameoperat = "add";
            adtab.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            columnNames.Clear();
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                string columnName = dataGridView1.Columns[i].HeaderText;
                columnNames.Add(columnName);
            }
            Add_table_form adtab = new Add_table_form();
            adtab.colval1 = colval1;
            adtab.colval2 = colval2;
            adtab.colval3 = colval3;
            adtab.colval4 = colval4;
            adtab.colval5 = colval5;
            adtab.colval6 = colval6;
            adtab.colval7 = colval7;
            adtab.colval8 = colval8;
            adtab.ColumnNames = columnNames;
            adtab.NameTable = nametab;
            adtab.SetLabels();
            adtab.nameoperat = "update";
            adtab.DataUpdate();
            adtab.idtab = idtab;
            adtab.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                idtab = DBNull.Value.Equals(selectedRow.Cells["id"].Value)
                    ? 0
                    : Convert.ToInt32(selectedRow.Cells["id"].Value);
                if (nametab == "zamovlennya")
                {
                    colval1 = selectedRow.Cells["cars_id"].Value.ToString();
                    colval2 = selectedRow.Cells["posluhy_id"].Value.ToString();
                    colval3 = selectedRow.Cells["data_zamovlennya"].Value.ToString();
                    colval4 = selectedRow.Cells["chas_pryynyattya_zamovlennya"].Value.ToString();

                }
                else if (nametab == "pratsivnyky")
                {
                    colval1 = selectedRow.Cells["name"].Value.ToString();
                    colval2 = selectedRow.Cells["posada"].Value.ToString();
                    colval3 = selectedRow.Cells["notes"].Value.ToString();
                    byte[] photo = RetrievePhotoFromDatabase(idtab);
                    DisplayPhoto(photo);
                }
                else if (nametab == "kliyenty")
                {
                    colval1 = selectedRow.Cells["name"].Value.ToString();
                    colval2 = selectedRow.Cells["email"].Value.ToString();
                    colval3 = selectedRow.Cells["phone"].Value.ToString();
                    colval4 = selectedRow.Cells["password"].Value.ToString();
                    colval5 = selectedRow.Cells["marka"].Value.ToString();
                    colval6 = selectedRow.Cells["model"].Value.ToString();
                    colval7 = selectedRow.Cells["vin"].Value.ToString();
                    colval8 = selectedRow.Cells["rik_vypusku"].Value.ToString();
                } else if (nametab == "posluhy")
                {
                    colval1 = selectedRow.Cells["pratsivnyk_id"].Value.ToString();
                    colval2 = selectedRow.Cells["nazva"].Value.ToString();
                    colval3 = selectedRow.Cells["opys"].Value.ToString();
                    colval4 = selectedRow.Cells["price"].Value.ToString();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (nametab == "kliyenty")
            {
                dataAdapter = new NpgsqlDataAdapter("SELECT kliyenty.id, kliyenty.name, kliyenty.email, kliyenty.phone, kliyenty.password, cars.marka, cars.model, cars.vin, cars.rik_vypusku FROM kliyenty JOIN cars ON kliyenty.id = cars.vlasnyk_id;", connection);
                dataTable = new DataTable();
                nametab = "kliyenty";

                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            }
            else if (nametab == "pratsivnyky")
            {
                dataAdapter = new NpgsqlDataAdapter("SELECT id, name, posada, notes FROM pratsivnyky", connection);
                dataTable = new DataTable();


                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;


                cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            }
            else
            {
                string query = $"SELECT * FROM {nametab}";
                dataAdapter = new NpgsqlDataAdapter(query, connection);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int idToDelete = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    if (nametab == "kliyenty")
                    {
                        string deleteQuery2 = $"DELETE FROM cars WHERE vlasnyk_id = @id";

                        using (NpgsqlCommand deleteCommand2 = new NpgsqlCommand(deleteQuery2, connection))
                        {
                            deleteCommand2.Parameters.AddWithValue("@id", idToDelete);

                            connection.Open();
                            deleteCommand2.ExecuteNonQuery();

                            string deleteQuery = $"SELECT delete_from_table('{nametab}', @id);";

                            using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@id", idToDelete);

                                deleteCommand.ExecuteNonQuery();
                            }
                        }
                        connection.Close();
                    }
                    else
                    {
                        string deleteQuery = $"SELECT delete_from_table('{nametab}', @id);";
                        //string deleteQuery = $"DELETE FROM {nametab} WHERE id = @id";

                        using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@id", idToDelete);

                            connection.Open();
                            deleteCommand.ExecuteNonQuery();
                            connection.Close();
                        }
                    }


                    DataRow[] rowsToDelete = dataTable.Select($"id = {idToDelete}");
                    foreach (DataRow row in rowsToDelete)
                    {
                        row.Delete();
                    }
                    dataTable.AcceptChanges();
                }
                catch (Exception n)
                {
                    DialogResult rezult = MessageBox.Show(n.Message, n.Source,
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Виберіть рядок для видалення.");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                string query = "";

                if (radioButton1.Checked)
                {
                    query = $"SELECT * FROM zamovlennya WHERE CAST(id AS TEXT) LIKE '%{searchText}%'";
                }
                else if (radioButton2.Checked)
                {
                    query = $"SELECT id, name, posada, notes FROM pratsivnyky WHERE name LIKE '%{searchText}%' OR posada LIKE '%{searchText}%'";
                }
                else if (radioButton3.Checked)
                {
                    query = $"SELECT kliyenty.id, kliyenty.name, kliyenty.email, kliyenty.phone, kliyenty.password, cars.marka, cars.model, cars.vin, cars.rik_vypusku, cars.vlasnyk_id FROM kliyenty JOIN cars ON kliyenty.id = cars.vlasnyk_id WHERE (kliyenty.name LIKE '%{searchText}%' OR kliyenty.email LIKE '%{searchText}%') OR (cars.marka LIKE '%{searchText}%' OR cars.model LIKE '%{searchText}%' OR cars.vin LIKE '%{searchText}%');";
                }
                else if (radioButton4.Checked)
                {
                    query = $"SELECT * FROM posluhy WHERE CAST(pratsivnyk_id AS TEXT) LIKE '%{searchText}%' OR nazva LIKE '%{searchText}%'";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    dataAdapter = new NpgsqlDataAdapter(query, connection);
                    dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть пошуковий термін.");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "ImageFiles(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = GetPhoto(open_dialog.FileName);
                    button2.BackColor = Color.Chartreuse;
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox6.Image = Image.FromFile(open_dialog.FileName);
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (img != null && dataGridView1.SelectedRows.Count > 0)
            {
                try
                {

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int idToUpdate = Convert.ToInt32(selectedRow.Cells["id"].Value);

                    string updateQuery = "UPDATE pratsivnyky SET photo = @photo WHERE id = @id";

                    using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@photo", img);
                        updateCommand.Parameters.AddWithValue("@id", idToUpdate);

                        connection.Open();
                        updateCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                    MessageBox.Show("Фото успішно вставлено!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка вставки фотографії: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть фотографію та рядок у таблиці.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] RetrievePhotoFromDatabase(int id)
        {
            byte[] photo = null;

            try
            {
                string query = "SELECT photo FROM pratsivnyky WHERE id = @id";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("photo")))
                            {
                                photo = (byte[])reader["photo"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка отримання фото: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return photo;
        }

        private void DisplayPhoto(byte[] photo)
        {
            if (photo != null)
            {
                MemoryStream ms = new MemoryStream(photo);
                pictureBox6.Image = Image.FromStream(ms);
                pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                pictureBox6.Image = null;
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = true;
            pictureBox7.Visible = false;
            button2.Enabled = false;
            if (radioButton4.Checked = true)
            {

                dataAdapter = new NpgsqlDataAdapter("SELECT * FROM posluhy", connection);
                dataTable = new DataTable();
                nametab = "posluhy";

                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                cmdBuilder = new NpgsqlCommandBuilder(dataAdapter);
            }

        }
    }
}
