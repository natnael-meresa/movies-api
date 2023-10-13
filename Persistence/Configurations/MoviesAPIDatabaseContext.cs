using Domain.Commmon;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configureations;

public class MoviesAPIDatabaseContext : DbContext
{


    public MoviesAPIDatabaseContext(DbContextOptions<MoviesAPIDatabaseContext> options) : base(options)
    {

    }

    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Cinema> Cinemas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=movies;Integrated Security=true;Pooling=true;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesAPIDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
        {
            entry.Entity.LastModifiedDate = DateTime.Now;
            entry.Entity.LastModifiedBy = "admin";

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "admin";
                entry.Entity.CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }


}