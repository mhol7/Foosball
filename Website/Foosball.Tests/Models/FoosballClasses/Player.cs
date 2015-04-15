using Foosball.Models.FoosballClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Foosball.Tests.Models.FoosballClasses
{
    [TestClass]
    public class PlayerTest
    {
        
        [TestMethod]
        public void TestWinLowChance()
        {
            int opponentElo = 1600;
            Player player = new Player { EloPoints = 1400 };

            Assert.AreEqual(24, player.ChanceToWin(opponentElo) * 100, 1);
        }
        [TestMethod]
        public void TestWinHighChance()
        {
            int opponentElo = 1400;
            Player player = new Player { EloPoints = 1600 };

            Assert.AreEqual(76, player.ChanceToWin(opponentElo) * 100, 1);
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

            Assert.AreEqual(1608, player.EloPoints);
        }
        [TestMethod]
        public void TestMuchEloWin()
        {
            int opponentElo = 1600;
            Player player = new Player { EloPoints = 1400 };
            player.CalculateEloWin(opponentElo);

            Assert.AreEqual(1424, player.EloPoints);
        }
        [TestMethod]
        public void TestEqualEloWin()
        {
            int opponentElo = 1400;
            Player player = new Player { EloPoints = 1400 };
            player.CalculateEloWin(opponentElo);

            Assert.AreEqual(1416, player.EloPoints);
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

            Assert.AreEqual(1576, player.EloPoints);
        }
        [TestMethod]
        public void TestEqualEloLose()
        {
            int opponentElo = 1500;
            Player player = new Player { EloPoints = 1500 };
            player.CalculateEloLose(opponentElo);

            Assert.AreEqual(1484, player.EloPoints);
        }



    }
}
