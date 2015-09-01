using System.Collections.Generic;
using NUnit.Framework;
using RiskApp.Core.Models;
using RiskApp.Core.Services.RiskDetector;

namespace RiskApp.Tests.Services.RiskDetector
{
    [TestFixture]
    public class RiskyBetDetectorTests
    {
        [TestCase(1, RiskType.None)]
        [TestCase(2, RiskType.None)]
        [TestCase(3, RiskType.Risky)]
        public void The_method_check_should_return_BigBet_for_bet_with_towin_gt_1000(int customerId, RiskType type)
        {
            var history = new Dictionary<int, SettledBetReport>
            {
                {2, new SettledBetReport {IsUnusual = false}},
                {3, new SettledBetReport {IsUnusual = true}}
            };
            var svc = new RiskyBetDetector();
            Assert.AreEqual(type, svc.Check(new UnsettledBet { CustomerId = customerId }, history));
        }
    }
}
