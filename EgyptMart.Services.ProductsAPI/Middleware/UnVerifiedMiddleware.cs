namespace EgyptMart.Services.ProductsAPI.Middleware
{
    public class UnVerifiedMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);

            if (context.Response.StatusCode == 403 &&
                context.User.Identity?.IsAuthenticated == true &&
                !context.User.HasClaim("isVerified", "True"))
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"error\": \"Access denied: user is not verified.\"}");
            }
        }


    }
}
