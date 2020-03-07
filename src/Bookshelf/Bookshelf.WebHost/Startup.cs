using Bookshelf.Application;
using Bookshelf.Authorization;
using Bookshelf.Authorization.Identity;
using Bookshelf.Authorization.Utils;
using Bookshelf.Repository;
using Bookshelf.Repository.Context;
using Bookshelf.Utils;
using Bookshelf.Validator;
using Bookshelf.WebHost.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.WebHost
{
    /// <summary>
    /// WebHost configuration class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Instatiates Startup class.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Contains all configuration (json files, environment, app arguments).
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Register services in IoC container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.RegisterGlobalConfig(Configuration);

            services.AddControllers();

            services.AddOptions();

            services.RegisterRepositories();

            services.AddIdentity<BookshelfIdentityUser, IdentityRole<Guid>>(
                config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 1;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.User.AllowedUserNameCharacters = null;
                    config.User.RequireUniqueEmail = false;

                })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidAudience = Configuration["JwtAudience"],
                        ValidateIssuer = false,
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"]))
                    };
                });

            //Disable redirecting when Unauthorized
            services.ConfigureApplicationCookie(config =>
            {
                config.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api"))
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };
            });

            services.RegisterCommandQueryHandlers();
            services.RegisterAuthorizationPolicies();
            services.RegisterAuthorizationServices();
            services.RegisterApplicationAutoMapper();
            services.RegisterValidators();

            services.RegisterSwagger();
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Configures HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        /// <param name="actionDescriptorCollectionProvider"></param>
        public static void Configure(
            IApplicationBuilder app,
            GlobalConfig config,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            app.UseDeveloperExceptionPage();
            if (config.AddSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookshelf API");
                });
            }

            app.UseRouting();

            // app.UseHttpsRedirection();

            app.UseCors(builder => builder
                            .WithOrigins(new[] { "http://localhost:4200" })
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            );

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PolicyValidator.ValidateEndpointsPolicies(actionDescriptorCollectionProvider);
        }
    }
}
