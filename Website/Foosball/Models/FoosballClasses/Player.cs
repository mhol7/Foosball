using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foosball.Models.FoosballClasses
{
    public class Player
    {
        public const int K = 32;

        public Player()
        {
        }

        public Player(string userId)
        {
            EloPoints = 1400;
            UserId = userId;
        }

        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int EloPoints { get; set; }
        public List<Match> Matches = new List<Match>();

        
        //Count declines in a row. if (count > 3) -> notify admin.
        // declinesCount, Inotify
        public int declinesCount = 0;
        public bool bann = false;
        public void BannUser(int UserId)
        {
            if (declinesCount >= 3)
            {
                //bann = cant be a part of a match ---> View assert if(bann = true) { player = inactiv }
                bann = true;
            }
        }
        


        public void CalculateEloWin(int averageElo)
        {
            EloPoints += EloChange(averageElo, true);
        }
        public void CalculateEloLose(int averageElo)
        {
            EloPoints -= EloChange(averageElo, false);
        }

        public int EloChange(int averageElo, bool isVictory)
        {
            int res = (int)Math.Round(ChanceToWin(averageElo) * K);
            return isVictory ? K - res : res;
        }

        public double ChanceToWin(int averageElo)
        {
            return 1 / (1 + Math.Pow(10.0, (averageElo - (double)EloPoints) / 400));
        }
    }

}
