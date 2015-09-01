using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services.RiskDetector
{
    /// <summary>
    /// All upcoming (i.e. unsettled) bets from customers that win at an unusual rate should be highlighted as risky (it is up to you how this is shown)
    /// </summary>
    public class BigBetDetector : IRiskyBetDetector
    {
        private readonly int _threshold;

        public BigBetDetector(int threshold)
        {
            _threshold = threshold;
        }

        public RiskType Check(UnsettledBet bet, Dictionary<int ,SettledBetReport> history)
        {
            if (bet.ToWin >= _threshold)
            {
                return RiskType.BigBet;
            }
            return RiskType.None;
        }
    }
}