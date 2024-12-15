
using Clickhouse.Kata.API.Options;
using ClickHouse.Client;
using ClickHouse.Client.ADO;

namespace Clickhouse.Kata.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddOptions<ClickHouseConnectionSettings>()
                .Bind(builder.Configuration.GetSection(ClickHouseConnectionSettings.ClickHouseConnection))
                .ValidateDataAnnotations();

            builder.Services.AddSingleton<IClickHouseConnection>(
                sp => new ClickHouseConnection(
                    BuildConnectionString(builder.Configuration.GetSection(ClickHouseConnectionSettings.ClickHouseConnection).Get<ClickHouseConnectionSettings>()!)));

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

        private static string BuildConnectionString(ClickHouseConnectionSettings settings)
             => $"Database={settings.Database};Host={settings.Host};Protocol=https;Port={settings.Port};Username={settings.Username};password={settings.Password}";
    }
}
