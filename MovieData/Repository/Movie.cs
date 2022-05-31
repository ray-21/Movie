using System;
using MovieEntity;
using Microsoft.EntityFrameworkCore;
using MovieData.DataConnection;
using System.Collections.Generic;
using System.Linq;

namespace MovieData.Repository
{
	public class Movie:IMovie
	{
        MovieDbContext _movieDbContext;
		public Movie(MovieDbContext movieDbContext)
		{
            _movieDbContext = movieDbContext;

		}

        public string AddMovie(MovieModel movieModel)
        {
            String message = "";
            _movieDbContext.MovieModel.Add(movieModel);
            _movieDbContext.SaveChanges();
            message = "Movie Inserted succesfully";
            return message;
            throw new NotImplementedException();
        }

        public string DeleteMovie(int MovieId)
        {
            string message = "";
            var foundMovie = _movieDbContext.MovieModel.Find(MovieId);
            if (foundMovie != null)
            {
                _movieDbContext.MovieModel.Remove(foundMovie);
                _movieDbContext.SaveChanges();
                message = "Movie Deleted Successfully..!!";
                return message;
            }
            else
            {
                message = "Movie Deleted Successfully..!!";
                return message;
            }
            
        }

        public object SelectMovie()
        {
           List<MovieModel> movieList = _movieDbContext.MovieModel.ToList();
            return movieList;
           
        }
    }
}

