using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SysBD_lab3
{
    internal class Regestration
    {
        private string connectionString = "Host=localhost;Port=5432;Database=sto;Username=postgres;Password=56789012345";
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private NpgsqlCommandBuilder cmdBuilder;
        private string name;
        private string email;
        private string phoneNumber;
        private string password;
        private string marka;
        private string model;
        private string rik_vipys;
        private string vin;
        private bool sucesfull;

        public void SetName(string name) { this.name = name; }
        public string GetName() { return this.name; }

        public void SetEmail(string email) {  this.email = email; }
        public string GetEmail() { return this.email;}

        public void SetPhoneNumber(string phoneNumber) { this.phoneNumber = phoneNumber; }
        public string GetPhoneNumber() { return this.phoneNumber; }

        public void SetPassword(string password) {  this.password = password; }
        public string GetPassword() { return this.password; }

        public void SetMarka(string marka) { this.marka = marka; }
        public string GetMarka() { return this.marka; }

        public void SetModel(string model) {  this.model = model; }
        public string GetModel() { return this.model; }

        public void SetRikVipys(string rik_vipys) { this.rik_vipys = rik_vipys; }
        public string GetRikVipys() { return this.rik_vipys; }

        public void SetSucesfull(bool sucesfull) { this.sucesfull = sucesfull; }
        public bool GetSucesfull() { return this.sucesfull; }

        public void Registration_User(string name, string email, string phoneNumber, string password, string marka, string model, int rik_vipys, string vin)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = $"SELECT COUNT(*) FROM kliyenty WHERE name = @name OR email = @email";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@name", name);
                    checkCommand.Parameters.AddWithValue("@email", email);

                    int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("Такий користувач або email вже існують!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                int kliyentId;


                string insertQueryKliyenty = "INSERT INTO kliyenty(name, email, phone, password) VALUES (@name, @email, @phone, @password) RETURNING id";
                using (NpgsqlCommand insertCommandKliyenty = new NpgsqlCommand(insertQueryKliyenty, connection))
                {
                    insertCommandKliyenty.Parameters.AddWithValue("@name", name);
                    insertCommandKliyenty.Parameters.AddWithValue("@email", email);
                    insertCommandKliyenty.Parameters.AddWithValue("@phone", phoneNumber);
                    insertCommandKliyenty.Parameters.AddWithValue("@password", password);

                    kliyentId = Convert.ToInt32(insertCommandKliyenty.ExecuteScalar());
                   

                    string insertQueryCars = "INSERT INTO cars(marka, model, vin, rik_vypusku, vlasnyk_id) VALUES (@marka, @model, @vin, @rik_vypysku, @vlasnyk_id)";
                    using (NpgsqlCommand insertCommandCars = new NpgsqlCommand(insertQueryCars, connection))
                    {
                        insertCommandCars.Parameters.AddWithValue("@marka", marka);
                        insertCommandCars.Parameters.AddWithValue("@model", model);
                        insertCommandCars.Parameters.AddWithValue("@vin", vin);
                        insertCommandCars.Parameters.AddWithValue("@rik_vypysku", rik_vipys);
                        insertCommandCars.Parameters.AddWithValue("@vlasnyk_id", kliyentId);

                        insertCommandCars.ExecuteNonQuery();
                    }

                    MessageBox.Show("Реєстрація пройшла успішно!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetSucesfull(true);
                    
                }

                connection.Close();
            }
        }

    }





}

