using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DevPlace.Blog.API.Domain.Respositorio
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}
