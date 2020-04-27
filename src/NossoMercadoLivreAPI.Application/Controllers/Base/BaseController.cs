using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivreAPI.Domain.Const;

namespace NossoMercadoLivreAPI.Application.Controllers.Base
{
    [Route("api/[controller]")]
    [EnableCors(Policy.AllowAll)]
    [Produces("application/json")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}