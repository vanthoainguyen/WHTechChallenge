using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services.RiskDetector
{
    public class UnusualBetDetector : IRiskyBetDetector
    {
        public const int HighlyUnusualRate = 30;
        public const int UnusualRate = 10;

        public RiskType Check(UnsettledBet bet, Dictionary<int, SettledBetReport> history)
        {
            if (history.ContainsKey(bet.CustomerId))
            {
                var stake = history[bet.CustomerId].AvgStake;
                
                if (bet.Stake > HighlyUnusualRate * stake)
                    return RiskType.HighlyUnusual;

                if (bet.Stake > UnusualRate * stake)
                    return RiskType.Unusual;
            }
            return RiskType.None;
        }
    }
}