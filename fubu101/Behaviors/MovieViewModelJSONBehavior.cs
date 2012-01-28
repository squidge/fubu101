namespace fubu101.Behaviors
{
    using FubuCore.Binding;

    using FubuMVC.Core;
    using FubuMVC.Core.Behaviors;
    using FubuMVC.Core.Runtime;

    using HtmlTags;

    using fubu101.Handlers.Movie;

    public class MovieViewModelJsonBehavior : BasicBehavior
    {
        private readonly IFubuRequest request;

        private readonly IRequestData requestData;

        private readonly IOutputWriter writer;

        public MovieViewModelJsonBehavior(IOutputWriter writer, IFubuRequest request, IRequestData requestData)
            : base(PartialBehavior.Executes)
        {
            this.writer = writer;
            this.request = request;
            this.requestData = requestData;
        }

        protected override DoNext performInvoke()
        {
            if (this.requestData.IsAjaxRequest())
            {
                var output = this.request.Get<MovieViewModel>();
                var rawJsonOutput = JsonUtil.ToJson(output);
                this.writer.Write(MimeType.Json.ToString(), rawJsonOutput);
                return DoNext.Stop;
            }

            return DoNext.Continue;
        }
    }
}