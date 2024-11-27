using _3rdSemesterProject.DataAccess;
using Microsoft.Extensions.Configuration;
using WebAPI.DAL;

//TODO: Change Stub to acces the real db.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped((sc) => DAOFactory.CreateRepository<IOrderDAO>(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDeparturesDAO, DeparturesDAOStub>();
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
