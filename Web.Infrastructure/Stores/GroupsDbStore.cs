using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Project.Models.Db;
using Web.Models.Entity;
using Web.Models.Enums;
using Web.Models.Interfaces.Stores;

namespace Web.Infrastructure.Stores
{
    public class GroupsDbStore : IGroupsDbStore
    {
        Context _context;
        IWebHostEnvironment _enviroment; 
        public GroupsDbStore(Context context,IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment=enviroment;
        }

        public async Task<User> addToGroup(string loginGroup, string loginUser)
        {
            Group group= await getGroup(loginGroup);
            User user= await _context.Users.FirstOrDefaultAsync(x=>x.Login==loginUser);

            UsersGroups usersGroups= new UsersGroups{User=user, Group=group};

            group.Users.Add(usersGroups);
            user.Groups.Add(usersGroups);
            _context.UpdateRange(user, usersGroups);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Group> createGroup(string login, string name)
        {
            //
            //
            var urlImg=_enviroment.WebRootPath + "/"+"Files/Avas/default.png";
            var pathImg="Files/Avas/default.png";
            var img = new Img {UrlImg=urlImg, PathImg= pathImg};
            var group = new Group { Login = login, Name = name, Ava=img};
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task deleteAdmin(string loginGroup, string loginUser)
        {
            AdminGroup adminGroup= await _context.AdminsGroups.FirstOrDefaultAsync(x=>x.User.Login==loginUser&&x.Group.Login==loginGroup);
            _context.AdminsGroups.Remove(adminGroup);
            await _context.SaveChangesAsync();
        }

        public async Task deleteFromGroup(string loginGroup, string loginUser)
        {
            UsersGroups us=await _context.UsersGroups.FirstOrDefaultAsync(x=>x.Group.Login==loginGroup&&x.User.Login==loginUser);
            _context.UsersGroups.Remove(us);
            await _context.SaveChangesAsync();
        }

        public async Task<RightType> getRight(string loginGroup, string loginUser)
        {
            return await _context.AdminsGroups
                    .Where(x=>x.User.Login==loginUser&&x.Group.Login==loginGroup)
                    .Select(x=>x.Right)
                    .FirstOrDefaultAsync();
        }

        public async Task<User> setAdmin(string loginGroup, string loginUser, RightType right)
        {
            User user= await _context.Users
                .FirstOrDefaultAsync(x=>x.Login==loginUser);
            Group group= await getGroup(loginGroup);
            AdminGroup admin= new AdminGroup{User=user, Right=right, Group=group};
            group.Admins.Add(admin);
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
            return user;
        }

        private async Task<Group> getGroup(string loginGroup)
        {
            return await _context.Groups.FirstOrDefaultAsync(x=>x.Login==loginGroup);
        }
        private async Task<bool> groupIsExist(string loginGroup)
        {
            return await _context.Groups.AnyAsync(x=>x.Login==loginGroup);
        }
        public async Task<bool> loginIsExist(string login)
        {
            bool user= await _context.Users.AnyAsync(x=>x.Login==login);
            bool group= await groupIsExist(login);
            return user || group;
        }
        public async Task<Img> saveAva(string login, Img img)
        {
            Group group= await getGroup(login);
            group.Ava=img;
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
            return group.Ava; 
        }

        public async Task<bool> userIsSubscribed(string login, string loginGroup)
        {
            return await _context.Groups.
                Where(x=>x.Login==loginGroup)
                .AnyAsync(x=>x.Users.Any(x=>x.User.Login==login));
        }
    }
}