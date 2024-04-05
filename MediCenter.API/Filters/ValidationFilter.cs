using Microsoft.AspNetCore.Mvc.Filters;

namespace MediCenter.API.Filters;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var message = context.ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}