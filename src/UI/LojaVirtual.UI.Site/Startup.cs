using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Services.Services;
using LojaVirtual.Infra.Data.EF;
using LojaVirtual.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LojaVirtual.UI.Site
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
            services.AddDbContext<LojaVirtualContext>();
            services.AddTransient<IRepositorieBoletin, RepositorieBoletin>();
            services.AddTransient<IServiceBoletin, ServiceBoletin>();

            services.AddTransient<IRepositorieProduto, RepositorieProduto>();
            services.AddTransient<IServiceProduto, ServiceProduto>();

            services.AddTransient<IRepositorieCategoria, RepositorieCategoria>();
            services.AddTransient<IServiceCategoria, ServiceCategoria>();

            services.AddTransient<IRepositorieFoto, RepositorieFoto>();

            services.AddAuthentication("CookieAuthentication")
           .AddCookie("CookieAuthentication", config =>
           {
               config.Cookie.Name = "UserLoginCookie";
               config.LoginPath = "/Home/Login";
               config.AccessDeniedPath = "/Home/AccessDenied";
           });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
