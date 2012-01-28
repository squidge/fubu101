
namespace fubu101.Handlers.Movie.Add
{
    using System.Web;

    using FubuMVC.Core.Continuations;

    using Simple.Data;

    public class PostHandler
    {
        public FubuContinuation Execute(AddInputModel inputModel)
        {
            var db = Database.OpenFile(HttpContext.Current.Server.MapPath("~/App_Data/fubu101.db"));
            db.movies.Insert(title: inputModel.Title, year: inputModel.Year);

            return FubuContinuation.RedirectTo(new MovieRequestModel());
        }

    }
}