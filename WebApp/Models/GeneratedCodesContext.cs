using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Code_Generator_Web_App.Models;

public partial class GeneratedCodesContext : DbContext
{
    private readonly IConfiguration _configuration;

    // Constructor to inject configuration
    public GeneratedCodesContext(DbContextOptions<GeneratedCodesContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }


    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Retrieve the connection string from appsettings.json
        var connectionString = _configuration.GetConnectionString("GeneratedCodes");
        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Code>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Codes__3214EC07EEC42B3D");

            entity.HasIndex(e => e.TheCode, "UQ__Codes__A25C5AA710361EA9").IsUnique();

            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TheCode).HasMaxLength(8);

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Codes)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Codes__Status__3A81B327");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC27079EF63E");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.State).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
