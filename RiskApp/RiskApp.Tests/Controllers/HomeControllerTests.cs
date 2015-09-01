using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using RiskApp.Controllers;
using RiskApp.Core.Models;
using RiskApp.Core.Services;

namespace RiskApp.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void The_method_Index_should_identify_unusual_rate_and_return_view()
        {
            // Arrange
            var betService = Substitute.For<IBetService>();
            var unusualBetDetector = Substitute.For<IBetAnalyticService>();
            unusualBetDetector.GetReport(Arg.Any<IEnumerable<SettledBet>>()).Returns(new List<SettledBetReport>
            {
                new SettledBetReport{CustomerId = 1, IsUnusual = true, HistoricalBets = new List<SettledBet>()},
                new SettledBetReport{CustomerId = 2, IsUnusual = false, HistoricalBets = new List<SettledBet>()},
            });
            
            var controller = new HomeController(betService, unusualBetDetector, new IRiskyBetDetector[0]);

            // Action
            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<SettledBetReport>;

            // Assert
            Assert.IsNotNull(result);
            betService.Received(1).GetSettledBet();
            Assert.AreEqual(2, model.ToList().Count);
        }

        [Test]
        public void The_method_Risky_should_identify_risky_bets_and_return_view()
        {
            // Arrange
            var betService = Substitute.For<IBetService>();
            var unusualBetDetector = Substitute.For<IBetAnalyticService>();
            var riskyBetDetector1 = Substitute.For<IRiskyBetDetector>();
            var riskyBetDetector2 = Substitute.For<IRiskyBetDetector>();
            
            unusualBetDetector.GetReport(Arg.Any<IEnumerable<SettledBet>>()).Returns(new List<SettledBetReport>
            {
                new SettledBetReport{CustomerId = 1, IsUnusual = true, AvgStake = 100},
                new SettledBetReport{CustomerId = 2, IsUnusual = false, AvgStake = 200},
            });

            betService.GetUnsettledBet().Returns(new List<UnsettledBet>
            {
                new UnsettledBet {},
                new UnsettledBet {},
                new UnsettledBet {}
            });

            var controller = new HomeController(betService, unusualBetDetector, new[] { riskyBetDetector1, riskyBetDetector2});

            // Action
            var result = controller.Risky() as ViewResult;
            var model = result.Model as IEnumerable<RiskyBet>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, model.ToList().Count);
            riskyBetDetector1.Received(3).Check(Arg.Any<UnsettledBet>(), Arg.Is<Dictionary<int, SettledBetReport>>(a => a.Count == 2));
            riskyBetDetector2.Received(3).Check(Arg.Any<UnsettledBet>(), Arg.Is<Dictionary<int, SettledBetReport>>(a => a.Count == 2));
        }
    }
}
