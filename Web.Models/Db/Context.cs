using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web.Models.Entity;

namespace Project.Models.Db
{
    public class Context:DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<UserInfo> Infos {get;set;}
        public DbSet<Post> Posts{get;set;}
        public DbSet<Img> Imgs{get;set;}
        public DbSet<Comment> Comments{get;set;}
        public Context(DbContextOptions<Context> options):base(options){}
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .UseLoggerFactory(MyLoggerFactory);
    }
}