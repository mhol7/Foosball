﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace Foosball.Models.FoosballClasses
{
    public class Match
    {
        public int MatchId { get; set; }

        [Required]
        public string Location;

        [Required]
        public DateTime Date;

        [Required]
        public Player[] Players;

        [Required]
        public bool[] Confirmations;

        public bool IsConfirmed { get { return !Confirmations.Select(x => false).Any(); } }

        public void EloAlarm()
        {
            if (!IsConfirmed) return;

            int team1Elo = 0;

            int team2Elo = 0;

            for (int i = 0; i < Players.Length / 2; i++)
            {
                team1Elo += Players[i].EloPoints / 2;
                team2Elo += Players[Players.Length - i - 1].EloPoints / 2;
            }
            for (int i = 0; i < Players.Length / 2; i++)
            {
                Players[i].CalculateEloWin(team2Elo);
                Players[Players.Length - i - 1].CalculateEloLose(team1Elo);
            }
        }
    }
}