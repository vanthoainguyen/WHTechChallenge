using System;
using System.Collections.Generic;
using System.Linq;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public class UnusualBetDetector : IUnusualBetDetector
    {
        public IEnumerable<Tuple<SettledBet, bool>> FindUnusualBet(IEnumerable<SettledBet> settledBets)
        {
            return settledBets.Select(x => new Tuple<SettledBet, bool>(x, true));
        }
    }
}