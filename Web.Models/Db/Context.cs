using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web.Models.Entity;
using Web.Models.Enums;

namespace Project.Models.Db
{
    public class Context:DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<UserInfo> Infos {get;set;}
        public DbSet<Post> Posts{get;set;}
        public DbSet<Img> Imgs{get;set;}
        public DbSet<Comment> Comments{get;set;}
        public DbSet<Subscribes> Subscribes { get; set; }
        public DbSet<Like> Likes{get;set;}
        public DbSet<Group> Groups{get;set;}
        public DbSet<AdminGroup> AdminsGroups{get;set;}
        public DbSet<UsersGroups> UsersGroups{get;set;}
        public Context(DbContextOptions<Context> options):base(options){}
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .UseLoggerFactory(MyLoggerFactory);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Like>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (LikeType)Enum.Parse(typeof(LikeType), v));
        }
    }
}