using System;
using System.IO;
using System.Collections.Generic;
using CleanCodeLaboration;

namespace MooGame
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            IUI ui = new ConsoleUI();
            GameLogic gameLogic = new GameLogic();
            GameController gameController = new GameController(gameLogic, ui);

            gameController.PlayGame();

        }
    }
}