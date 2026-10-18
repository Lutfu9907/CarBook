using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.CarDescriptionRepositories;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();

// Application katmanındaki tüm CQRS handler'larını (adı "Handler" ile biten sınıflar) tek seferde kaydeder.
// Yeni bir modül eklendiğinde buraya ayrıca satır eklemek gerekmez.
var handlerTypes = typeof(GetAboutQueryHandler).Assembly.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Handler"));
foreach (var handlerType in handlerTypes)
{
    builder.Services.AddScoped(handlerType);
}

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
