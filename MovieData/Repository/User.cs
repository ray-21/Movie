using System;
using MovieData.DataConnection;
using MovieEntity;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace MovieData.Repository
{
    public class User :IUser
        

	{
        MovieDbContext _movieDbContext;
		public User(MovieDbContext movieDbContext)
		{
            _movieDbContext = movieDbContext;
		}

        public string Delete()
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object Login()
        {
            throw new NotImplementedException();
        }

        public string Register(UserModel userModel)
        {
            string msg = "";
            //insert into usermodelid,usermodel.fname
             _movieDbContext.UserModel.Add(userModel);
            _movieDbContext.SaveChanges();//execute sql queries
            msg = "Inserted";
            return msg;
            throw new NotImplementedException();
        }

        public string Register()
        {
            throw new NotImplementedException();
        }

        public object SelectUsers()
        {
            
            List<UserModel> userList = _movieDbContext.UserModel.ToList();
            return userList;
            throw new NotImplementedException();
        }

        public string Update()
        {
            throw new NotImplementedException();
        }
    }
}

