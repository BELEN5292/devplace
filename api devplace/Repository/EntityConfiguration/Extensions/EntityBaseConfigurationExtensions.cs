using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DevPlace.Blog.API.Domain.Respositorio;
using Microsoft.EntityFrameworkCore;
using MetadataBuilder = Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevPlace.Blog.API.Repository.EntityConfiguration.Extensions
{
    public static class EntityBaseConfigurationExtensions 
    {
        internal static void ConfigureEntityBase<TEntity>(this MetadataBuilder.EntityTypeBuilder<TEntity> builder)
              where TEntity : class, IEntityBase
        {
            builder.HasKey(_ => _.Id);
          

}

    }
}
