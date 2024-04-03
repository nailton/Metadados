using Metadados.Data;
using Metadados.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IContaService, ContaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Correctly configured DbContext with constructor
if (Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") == "InMemory")
{
    builder.Services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("Teste"); });
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlite("Data Source=Data/DB/banco.sqlite"); });
}

// Other services like controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();