using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevPlace.Blog.API.Domain.Models;
using DevPlace.Blog.API.Repository;
using Microsoft.AspNetCore.Mvc;


namespace DevPlace.Blog.API.Controllers
{
    [ApiController]
    [Route("ArticuloBlog")]
    public class ArticulosController : ControllerBase
    {
        private readonly DbContextApi _DbContext;

        public ArticulosController(DbContextApi context)
        {
            this._DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet()]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<ArticuloBlog>>> GetArticlesAsync()
        {
            return await Task.FromResult(Ok(_DbContext.Articulos));
        }
    }
}
