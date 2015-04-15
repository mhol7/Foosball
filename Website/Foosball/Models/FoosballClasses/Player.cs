using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foosball.Models.FoosballClasses
{
    public class Player
    {
        public const int Elophant = 50;
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
            int res = (int)(ChanceToWin(averageElo) * Elophant);
            return isVictory ? Elophant - res : res;
        }

        public double ChanceToWin(int averageElo)
        {
            if (averageElo == EloPoints) return 0.5;
            double res = 1 / (1 + 10 * (
                    Math.Abs(averageElo - (double)EloPoints)) / 400);
            return MeBetter(averageElo) ? 1 - res : res;
        }

        bool MeBetter(int opponentElo)
        {
            return opponentElo < EloPoints;
        }
    }

}
