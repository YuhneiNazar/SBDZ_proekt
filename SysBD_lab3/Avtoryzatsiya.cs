using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace SysBD_lab3
{
    public class Avtoryzatsiya
    {
        private string connectionString = "Host=localhost;Port=5432;Database=sto;Username=postgres;Password=56789012345";
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private NpgsqlCommandBuilder cmdBuilder;
        private string login;
        private string password;
        private string role;
        private int usercarid;
        private string markacar;
        private string modelcar;
        private int poslugid;
        private DateTime currentDate = DateTime.Now;

        public string GetRole() { return this.role; }
        public string GetLogin () { return this.login; }
        public void SetLogin(string login) { this.login = login; }

        public int CarID
        {
            get { return usercarid; }
            set { usercarid = value; }
        }

        public string CarMarka
        {
            get { return markacar; }
            set { markacar = value; }
        }

        public string CarModel
        {
            get { return modelcar; }
            set { modelcar = value; }
        }

        public int PoslugID
        {
            get { return poslugid; }
            set { poslugid = value; }
        }


        public string PasswordUser
        {
            get { return password; }
            set { password = value; }
        }


        public void avtorization_user(string login, string password)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                SetLogin(login);
                PasswordUser = password;
                connection.Open();
                string checkQueradmin = $"SELECT * FROM admins WHERE email = @email AND password = @password";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQueradmin, connection))
                {
                    checkCommand.Parameters.AddWithValue("@email", login);
                    checkCommand.Parameters.AddWithValue("@password", password);

                    int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingUserCount == 0)
                    {
                        string checkQuerkliyent = $"SELECT * FROM kliyenty WHERE email = @email AND password = @password";
                        using (NpgsqlCommand checkCommand2 = new NpgsqlCommand(checkQuerkliyent, connection))
                        {
                            checkCommand2.Parameters.AddWithValue("@email", login);
                            checkCommand2.Parameters.AddWithValue("@password", password);

                            int existingUserCount2 = Convert.ToInt32(checkCommand2.ExecuteScalar());

                            if (existingUserCount2 == 0)
                            {   
                                MessageBox.Show("Такий користувач неіснує або неправильний пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                connection.Close();
                                return;
                            }
                            else
                            {
                               
                                
                                this.role = "user";
                            }
                        }
                    }
                    else
                    {   
                        
                        this.role = "administrator";
                        
                    }
                }
                
            }

        }

        public void getCarId()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string login, password;
                login = GetLogin();
                password = PasswordUser;
                string checkQuerkliyent = $"SELECT id FROM kliyenty WHERE email = @email AND password = @password";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuerkliyent, connection))
                {
                    checkCommand.Parameters.AddWithValue("@email", login);
                    checkCommand.Parameters.AddWithValue("@password", password);

                    int iduser = Convert.ToInt32(checkCommand.ExecuteScalar());

                    string checkQueryCars = "SELECT id FROM cars WHERE vlasnyk_id = @idkliyenta";
                    using (NpgsqlCommand checkCommandCars = new NpgsqlCommand(checkQueryCars, connection))
                    {
                        checkCommandCars.Parameters.AddWithValue("@idkliyenta", iduser);
                        int idcar = Convert.ToInt32(checkCommandCars.ExecuteScalar());
                        CarID = idcar;
                    }


                    string markaQueryCars = "SELECT marka, model FROM cars WHERE id = @idcars";
                    using (NpgsqlCommand CommandCars2 = new NpgsqlCommand(markaQueryCars, connection))
                    {
                        CommandCars2.Parameters.AddWithValue("@idcars", CarID);

                        using (NpgsqlDataReader reader = CommandCars2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CarMarka = reader["marka"].ToString();
                                CarModel = reader["model"].ToString();
                            }
                        }
                    }

                }
                connection.Close();
            }
        }



        public DataTable GetPosluhyData()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nazva FROM posluhy";
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public string GetOpsPosluhyData(string nazvapos)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT opys FROM posluhy WHERE nazva = @nazvapos";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nazvapos", nazvapos);

                    object result = command.ExecuteScalar();

                    return result != null ? result.ToString() : null;
                }

            }
        }

        public void SetIdPosluh(string nazvapos)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id FROM posluhy WHERE nazva = @nazvapos";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nazvapos", nazvapos);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        PoslugID = Convert.ToInt32(result);
                    }
                    else
                    {
                       PoslugID = 0;
                    }
                }
            }
        }

        public void AddZamovlenya(DateTime chasprynatyazam)
        {
            try
            {
                int carid = CarID;
                int posid = PoslugID;
                DateTime dataZam = currentDate;
                DateTime chasPryynyattyaZam = chasprynatyazam;

                connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string timeConflictQuery = "SELECT COUNT(*) FROM zamovlennya WHERE chas_pryynyattya_zamovlennya = @chaszam";
                using (NpgsqlCommand timeConflictCommand = new NpgsqlCommand(timeConflictQuery, connection))
                {
                    timeConflictCommand.Parameters.AddWithValue("@chaszam", chasPryynyattyaZam);

                    int count = Convert.ToInt32(timeConflictCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Помилка замовлення! Конфлікт часу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string existingOrderQuery = "SELECT COUNT(*) FROM zamovlennya WHERE cars_id = @carsid AND posluhy_id = @posid";
                using (NpgsqlCommand existingOrderCommand = new NpgsqlCommand(existingOrderQuery, connection))
                {
                    existingOrderCommand.Parameters.AddWithValue("@carsid", carid);
                    existingOrderCommand.Parameters.AddWithValue("@posid", posid);

                    int count = Convert.ToInt32(existingOrderCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Помилка замовлення! Замовлення з цим автомобілем та послугою вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string insertQueryZamovlenya = "INSERT INTO zamovlennya (cars_id, posluhy_id, data_zamovlennya, chas_pryynyattya_zamovlennya) VALUES (@carsid, @posid, @datazam, @chaszam)";

                using (NpgsqlCommand insertCommandZamovlenya = new NpgsqlCommand(insertQueryZamovlenya, connection))
                {
                    insertCommandZamovlenya.Parameters.AddWithValue("@carsid", carid);
                    insertCommandZamovlenya.Parameters.AddWithValue("@posid", posid);
                    insertCommandZamovlenya.Parameters.AddWithValue("@datazam", dataZam);
                    insertCommandZamovlenya.Parameters.AddWithValue("@chaszam", chasPryynyattyaZam);

                    insertCommandZamovlenya.ExecuteNonQuery();

                    MessageBox.Show("Замовлення успішно добавлене!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Помилка додавання замовлення!" + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
