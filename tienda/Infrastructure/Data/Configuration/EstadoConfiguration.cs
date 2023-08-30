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
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estado");

            builder.Property(p=>p.NombreEstado)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p=>p.Pais)
            .WithMany(p => p.Estados)
            .HasForeignKey(p => p.IdPaisFk);
        }
    }
}