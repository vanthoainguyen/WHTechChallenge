using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RiskApp.Core.Models;
using RiskApp.Core.Services;

namespace RiskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBetService _betService;
        private readonly IBetAnalyticService _analyticService;
        private readonly IEnumerable<IRiskyBetDetector> _riskyDetectors;

        public HomeController(IBetService betService, IBetAnalyticService analyticService, IEnumerable<IRiskyBetDetector> riskyDetectors)
        {
            _betService = betService;
            _analyticService = analyticService;
            _riskyDetectors = riskyDetectors;
        }

        /// <summary>
        /// Show unusale settled bet
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = _betService.GetSettledBet();
            var unusualBets = _analyticService.GetReport(data);
            return View(unusualBets);
        }


        public ActionResult Risky()
        {
            var settledBet = _betService.GetSettledBet();
            var history = _analyticService.GetReport(settledBet).ToDictionary(x => x.CustomerId, x => x);
            var data = _betService.GetUnsettledBet();

            var result = data.Select(b => new RiskyBet(b)
            {
                RiskTypes = _riskyDetectors.Select(r => r.Check(b, history)).Distinct().ToList()
            });

            return View(result);
        }
    }
}
