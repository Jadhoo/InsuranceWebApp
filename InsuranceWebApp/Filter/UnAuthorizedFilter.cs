using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InsuranceWebApp.Filter
{
    public class UnAuthorizedFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAdmin = Convert.ToString(HttpContext.Current.Session["Role"]) == "admin" ? true : false;
            if (isAdmin)
            {
                return;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller","User" },
                    {"action","Unauthorize" }
                }
                );
            }
            base.OnActionExecuting(filterContext);

        }
    }
}