using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services.RiskDetector
{
    /// <summary>
    /// All upcoming (i.e. unsettled) bets from customers that win at an unusual rate should be highlighted as risky (it is up to you how this is shown)
    /// </summary>
    public class RiskyBetDetector : IRiskyBetDetector
    {
        public RiskType Check(UnsettledBet bet, Dictionary<int, SettledBetReport> history)
        {
            if (history.ContainsKey(bet.CustomerId) && history[bet.CustomerId].IsUnusual)
            {
                return RiskType.Risky;
            }
            return RiskType.None;
        }
    }
}