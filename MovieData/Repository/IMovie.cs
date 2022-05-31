using System;
using MovieEntity;
namespace MovieData.Repository
{
	public interface IMovie
	{

		string AddMovie(MovieModel movieModel);

		string DeleteMovie(int id);
		object SelectMovie();

	}
}

