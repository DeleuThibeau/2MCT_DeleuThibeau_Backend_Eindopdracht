using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Configuration;
using EindopdrachtBackEnd.Data;
using EindopdrachtBackEnd.Repositories;
using EindopdrachtBackEnd.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EindopdrachtBackEnd
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
            // AUTOMAPPER => DTO
            services.AddAutoMapper(typeof(Startup));
            // DB CONNECTION
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            // CONTEXT
            services.AddDbContext<AnimeContext>();
            // CONTROLLERS
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EindopdrachtBackEnd", Version = "v1" });
            });

            //INTERFACCES

                //CONTEXT
            services.AddTransient<IAnimeContext,AnimeContext>();

                // REPOS
            services.AddTransient<IAnimeRepository,AnimeRepository>();
            services.AddTransient<IGenreRepository,GenreRepository>();
            services.AddTransient<IStudioRepository,StudioRepository>();
            services.AddTransient<IStreamingServiceRepository,StreamingServiceRepository>();

                // SERVICES
            services.AddTransient<IAnimeService,AnimeService>();
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EindopdrachtBackEnd v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
