namespace fubu101
{
    using System.Linq;

    using FluentValidation.Results;
    using FubuMVC.Core;
    using FubuMVC.Core.Runtime;
    using FubuMVC.Spark;

    using HtmlTags;

    using fubu101.Behaviors;
    using fubu101.Configuration;
    using fubu101.Handlers;
    using fubu101.Handlers.Movie;

    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            IncludeDiagnostics(true);

            this.ApplyConvention<ModelValidationConfiguration>();

            this.ApplyHandlerConventions<HandlersMarker>();

            HtmlConvention(x => x.Editors.Always.Modify((request, tag) =>
            {
                var fubuRequest = request.Get<IFubuRequest>();
                var validationResult = fubuRequest.Get<ValidationResult>();
                if (validationResult.IsValid) return;
                var ul = new HtmlTag("ul");
                var liTags = validationResult.Errors.Where(error => error.PropertyName == request.Accessor.InnerProperty.Name).Select(vf => new HtmlTag("li", li => li.Text(vf.ErrorMessage)));
                ul.Append(liTags);
                tag.Append(ul);
            }));

            this.UseSpark();

            Routes
                .IgnoreNamespaceText("fubu101")
                .HomeIs<GetHandler>(action => action.Execute(new MovieRequestModel()));

            Policies.EnrichCallsWith<MovieViewModelJsonBehavior>(request => request.Returns<MovieViewModel>());

            Views.TryToAttachWithDefaultConventions();
        }
    }
}