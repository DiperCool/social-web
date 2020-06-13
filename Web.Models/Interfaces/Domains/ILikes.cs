using System.Collections.Generic;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;
using Web.Models.Enums;
using Web.Models.Models;

namespace Web.Models.Interfaces.Domains
{
    public interface ILikes
    {
        Like SetLike(string login, LikeType type, int id);
		void UnLike(string login, LikeType type, int id);
		PaginationResult<UserDTO> getLikes(LikeType type, int id, int page);
		bool isLike(LikeType type, int id, string login);	
    }
}