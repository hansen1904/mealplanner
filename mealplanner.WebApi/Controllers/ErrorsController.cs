using mealplanner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mealplanner.WebApi.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Index()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                Error customError => ((int)customError.StatusCode, customError.ErrorMessage),
                _ => ((int)HttpStatusCode.InternalServerError, "An unexcepted error occured."),
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}
