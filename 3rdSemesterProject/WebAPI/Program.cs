using _3rdSemesterProject.DataAccess;
using Microsoft.Extensions.Configuration;
using WebAPI.DAL;

//TODO: Change Stub to acces the real db.
var builder = WebApplication.CreateBuilder(args);
// Here the builder assigns that any class that needs class for any of these Interfaces are given a DAO class corresponding with their need.
// Connectionstring defined as DefaultConnection in appsettings.json
// For release purposes change where the Connectionstring is stores for safety purposes
builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IOrderDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IRouteDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IDepartureDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IBoatDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
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
