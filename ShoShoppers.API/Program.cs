using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using ShoShoppers.Api.Options;
using ShoShoppers.API.CustomMiddleware;
using ShoShoppers.Bll.Options;
using ShoShoppers.Bll.Services;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using System.Reflection;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

const string developmentPolicy = "_DevelopmentPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllersWithViews(configure => { configure.ReturnHttpNotAcceptable = true; })
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<AdminInfoOptions>(builder.Configuration.GetSection("AdminInfo"));
builder.Services.Configure<EmailInformationOptions>(builder.Configuration.GetSection("EmailInformation"));
builder.Services.Configure<NpInfoOptions>(builder.Configuration.GetSection("NpInfo"));

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("ShoShoperAPISpecification", new OpenApiInfo
    {
        Title = "ShoShopper API",
        Description = "Using this api you can manipulate shopers and sending emails",
        Contact = new OpenApiContact
        {
            Email = "denis110402@gmail.com",
            Name = "Fedorov Denys",
            Url = new Uri("https://t.me/Shindd")
        }
    });

    setupAction.AddSecurityDefinition("ShoShopersApiBearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Input a valid token to access this API"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ShoShopersApiBearerAuth"
                }
            },
            new List<string>()
        }
    });

    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});

builder.Services.AddScoped<IEMailService, EMailService>();
builder.Services.AddScoped<IPinService, PinService>();
builder.Services.AddScoped<IShopperService, ShopperService>();
builder.Services.AddScoped<IIndividualDesignService, IndividualDesignService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSingleton<INpService, NpService>();
builder.Services.AddHttpClient<INpService, NpService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var mySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 30));
builder.Services.AddDbContext<ShoShoppersContext>(dbContextOptions =>
{
    dbContextOptions.UseMySql(
                     builder.Configuration["ConnectionStrings:ShoShoperDbConnectionString"],
                     mySqlServerVersion, options => { options.EnableRetryOnFailure(); options.MigrationsAssembly("ShoShoppers.Dal"); });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(developmentPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:46633", "http://localhost:5003")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AdminInfo:SecretForKey"]))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseHsts();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint("/swagger/ShoShoperAPISpecification/swagger.json", "ShoShoper API");
        setupAction.RoutePrefix = string.Empty;
    });
}

app.UseCors(developmentPolicy);

app.UseMiddleware<HttpStatusCodeCustomExceptionMiddleware>();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();