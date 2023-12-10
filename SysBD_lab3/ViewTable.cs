using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using NpgsqlTypes;
using System.Globalization;
using System.Reflection;

namespace SysBD_lab3
{
    internal class ViewTable
    {
        private string connectionString = "Host=localhost;Port=5432;Database=sto;Username=postgres;Password=56789012345";
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private NpgsqlCommandBuilder cmdBuilder;

        public void addData(string t1, string t2, string t3, string t4, string t5, string t6, string t7, string t8, string nametable)
        { if (nametable == "zamovlennya") {

                try
                {
                    int carid = int.Parse(t1);
                    int posid = int.Parse(t2);
                    DateTime dataZam = DateTime.Parse(t3);
                    DateTime chasPryynyattyaZam = DateTime.Parse(t4);
                    string resultMessage;

                    connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    string scanQueryZamovlenya = "SELECT scan_ins_zamov (@carsid, @posid)";
                    using (NpgsqlCommand ScanCommandZamovlenya = new NpgsqlCommand(scanQueryZamovlenya, connection))
                    {

                        ScanCommandZamovlenya.Parameters.AddWithValue("@carsid", carid);
                        ScanCommandZamovlenya.Parameters.AddWithValue("@posid", posid);

                        ScanCommandZamovlenya.ExecuteNonQuery();
                        resultMessage = (string)ScanCommandZamovlenya.ExecuteScalar();
                        if (resultMessage != "true")
                        {
                            MessageBox.Show(resultMessage, "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (resultMessage == "true")
                    {
                        string insertQueryZamovlenya = "INSERT INTO zamovlennya (cars_id, posluhy_id, data_zamovlennya, chas_pryynyattya_zamovlennya) VALUES (@carsid, @posid, @datazam, @chaszam)";

                        using (NpgsqlCommand insertCommandZamovlenya = new NpgsqlCommand(insertQueryZamovlenya, connection))
                        {

                            insertCommandZamovlenya.Parameters.AddWithValue("@carsid", carid);
                            insertCommandZamovlenya.Parameters.AddWithValue("@posid", posid);
                            insertCommandZamovlenya.Parameters.AddWithValue("@datazam", dataZam);
                            insertCommandZamovlenya.Parameters.AddWithValue("@chaszam", chasPryynyattyaZam);

                            insertCommandZamovlenya.ExecuteNonQuery();
                           
                        }
                        try
                        {
                            MessageBox.Show("Замовлення успішно добавлене!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception n)
                        {
                            MessageBox.Show("Помилка додавання замовлення!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Помилка конвертації: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                connection.Close();
            }
            if (nametable == "pratsivnyky")
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = $"SELECT COUNT(*) FROM pratsivnyky WHERE name = @name";
                    using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@name", t1);

                        int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingUserCount > 0)
                        {
                            MessageBox.Show("Такий працівник вже існує!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    try
                    {
                        //string insertQueryPratsivniky = "INSERT INTO pratsivnyky(name, posada, notes) VALUES (@name, @posada, @notes)";
                        string insertQueryPratsivniky = "SELECT insert_pratsivnyka(@name, @posada, @notes);";
                        using (NpgsqlCommand insertCommandPratsivniky = new NpgsqlCommand(insertQueryPratsivniky, connection))
                        {
                            insertCommandPratsivniky.Parameters.AddWithValue("@name", t1);
                            insertCommandPratsivniky.Parameters.AddWithValue("@posada", t2);
                            insertCommandPratsivniky.Parameters.AddWithValue("@notes", t3);

                            int newId = (int)insertCommandPratsivniky.ExecuteScalar();

                            MessageBox.Show("Ідентифікатор доданого працівника: " + newId.ToString());
                        }

                    }
                    catch (Exception n)
                    {
                        MessageBox.Show("Помилка додавання працівника!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        MessageBox.Show("Працівник успішно добавлений!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }

            if (nametable == "kliyenty")
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = $"SELECT COUNT(*) FROM kliyenty WHERE name = @name";
                    using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@name", t1);

                        int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingUserCount > 0)
                        {
                            MessageBox.Show("Такий клієнт вже існує!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    try
                    {
                        int rik_vipusk = int.Parse(t8);
                        int kliyentId;
                        string insertQueryKliyenty = "INSERT INTO kliyenty(name, email, phone, password) VALUES (@name, @email, @phone, @password) RETURNING id";
                        using (NpgsqlCommand insertCommandKliyenty = new NpgsqlCommand(insertQueryKliyenty, connection))
                        {
                            insertCommandKliyenty.Parameters.AddWithValue("@name", t1);
                            insertCommandKliyenty.Parameters.AddWithValue("@email", t2);
                            insertCommandKliyenty.Parameters.AddWithValue("@phone", t3);
                            insertCommandKliyenty.Parameters.AddWithValue("@password", t4);

                            kliyentId = Convert.ToInt32(insertCommandKliyenty.ExecuteScalar());

                            string insertQueryCars = "INSERT INTO cars(marka, model, vin, rik_vypusku, vlasnyk_id) VALUES (@marka, @model, @vin, @rik_vypysku, @vlasnyk_id)";
                            using (NpgsqlCommand insertCommandCars = new NpgsqlCommand(insertQueryCars, connection))
                            {
                                insertCommandCars.Parameters.AddWithValue("@marka", t5);
                                insertCommandCars.Parameters.AddWithValue("@model", t6);
                                insertCommandCars.Parameters.AddWithValue("@vin", t7);
                                insertCommandCars.Parameters.AddWithValue("@rik_vypysku", rik_vipusk);
                                insertCommandCars.Parameters.AddWithValue("@vlasnyk_id", kliyentId);

                                insertCommandCars.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Клієнт успішно добавлений!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка додавання клієнта: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            if (nametable == "posluhy")
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = $"SELECT COUNT(*) FROM posluhy WHERE nazva = @name";
                    using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@name", t2);

                        int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingUserCount > 0)
                        {
                            MessageBox.Show("Така послуга вже існує!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    try
                    {
                        int idprat = Convert.ToInt32(t1);
                        decimal price = Convert.ToDecimal(t4);
                        string insertQueryPratsivniky = "INSERT INTO posluhy(pratsivnyk_id, nazva, opys, price) VALUES (@pratid, @nazva, @opys, @price)";
                        using (NpgsqlCommand insertCommandPratsivniky = new NpgsqlCommand(insertQueryPratsivniky, connection))
                        {
                            insertCommandPratsivniky.Parameters.AddWithValue("@pratid", idprat);
                            insertCommandPratsivniky.Parameters.AddWithValue("@nazva", t2);
                            insertCommandPratsivniky.Parameters.AddWithValue("@opys", t3);
                            insertCommandPratsivniky.Parameters.AddWithValue("@price", price);
                            insertCommandPratsivniky.ExecuteNonQuery();
                        }

                    }
                    catch (Exception n)
                    {
                        MessageBox.Show("Помилка додавання послуги!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        MessageBox.Show("Послуга успішно добавлена!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
        }

        public void UpdateData(string t1, string t2, string t3, string t4, string t5, string t6, string t7, string t8, string nametable, int idtab)
        {    
            if (nametable == "zamovlennya")
            {
                try
                {
                    int carid = int.Parse(t1);
                    int posid = int.Parse(t2);
                    DateTime dataZam = DateTime.Parse(t3);
                    DateTime chasPryynyattyaZam = DateTime.Parse(t4);

                    connection = new NpgsqlConnection(connectionString);
                    connection.Open();

                    string updateQueryZamovlennya = "UPDATE zamovlennya SET cars_id = @carsid, posluhy_id = @posid, data_zamovlennya = @datazam, chas_pryynyattya_zamovlennya = @chaszam WHERE id = @zamovlennyaId";

                    using (NpgsqlCommand updateCommandZamovlennya = new NpgsqlCommand(updateQueryZamovlennya, connection))
                    {
                        updateCommandZamovlennya.Parameters.AddWithValue("@zamovlennyaId", idtab);
                        updateCommandZamovlennya.Parameters.AddWithValue("@carsid", carid);
                        updateCommandZamovlennya.Parameters.AddWithValue("@posid", posid);
                        updateCommandZamovlennya.Parameters.AddWithValue("@datazam", dataZam);
                        updateCommandZamovlennya.Parameters.AddWithValue("@chaszam", chasPryynyattyaZam);

                        updateCommandZamovlennya.ExecuteNonQuery();
                    }
                    try
                    {
                        MessageBox.Show("Замовлення успішно оновлене!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception n)
                    {
                        MessageBox.Show("Помилка оновлення замовлення!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Помилка конвертації: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                connection.Close();
            }
            if (nametable == "pratsivnyky")
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string updateQueryPratsivnyky = "UPDATE pratsivnyky SET name = @name, posada = @posada, notes = @notes WHERE id = @pratsivnykId";

                using (NpgsqlCommand updateCommandPratsivnyky = new NpgsqlCommand(updateQueryPratsivnyky, connection))
                {
                    updateCommandPratsivnyky.Parameters.AddWithValue("@pratsivnykId", idtab);
                    updateCommandPratsivnyky.Parameters.AddWithValue("@name", t1); 
                    updateCommandPratsivnyky.Parameters.AddWithValue("@posada", t2);
                    updateCommandPratsivnyky.Parameters.AddWithValue("@notes", t3); 

                    updateCommandPratsivnyky.ExecuteNonQuery();
                }

                try
                {
                    MessageBox.Show("Працівник успішно оновлений!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception n)
                {
                    MessageBox.Show("Помилка оновлення працівника!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
            }
            if (nametable == "kliyenty")
            {
                try
                {
                    connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string updateQueryKliyenty = "UPDATE kliyenty SET name = @name, email = @email, phone = @phone, password = @password WHERE id = @kliyentId";

                using (NpgsqlCommand updateCommandKliyenty = new NpgsqlCommand(updateQueryKliyenty, connection))
                {
                    updateCommandKliyenty.Parameters.AddWithValue("@kliyentId", idtab);
                    updateCommandKliyenty.Parameters.AddWithValue("@name", t1);
                    updateCommandKliyenty.Parameters.AddWithValue("@email", t2);
                    updateCommandKliyenty.Parameters.AddWithValue("@phone", t3);
                    updateCommandKliyenty.Parameters.AddWithValue("@password", t4);

                    updateCommandKliyenty.ExecuteNonQuery();

                        string updateQueryCars = "UPDATE cars SET marka = @marka, model = @model, vin = @vin, rik_vypusku = @rik_vypusku WHERE vlasnyk_id = @id";

                        using (NpgsqlCommand updateCommandCars = new NpgsqlCommand(updateQueryCars, connection))
                        {
                            int rik_vipusk = int.Parse(t8);
                            updateCommandCars.Parameters.AddWithValue("@id", idtab);
                            updateCommandCars.Parameters.AddWithValue("@marka", t5);
                            updateCommandCars.Parameters.AddWithValue("@model", t6);
                            updateCommandCars.Parameters.AddWithValue("@vin", t7);
                            updateCommandCars.Parameters.AddWithValue("@rik_vypusku", rik_vipusk);

                            updateCommandCars.ExecuteNonQuery();
                        }

                    }
                    
                    MessageBox.Show("Клієнт успішно оновлений!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка онолвення клієнта: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
            }
            if (nametable == "posluhy")
            {
                try
                {
                    connection = new NpgsqlConnection(connectionString);
                    connection.Open();

                    string updateQueryPosluhy = "UPDATE posluhy SET pratsivnyk_id = @pratsivnykId, nazva = @nazva, opys = @opys, price = @price WHERE id = @poslugaId";

                    using (NpgsqlCommand updateCommandPosluhy = new NpgsqlCommand(updateQueryPosluhy, connection))
                    {
                        int pratsivnykId = int.Parse(t1);
                        decimal price = decimal.Parse(t4);

                        updateCommandPosluhy.Parameters.AddWithValue("@poslugaId", idtab);
                        updateCommandPosluhy.Parameters.AddWithValue("@pratsivnykId", pratsivnykId);
                        updateCommandPosluhy.Parameters.AddWithValue("@nazva", t2);
                        updateCommandPosluhy.Parameters.AddWithValue("@opys", t3);
                        updateCommandPosluhy.Parameters.AddWithValue("@price", price);

                        updateCommandPosluhy.ExecuteNonQuery();
                    }

                    MessageBox.Show("Послуга успішно оновлена!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка оновлення послуги: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
            }

        }


    }
}
