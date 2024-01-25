using AspNetCoreRateLimit;
using Azure.Storage.Blobs;
using Fitzilla.BLL;
using Fitzilla.BLL.Services;
using Fitzilla.DAL;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
        });

        builder.Services.AddMemoryCache();
        builder.Services.ConfigureRateLimiting();
        builder.Services.AddHttpContextAccessor();

        builder.Services.ConfigureHttpCacheHeaders();

        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureJWT(builder.Configuration);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowEverything", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        builder.Services.ConfigureAutoMapper();

        builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorageConnection")));

        builder.Services.AddScoped<IBlobRepository, BlobRepository>();

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IAuthManager, AuthManager>();
        builder.Services.AddScoped<ExerciseManager>();
        builder.Services.AddScoped<MacroManager>();
        builder.Services.AddScoped<PlanManager>();
        builder.Services.AddScoped<SessionManager>();

        AddSwaggerDoc(builder.Services);


        // Add services to the container.

        builder.Services.AddControllers(/*config =>
{
    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
    {
        Duration = 120
    });
}*/).AddNewtonsoftJson(option =>
    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


        builder.Services.AddEndpointsApiExplorer();

        void AddSwaggerDoc(IServiceCollection services)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    },
                    Scheme = "0auth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
                    }
                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fitzilla.API", Version = "v1" });
            });
        }

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fitzilla v1"));
        }

        app.ConfigureExceptionHandler();

        app.UseCors("AllowEverything");
        app.UseRouting();

        app.UseResponseCaching();
        app.UseHttpCacheHeaders();
        app.UseIpRateLimiting();


        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}