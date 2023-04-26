using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrabajoPractico3.Models;

namespace TrabajoPractico3.Context;

public partial class TrabajoPractico3Context : DbContext
{
    public TrabajoPractico3Context()
    {
    }

    public TrabajoPractico3Context(DbContextOptions<TrabajoPractico3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonasInformacion> PersonasInformacion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonasInformacion>(entity =>
        {
            entity.ToTable("PersonasInformacion");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nacionalidad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
