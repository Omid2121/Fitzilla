using AspNetCoreRateLimit;
using Fitzilla.BLL.Services;
using Fitzilla.DAL;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Fitzilla.BLL;

public static class ServiceExtensions
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentityCore<User>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
        });
        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
        builder.AddTokenProvider("FitzillaApi", typeof(DataProtectorTokenProvider<User>));
        builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        //var key = Environment.GetEnvironmentVariable("JwtSecretKey");
        var key = jwtSettings.GetSection("JwtSecretKey").Value;

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,              // Validate the server that created that token
                ValidateLifetime = true,            // Validate the lifetime of the token
                ValidateAudience = true,            // Validate the recipient of the token is authorized to receive it
                ValidateIssuerSigningKey = true,    // Validate the encripted key is valid and trusted by the server
                ValidAudience = jwtSettings.GetSection("JwtValidAudience").Value,
                ValidIssuer = jwtSettings.GetSection("JwtValidIssuer").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ClockSkew = TimeSpan.FromSeconds(60) // 1 minute tolerance for the expiration date
            };
        });
    }

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new Error
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error. Please Try Again Later."
                    }.ToString());
                }
            });
        });
    }    

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });
    }

    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthManager, AuthManager>();
        services.AddScoped<IBlobRepository, BlobRepository>();
        services.AddScoped<ExerciseManager>();
        services.AddScoped<MacroManager>();
        services.AddScoped<PlanManager>();
        services.AddScoped<SessionManager>();
    }

    public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
    {
        services.AddResponseCaching();
        services.AddHttpCacheHeaders(
            (expirationOpt) =>
            {
                expirationOpt.MaxAge = 1200;
                expirationOpt.CacheLocation = CacheLocation.Public;
            },
            (validationOpt) =>
            {
                validationOpt.MustRevalidate = true;
                validationOpt.ProxyRevalidate = true;
            }
        );
    }

    public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        var rateLimitRules = new List<RateLimitRule>
        {
            new RateLimitRule
            {
                Endpoint = "*",
                Limit = 100,
                Period = "5m"
            }
        };
        services.Configure<IpRateLimitOptions>(opt =>
        {
            opt.GeneralRules = rateLimitRules;
        });
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
    }
}
