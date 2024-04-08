using JPC.AmountConverter.Application.AmountConverterService;
using JPC.AmountConverter.Application.Shared.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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

            // Add your services here
            services.Configure<AmountConverterConfiguration>(Configuration.GetSection("RapidApi"));
            services.AddTransient(provider => provider.GetRequiredService<IOptions<AmountConverterConfiguration>>().Value);
            services.AddTransient<IAmountConverterService, AmountConverterService>(); // Added the created service in Transient Lifetime
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the request pipeline
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
