using System;
using System.Collections.Generic;
using System.Text;
using MovieEntity.Models;

namespace MovieData.Repository
{
	public interface IMovieTime
	{
		public string AddMovieTime(ShowMovieTime movieTime);

		List<ShowMovieTime> showAllMovie();
	}
}

