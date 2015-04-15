using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Foosball.Models.FoosballClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Foosball.Tests.Models.FoosballClasses
{
    [TestClass]
    public class MatchTest
    {
        Player[] GeneratePlayers(int p1ELo, int p2ELo, int p3ELo, int p4ELo)
        {
            Player[] players = new Player[4];
            int[] elos = { p1ELo, p2ELo, p3ELo, p4ELo };
            for (int i = 0; i < elos.Length; i++)
            {
                players[i] = new Player { EloPoints = elos[i], UserId = "Id" + i };
            }

            return players;
        }


        [TestMethod]
        public void TestIsConfirmedFalse()
        {
            Player[] players = GeneratePlayers(1400, 1400, 1600, 1600);
            Match m = new Match { Confirmations = new bool[4], Date = new DateTime(2011, 12, 1), Location = "Vitafit", Players = players };
            Assert.IsFalse(m.IsConfirmed);
        }

        [TestMethod]
        public void TestOneConfirmation()
        {

            Player[] players = GeneratePlayers(1400, 1400, 1600, 1600);
            Match m = new Match { Confirmations = new bool[4], Date = new DateTime(2011, 12, 1), Location = "Vitafit", Players = players };

            m.Confirm(players[1]);

            Assert.IsTrue(m.Confirmations[1]);
        }

        [TestMethod]
        public void TestAllConfirmation()
        {
            Player[] players = GeneratePlayers(1400, 1400, 1600, 1600);
            Match m = new Match { Confirmations = new[] { true, true, true, true }, Date = new DateTime(2011, 12, 1), Location = "Vitafit", Players = players };

            Assert.IsTrue(m.IsConfirmed);
        }

        [TestMethod]
        public void TestEloAlarmEqualTeamMembers()
        {

            Player[] players = GeneratePlayers(1600, 1600, 1400, 1400);
            Match m = new Match { Confirmations = new bool[4], Date = new DateTime(2011, 12, 1), Location = "Vitafit", Players = players };

            foreach (Player player in players)
            {
                m.Confirm(player);
            }
            Assert.AreEqual(1608, players[0].EloPoints);
            Assert.AreEqual(1608, players[1].EloPoints);
            Assert.AreEqual(1392, players[2].EloPoints);
            Assert.AreEqual(1392, players[3].EloPoints);
        }

        [TestMethod]
        public void TestEloAlarmEqualTeamMembersUpset()
        {

            Player[] players = GeneratePlayers(1400, 1400, 1600, 1600);
            Match m = new Match { Confirmations = new bool[4], Date = new DateTime(2011, 12, 1), Location = "Vitafit", Players = players };

            foreach (Player player in players)
            {
                m.Confirm(player);
            }
            Assert.AreEqual(1424, players[0].EloPoints);
            Assert.AreEqual(1424, players[1].EloPoints);
            Assert.AreEqual(1576, players[2].EloPoints);
            Assert.AreEqual(1576, players[3].EloPoints);
        }

        [TestMethod]
        public void TestEloAlarmDifferentTeamMembers()
        {

            Player[] players = GeneratePlayers(1800, 2200, 1500, 1700);
            Match m = new Match { Confirmations = new bool[4], Date = new DateTime(2011, 12, 1), Location = "Vitafit", Players = players };

            foreach (Player player in players)
            {
                m.Confirm(player);
            }
            Assert.AreEqual(1808, players[0].EloPoints);
            Assert.AreEqual(2201, players[1].EloPoints);
            Assert.AreEqual(1498, players[2].EloPoints);
            Assert.AreEqual(1695, players[3].EloPoints);
        }

        [TestMethod]
        public void TestEloAlarmDifferentTeamMembersUpset()
        {

            Player[] players = GeneratePlayers(1500, 1700, 1800, 2200);
            Match m = new Match { Confirmations = new bool[4], Date = new DateTime(2011, 12, 1), Location = "Vitafit", Players = players };

            foreach (Player player in players)
            {
                m.Confirm(player);
            }
            Assert.AreEqual(1530, players[0].EloPoints);
            Assert.AreEqual(1727, players[1].EloPoints);
            Assert.AreEqual(1776, players[2].EloPoints);
            Assert.AreEqual(2169, players[3].EloPoints);
        }
    }
}
