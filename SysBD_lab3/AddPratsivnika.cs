using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SysBD_lab3
{
    internal class AddPratsivnika
    {
        private string connectionString = "Host=localhost;Port=5432;Database=sto;Username=postgres;Password=56789012345";
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private NpgsqlCommandBuilder cmdBuilder;
        private bool sucesfull=false;
        private string bdname;
        private string bdposada;
        private string bdnotes;
        private byte[] bdimg;
        public void SetSucesfull(bool sucesfull) { this.sucesfull = sucesfull; }
        public bool GetSucesfull() { return this.sucesfull; }

        public string BdName
        {
            get { return bdname; }
            set { bdname = value; }
        }

        public string BdPosada
        {
            get { return bdposada; }
            set { bdposada = value; }
        }

        public string BdNotes
        {
            get { return bdnotes; }
            set { bdnotes = value; }
        }

        public byte[] BdImg
        {
            get { return bdimg; }
            set { bdimg = value; }
        }



        public void addPratsivnika(string name, string posada, string notes, byte[] img)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = $"SELECT COUNT(*) FROM pratsivnyky WHERE name = @name";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@name", name);

                    int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("Такий працівник вже існує!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    string insertQueryPratsivniky = "INSERT INTO pratsivnyky(name, posada, photo, notes) VALUES (@name, @posada, @photo, @notes)";
                    using (NpgsqlCommand insertCommandPratsivniky = new NpgsqlCommand(insertQueryPratsivniky, connection))
                    {
                        insertCommandPratsivniky.Parameters.AddWithValue("@name", name);
                        insertCommandPratsivniky.Parameters.AddWithValue("@posada", posada);
                        insertCommandPratsivniky.Parameters.AddWithValue("@photo", img);
                        insertCommandPratsivniky.Parameters.AddWithValue("@notes", notes);
                        insertCommandPratsivniky.ExecuteNonQuery();
                    }
                }
                catch (Exception n)
                {
                    MessageBox.Show("Помилка додавання працівника!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MessageBox.Show("Працівник успішно добавлений!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetSucesfull(true);
                }
                connection.Close();
            }
        }

        public void SearchPratsivnika(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string searchQuery = "SELECT name, posada, photo, notes FROM pratsivnyky WHERE name = @name";
                using (NpgsqlCommand searchCommand = new NpgsqlCommand(searchQuery, connection))
                {
                    searchCommand.Parameters.AddWithValue("@name", name);

                    using (NpgsqlDataReader reader = searchCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             bdname = reader["name"].ToString();
                            bdposada = reader["posada"].ToString();
                            object photoObject = reader["photo"];
                            if (photoObject != DBNull.Value)
                            {
                                byte[] bdimg = (byte[])photoObject;
                            }
                            bdnotes = reader["notes"].ToString();

                            SetSucesfull(true);
                        }
                        else
                        {
                            MessageBox.Show("Працівника не знайдено в БД!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                connection.Close();

            }
        }

    }
}
