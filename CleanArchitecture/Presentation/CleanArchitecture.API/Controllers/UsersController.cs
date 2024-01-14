using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanArchitecture.Aplication.UseCases.CreateUser;
using CleanArchitecture.Aplication.UseCases.GetAllUser;
using CleanArchitecture.Aplication.UseCases.UpdateUser;
namespace CleanArchitecture.API.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator){
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>>
        GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            // var validator = new CreateUserValidator();
            // var validationResult = await validator.ValidateAsync(request);

            // if (!validationResult.IsValid)
            // {
            //     return BadRequest(validationResult.Errors);
            // }
            
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        } 

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResponse>> 
        Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
           if (id != request.Id)
            {
                return BadRequest();
            }
            
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }



    }
}
