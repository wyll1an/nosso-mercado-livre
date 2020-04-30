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
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Salva Usuário. O campo password deve ser passado sem criptografia. A criptografia é gerada ao inserir usuário.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("saveUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save([FromServices] IUserRepository userRepository, [FromBody]UserRequest user)
        {
            User userSave = new User(user);

            await userRepository.InsertAsync(userSave);

            return Ok();
        }
    }
}