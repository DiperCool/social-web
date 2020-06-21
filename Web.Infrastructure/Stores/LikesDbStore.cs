using Web.Models.Enums;
using Web.Models.Entity;
using System.Collections.Generic;
using Project.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.Models.EntityModels;

namespace Web.Models.Interfaces.Stores
{
    public class LikesDbStore : ILikesDbStore
    {
		private Context _context;

        public LikesDbStore(Context context)
        {
            _context = context;
        }

        public int countLikes(LikeType like, int id)
        {
            return _context.Likes
				.Where(x=>x.Type==like&&x.IdType==id)
				.Count();
        }

        public List<SubscriberEntity> getLikes(LikeType type, int id, int page, int pageSize)
        {
            return _context.Likes                
				.AsNoTracking()
                .Where(x=>x.IdType==id&&x.Type==type&&x.Id>page)
                .Take(pageSize)
                .Include(x=>x.Who)
					.ThenInclude(x=>x.Ava)
                .Select(x=>new SubscriberEntity{Id=x.Id, User=x.Who})
                .ToList();
        }

        public bool isLike(LikeType type, int id, string login)
        {
            return _context.Likes
                .AsNoTracking()
				.Where(x=>x.Who.Login==login&&x.Type==type&&x.IdType==id)
                .Count()==1;
        }

        public SubscriberEntity SetLike(string login, LikeType type, int id)
        {
            var res=isLike(type, id, login);
            if(res)
            {
                return null;
            }
            var user= _context.Users
                .Include(x=>x.Ava)
				.FirstOrDefault(x=>x.Login==login);
			var like= new Like()
			{
				Who=user,
				Type= type,
				IdType= id
			};
			_context.Likes.Add(like);
			_context.SaveChanges();
			return new SubscriberEntity{Id=like.Id, User=like.Who};
        }

        public void UnLike(string login, LikeType type, int id)
        {
            var like= _context.Likes
				.Where(x=>x.Who.Login==login&&x.Type==type&&x.IdType==id)
				.FirstOrDefault();
			if(like==null) return;
			_context.Likes.Remove(like);
			_context.SaveChanges();

        }
    }

}
