using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App_Parking.Controllers
{
    public class BaseController : Controller
    {
        protected string menuName;
        protected int priID;
        protected TICKET_MANAGEREntities3 db;
        // GET: BaseController
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {       
            var session = (ACCOUNT)Session["USER_SESSION"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}