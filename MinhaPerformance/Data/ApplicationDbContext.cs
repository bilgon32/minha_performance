using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using MinhaPerformance.Models;
using System.Reflection.Metadata;

namespace MinhaPerformance.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<HistoricoFeedback>()
            .HasOne<ApplicationUser>(hf => hf.Provedor)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<HistoricoFeedback>()
            .HasOne<ApplicationUser>(hf => hf.Receptor)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Criterio> Criterios { get; set; }
    public DbSet<HistoricoFeedback> HistoricoFeedbacks { get; set; }
    public DbSet<HistoricoFeedbackCriterio> HistoricoFeedbackCriterios { get; set; }
}

