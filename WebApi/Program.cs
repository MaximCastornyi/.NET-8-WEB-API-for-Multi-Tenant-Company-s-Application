
using Infrastructure;
using Application;

namespace WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.GetJwtSettings(builder.Configuration);
            builder.Services.AddJwtAuthentication(builder.Services.GetJwtSettings(builder.Configuration));
            builder.Services.AddApplicationServices();
            var app = builder.Build();


            // Database Seeder
            await app.Services.AddDatabaseInitializerAsync();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseInfrastructure();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
