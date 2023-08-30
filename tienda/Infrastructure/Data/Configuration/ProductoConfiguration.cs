using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto>builder)
        {
            builder.ToTable("producto");

            builder.Property(p=>p.NombreProducto)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p=>p.StockMin)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p=>p.StockMax)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p=>p.Stock)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p=>p.ValorVta)
            .IsRequired()
            .HasColumnType("double");
        }
    }
