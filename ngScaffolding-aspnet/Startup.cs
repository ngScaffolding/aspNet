using System;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ngScaffolding.database;
using ngScaffolding.models.Models;
using ngScaffolding.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.IdentityModel.Tokens;
using ngScaffolding.database.Models;
using ngScaffolding.Data;
using ngScaffolding.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ngScaffolding_aspnet
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ConnectionStringsService _connectionStringsService;

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            _connectionStringsService = new ConnectionStringsService();

            foreach (var configurationSection in _configuration.GetSection("ConnectionStrings").GetChildren())
            {
                _connectionStringsService.Add(configurationSection.Key, configurationSection.Value);
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Create AppSettings
            var appSettings = new AppSettingsService();
            appSettings.AuthEndpoint = "http://localhost:50020";
            appSettings.AuthAudience = "http://localhost:50020/resources";
            appSettings.UserInfoEndpoint = "http://localhost:50020/connect/userinfo";


            // Add CORS
            services.AddCors();

            // Database
            services.AddDbContext<ngScaffoldingContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("ngScaffolding")));


            // Add framework services.
            services.AddMvcCore(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            })
                .AddApiExplorer()
                .AddJsonFormatters()
                // Enable Authorisation here
                .AddAuthorization()
                .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = appSettings.AuthEndpoint;
                    options.Audience = appSettings.AuthAudience;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });

            // Use a Memory Cache
            services.AddMemoryCache();

            // Configuration Object
            services.AddSingleton<IConfiguration>(provider => _configuration);
            services.AddSingleton<IConnectionStringsService>(provider => _connectionStringsService);
            services.AddSingleton<IAppSettingsService>(provider => appSettings);
            
            //Repository Pattern Here
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IRepository<MenuItem>), typeof(Repository<MenuItem>));
            services.AddScoped(typeof(IRepository<ApplicationLog>), typeof(Repository<ApplicationLog>));
            services.AddScoped(typeof(IRepository<DataSource>), typeof(Repository<DataSource>));
            services.AddScoped(typeof(IRepository<UserPreferenceDefinition>), typeof(Repository<UserPreferenceDefinition>));


            services.AddSingleton<ICacheService, CacheService>();

            // Services
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IReferenceValuesService), typeof(ReferenceValuesService));

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ngScaffolding-aspnet", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ngScaffolding-aspnet API V1");
            });

            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
