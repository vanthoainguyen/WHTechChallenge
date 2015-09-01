using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public interface IBetAnalyticService
    {
        IEnumerable<SettledBetReport> GetReport(IEnumerable<SettledBet> settledBets);
    }
}