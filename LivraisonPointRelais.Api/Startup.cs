using AutoMapper;
using LivraisonPointRelais.Api.MapperProfiles;
using LivraisonPointRelais.Data.Repositories;
using LivraisonPointRelais.Model.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LivraisonPointRelais.Api
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
            services.AddControllers();
            services.AddAutoMapper(typeof(ProduitProfile), typeof(ClientProfile));
            services.AddScoped<IClientRepository, ClientRepository>()
                    .AddScoped<IProduitRepository, ProduitRepository>();
            services.AddDbContext<LivraisonPointRelaisDbContext>(
                options => options.UseSqlite("Data Source=LivraisonPointRelais.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
