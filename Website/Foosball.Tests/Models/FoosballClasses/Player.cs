using System;
using Foosball.Models.FoosballClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Foosball.Models.FoosballClasses
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestWinLowChance()
        {
            int opponentElo = 1600;
            Player player = new Player { EloPoints = 1400 };

            Assert.AreEqual(16.6, player.ChanceToWin(opponentElo) * 100, 1);
        }
        [TestMethod]
        public void TestWinHighChance()
        {
            int opponentElo = 1400;
            Player player = new Player { EloPoints = 1600 };

            Assert.AreEqual(83, player.ChanceToWin(opponentElo) * 100, 1);
        }
        [TestMethod]
        public void TestWinEqualChance()
        {
            int opponentElo = 1500;
            Player player = new Player { EloPoints = 1500 };

            Assert.AreEqual(50, player.ChanceToWin(opponentElo) * 100, 1);
        }


        [TestMethod]
        public void TestLittleEloWin()
        {
            int opponentElo = 1400;
            Player player = new Player { EloPoints = 1600 };
            player.CalculateEloWin(opponentElo);

            Assert.AreEqual(1609, player.EloPoints);
        }
        [TestMethod]
        public void TestMuchEloWin()
        {
            int opponentElo = 1600;
            Player player = new Player { EloPoints = 1400 };
            player.CalculateEloWin(opponentElo);

            Assert.AreEqual(1442, player.EloPoints);
        }
        [TestMethod]
        public void TestEqualEloWin()
        {
            int opponentElo = 1400;
            Player player = new Player { EloPoints = 1400 };
            player.CalculateEloWin(opponentElo);

            Assert.AreEqual(1425, player.EloPoints);
        }

        [TestMethod]
        public void TestLittleEloLose()
        {
            int opponentElo = 1600;
            Player player = new Player { EloPoints = 1400 };
            player.CalculateEloLose(opponentElo);

            Assert.AreEqual(1392, player.EloPoints);
        }
        [TestMethod]
        public void TestMuchEloLose()
        {
            int opponentElo = 1400;
            Player player = new Player { EloPoints = 1600 };
            player.CalculateEloLose(opponentElo);

            Assert.AreEqual(1559, player.EloPoints);
        }
        [TestMethod]
        public void TestEqualEloLose()
        {
            int opponentElo = 1500;
            Player player = new Player { EloPoints = 1500 };
            player.CalculateEloLose(opponentElo);

            Assert.AreEqual(1475, player.EloPoints);
        }



    }
}
