using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using NossoMercadoLivreAPI.Application.Controllers.Base;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;
using System.Threading.Tasks;
using FluentValidation;

namespace NossoMercadoLivreAPI.Application.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        /// Salva Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Save([FromBody]UserRequest user)
        {
            try
            {
                return Ok(await _userService.SaveUserAsync(user));
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody]UserUpdateRequest user)
        {
            try
            {
                return Ok(await _userService.UpdateUserAsync(user));
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAllAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca usuário pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                return Ok(await _userService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}