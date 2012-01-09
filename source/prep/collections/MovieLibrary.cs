using System;
using System.Collections.Generic;

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
        foreach (var movie in movies)
        {
            yield return movie;
        }
    }

    public void add(Movie movie)
    {
        if (movies.Contains(movie)) return;
        movies.Add(movie);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
        var moviesList = (List<Movie>) movies;
        moviesList.Sort((x, y) => y.title.CompareTo(x.title));
        return moviesList;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        var moviesList = (List<Movie>)movies;
        return moviesList.FindAll((x) => x.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        var moviesList = (List<Movie>)movies;
        return moviesList.FindAll((x) => x.production_studio == ProductionStudio.Pixar || x.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
        var moviesList = (List<Movie>)movies;
        moviesList.Sort((x, y) => x.title.CompareTo(y.title));
        return moviesList;
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
        var moviesList = (List<Movie>)movies;
        moviesList.Sort((x, y) =>
        {
            var comparissonIndex = studioRatings[y.production_studio].CompareTo(studioRatings[x.production_studio]);
            if (comparissonIndex == 0)
                comparissonIndex = x.date_published.Year.CompareTo(y.date_published.Year);
            return comparissonIndex;
        });
        return moviesList;
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
        var moviesList = (List<Movie>)movies;
        return moviesList.FindAll(x => x.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
        var moviesList = (List<Movie>)movies;
        return moviesList.FindAll(x => x.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
        var moviesList = (List<Movie>)movies;
        return moviesList.FindAll(x => startingYear <= x.date_published.Year && x.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
        var moviesList = (List<Movie>)movies;
        return moviesList.FindAll(x => x.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
        var moviesList = (List<Movie>)movies;
        return moviesList.FindAll(x => x.genre == Genre.action);
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
        var moviesList = (List<Movie>)movies;
        moviesList.Sort((x, y) => y.date_published.CompareTo(x.date_published));
        return moviesList;
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
        var moviesList = (List<Movie>)movies;
        moviesList.Sort((x, y) => x.date_published.CompareTo(y.date_published));
        return moviesList;
    }
  }
}