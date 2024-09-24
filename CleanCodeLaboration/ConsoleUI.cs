using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CleanCodeLaboration
{
    public class ConsoleUI : IUI
    {
        public void DisplayGreeting(string? goal = null)
        {
            Console.WriteLine("New game:\n");
            if (goal != null)
            {
                Console.WriteLine("For practice, number is: " + goal + "\n");
            }
        }
        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
        public bool GetContinue() 
        {
            Console.WriteLine("Continue? (y/n)");
            return Console.ReadLine().Equals("y") ? true : false;
        }

        public string GetGuess()
        {
            Console.WriteLine("Make your guess: ");
            return Console.ReadLine();
        }

        public string GetUserName()
        {
            Console.WriteLine("Enter your user name: ");
            return Console.ReadLine();
        }
    }

}
