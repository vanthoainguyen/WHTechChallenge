using System;
using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public interface IUnusualBetDetector
    {
        IEnumerable<Tuple<SettledBet, bool>> FindUnusualBet(IEnumerable<SettledBet> settledBets);
    }
}