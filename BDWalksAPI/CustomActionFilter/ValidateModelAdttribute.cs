using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BDWalksAPI.CustomActionFilter
{
    public class ValidateModelAdttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (context.ModelState.IsValid ==false) 
            {
                context.Result = new BadRequestResult();
            }
        }

    }
}
