using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;

namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            // Identity configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDbContext>();

            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));
            builder.Services.AddTransient<IUser, UserServices>();
            builder.Services.AddTransient<ISong, SongServices>();
            builder.Services.AddTransient<IPlayList, PlaylistsServices>();
            builder.Services.AddTransient<IArtists, ArtistsServices>();

            builder.Services.AddTransient<IAccounts, IdentityAccountService>();

            //Define the jwt service 
            builder.Services.AddScoped<JwtTokenService>();

            //Add auth service to the app using jwt 
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
                    }
                );

            //swager configration 
            builder.Services.AddSwaggerGen(
                option =>
                {
                    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Tunify API",
                        Version = "v1",
                        Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                    });
                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Please enter user token below."
                    });

                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                }
                );
            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            //Call swagger services
            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
             );

            //Call swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });


            app.MapControllers();
          //  app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
