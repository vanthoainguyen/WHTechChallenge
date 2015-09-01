using System.Collections.Generic;

namespace RiskApp.Core.Models
{
    public class SettledBetReport
    {
        public int CustomerId { get; set; }
        public bool IsUnusual { get; set; }
        public List<SettledBet> HistoricalBets { get; set; }
        public double WinRate { get; set; }
        public double AvgStake { get; set; }
    }
}