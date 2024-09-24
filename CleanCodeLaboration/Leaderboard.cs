using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanCodeLaboration
{
    public class Leaderboard
    {
        public Leaderboard()
        {
        }
        public void SaveResult(string name, int nunmberOfGuesses)
        {
            StreamWriter fileOutput = new StreamWriter("result.txt", append: true);
            fileOutput.WriteLine(name + "#&#" + nunmberOfGuesses);
            fileOutput.Close();
        }
        public void ViewTopList()
        {
            StreamReader fileInput = new StreamReader("result.txt");
            List<PlayerData> players = new List<PlayerData>();
            string? line;
            while ((line = fileInput.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData playerData = new PlayerData(name, guesses);
                int position = players.IndexOf(playerData);
                if (position < 0)
                {
                    players.Add(playerData);
                }
                else
                {
                    players[position].Update(guesses);
                }
            }
            players.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData player in players)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
            }
            fileInput.Close();
        }
    }

}
