using System;
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
            var unusualBetDetector = Substitute.For<IUnusualBetDetector>();
            unusualBetDetector.FindUnusualBet(Arg.Any<IEnumerable<SettledBet>>()).Returns(new List<Tuple<SettledBet, bool>>
            {
                new Tuple<SettledBet, bool>(new SettledBet(), true),
                new Tuple<SettledBet, bool>(new SettledBet(), false)
            });
            
            var controller = new HomeController(betService, unusualBetDetector);

            // Action
            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Tuple<SettledBet, bool>>;

            // Assert
            Assert.IsNotNull(result);
            betService.Received(1).GetSettledBet();
            Assert.AreEqual(2, model.ToList().Count);
        }
    }
}
