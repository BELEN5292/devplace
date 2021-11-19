using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPlace.Blog.API.Domain.DTOs
{
    public class ArticuloDto
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public string Tags { get; set; }
    }
}
