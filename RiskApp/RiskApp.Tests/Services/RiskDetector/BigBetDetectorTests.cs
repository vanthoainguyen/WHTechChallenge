using NUnit.Framework;
using RiskApp.Core.Models;
using RiskApp.Core.Services.RiskDetector;

namespace RiskApp.Tests.Services.RiskDetector
{
    [TestFixture]
    public class BigBetDetectorTests
    {
        [TestCase(999, RiskType.None)]
        [TestCase(1000, RiskType.BigBet)]
        [TestCase(1001, RiskType.BigBet)]
        public void The_method_check_should_return_BigBet_for_bet_with_towin_gt_1000(int towin, RiskType type)
        {
            var svc = new BigBetDetector(1000);
            Assert.AreEqual(type, svc.Check(new UnsettledBet { ToWin = towin }, null));
        }
    }
}
