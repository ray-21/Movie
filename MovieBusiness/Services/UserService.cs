using System;
using MovieData.Repository;
using MovieEntity;
namespace MovieBusiness.Services
	
{
	public class UserService
	{
		IUser _iuser;

		public UserService(IUser user)
		{
			_iuser = user;
		}
		public string Register(UserModel userModel)
        {
			return _iuser.Register(userModel);
        }
		public object SelectUser()
		{
			return _iuser.SelectUsers();
		}

		public string deleteUser(int id)
		{
			return _iuser.Delete(id);
		}
	}
}


