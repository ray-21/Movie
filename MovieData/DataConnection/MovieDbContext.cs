using System;
using Microsoft.EntityFrameworkCore;
using MovieEntity;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MovieEntity.Models;

namespace MovieData.DataConnection
{
	public class MovieDbContext:DbContext
	{ 

        public MovieDbContext(DbContextOptions<MovieDbContext>options) : base(options)
		{
		}

		public DbSet<UserModel>UserModel { get; set; }
		public DbSet<MovieModel>MovieModel{ get; set; }
        public DbSet<ThreaterModel>ThreaterModel{ get; set; }
		public DbSet<ShowMovieTime> MovieTime { get; set; }
	}
}

