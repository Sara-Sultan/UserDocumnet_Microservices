using Document.Application.CommandsMediatR;
using Document.Application.QueriesMediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Document.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDocumentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserDocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserDocumentByUserId(int userId)
        {
            var response = await _mediator.Send(new GetUserDocumentByUserIdQuery { UserId = userId });
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddNewUserDocumentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteUserDocumentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
