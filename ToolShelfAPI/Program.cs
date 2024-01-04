using System.Data.SqlClient;
using ToolShelfAPI.Data;
using ToolShelfAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = "Server=DESKTOP-8VCQBC7\\SQLEXPRESS;Database=ToolShelf;Integrated Security=True;";
builder.Services.AddSingleton(new SqlConnection(connectionString));
builder.Services.AddSingleton<IHomeDataLayer, HomeDataLayer>();
builder.Services.AddSingleton<IHomeService, HomeService>();
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
