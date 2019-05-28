using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad2;

namespace TUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            DataLoader.LoadData(ref players);
            Console.WriteLine(players.Count);
            Console.WriteLine(players[0].Id);
            Console.WriteLine(players[0].Age);
            Console.WriteLine(players[0].Value);

            Console.ReadKey();
        }
    }
}
