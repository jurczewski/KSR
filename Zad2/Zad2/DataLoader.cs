using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public class DataLoader
    {
        public static void LoadData(ref List<Player> players)
        {
            var fileName = System.IO.Path.GetFullPath(@"../../../Data\ksr.mdf");
            var datasourceName = @"PIOTR\SQLEXPRESS";
            string connectionString = @"Data Source="+datasourceName+@"; AttachDbFilename =" + fileName + @";Integrated Security=True;Connect Timeout=30;User Instance=True";

            var query = "select Id,Age,Overall,Value,Wage,Height,Weight,FKAccuracy,SprintSpeed,Stamina,Strength from [data]";

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
    }
}
