using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Request;

namespace NossoMercadoLivreAPI.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// Salva Categoria.
        /// </summary>
        /// <param name="categoryRepository"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost("saveCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save([FromServices] ICategoryRepository categoryRepository, [FromBody]CategoryRequest category)
        {
            Category categorySave = new Category(category);

            await categoryRepository.InsertAsync(categorySave);

            return Ok();
        }
    }
}