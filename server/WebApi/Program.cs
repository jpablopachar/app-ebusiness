using AutoMapper;
using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfiles()));

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<MarketDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));

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
    }
    catch (Exception exception)
    {
        var logger = loggerFactory.CreateLogger<Program>();

        logger.LogError(exception, "Se produjo un error al realizar la migración de la base de datos.");
    }
}

app.Run();
