using AutoMapper;
using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITokenService, TokenService>();

var builderIdentity = builder.Services.AddIdentityCore<User>();

builderIdentity = new IdentityBuilder(builderIdentity.UserType, builderIdentity.Services);

builderIdentity.AddEntityFrameworkStores<AuthDbContext>();
builderIdentity.AddSignInManager<SignInManager<User>>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = false
    };
});

var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfiles()));

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<MarketDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));

builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// Add services to the container.
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddControllers();

builder.Services.AddCors(option => option.AddPolicy("CorsRule", rule => rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

// app.UseHttpsRedirection();
app.UseStatusCodePagesWithReExecute("/errors", "?code={0}");

app.UseCors("CorsRule");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using (var environment = app.Services.CreateScope())
{
    var services = environment.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = services.GetRequiredService<MarketDbContext>();

        await context.Database.MigrateAsync();

        await MarketDbContextData.LoadDataAsync(context, loggerFactory);

        var userManager = services.GetRequiredService<UserManager<User>>();
        var identityContext = services.GetRequiredService<AuthDbContext>();

        await identityContext.Database.MigrateAsync();
        await AuthDbContextData.SeedUserAsync(userManager);
    }
    catch (Exception exception)
    {
        var logger = loggerFactory.CreateLogger<Program>();

        logger.LogError(exception, "Se produjo un error al realizar la migración de la base de datos.");
    }
}

app.Run();
