﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace AXA_TEST_CASE.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddSwaggerAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                var securityDef = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authentication header usiong bearer scheme."

                };

                opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityDef);
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string[]{ }
                    }

                });
            });

            return services;
        }
    }
}
