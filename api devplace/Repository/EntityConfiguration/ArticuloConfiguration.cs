using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevPlace.Blog.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevPlace.Blog.API.Repository.EntityConfiguration.Extensions;
using DevPlace.Blog.API.Domain.Validation;

namespace DevPlace.Blog.API.Repository.EntityConfigurations
{
    public class ArticuloConfiguration : IEntityTypeConfiguration<ArticuloBlog>
    {
        public void Configure(EntityTypeBuilder<ArticuloBlog> builder)
        {

            builder.Property(a => a.Titulo).IsRequired().HasMaxLength(ArticuloBlogValidacion.Constraints.TituloMaxLength);
            builder.Property(a => a.Descripcion).IsRequired().HasMaxLength(ArticuloBlogValidacion.Constraints.DescripcionMaxLenght);
            builder.Property(a => a.Contenido).HasMaxLength(ArticuloBlogValidacion.Constraints.ContenidoMaxLenght);
            builder.Property(a => a.Tags).HasMaxLength(ArticuloBlogValidacion.Constraints.ContenidoTagsMaxLenght);
            builder.ConfigureEntityBase();
            builder.HasMany(a => a.Comentarios).WithOne(c => c.Articulo).HasForeignKey(a => a.ArticuloId);
        }

    }
}