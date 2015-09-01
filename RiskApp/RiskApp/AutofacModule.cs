using System.Web;
using Autofac;
using RiskApp.Core.Data;
using RiskApp.Core.Services;
using RiskApp.Core.Services.RiskDetector;

namespace RiskApp
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CsvBetService>()
                .WithParameter(new NamedParameter("basePath", HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data")))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<BetAnalyticService>()
                .AsImplementedInterfaces()
                .SingleInstance();


            builder
                .RegisterType<RiskyBetDetector>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<UnusualBetDetector>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<BigBetDetector>()
                .WithParameter(new NamedParameter("threshold", 1000))
                .AsImplementedInterfaces()
                .SingleInstance();
            
        }
    }
}