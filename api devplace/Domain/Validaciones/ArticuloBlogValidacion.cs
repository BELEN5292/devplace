using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPlace.Blog.API.Domain.Validacion
{
    public class ArticuloBlogValidacion
    {
        public class Constraints
        {
            public static int TituloMaxLength = 50;
            public static int DescripcionMaxLenght = 500;
            public static int ContenidoMaxLenght = 8000;
            public static int ContenidoTagsMaxLenght = 50;
        }
    }
}
