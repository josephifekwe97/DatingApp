using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DatingApp.Api
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";
        private const string _apiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // services.AddCors(
            //     options => options.AddPolicy(
            //         name: _defaultCorsPolicyName,
            //         builder => builder
            //             .SetIsOriginAllowedToAllowWildcardSubdomains()
            //             .WithOrigins(
            //                 // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
            //                 Configuration["App:CorsOrigins"]
            //                     .Split(",", StringSplitOptions.RemoveEmptyEntries)
            //                     //.Select(o => o.RemovePostFix("/"))
            //                     .ToArray()
            //             )

            //             .AllowAnyHeader()
            //             .AllowAnyMethod()
            //             .AllowCredentials()
            //     )
            // );

            services.AddControllers();
            services.AddDbContext<ApplicationDbcontext>(X => X.UseSqlite("DataSource = DatingApp.db"));
            // services.AddDbContext<ApplicationDbcontext>(X=> X.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                // c.SwaggerDoc("v1", new OpenApiInfo { Title = "DatingApp.Api", Version = "v1" });
                c.SwaggerDoc(_apiVersion, new OpenApiInfo
                {
                    Version = _apiVersion,
                    Title = "Smartace HR API",
                    Description = "ERP",
                    // uncomment if needed TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "ERP",
                        Email = string.Empty,
                        Url = new Uri("http://www.smartace.ng/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("http://www.smartace.ng/"),
                    }
                });

            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()// allow credentials
            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatingApp.Api v1"));
            }

            // app.UseHttpsRedirection();

            // app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();

            //    app.UseCors(x => x
            // .AllowAnyMethod()
            // .AllowAnyHeader()
            // .SetIsOriginAllowed(origin => true) // allow any origin
            //.AllowCredentials()); // allow crede
            // );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
