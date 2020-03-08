using Bookshelf.Validator.Filter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Bookshelf.WebHost.Extensions
{
    /// <summary>
    /// Contains extensions of <see cref="IServiceCollection">IServiceCollection</see> to register Swagger
    /// </summary>
    public static class IServiceCollectionSwaggerExtensions
    {
        /// <summary>
        /// Registers Swagger.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bookshelf API",
                    Description = "Example Rest Backend",
                    Contact = new OpenApiContact()
                    {
                        Name = "Bookshelf",
                        Email = "kontakt@piotrtrojan.com",
                        Url = new Uri("http://www.piotrtrojan.com")
                    }
                });

                var security = new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                };

                c.IncludeXmlComments(GetSwaggerControllersXmlCommentsPath());
                c.IncludeXmlComments(GetSwaggerWebContractXmlCommentsPath());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(security);
                c.SchemaFilter<AddFluentValidationRules>();
            });
        }

        private static string GetSwaggerWebContractXmlCommentsPath()
        {
            var app = AppContext.BaseDirectory;
            var assemblyDocumentation = "Bookshelf.WebContract.xml"; // In the future, there may be more fancy way to resolve that name.
            return System.IO.Path.Combine(app, assemblyDocumentation);
        }

        private static string GetSwaggerControllersXmlCommentsPath()
        {
            var app = AppContext.BaseDirectory;
            var assemblyDocumentation = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name.Replace(".dll", ".xml");
            return System.IO.Path.Combine(app, assemblyDocumentation);
        }
    }
}
