using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodeLaboration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Tests
{
    [TestClass()]
    public class GameLogicTests
    {
        GameLogic gameLogic;
        string goal;

        [TestInitialize] 
        public void Init() 
        {
            GameLogic gameLogic = new GameLogic();
            goal = gameLogic.GenerateGoal();
        }

        [TestMethod()]
        public void GenerateGoalLengthTest()
        {
            Assert.AreEqual(4, goal.Length);
        }

        [TestMethod()]
        public void GenerateGoalUniqueNumbersTest()
        {
            Assert.IsTrue(goal.Distinct().Count() == goal.Length);
        }

        [TestMethod()]
        public void ValidateGuessAllWrongTest()
        {
            GameLogic gameLogic = new GameLogic();

            string validateGoal = "1234";
            string validateGuess = "5678";

            Assert.AreEqual(",\n", gameLogic.ValidateGuess(validateGoal, validateGuess));
        }

        [TestMethod()]
        public void ValidateGuessAllCorrectTest()
        {
            GameLogic gameLogic = new GameLogic();

            string validateGoal = "1234";
            string validateGuess = "1234";

            Assert.AreEqual("BBBB,\n", gameLogic.ValidateGuess(validateGoal, validateGuess));
        }

        [TestMethod()]
        public void ValidateGuessAllWrongLoacationTest()
        {
            GameLogic gameLogic = new GameLogic();

            string validateGoal = "1234";
            string validateGuess = "2341";

            Assert.AreEqual(",CCCC\n", gameLogic.ValidateGuess(validateGoal, validateGuess));
        }

        [TestMethod()]
        public void ValidateGuessMixWrongRightLoacationTest()
        {
            GameLogic gameLogic = new GameLogic();

            string validateGoal = "1234";
            string validateGuess = "2134";

            Assert.AreEqual("BB,CC\n", gameLogic.ValidateGuess(validateGoal, validateGuess));
        }
    }
}