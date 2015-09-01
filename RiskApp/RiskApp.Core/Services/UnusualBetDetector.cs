using System;
using System.Collections.Generic;
using System.Linq;
using RiskApp.Core.Models;

namespace RiskApp.Core.Services
{
    public class UnusualBetDetector : IUnusualBetDetector
    {
        private const double UnusualRate = 0.6;
        public IEnumerable<UnusualBetViewModel> FindUnusualBet(IEnumerable<SettledBet> settledBets)
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
                        Lose = betGroup.Count(x => x.Win == 0)
                    }

                select new UnusualBetViewModel
                {
                    CustomerId = k.CustomerId,
                    IsUnusual = k.Lose == 0 && k.Win > 0 || (double) k.Win/k.Lose > UnusualRate,
                    HistoricalBets = bets.Where(x => x.CustomerId == k.CustomerId).ToList(),
                    WinRate = Math.Round((double)k.Win / k.Lose, 1)
                };

            return result;
        }
    }
}