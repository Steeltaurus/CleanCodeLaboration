using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration
{
    class GameController
    {
        GameLogic game;
        IUI io;
        Leaderboard leaderboard = new Leaderboard();

        string goal = String.Empty;
        int numberOfGuesses;
        string userName = String.Empty;

        public GameController(GameLogic game, IUI io)
        {
            this.game = game;
            this.io = io;
        }

        public void PlayGame()
        {
            bool gameOn = true;

            userName = io.GetUserName();

            do
            {
                numberOfGuesses = 0;
                goal = game.GenerateGoal();

                io.DisplayGreeting(goal);

                PlayRound();

                SaveToLeaderboard();

                ViewLeaderboard();
                
                gameOn = io.GetContinue();
            } while (gameOn);
            
        }
        private void PlayRound()
        {
            string guess;
            do
            {
                guess = io.GetGuess();
                numberOfGuesses++;
                io.DisplayText(game.ValidateGuess(goal, guess));

            } while (guess != goal);
        }
        private void ViewLeaderboard()
        {
            leaderboard.ViewTopList();
            io.DisplayText("Correct, it took " + numberOfGuesses + " guesses\n");
        }

        private void SaveToLeaderboard()
        {
            leaderboard.SaveResult(userName, numberOfGuesses);
        }
    }

}
