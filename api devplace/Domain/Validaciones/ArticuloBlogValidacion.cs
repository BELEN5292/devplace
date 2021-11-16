using DevPlace.Blog.API.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPlace.Blog.API.Domain.Validation
{
    public class ArticuloBlogValidacion : AbstractValidator<ArticuloBlog>
    {
        public class Constraints
        {
            public static int TituloMaxLength = 50;
            public static int DescripcionMaxLenght = 500;
            public static int ContenidoMaxLenght = 8000;
            public static int ContenidoTagsMaxLenght = 50;
        }

        public ArticuloBlogValidacion()
        {
            // Agregar aqui las validaciones de cada campo en particular.
            // La validaciones básicas, generalmente son las mínimas,
            // las requeridas para persistir en la base de datos.
            // Es muy probable que sean igual a las que utilizamos en EntityConfiguration.
            // Pero puede haber otras adicionales, que no son requeridas por la base de datos
            // y si son requeridas por nuestra aplicación.
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(ArticuloBlogValidacion.Constraints.TituloMaxLength);

            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .MaximumLength(ArticuloBlogValidacion.Constraints.DescripcionMaxLenght);

            RuleFor(x => x)
                .Custom(ValidarArticulo);
        }

        private void ValidarArticulo(ArticuloBlog articulo, ValidationContext<ArticuloBlog> context)
        {
            ValidarTituloDistintoDescription(articulo, context);
            ValidarTituloNoContienePalabrasReservadas(articulo, context);
        }

        private void ValidarTituloDistintoDescription(ArticuloBlog articulo, ValidationContext<ArticuloBlog> context)
        {
            // Agregar aquí, las validaciones generales del modelo.
            // Aquellas que no son específicas de una sola propiedad, sino que son más complejas
            // o requieren otros servicios o lógicas adicionales.
            if (articulo.Titulo == articulo.Descripcion)
            {
                context.AddFailure(new ValidationFailure(
                    propertyName: nameof(ArticuloBlog.Titulo),
                    errorMessage: "El 'Titulo' debe ser distinto a la 'Descripción'"));
            }
        }

        private void ValidarTituloNoContienePalabrasReservadas(ArticuloBlog articulo, ValidationContext<ArticuloBlog> context)
        {
            // Otras validaciones aqui.
        }
    }
}
