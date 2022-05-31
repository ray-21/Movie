using System;
namespace MovieData.Repository
{
	public interface IThreater
	{
		string AddThreater(MovieEntity.Models.ThreaterModel thetreModel);

		object SelectThreater();
	}
}

