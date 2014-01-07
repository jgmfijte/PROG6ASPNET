using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelService.Filters
{
    public class MedewerkersFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie login = HttpContext.Current.Request.Cookies["LoginCookie"];
            if (login != null)
            {
                if(login["rol"] == "Medewerker")
                {
                }
                else
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "KlantNotAllowed";
                    result.ViewBag.ErrorMessage = "Je moet een medewerker zijn om deze pagina te zien...";
                    filterContext.Result = result;
                }
                
            }
            else {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

    }
}