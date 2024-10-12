using Utility;
using Persistence;
using Application;
using Api.Extensions;
using Api.Services.Identity;
using Api.Services.Security;
using Contract.Services.Security;
using NLog;
using NLog.Web;
using System.Text.Encodings.Web;


var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
try
{
    logger.Info("WebApi initializing");
    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });


    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    #region Authentication & Authorization
    builder.Services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
    #endregion

    builder.Services.AddSwaggerExtension();
    builder.Services.AddJwtExtension(builder.Configuration);

    builder.Services.ConfigureUtilityServices(builder.Configuration);
    builder.Services.ConfigurePersistenceServices(builder.Configuration);
    builder.Services.ConfigureApplicationServices();

    var allowedOriginUrl = builder.Configuration.GetSection("AllowedOriginUrl");

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", b => b
        .WithOrigins(allowedOriginUrl.Get<string[]>() ?? [])
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
    });

    var app = builder.Build();

    IConfiguration configuration = app.Configuration;
    IWebHostEnvironment environment = app.Environment;

    app.UseErrorHandlingMiddleware();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerExtension();
    }

    app.Use(async (context, next) =>
    {
        context.Request.EnableBuffering();
        context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
        context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
        context.Response.Headers.Append("X-Xss-Protection", "1; mode=block");
        context.Response.Headers.Append("Referrer-Policy", "no-referrer");
        context.Response.Headers.Append("X-Permitted-Cross-Domain-Policies", "none");
        //context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'");
        await next();
    });

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseCors("CorsPolicy");

    app.MapControllers();
    if (app.Environment.IsDevelopment())
    {
        app.MapSwagger();
    }


    logger.Info("WebApi initialized");
    app.Run();

}
catch (Exception ex)
{
    logger.Fatal(ex);
}
finally
{
    logger.Info("WebApi Ended");
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

public partial class Program { }