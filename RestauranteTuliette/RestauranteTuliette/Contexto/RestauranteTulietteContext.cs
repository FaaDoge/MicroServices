using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Modelos.Entity;

namespace RestauranteTuliette.Contexto;

public partial class RestauranteTulietteContext : DbContext
{
    public RestauranteTulietteContext()
    {
    }

    public RestauranteTulietteContext(DbContextOptions<RestauranteTulietteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bebidum> Bebida { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=RestauranteTuliette; Integrated Security=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bebidum>(entity =>
        {
            entity.HasKey(e => e.IdBebida).HasName("PK__Bebida__A111F0E3B5D7E393");

            entity.HasOne(d => d.IdIngredienteNavigation).WithMany(p => p.Bebidas).HasConstraintName("FK__Bebida__idIngred__3C69FB99");
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngrediente).HasName("PK__Ingredie__3DA4DD6021E74CBB");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC38AB35B7E");

            entity.HasOne(d => d.IdBebidaNavigation).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedido__IdBebida__4316F928");

            entity.HasOne(d => d.IdPlatoNavigation).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedido__IdPlato__4222D4EF");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedido__idUbicac__412EB0B6");
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.HasKey(e => e.IdPlato).HasName("PK__Plato__4C9439207D565DA9");

            entity.HasOne(d => d.IdIngredienteNavigation).WithMany(p => p.Platos).HasConstraintName("FK__Plato__idIngredi__398D8EEE");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C7A6083A4");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK__Ubicacio__778CAB1DA8E881EE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97B81A6CE2");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuario__IdRol__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
