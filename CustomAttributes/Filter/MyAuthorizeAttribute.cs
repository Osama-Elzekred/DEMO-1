using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DEMO_1.CustomAttributes.Filter
{
    public class MyAuthorizeAttribute: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // check if the user is authenticated
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // if not, redirect to the login page
                context.Result = new ContentResult{
                Content="LOGIN IN FRIST YA 7ARAMY "};  
            }
            
            //base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
