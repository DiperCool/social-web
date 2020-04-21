using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Project.Models.Classes;
using Project.Models.Db;
using Project.Models.Interfaces;
using Web.Domain.Account;
using Web.Domain.Auth;
using Web.Infrastructure.Jwt;
using Web.Infrastructure.validation;
using Web.Models.Configs.Jwt;
using Web.Models.Interfaces;

namespace Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddTransient<IAuthDbStore, AuthDbStore>();
            services.AddTransient<IJwt, JwtLib>();
            services.AddTransient<IValidation, Validation>();
            services.AddTransient<IAuth, Auth>();
            services.AddTransient<IAccount, Account>();
            services.AddTransient<IProfileDbStore, ProfileDbStore>();
            services.AddTransient<IFilesWorker, FilesWorker>();
            services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt=>{
                opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            
                            ValidateIssuer = true,                         
                            ValidIssuer = JwtOptions.ISSUER,                      
                            ValidateAudience = true,                           
                            ValidAudience = JwtOptions.AUDIENCE,                            
                            ValidateLifetime = true,
                            IssuerSigningKey = JwtOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                opt.Events=new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
            });
        }
    }
}
