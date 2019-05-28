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
            var fileName = @"C:\Users\Bartosz\Dysk Google\Studia\Komputerowe Systemy Rozpoznawania\KSR_repo\Zad2\Data\ksr.mdf";

            string connectionString = @"DataSource=.\\SQLEXPRESS; AttachDbFilename =" + fileName + @";Integrated Security=True;Connect Timeout=30;User Instance=True";

            var query = "select Id, Age, Overall from [data]";

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
                    player.Age = (int)reader["Age"];

                    players.Add(player);
                }
            }
        }
    }
}
