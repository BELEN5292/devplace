using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevPlace.Blog.API.Domain.Respositorio;
using DevPlace.Blog.API.Repository;

namespace DevPlace.Blog.API.Domain.Models
{
    public class ArticuloBlog : EntityBase
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public string Tags { get; set; }

        public virtual ICollection<ComentarioBlog> Comentarios { get; set; } = new List<ComentarioBlog>();
    }
}
