namespace Datos.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<General> General { get; set; }
        public virtual DbSet<Horas> Horas { get; set; }
        public virtual DbSet<Requerimiento> Requerimiento { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<General>()
            //    .Property(e => e.Codigo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<General>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<General>()
            //    .Property(e => e.Valor)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Horas>()
            //    .Property(e => e.Detalle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Horas>()
            //    .Property(e => e.Horas1)
            //    .HasPrecision(18, 0);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.Detalle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.Prioridad)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.TipoRequerimiento)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.ArchivoAdjunto)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.AliasArchivo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.Estado)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.Avance)
            //    .HasPrecision(16, 2);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.TiempoEstimado)
            //    .HasPrecision(18, 0);

            //modelBuilder.Entity<Requerimiento>()
            //    .Property(e => e.Proyecto)
            //    .IsUnicode(false);

            modelBuilder.Entity<Requerimiento>()
                .HasMany(e => e.Horas)
                .WithOptional(e => e.Requerimiento)
                .HasForeignKey(e => new { e.IdRequerimiento, e.IdUsuario });

            //modelBuilder.Entity<Rol>()
            //    .Property(e => e.NombreRol)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .Property(e => e.Nombres)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .Property(e => e.Apellidos)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .Property(e => e.Correo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .Property(e => e.Direccion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .Property(e => e.Password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .Property(e => e.Usuario1)
            //    .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Requerimiento)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
