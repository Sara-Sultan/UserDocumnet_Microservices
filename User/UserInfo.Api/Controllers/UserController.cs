using UserInfo.Application.CommandsMediatR;
using UserInfo.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserInfo.Application.QueriesMediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserInfo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery { Id = id });
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddNewUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

            // _createCommand.Execute(user);
            // return new HttpResponseMessage(HttpStatusCode.Created);
        }



        //[HttpPut("[action]")]
        //public async Task<IActionResult> UpdateUser(UpdateUseCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    return NoContent();
        //}


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
