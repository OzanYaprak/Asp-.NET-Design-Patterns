using DesignPattern.Observer.DataAccessLayer;
using DesignPattern.Observer.Models;
using DesignPattern.Observer.ObserverPattern;
using DesignPattern.Observer.ObserverPattern.Classes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Observer
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
            services.AddDbContext<DbContext>();
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<DbContext>();

            services.AddSingleton<ObserverObject>(serviceProvider =>
            {
                ObserverObject observerObject = new();

                observerObject.RegisterObserver(new CreateWelcomeMessage(serviceProvider));
                observerObject.RegisterObserver(new CreateMagazineAnnouncement(serviceProvider));
                observerObject.RegisterObserver(new CreateDiscountCode(serviceProvider));

                return observerObject;
            });

            services.AddControllersWithViews();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
