using System;
using System.Web;
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
                .WithParameter(new NamedParameter("basePath", HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data")))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<UnusualBetDetector>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}