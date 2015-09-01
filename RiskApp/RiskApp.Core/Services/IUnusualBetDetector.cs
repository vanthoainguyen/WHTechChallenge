using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public interface IUnusualBetDetector
    {
        IEnumerable<UnusualBetViewModel> FindUnusualBet(IEnumerable<SettledBet> settledBets);
    }
}