using DocumentRepository.Models.Services;
using DocumentRepository.Models.Services.Abstracts;
using DocumentRepository.Models.Services.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository
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

            //подключаю конфиг из appsetting.json
            Configuration.Bind("Project", new Config());

            services.AddTransient<IAccountRep, AccountEF>();
            services.AddTransient<IDocumentRep, DocumentEF>();
            //services.AddTransient<DataManager>(); //If I will use it

            //подключаю контекст ДБ
            services.AddDbContext<ContextEF>(con => con.UseSqlServer(Config.ConnectionString));

            //настраиваю аутентификацию
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "DocRepAuth";
                options.LoginPath = "/Authentication/SignIn";
            });
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
