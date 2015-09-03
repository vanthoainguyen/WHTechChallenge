# WHTechChallenge

This is VS.NET 2012 MVC 4.0 project
Simply compile and run the web app

- Home/Index to show customers with unusual wining rate
- Home/Risk to show risky bets
- 

# Found issues:
- RiskyBetDetectorTests.cs has wrong test method name because of copy&paste
- The WebApp had to refer to RiskApp.Core.Data to register component in AutofacModule which is not good (Violate DIP) => use Autofac xml.config and remove direct dependency
- BetAnalyticService.cs missed the case when user always win, lose = 0 => Runtime error. Better add a unit test to cover that case. Cannot mark bet as risk if user only win 1, lose = 0
- UnusualBetDetector .cs: make the UnusualRate configurable instead of hardcoding as 2 constants
- Use some kind of caching for BetAnalyticService as it suppose to be the heavy load on real environment OR find the users from unsettledbet and get analytic data from those only
