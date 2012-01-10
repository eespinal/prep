using System.Collections.Generic;
using prep.utility;
using prep.utility.extensions;
using prep.utility.filtering;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;
    //Studio Ratings (highest to lowest)
    //MGM
    //Pixar
    //Dreamworks
    //Universal
    //Disney
    readonly Dictionary<ProductionStudio, int> studioRatings = new Dictionary<ProductionStudio, int>
    {
      {ProductionStudio.MGM, 5},
      {ProductionStudio.Pixar, 4},
      {ProductionStudio.Dreamworks, 3},
      {ProductionStudio.Universal, 2},
      {ProductionStudio.Disney, 1},
      {ProductionStudio.Paramount, 0}
    };

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public bool is_published_by_pixar(Movie movie)
    {
      return movie.production_studio == ProductionStudio.Pixar;
    }


    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      var moviesList = (List<Movie>) movies;
      moviesList.Sort((x, y) => y.title.CompareTo(x.title));
      return moviesList;
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      var moviesList = (List<Movie>) movies;
      moviesList.Sort((x, y) => y.date_published.CompareTo(x.date_published));
      return moviesList;
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      var moviesList = (List<Movie>) movies;
      moviesList.Sort((x, y) => x.title.CompareTo(y.title));
      return moviesList;
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      var moviesList = (List<Movie>) movies;
      moviesList.Sort((x, y) => x.date_published.CompareTo(y.date_published));
      return moviesList;
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      var moviesList = (List<Movie>) movies;
      moviesList.Sort((x, y) =>
      {
        var comparissonIndex = studioRatings[y.production_studio].CompareTo(studioRatings[x.production_studio]);
        if (comparissonIndex == 0)
          comparissonIndex = x.date_published.Year.CompareTo(y.date_published.Year);
        return comparissonIndex;
      });
      return moviesList;
    }
  }
}