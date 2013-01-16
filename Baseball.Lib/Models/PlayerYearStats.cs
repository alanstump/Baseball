using Baseball.Lib.Utils;

namespace Baseball.Lib.Models
{
    public class PlayerYearStats
    {
        public Player Player { get; set; }
        public int Year { get; set; }
        public int GamesPlayed { get; set; }
        public int AtBats { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int RunsBattedIn { get; set; }
        public int Walks { get; set; }
        public int StrikeOuts { get; set; }

        public double Average
        {
            get { return PercentHelper.CalculateAverage(AtBats, Hits); }
        }

        public double OnBasePercentage
        {
            get { return PercentHelper.CalculateOnBasePercentage(AtBats, Hits, Walks); }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((PlayerYearStats) obj);
        }

        protected bool Equals(PlayerYearStats other)
        {
            return Equals(Player, other.Player) && 
                   Year == other.Year && 
                   GamesPlayed == other.GamesPlayed && 
                   AtBats == other.AtBats && 
                   Runs == other.Runs && 
                   Hits == other.Hits && 
                   Doubles == other.Doubles && 
                   Triples == other.Triples && 
                   HomeRuns == other.HomeRuns && 
                   RunsBattedIn == other.RunsBattedIn && 
                   Walks == other.Walks && 
                   StrikeOuts == other.StrikeOuts;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Player != null ? Player.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Year;
                hashCode = (hashCode * 397) ^ GamesPlayed;
                hashCode = (hashCode * 397) ^ AtBats;
                hashCode = (hashCode * 397) ^ Runs;
                hashCode = (hashCode * 397) ^ Hits;
                hashCode = (hashCode * 397) ^ Doubles;
                hashCode = (hashCode * 397) ^ Triples;
                hashCode = (hashCode * 397) ^ HomeRuns;
                hashCode = (hashCode * 397) ^ RunsBattedIn;
                hashCode = (hashCode * 397) ^ Walks;
                hashCode = (hashCode * 397) ^ StrikeOuts;
                return hashCode;
            }
        }
    }
}