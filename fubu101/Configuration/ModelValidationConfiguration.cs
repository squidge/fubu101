namespace fubu101.Configuration
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentValidation;

    using FubuMVC.Core.Registration;
    using FubuMVC.Core.Registration.Nodes;

    using StructureMap;

    using fubu101.Behaviors;

    public class ModelValidationConfiguration : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Actions()
            .Where(x => x.HasInput && ObjectFactory.Model.HasDefaultImplementationFor(typeof(IValidator<>).MakeGenericType(x.InputType())))
            .Each(x => x.AddBefore(new Wrapper(typeof(ModelValidationBehavior<>).MakeGenericType(x.InputType()))));
        }
    }
}