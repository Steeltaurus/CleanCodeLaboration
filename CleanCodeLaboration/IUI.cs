using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration
{
    interface IUI
    {
        public string GetGuess();
        public string GetUserName();
        public void DisplayGreeting(string? goal);
        public void DisplayText(string text);
        public bool GetContinue();
    }
}
