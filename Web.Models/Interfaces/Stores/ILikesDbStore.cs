using System.Collections.Generic;
using Web.Models.Entity;
using Web.Models.Enums;
namespace Web.Models.Interfaces.Stores
{
	public interface ILikesDbStore
	{
		User SetLike(string login, LikeType type, int id);
		void UnLike(string login, LikeType type, int id);

		List<User> getLikes(LikeType type, int id, int page, int pageSize);
		int countLikes(LikeType like, int id);

		bool isLike(LikeType type, int id, string login);		
	}
}