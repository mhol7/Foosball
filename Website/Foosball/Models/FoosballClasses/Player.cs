using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foosball.Models.FoosballClasses
{
    public class Player
    {
        public const int Elophant = 32;
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
            int res = (int)Math.Round(ChanceToWin(averageElo) * Elophant);
            return isVictory ? Elophant - res : res;
        }

        public double ChanceToWin(int averageElo)
        {
            return 1 / (1 + Math.Pow(10.0, (averageElo - (double)EloPoints) / 400));
           
        }

        bool MeBetter(int opponentElo)
        {
            return opponentElo < EloPoints;
        }
    }

}
