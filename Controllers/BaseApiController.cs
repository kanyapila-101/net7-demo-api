using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace net7_demo_api.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IActionResult Problem(List<ErrorOr.Error> errors)
        {
            if (errors.Count is 0)
                return Problem();

            //For this category we might have an array of errors which we need to show to the user
            if (errors.All(e => e.Type == ErrorType.Validation))
            {
                var modelStateDict = new ModelStateDictionary();
                foreach (var error in errors)
                {
                    modelStateDict.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem(modelStateDict);
            }

            HttpContext.Items["errors"] = errors;

            var firstError = errors[0];
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}