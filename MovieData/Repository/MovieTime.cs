using System;
using System.Collections.Generic;
using System.Linq;
using MovieData.DataConnection;
using MovieEntity;
using MovieEntity.Models;

namespace MovieData.Repository
{
    public class MovieTime : IMovieTime
    {
        MovieDbContext _movieDbContext;

        public string AddMovieTime(ShowMovieTime movieTime)
        {
            _movieDbContext.MovieTime.Add(movieTime);
            _movieDbContext.SaveChanges();
            return "Movie Time Added Successfully...!!";
        }

        public List<ShowMovieTime> showAllMovie()
        {
            return _movieDbContext.MovieTime.ToList();
        }
    }
    }


