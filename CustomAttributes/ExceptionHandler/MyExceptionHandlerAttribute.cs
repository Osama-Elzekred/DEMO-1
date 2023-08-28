using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DEMO_1.CustomAttributes.ExceptionHandler
{
    public class MyExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext context)
        {
           
            if (!context.ExceptionHandled) // Make sure the exception hasn't already been handled
            {
                // Log the exception or perform any desired error handling here

                // You can customize the response based on the exception type or any other criteria
                if (context.Exception is FormatException)
                {
                    // Handle FormatException, for example, return a specific view or response
                    context.Result = new ContentResult { Content = "ERROR YA A7WAL 1" };
                }
                else
                {
                    // For other exceptions, you can set a generic error view or response
                    context.Result = new ContentResult { Content = "ERROR YA A7WAL 2" };
                }

                // Mark the exception as handled
                context.ExceptionHandled = true;
            }

            base.OnException(context);
            //base.OnActionExecuting(context);
        }

        
    }
}
