namespace Restorent
{
    public static class RedirectInvalidPathMiddlewareExtensions
    {
        public static IApplicationBuilder UseRedirectInvalidPathMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RedirectInvalidPathMiddleware>();
        }
    }
    public class RedirectInvalidPathMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectInvalidPathMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the requested path is valid (you can customize this condition)
            if (!IsValidPath(context.Request.Path))
            {
                // Redirect to the login page
                context.Response.Redirect("/Admin/Account/Login");
                return;
            }

            await _next(context);
        }

        private bool IsValidPath(PathString path)
        {
            // Customize this method based on your requirements
            // For example, you might check against a list of valid paths
            return path.StartsWithSegments("/ValidPath1") || path.StartsWithSegments("/ValidPath2");
        }
    }

}
