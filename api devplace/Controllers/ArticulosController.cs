using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevPlace.Blog.API.Domain.DTOs;
using DevPlace.Blog.API.Domain.Models;
using DevPlace.Blog.API.Domain.Validation;
using DevPlace.Blog.API.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevPlace.Blog.API.Controllers
{
    [ApiController]
    [Route("ArticuloBlog")]
    public class ArticulosController : ControllerBase
    {
        private readonly DbContextApi _dbContext;
        private readonly ArticuloBlogValidacion _articuloValidator;
        private readonly IMapper _mapper;

        public ArticulosController(
            DbContextApi context,
            ArticuloBlogValidacion articuloValidator,
            IMapper mapper)
        {
            this._dbContext = context ?? throw new ArgumentNullException(nameof(context));
            this._articuloValidator = articuloValidator;
            this._mapper = mapper;
        }

        [HttpGet()]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<ArticuloBlog>>> GetArticlesAsync()
        {
            var articulos = await _dbContext.Articulos.ToListAsync();
            var articulosDto = _mapper.Map<IEnumerable<ArticuloDto>>(articulos);
            return Ok(articulosDto);
        }

        [HttpPost()]
        public async Task<ActionResult<ArticuloBlog>> PostAsync(CrearArticuloDto articuloDto)
        {
            // Convertir el dto de entrada a una entidad de base de datos.
            ArticuloBlog dbArticulo = _mapper.Map<ArticuloBlog>(articuloDto);

            // Ref: FluentValidator: https://docs.fluentvalidation.net/en/latest/aspnet.html
            var result = await _articuloValidator.ValidateAsync(dbArticulo);
            if (!result.IsValid)
            {
                // Agregar mensajes de validación a ModelState.
                result.AddToModelState(ModelState, null);
                // Retornar el modelState como respuesta en formato json.
                return ValidationProblem(ModelState);
            }

            _dbContext.Articulos.Add(dbArticulo);
            await _dbContext.SaveChangesAsync();

            var nuevoArticuloDto = _mapper.Map<ArticuloDto>(dbArticulo);
            return Ok(nuevoArticuloDto);
        }
    }
}
