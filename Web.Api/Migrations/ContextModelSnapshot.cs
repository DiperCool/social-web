﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project.Models.Db;

namespace Web.Api.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Web.Models.Entity.AdminGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("Right")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("AdminsGroups");
                });

            modelBuilder.Entity("Web.Models.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("To")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Web.Models.Entity.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Web.Models.Entity.Img", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PathImg")
                        .HasColumnType("text");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("UrlImg")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Imgs");
                });

            modelBuilder.Entity("Web.Models.Entity.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdType")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("WhoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WhoId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Web.Models.Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("groupId")
                        .HasColumnType("integer");

                    b.Property<int?>("userId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("groupId");

                    b.HasIndex("userId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Web.Models.Entity.Subscribes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ToId")
                        .HasColumnType("integer");

                    b.Property<int?>("WhoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ToId");

                    b.HasIndex("WhoId");

                    b.ToTable("Subscribes");
                });

            modelBuilder.Entity("Web.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AvaId")
                        .HasColumnType("integer");

                    b.Property<int>("CountSubscribed")
                        .HasColumnType("integer");

                    b.Property<int>("CountSubscribers")
                        .HasColumnType("integer");

                    b.Property<string>("Emeil")
                        .HasColumnType("text");

                    b.Property<int?>("InfoUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AvaId");

                    b.HasIndex("InfoUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Web.Models.Entity.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AboutMe")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("Web.Models.Entity.UsersGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersGroups");
                });

            modelBuilder.Entity("Web.Models.Entity.AdminGroup", b =>
                {
                    b.HasOne("Web.Models.Entity.Group", "Group")
                        .WithMany("Admins")
                        .HasForeignKey("GroupId");

                    b.HasOne("Web.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Web.Models.Entity.Comment", b =>
                {
                    b.HasOne("Web.Models.Entity.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Web.Models.Entity.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Web.Models.Entity.Img", b =>
                {
                    b.HasOne("Web.Models.Entity.Post", null)
                        .WithMany("Photos")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Web.Models.Entity.Like", b =>
                {
                    b.HasOne("Web.Models.Entity.User", "Who")
                        .WithMany()
                        .HasForeignKey("WhoId");
                });

            modelBuilder.Entity("Web.Models.Entity.Post", b =>
                {
                    b.HasOne("Web.Models.Entity.Group", "group")
                        .WithMany("Posts")
                        .HasForeignKey("groupId");

                    b.HasOne("Web.Models.Entity.User", "user")
                        .WithMany("Posts")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Web.Models.Entity.Subscribes", b =>
                {
                    b.HasOne("Web.Models.Entity.User", "To")
                        .WithMany()
                        .HasForeignKey("ToId");

                    b.HasOne("Web.Models.Entity.User", "Who")
                        .WithMany()
                        .HasForeignKey("WhoId");
                });

            modelBuilder.Entity("Web.Models.Entity.User", b =>
                {
                    b.HasOne("Web.Models.Entity.Img", "Ava")
                        .WithMany()
                        .HasForeignKey("AvaId");

                    b.HasOne("Web.Models.Entity.UserInfo", "InfoUser")
                        .WithMany()
                        .HasForeignKey("InfoUserId");
                });

            modelBuilder.Entity("Web.Models.Entity.UsersGroups", b =>
                {
                    b.HasOne("Web.Models.Entity.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId");

                    b.HasOne("Web.Models.Entity.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
