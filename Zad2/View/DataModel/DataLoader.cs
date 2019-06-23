using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Zad2
{
    public class DataLoader
    {
        public static void LoadDataFromDB(ref List<Player> players)
        {
            var connectionString = @"Server=.\SQLExpress;Integrated Security=true;Initial Catalog=ksr;";

            var query = "SELECT Id, Age, Overall, Value, Wage, Height, Weight, FKAccuracy, SprintSpeed, Stamina, Strength FROM [data]";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(query, connection);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Player player = new Player();
                    
                    player.Id = (int)reader["Id"];
                    player.Age = decimal.ToInt16((decimal)reader["Age"]);
                    player.Overall = decimal.ToInt16((decimal)reader["Overall"]);
                    player.Value = decimal.ToDouble((decimal)reader["Value"]);
                    player.Wage = decimal.ToDouble((decimal)reader["Wage"]);
                    player.Height = decimal.ToInt16((decimal)reader["Height"]);
                    player.Weight = decimal.ToInt16((decimal)reader["Weight"]);
                    player.Fk_accuracy = decimal.ToInt16((decimal)reader["FKAccuracy"]);
                    player.Sprint_speed = decimal.ToInt16((decimal)reader["SprintSpeed"]);
                    player.Stamina = decimal.ToInt16((decimal)reader["Stamina"]);
                    player.Strength = decimal.ToInt16((decimal)reader["Strength"]);

                    players.Add(player);
                }
            }
        }

        public static void LoadDataFromCSV(ref List<Player> players)
        {
            using (var reader = new StreamReader(@"C:\Users\Bartosz\Dysk Google\Studia\Komputerowe Systemy Rozpoznawania\KSR_repo\Zad2\Data\data_only11_new.txt", true))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');

                    Player player = new Player();

                    player.Id = int.Parse(values[0]);
                    player.Age = int.Parse(values[1]);
                    player.Overall = int.Parse(values[2]);
                    player.Value = double.Parse(values[3]);
                    player.Wage = double.Parse(values[4]);
                    player.Height = int.Parse(values[5]);
                    player.Weight = int.Parse(values[6]);
                    player.Fk_accuracy = int.Parse(values[7]);
                    player.Sprint_speed = int.Parse(values[8]);
                    player.Stamina = int.Parse(values[9]);
                    player.Strength = int.Parse(values[10]);

                    var str = player.ToString();

                    players.Add(player);
                }
            }
        }
    }
}
