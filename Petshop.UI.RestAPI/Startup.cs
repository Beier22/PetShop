using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ownerShop.Core.AppServices;
using PetShop.Core.AppServices;
using PetShop.Core.AppServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.SQLData;
using PetShop.Infrastructure.SQLData.Repositories;
using PetShopUI;

namespace Petshop.UI.RestAPI
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //FakeDB.SamplePets();
            //FakeDB.SampleOwners();

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlite("Data Source=PetShopSQLite.db")
                    );
            }
            else
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))
                    );
            }
            

            services.AddScoped<IPetRepo, PetRepo>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepo, OwnerRepo>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddScoped<IPrinter, Printer>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using(var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<PetShopContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DbInitializer.Seed(context);
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<PetShopContext>();
                    context.Database.EnsureCreated();
                }
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
