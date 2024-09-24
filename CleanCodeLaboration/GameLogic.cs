using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration
{
    public class GameLogic
    {
        const int GOAL_LENGTH = 4;
        const int MAX_INTERVAL = 10;

        public string GenerateGoal()
        {
            string randomDigit;

            Random randomGenerator = new Random();
            string goal = String.Empty;
            for (int i = 0; i < GOAL_LENGTH; i++)
            {
                do randomDigit = randomGenerator.Next(MAX_INTERVAL).ToString();
                while (goal.Contains(randomDigit));

                goal = goal + randomDigit;
            }
            return goal;
        }

        public string ValidateGuess(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += AppendSpaces();     // if player entered less than 4 chars

            for (int i = 0; i < GOAL_LENGTH; i++)
            {
                if (goal[i] == guess[i])
                {
                    bulls++;
                }
                else if (goal.Contains(guess[i]))
                {
                    cows++;
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows) + "\n";
        }

        private string AppendSpaces()
        {
            string spaces = String.Empty;
            for (int i = 0; i < GOAL_LENGTH; i++)
            {
                spaces += " ";
            }
            return spaces;
        }
    }

}