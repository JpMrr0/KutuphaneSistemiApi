using KutuphaneSistemiApi.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneSistemiApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthServicesController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthServicesController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var endpoints = _authService.GetAuthorizeDefinitonEndpoints(typeof(Program));
            return Ok(endpoints);
        }
    }
}
