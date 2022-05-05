using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GitHubProjectSearcher.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromMinutes(1),
                        ValidateAudience = false,
                    };
                    config.Authority = "https://localhost:7260";
                    config.Audience = "https://localhost:7260";
                });
            services.AddAuthorization();

            return services;
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string title, string version
        , string identityServerConnect)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: version, new OpenApiInfo { Title = title, Version = version });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(identityServerConnect),
                            TokenUrl = new Uri(identityServerConnect),
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            return services;
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, string documentTitle, string versionTitle,
            string swaggerEndpoint, string clientId, string clientSecret)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerEndpoint, versionTitle);
                c.DocumentTitle = documentTitle;
                c.OAuthClientId(clientId);
                c.OAuthScopeSeparator(" ");
                c.OAuthClientSecret(clientSecret);
            });
            return app;
        }
    }
}
