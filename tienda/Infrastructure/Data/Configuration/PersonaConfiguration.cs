using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona>builder)
        {
            builder.ToTable("persona");

            builder.Property(p=>p.IdPersona)
            .IsRequired()
            .HasMaxLength(15);

            builder.Property(p=>p.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p=>p.FechaNac)
            .IsRequired()
            .HasColumnType("Date");

            builder
            .HasMany(p=>p.Productos)
            .WithMany(p =>p.Personas)
            .UsingEntity<ProductoPersona>(
                j=>j
                    .HasOne(pt =>pt.Producto)
                    .WithMany(t =>t.ProductosPersonas)
                    .HasForeignKey(pt =>pt.IdProductoFk ),
                j=> j
                    .HasOne(pt =>pt.Persona)
                    .WithMany(t =>t.ProductosPersonas)
                    .HasForeignKey(pt =>pt.IdPersonaFk ),
                j=>
                {
                    j.HasKey(t => new { t.IdProductoFk, t.IdPersonaFk});
                }
            );
            
            builder
            .HasOne(p => p.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTipoPerFk);
        }
    }
}