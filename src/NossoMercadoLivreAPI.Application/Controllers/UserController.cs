using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Request;
using FluentValidation;
using FluentValidation.Results;
using NossoMercadoLivreAPI.Util;

namespace NossoMercadoLivreAPI.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<UserRequest> _validator;

        public UserController(IValidator<UserRequest> validator)
        {
            _validator = validator;
        }

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
                ValidationResult result = _validator.Validate(user, ruleSet: "all");

                if (result.IsValid)
                {
                    var userEntity = await userRepository.GetOneByFilterAsync(u => u.Email == user.Email);
                    if (userEntity != null)
                        throw new ArgumentException(MessagesAPI.USER_ALREADY_EXISTS);

                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                    UserEntity userSave = new UserEntity(user);

                    await userRepository.InsertAsync(userSave);

                    return Ok();
                } 
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}