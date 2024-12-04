using _3rdSemesterProject.DataAccess;
using Microsoft.Extensions.Configuration;
using WebAPI.DAL;

//TODO: Change Stub to acces the real db.
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IRouteDAO>(builder.Configuration.GetConnectionString("Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-S231_10503080;User ID=DMA-CSD-S231_10503080;Password=Password1!;TrustServerCertificate=True;")));
builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IOrderDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IRouteDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IDepartureDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));
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
