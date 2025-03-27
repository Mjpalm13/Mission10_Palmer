using Microsoft.EntityFrameworkCore;
using Mission10.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Establish the Sqlite connection for the database
builder.Services.AddDbContext<BowlingLeagueContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DbConnection")));

// Add Cors for using a specific port
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Establish what port localhost would be using to access the data 
app.UseCors(x => x.WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();