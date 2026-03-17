using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cursos.API.Filters;

public class ValidacaoModelStateCustomizado : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
            context.Result = new BadRequestObjectResult(errors);
        }
    }
}