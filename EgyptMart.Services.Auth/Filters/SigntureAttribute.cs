using System.Security.Claims;
using EgyptMart.Services.Auth.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EgyptMart.Services.Auth.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SigntureAttribute : ActionFilterAttribute
    {




        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                // Get the current user from the request context
                var user = context.HttpContext.User;

                // Try to get the "UserId" claim from JWT
                var usernameClaim = user.FindFirst(ClaimTypes.Name)?.Value;
                var userIDClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var pathnameRequest = context.HttpContext.Request.Path.Value?.Split("/").LastOrDefault();

                // Ensure required data is available
                if (string.IsNullOrEmpty(usernameClaim) || string.IsNullOrEmpty(userIDClaim) || string.IsNullOrEmpty(pathnameRequest))
                {
                    context.HttpContext.Response.Headers.Append("Sign-Invalid", "True");
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var key = Signing.GetMyKey(usernameClaim, pathnameRequest);

                if (context.HttpContext.Request.Headers.TryGetValue("sign", out var sign))
                {
                    var clearText = Signing.ValidateRequest(sign, key);

                    if (clearText == null)
                    {
                        context.HttpContext.Response.Headers.Append("Sign-Invalid", "True");
                        context.Result = new UnauthorizedResult();
                        return;
                    }


                    var parts = clearText.Split("@");

                    if (parts.Length < 2)
                    {
                        context.HttpContext.Response.Headers.Append("Sign-Invalid", "True");
                        context.Result = new UnauthorizedResult();
                        return;
                    }

                    var clearedUserID = parts[0];
                    var clearedDate = parts[1];

                    if (userIDClaim != clearedUserID)
                    {
                        context.HttpContext.Response.Headers.Append("Sign-Invalid", "True");
                        context.Result = new UnauthorizedResult();
                        return;
                    }


                    if (DateTime.TryParse(clearedDate, out DateTime clearedDateTime) &&
                        (DateTime.UtcNow - clearedDateTime).TotalMinutes > 5)
                    {
                        context.HttpContext.Response.Headers.Append("Sign-Invalid", "True");
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
                else
                {
                    context.HttpContext.Response.Headers.Append("Sign-Invalid", "True");
                    context.Result = new UnauthorizedResult();
                    return;
                }

                // ✅ All good, continue
                base.OnActionExecuting(context);
            }
            catch (Exception ex)
            {

                context.HttpContext.Response.Headers.Append("Sign-Invalid", "True");

                context.Result = new UnauthorizedResult(); // Fallback: unauthorized
            }
        }

    }
}
