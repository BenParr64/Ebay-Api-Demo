using AutoMapper;
using EbayApiExample.Services;
using EbayApiExample.Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servoces
builder.Services.AddScoped<IEbayApiService, EbayApiService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

builder.Services.AddSingleton(new MapperConfiguration(mc =>
{
    mc.AddProfile(new InventoryItemProfile());
}).CreateMapper());


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