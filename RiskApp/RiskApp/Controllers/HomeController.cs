using System.Web.Mvc;
using RiskApp.Core.Services;

namespace RiskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBetService _betService;
        private readonly IUnusualBetDetector _betDetector;

        public HomeController(IBetService betService, IUnusualBetDetector betDetector)
        {
            _betService = betService;
            _betDetector = betDetector;
        }

        /// <summary>
        /// Show unusale settled bet
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = _betService.GetSettledBet();
            var unusualBets = _betDetector.FindUnusualBet(data);
            return View(unusualBets);
        }
    }
}
