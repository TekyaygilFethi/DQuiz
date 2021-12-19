using System;
using DQuiz.Business.App.AdminManagerFolder;
using DQuiz.Business.App.QuizManagerFolder;
using DQuiz.Business.RepositoryFolder;
using DQuiz.Business.UnitOfWorkFolder;
using DQuiz.Data.POCO;
using DQuiz.Database.DbContexts;
using DQuiz.MVC.Filters;
using DQuiz.MVC.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DQuiz.App
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
            services.AddControllersWithViews();

            services.AddSession(option =>
            {
                //Süre 1 dk olarak belirlendi
                option.IdleTimeout = TimeSpan.FromMinutes(120);
            });
            services.AddSignalR();
            services.AddCors(o =>
            {
                o.AddPolicy("All", p =>
                {
                    p.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
            services.AddSignalR();

            #region Repository Injection
            services.AddTransient<IRepository<Answer>, Repository<Answer>>();
            services.AddTransient<IRepository<Metric>, Repository<Metric>>();
            services.AddTransient<IRepository<Question>, Repository<Question>>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            #endregion

            #region UnitOfWork Injection
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Service Injections
            services.AddTransient<IAdminManagementService, AdminManagementService>();
            services.AddTransient<IQuizManagementService, QuizManagementService>();
            #endregion

            #region Filter Injection
            services.AddScoped<AdminFilter>();
            services.AddScoped<QuestionPageFilter>();
            services.AddScoped<EndContestFilter>();
            services.AddScoped<IndexFilter>();
            #endregion

            #region DbContext Injection
            services.AddDbContext<DQuizDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Dev"));
                options.EnableSensitiveDataLogging();

            });



            #endregion
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("All");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<PoolHub>("/poolhub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
