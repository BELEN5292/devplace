using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevPlace.Blog.API.Domain.Models;
using DevPlace.Blog.API.Domain.Validaciones;
using DevPlace.Blog.API.Repository.EntityConfiguration.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevPlace.Blog.API.Repository.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<ComentarioBlog>
    {
        public void Configure(EntityTypeBuilder<ComentarioBlog> builder)
        {
            

            builder.Property(c => c.Texto).IsRequired().HasMaxLength(ComentarioBlogValidacion.Constraints.TextoMaxLength);
          
            builder.HasOne(c => c.Articulo).WithMany(a => a.Comentarios).HasForeignKey(a => a.ArticuloId);
            builder.ConfigureEntityBase();
        }
    }
}
