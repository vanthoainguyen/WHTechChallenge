using Autofac;
using RiskApp.Core.Data;
using RiskApp.Core.Services;

namespace RiskApp
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CsvBetService>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<UnusualBetDetector>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}