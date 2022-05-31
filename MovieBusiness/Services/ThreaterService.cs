using System;
using MovieData.Repository;

namespace MovieBusiness.Services
{
	public class ThreaterService
	{
		IThreater _threater;
		public ThreaterService(IThreater threater )
		{
			this._threater = threater;
		}
        public string AddThetre(MovieEntity.Models.ThreaterModel threaterModel)
        {
            return
          _threater.AddThreater(threaterModel);

        }

        public Object SelectThreater()
        {
            return _threater.SelectThreater();
        }
    }
}

