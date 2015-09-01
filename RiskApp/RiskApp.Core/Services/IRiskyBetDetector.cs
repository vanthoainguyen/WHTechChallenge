using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public interface IRiskyBetDetector
    {
        RiskType Check(UnsettledBet bet, Dictionary<int, SettledBetReport> history);
    }
}
