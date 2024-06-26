﻿using JPC.AmountConverter.Application.AmountConverterService;
using Microsoft.OpenApi.Models;

namespace JPC.AmountConverter.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here, similar to what's in the CreateBuilder block in Program.cs
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Amount Converter API", Version = "v1" });
                options.SwaggerDoc("notifier", new OpenApiInfo { Title = "Amount Converter API", Version = "v1" });
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (docName == "v1" && string.IsNullOrEmpty(apiDesc.GroupName))
                    {
                        return true;
                    }
                    return apiDesc.GroupName == docName;
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            // Add your services here
            services.AddTransient<IAmountConverterService, AmountConverterService>(); // Added the created service in Transient Lifetime
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the request pipeline
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Amount Converter API V1");
                });
            }

            app.UseCors("AllowAllOrigins");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
