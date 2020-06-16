using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using Project.Models.Db;
using Web.Models.AutoMapperDTO;
using Web.Models.Entity;
using Web.Models.EntityModels;
using Web.Models.Interfaces.Stores;

namespace Web.Infrastructure.Stores
{
    public class SubscribersDbStore: ISubscribersDbStore
    {
        public SubscribersDbStore(Context context)
        {
            _context = context;
        }

        private Context _context;
        public void SubscribeToUser(string to, string who)
        {
            User userTo = _context.Users
                .FirstOrDefault(x => x.Login == to);
            User userWho = _context.Users
                .FirstOrDefault(x => x.Login == who);
            if(userTo==null) return;
            if (UserIsSubscribed(to,who)) return;
            var subs= new Subscribes()
            {
                To = userTo,
                Who = userWho
            };
            userWho.CountSubscribed+=1;
            userTo.CountSubscribers+=1;
            _context.Subscribes.Add(subs);
            _context.Users.UpdateRange(userWho, userTo);
            _context.SaveChanges();
        }

        public bool UserIsSubscribed(string to, string who)
        {
            return _context.Subscribes
                .AsNoTracking()
                .Any(x => x.To.Login == to && x.Who.Login == who);
        }

        public void UnSubscribeUser(string to, string who)
        {
            var subs = _context.Subscribes
                .Include(x=>x.To)
                .Include(x=>x.Who)
                .FirstOrDefault(x => x.To.Login == to && x.Who.Login == who);
            var userTo= subs.To;
            var userWho= subs.Who;
            userTo.CountSubscribers-=1;
            userWho.CountSubscribed-=1;
            if (subs == null) return;
            _context.Subscribes.Remove(subs);
            _context.Users.UpdateRange(userWho, userTo);
            _context.SaveChanges();
        }

        public List<SubscriberEntity> GetSubscribers(string login,int page, int pageSize)
        {
            return _context.Subscribes
                .AsNoTracking()
                .Where(x => x.To.Login == login&&x.Id>page)
                .Take(pageSize)
                .Include(x=>x.Who)
                    .ThenInclude(x=>x.Ava)
                .Select(x=>new SubscriberEntity{Id=x.Id, User=x.Who})
                .ToList();
        }

        public List<SubscriberEntity> GetSubscribed(string login,int page, int pageSize)
        {
            return _context.Subscribes
                .AsNoTracking()
                .Where(x => x.Who.Login == login&&x.Id>page)
                .Take(pageSize)
                .Include(x=>x.To)
                    .ThenInclude(x=>x.Ava)
                .Select(x=>new SubscriberEntity{Id=x.Id, User=x.To})
                .ToList();
        }

        public int CountSubscribers(string login)
        {
            return _context.Subscribes
                .AsNoTracking()
                .Count(x => x.To.Login == login);
        }

        public int CountSubscribed(string login)
        {
            return _context.Subscribes
                .AsNoTracking()
                .Count(x => x.Who.Login == login);
        }
    }
}