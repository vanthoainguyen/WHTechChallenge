using System.Collections.Generic;
using RiskApp.Core.Models;
using RiskApp.Core.Services;

namespace RiskApp.Core.Data
{
    public class CsvBetService : IBetService
    {
        public IEnumerable<SettledBet> GetSettledBet()
        {
            yield break;
        }

        public IEnumerable<UnsettledBet> GetUnsettledBetBet()
        {
            yield break;
        }
    }
}
