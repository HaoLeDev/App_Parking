using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Parking.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View("Dashboard");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}