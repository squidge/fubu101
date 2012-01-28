
namespace fubu101.Handlers.Movie
{
    using System.Web;

    using Simple.Data;

    public class GetHandler
    {
        public MovieViewModel Execute(MovieRequestModel requestModel)
        {
            var db = Database.OpenFile(HttpContext.Current.Server.MapPath("~/App_Data/fubu101.db"));
            var movies = db.movies.All();

            return new MovieViewModel(movies);
        }
    }
}