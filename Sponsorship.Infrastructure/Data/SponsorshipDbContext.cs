
using Microsoft.EntityFrameworkCore;
using Sponsorship.Domain.Entities;
namespace Sponsorship.Infrastructure.Data;

public class SponsorshipDbContext : DbContext
{
    public SponsorshipDbContext(DbContextOptions<SponsorshipDbContext> options)
        : base(options)
    {
    }



    public DbSet<Departments> Departments { get; set; }
    public DbSet<SponsorshipRequests> SponsorshipRequests { get; set; }
    public DbSet<SponsorshipTypes> SponsorshipTypes { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<WorkflowStatus> WorkflowStatus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var createdAt = entityType.FindProperty("CreatedAt");
            if (createdAt != null)
            {
                createdAt.SetColumnType("timestamp with time zone");
            }

            var updatedAt = entityType.FindProperty("UpdatedAt");
            if (updatedAt != null)
            {
                updatedAt.SetColumnType("timestamp with time zone");
            }
        }
    }
}