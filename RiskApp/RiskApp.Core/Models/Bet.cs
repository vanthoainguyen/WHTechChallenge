namespace RiskApp.Core.Models
{
    public abstract class Bet
    {
        public int CustomerId { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
    }
}