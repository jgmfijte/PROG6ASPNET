using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Filters
{
    public class LoggedInFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie login = HttpContext.Current.Request.Cookies["LoginCookie"];
            if (login == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

    }
}