using ISCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Data;

public class ISCCDbContext : DbContext
{
    public ISCCDbContext(DbContextOptions<ISCCDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Employer> Employers => Set<Employer>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Inspection> Inspections => Set<Inspection>();
    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<Session> Sessions => Set<Session>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ISCCDbContext).Assembly);
    }
}
