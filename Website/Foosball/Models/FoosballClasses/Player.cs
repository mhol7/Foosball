using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Foosball.Controllers;

namespace Foosball.Models.FoosballClasses
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Key]
        [ForeignKey("AspNetUsers")]
        public string AspNetUserId { get; set; }


        public Elo PlayerElo { get; set; }

        public int EloPoints { get { return PlayerElo.EloPoints; } }

        public void CalculateElo(int averageElo)
        {
            PlayerElo.CalculateNewElo(averageElo);
        }




    }
}
