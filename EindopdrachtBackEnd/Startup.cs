using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Configuration;
using EindopdrachtBackEnd.Data;
using EindopdrachtBackEnd.Repositories;
using EindopdrachtBackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json; //to fix infinite looping during SELECT

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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // AUTHENTICATION
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.Authority = "https://dev-xfqsdz8z.eu.auth0.com";
                options.Audience = "http://animeAPI";
            });
            // SWAGGER
            services.AddSwaggerGen(c =>
            {
                // ALLOWS MULTIPLE CONTROLLERS IN SWAGGER
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnimeApi", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "RecommendationApi", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            // VERSIONING
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
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
            services.AddTransient<IRecommendationService,RecommendationService>();
            
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // SWAGGER
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimeApi v1");

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            //AUTH0
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
