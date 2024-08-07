using Microsoft.EntityFrameworkCore;
using System;
using TunifyPlatform.Data;

namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
