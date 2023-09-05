using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FBUsuarios
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-29IJM15\\LOCAL;Initial Catalog=pactia;Integrated Security=True"));

            builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()));
        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowWebApp");

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
