using System;
using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public class UnusualBetDetector : IUnusualBetDetector
    {
        public IEnumerable<Tuple<SettledBet, bool>> FindUnusualBet(IEnumerable<SettledBet> settledBets)
        {
            yield break;
        }
    }
}