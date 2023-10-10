using MacPBaseConversionsMicroservice.Services;
using MacPBaseConversionsMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MacPBaseConversionsMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string corsPolicyName = "MacPsCORSPolicy";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IBaseConversionService, BaseConversionService>();

            //CORS Policy: allow all origins, methods and headers so that any domain can request a Unit Conversion
            //              With this microservice, this is not a concern as there's no access to any data anywhere
            //              If run on a hosting/cloud instead of a local Docker, policies should be set properly
            builder.Services.AddCors(options => {
                options.AddPolicy(name: corsPolicyName,
                    policy => {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.UseCors(corsPolicyName);

            app.MapControllers();

            app.Run();
        }
    }
}