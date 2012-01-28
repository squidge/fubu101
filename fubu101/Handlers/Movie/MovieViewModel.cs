
namespace fubu101.Handlers.Movie
{
    using System.Collections.Generic;

    public class MovieViewModel
    {
        public IList<Movie> Movies { get; private set; }

        public MovieViewModel(dynamic movies)
        {
            Movies = new List<Movie>();
            foreach(var movie in movies)
            {
                Movies.Add(new Movie
                    {
                        Title = movie.title,
                        Year = movie.year
                    });
            }
        }
    }
}