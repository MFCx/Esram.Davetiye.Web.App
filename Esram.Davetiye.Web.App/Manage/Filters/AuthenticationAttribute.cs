using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Manage.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context.HttpContext.Request.Cookies["_edul"];
            if (id == null)
            {
                var dictionary = new RouteValueDictionary();
                dictionary.Add("controller", "account");
                dictionary.Add("action", "login");
                dictionary.Add("area", "ritapanel");
                context.Result = new RedirectToRouteResult(dictionary);
            }
        }
    }
}
