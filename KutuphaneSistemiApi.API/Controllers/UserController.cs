using KutuphaneSistemiApi.Application.Attributes;
using KutuphaneSistemiApi.Application.Constants;
using KutuphaneSistemiApi.Application.Features.Commands.AppUser.CreateUser;
using KutuphaneSistemiApi.Application.Features.Commands.AppUser.DeleteUser;
using KutuphaneSistemiApi.Application.Features.Commands.AppUser.LoginUser;
using KutuphaneSistemiApi.Application.Features.Commands.AppUser.RefreshTokenLoginUser;
using KutuphaneSistemiApi.Application.Features.Commands.AppUser.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneSistemiApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response.Message);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromQuery] RefreshTokenLoginUserCommandRequest loginRequest)
        {
            var response = await _mediator.Send(loginRequest);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        [AuthorizeDefiniton(ActionType = Application.Enums.ActionType.Deleting, Menu = AuthorizeDefinitionConstants.User, Definiton = "Delete User")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest deleteUserCommandRequest)
        {
            var response = await _mediator.Send(deleteUserCommandRequest);
            return Ok(response.ResponseMessage);
        }
        [HttpPut("[action]")]
        [AuthorizeDefiniton(ActionType = Application.Enums.ActionType.Updating, Menu = AuthorizeDefinitionConstants.User, Definiton = "Update User")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest updateUserCommandRequest)
        {
            var response = await _mediator.Send(updateUserCommandRequest);
            return Ok(response.ResponseMessage);
        }
    }
}
