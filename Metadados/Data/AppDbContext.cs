using Metadados.Models;
using Metadados.Services;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Data;

public class AppDbContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data/DB/banco.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}