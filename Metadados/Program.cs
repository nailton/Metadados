using Metadados.Data;
using Metadados.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IContaService, ContaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS for development and production environments (adjust origins as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        policy =>
        {
            // Allow requests from specific origins during development
            if (builder.Environment.IsDevelopment())
            {
                policy.WithOrigins("http://localhost:63343").AllowAnyMethod().AllowAnyHeader();
            }
            else  // Allow requests from your production frontend domain(s)
            {
                policy.WithOrigins("https://your-production-domain.com").AllowAnyMethod().AllowAnyHeader();
            }
        });
});

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
app.UseCors("AllowMyOrigin"); // Apply CORS middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();