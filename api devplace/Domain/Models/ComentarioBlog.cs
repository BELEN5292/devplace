using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevPlace.Blog.API.Domain.Respositorio;
using DevPlace.Blog.API.Repository;

namespace DevPlace.Blog.API.Domain.Models
{
    public class ComentarioBlog : EntityBase
    {
        public string Texto { get; set; }

        public int ArticuloId { get; set; }
        public ArticuloBlog Articulo { get; set; }        
    }
}

