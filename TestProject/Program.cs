using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Services;

namespace TestProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("SourceDb")), ServiceLifetime.Transient);
            builder.Services.AddDbContext<Target1DatabaseContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("TargetDb")), ServiceLifetime.Transient);
            builder.Services.AddDbContext<Target2DatabaseContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Target2Db")), ServiceLifetime.Transient);

            builder.Services.AddScoped<DataTransferService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
