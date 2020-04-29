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
        /// Salva Usuário
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("saveUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save([FromServices] IUserRepository userRepository, [FromBody]UserRequest user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                User userSave = new User(user);

                await userRepository.InsertAsync(userSave);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}