using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Ocorrencia> Ocorrencias { get; set; }
    
    public DbSet<Setor> Setor {get; set;}

    public DbSet<Usuario> usuario {get; set;}
}
