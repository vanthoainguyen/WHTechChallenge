using System.Collections.Generic;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public interface IBetService
    {
        IEnumerable<SettledBet> GetSettledBet();
        IEnumerable<UnsettledBet> GetUnsettledBet();
    }
}
