using System;
using MovieData.Repository;
using MovieEntity;

namespace MovieBusiness.Services
{
	public class MovieServices
	{
		IMovie movie;
		public MovieServices(IMovie movie)
		{
			this.movie = movie;
		}

        public string AddMovie(MovieModel movieModel)
        {
            return movie.AddMovie(movieModel);
        }

        public object SelectMovie()
        {
            return movie.SelectMovie();
        }

        public string DeleteMovie(int id)
        {
            return movie.DeleteMovie(id);
        }





    }

}

