using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Privnote.DAL;
using Privnote.DAL.RepositoriesImpl;
using Privnote.DomainModel.Managers.NotesManager;
using Privnote.DomainModel.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var dbHost = Environment.GetEnvironmentVariable("DATABASE_HOST");
var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
var dbName = Environment.GetEnvironmentVariable("DATABASE_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
var dbPort = Environment.GetEnvironmentVariable("DATABASE_PORT");

var connectionString = environment == "Development" 
    ? builder.Configuration.GetConnectionString("DbConnectionString") 
    : $"server={dbHost};port={dbPort};database={dbName};uid={dbUser};password={dbPassword};";

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseNpgsql(connectionString);
});

builder.Services.AddAutoMapper(config => config.AddExpressionMapping(), AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<INoteRepository, NoteRepository>();
builder.Services.AddTransient<INoteManager, NoteManager>();

var app = builder.Build();

var dbContext = app.Services.GetRequiredService<ApplicationContext>();
dbContext.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();