using Application.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.BaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController:ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
        public IActionResult CreateActionResultInstance<T>(ResponseDto<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
