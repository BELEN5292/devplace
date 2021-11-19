using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPlace.Blog.API.Domain.DTOs
{
    /// <summary>
    /// Este DTO solo tiene las propiedades que son necesarias para crear un Articulo.
    /// </summary>
    public class CrearArticuloDto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public string Tags { get; set; }
    }
}
