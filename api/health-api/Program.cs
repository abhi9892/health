using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using health_api._Shared.dbc.auth;
using health_api._Shared;
// ## inceptor code block placeholder for imports ## //

var builder = WebApplication.CreateBuilder(args);

//Set up Logging
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//Set up Services
var services = builder.Services;


services.AddEndpointsApiExplorer();
services.AddCors();
services.AddMediatR( cfg=>cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
services.AddDbContext<AuthContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("default")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// ## inceptor code block placeholder ## //

//var appAuth = new AppAuth(builder.Configuration);
//services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(appAuth.GetJwtBearerOptions);
//services.AddAuthorization(appAuth.GetAuthorizationOptions);

JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    MaxDepth = 10,
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};
serializerOptions.Converters.Add(new JsonStringEnumConverter());
services.AddSingleton(s => serializerOptions);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.Logger.LogInformation("The application started");


app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader()); ;
app.UseHttpsRedirection();


//app.UseAuthentication();

//app.UseAuthorization();

app.MapSharedEndpoints();
app.Run();

