namespace Seventh.Desafio.Infra;

public class SeventhContext : DbContext
{
    public SeventhContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeventhContext).Assembly);
    }
}
