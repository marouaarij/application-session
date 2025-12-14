namespace application_session.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    public class RequireLoginFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isLogged = context.HttpContext.Session.GetString("isLogged");
            Console.WriteLine($"[DEBUG] isLogged = {isLogged}");

            if (isLogged != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
