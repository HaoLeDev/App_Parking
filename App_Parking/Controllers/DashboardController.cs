using BusinessEntities;
using Newtonsoft.Json;
using RestSharp;
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
            return RedirectToAction("GetAll");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        //public ActionResult GetAll()
        //{
        //    var client = new RestClient("https://restcountries.eu");
        //    var request = new RestRequest("rest/v2/all?fields=name;capital;currencies", Method.GET);
        //    //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
        //    //request.AddUrlSegment("id", "123");
        //    IRestResponse response = client.Execute(request);
        //    var content = response.Content; // raw content as string
        //    CountryName[] items = JsonConvert.DeserializeObject<CountryName[]>(content);
        //    // or automatically deserialize result
        //    // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
        //    //var response2 = client.Execute<RootObject>(request);
        //    //var name = response2.Data.name;
        //    //return Json(items, JsonRequestBehavior.AllowGet);
        //    return View("~/Views/Dashboard/Dashboard.cshtml", JsonRequestBehavior.AllowGet);
        //}
    }
}