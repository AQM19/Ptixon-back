using Business.DTOs;
using Presentation.API.Extensions;
using Presentation.API.Middlewares;
using Presentation.VMs;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
    }
);

builder.Services.AddCustomParamsApplicationConfiguration(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSecurityConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddAuthenticationConfigurationExtension(builder.Configuration);
builder.Services.AddDataBaseContextConfiguration(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MapperProfileDTO).Assembly, typeof(MapperProfileVM).Assembly);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLoggerConfiguration(builder.Configuration);
//builder.Services.AddSwaggerGen();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors("StrictOrigin");

app.UseAuthentication();
app.UseAuthorization();
//app.UseRateLimiter();
app.MapControllers();

// Check migrations and seed the database
app.CheckMigrationsAndSeedDB();

app.Run();
