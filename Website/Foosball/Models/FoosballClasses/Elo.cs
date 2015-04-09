namespace Foosball.Models.FoosballClasses
{
    public class Elo
    {
        public int EloPoints { get; set; }

        public Elo()
        {
            EloPoints = 800;
        }

        public void CalculateNewElo(int opponentElo)
        {
            EloPoints += 1;
        }

    }
}