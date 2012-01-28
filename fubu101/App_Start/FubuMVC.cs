using System.Web.Routing;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

// You can remove the reference to WebActivator by calling the Start() method from your Global.asax Application_Start
[assembly: WebActivator.PreApplicationStartMethod(typeof(fubu101.App_Start.AppStartFubuMVC), "Start", callAfterGlobalAppStart: true)]

namespace fubu101.App_Start
{
    using FluentValidation;

    using FubuMVC.Core.Continuations;

    public static class AppStartFubuMVC
    {
        public static void Start()
        {
            FubuApplication.For<ConfigureFubuMVC>()
                .StructureMapObjectFactory(container =>
                {
                    container.Scan(scanner =>
                    {
                        scanner.TheCallingAssembly();
                        scanner.WithDefaultConventions();
                        scanner.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
                    });
                    container.For<IContinuationDirector>().Use<ContinuationHandler>();
                })
                .Bootstrap();

			PackageRegistry.AssertNoFailures();
        }
    }
}