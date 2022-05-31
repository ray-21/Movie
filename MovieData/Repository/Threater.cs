using System;
using System.Collections.Generic;
using System.Linq;
using MovieData.DataConnection;
using MovieEntity.Models;

namespace MovieData.Repository
{
	public class Threater:IThreater
	{
        MovieDbContext _movieDbContext;
        public Threater(MovieDbContext movieDbContext)
		{
            _movieDbContext = movieDbContext;

        }

        public string AddThreater(ThreaterModel threaterModel)
        {
            string message = "";
            _movieDbContext.ThreaterModel.Add(threaterModel);
            _movieDbContext.SaveChanges();
            message = "Thetre Added Successfully..!!";
            return message;
            
        }

        public object SelectThreater()
        {
            List<ThreaterModel> thetreList = _movieDbContext.ThreaterModel.ToList();
            return thetreList;
        }
    }
}

