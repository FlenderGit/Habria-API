using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Infrastructure.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<TypeChapitre> Chapitres => Set<TypeChapitre>();
    public DbSet<Observation> Observations => Set<Observation>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Building>()
            .HasMany(a => a.Observations)
            .WithOne(a => a.Building)
            .HasForeignKey(a => a.BuildingId);

        modelBuilder.Entity<TypeChapitre>()
            .HasMany(a => a.RelatedTypeObservation)
            .WithOne(a => a.TypeChapitre)
            .HasForeignKey(a => a.TypeChapitreId);

        modelBuilder.Entity<TypeNotation>()
            .HasMany(a => a.Observations)
            .WithOne(a => a.TypeNotation)
            .HasForeignKey(a => a.TypeNotationId);

        modelBuilder.Entity<Observation>()
            .HasMany(a => a.SubObservations)
            .WithOne(a => a.Observation)
            .HasForeignKey(a => a.ObservationId);
    }

}
