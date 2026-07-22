using Fiap.Cloud.Games.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Cloud.Games.Infra.Data.EntityFramework
{
  public class Contexto : DbContext
  {
    readonly string _defaultSchema;

    public static string DefaultSchema { get { return "dbo"; } }

    protected Contexto() : base() { }

    public Contexto(DbContextOptions<Contexto> options, string defaultSchema = "dbo") : base(options)
    {
      _defaultSchema = defaultSchema;

      this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<Usuario> Usuario { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema(_defaultSchema);

      
      modelBuilder.Entity<Usuario>(entity =>
      {
        entity.HasKey(x => x.Id)
                  .HasName("PK_Usuario");

        entity.ToTable("Usuario", "dbo");
        
      });
     

      base.OnModelCreating(modelBuilder);
    }
  }
}