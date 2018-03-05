using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyStoreFront1.Models;


namespace MyStoreFront1
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
            services.AddMvc();
            services.AddAntiforgery();
            services.AddSession();

            services.Configure<Models.ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddOptions();

            services.AddDbContext<JoshTestContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                        sqlOptions => sqlOptions.MigrationsAssembly(this.GetType().Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<JoshTestContext>()
                .AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, JoshTestContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink(); //I added this manually
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
