using System;
using System.Collections.Generic;
using System.Linq;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public class BetAnalyticService : IBetAnalyticService
    {
        private const double UnusualRate = 0.6;
        public IEnumerable<SettledBetReport> GetReport(IEnumerable<SettledBet> settledBets)
        {
            var bets = settledBets.ToList();
            var result =
                from bet in bets
                group bet by bet.CustomerId
                into betGroup
                let k =
                    new
                    {
                        CustomerId = betGroup.Key,
                        Win = betGroup.Count(x => x.Win > 0),
                        Lose = betGroup.Count(x => x.Win == 0),
                        AvgStake = betGroup.Sum(x => x.Stake) / betGroup.Count()
                    }

                select new SettledBetReport
                {
                    CustomerId = k.CustomerId,
                    IsUnusual = k.Lose == 0 && k.Win > 0 || (double) k.Win/k.Lose > UnusualRate,
                    HistoricalBets = bets.Where(x => x.CustomerId == k.CustomerId).ToList(),
                    WinRate = Math.Round((double)k.Win / k.Lose, 1),
                    AvgStake = k.AvgStake
                };

            return result;
        }
    }
}