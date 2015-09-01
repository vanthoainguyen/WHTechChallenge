using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RiskApp.Core.Data;
using RiskApp.Core.Models;
using RiskApp.Core.Services;

namespace RiskApp.Tests.Services
{
    [TestFixture]
    public class BetAnalyticServiceTests
    {
        [Test, TestCaseSource("GetTestData")]
        public void The_method_GetReport_should_identify_user_with_unusual_bet(IEnumerable<SettledBet> bets)
        {
            var svc = new BetAnalyticService();

            // Action
            var result = svc.GetReport(bets).ToList();

            // Assert
            Assert.AreEqual(6, result.Count);
            Assert.IsTrue(result[0].IsUnusual && result[0].CustomerId == 1 && result[0].AvgStake == 49.0);
            Assert.IsTrue(!result[1].IsUnusual && result[1].CustomerId == 2 && result[1].AvgStake == 12.5);
            Assert.IsTrue(!result[2].IsUnusual && result[2].CustomerId == 3 && result[2].AvgStake == 36.7);
            Assert.IsTrue(result[3].IsUnusual && result[3].CustomerId == 4 && result[3].AvgStake == 174.4);
            Assert.IsTrue(!result[4].IsUnusual && result[4].CustomerId == 5 && result[4].AvgStake == 20.7);
            Assert.IsTrue(result[5].IsUnusual && result[5].CustomerId == 6 && result[5].AvgStake == 48.0);
        }

        private IEnumerable<IEnumerable<SettledBet>> GetTestData()
        {
            var svc = new CsvBetService(Environment.CurrentDirectory);
            yield return svc.GetSettledBet();
        }
    }
}
