using AppShip.ActionClass;
using AppShip.Interface;
using AppShip.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectingString = builder.Configuration.GetConnectionString("ConnectDb");
builder.Services.AddDbContext<ShipShipContext>(options => options.UseSqlServer(connectingString));
builder.Services.AddTransient<IUser, ClientClass>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
