using System;
using MovieEntity;
namespace MovieData.Repository
{
	public interface IUser
	{
		String Register(UserModel userModel);
		object Login();
		String Update();
		String Delete(int id);
		Object SelectUsers();
	}
}

