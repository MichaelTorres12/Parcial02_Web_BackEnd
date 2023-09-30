using System;
using System.Collections.Generic;
using BackendAV100520TC100220.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAV100520TC100220.Context;

public partial class Av100520Tc100220Context : DbContext
{
    public Av100520Tc100220Context()
    {
    }

    public Av100520Tc100220Context(DbContextOptions<Av100520Tc100220Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Elecciones2019> Elecciones2019s { get; set; }

    public virtual DbSet<Vista2019> Vista2019s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=CC5-01\\SQLEXPRESS; database=AV100520_TC100220; integrated security=true; Encrypt=false; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elecciones2019>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__eleccion__3213E83F54D18F24");

            entity.ToTable("elecciones_2019");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Candidato)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("candidato");
            entity.Property(e => e.Departamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("departamento");
            entity.Property(e => e.Votos).HasColumnName("votos");
        });

        modelBuilder.Entity<Vista2019>(entity =>
        {
            entity
                .ToView("vista_2019");

            entity.Property(e => e.Candidato)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("candidato");
            entity.Property(e => e.CantidadDeVotos).HasColumnName("CantidadDeVotos");
            entity.Property(e => e.Porcentaje).HasColumnName("Porcentaje");
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Vista2019>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
