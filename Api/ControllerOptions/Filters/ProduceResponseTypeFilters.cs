using EventsBookingBackend.Application.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventsBookingBackend.Api.ControllerOptions.Filters;

public class ProducesResponseTypesFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

        if (controllerActionDescriptor != null)
        {
            controllerActionDescriptor.MethodInfo
                .GetCustomAttributes(true)
                .OfType<ProducesResponseTypeAttribute>()
                .ToList()
                .ForEach(attribute => { context.Filters.Add(attribute); });

            context.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorModel),
                StatusCodes.Status500InternalServerError));
            context.Filters.Add(new ProducesResponseTypeAttribute(typeof(ValidationErrorModel),
                StatusCodes.Status400BadRequest));
        }
    }
}