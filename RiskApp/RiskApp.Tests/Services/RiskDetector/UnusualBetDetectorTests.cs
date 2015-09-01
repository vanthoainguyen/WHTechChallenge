using System.Collections.Generic;
using NUnit.Framework;
using RiskApp.Core.Models;
using RiskApp.Core.Services.RiskDetector;

namespace RiskApp.Tests.Services.RiskDetector
{
    [TestFixture]
    public class UnusualBetDetectorTests
    {
        [TestCase(1, 1000, RiskType.None)]
        [TestCase(2, 9, RiskType.None)]
        [TestCase(2, 10, RiskType.None)]
        [TestCase(2, 11, RiskType.Unusual)]
        [TestCase(2, 30, RiskType.Unusual)]
        [TestCase(2, 31, RiskType.HighlyUnusual)]
        [TestCase(2, 99, RiskType.HighlyUnusual)]
        public void The_method_check_should_return_RiskType_by_stake(int customerId, int stake, RiskType type)
        {
            var history = new Dictionary<int, SettledBetReport>
            {
                {2, new SettledBetReport {AvgStake = 1}},
            };
            var svc = new UnusualBetDetector();
            Assert.AreEqual(type, svc.Check(new UnsettledBet { CustomerId = customerId, Stake = stake }, history));
        }
    }
}
