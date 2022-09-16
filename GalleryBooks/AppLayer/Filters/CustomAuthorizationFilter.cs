using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AppLayer.Filters
{
        public class CustomAuthorizationFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                string currentUser = context.HttpContext.Session.GetString("Email");
                if (string.IsNullOrEmpty(currentUser))
                {
                    //throw new UnauthorizedAccessException();
                    context.Result = new RedirectToRouteResult(new
                    {
                        controller = "Admin",
                        action = "Login"
                    });
                }

            }
        }

        public class AuthorizeAttribute : TypeFilterAttribute
        {
            public AuthorizeAttribute() : base(typeof(CustomAuthorizationFilter))
            {

            }
        }

    
}
