using BTSMonitoring.Data;
using MapTest.Data;
using MapTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapTest.Controllers
{
    public class BTSMapController : Controller
    {
        // GET: BTSMap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddBTS()
        {
            return View();
        }
        public ActionResult MapDetail()
        {
            return View();
        }
        public JsonResult DataMonitoringByAccount()
        {
            try
            {
                Bo_Bts_Account bo = new Bo_Bts_Account();
                DataTable dt = bo.GetAll();
                List<BTS_MONITORING> lst = new List<BTS_MONITORING>();
                if(dt==null || dt.Rows.Count == 0)
                {
                    return null;
                }
                foreach( DataRow item in dt.Rows)
                {
                    BTS_MONITORING bts = new BTS_MONITORING();
                    bts.ID = int.Parse(item["ID"].ToString().Trim());
                    bts.LAT = item["LAT"].ToString().Trim();
                    bts.LNG = item["LNG"].ToString().Trim();
                    bts.NAME = item["NAME"].ToString().Trim();
                    bts.IMAGE = item["IMAGE"].ToString().Trim();
                    lst.Add(bts);
                }
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public JsonResult DataControllers(string BTS_ID)
        {
            return Json(GetLocationsControllerOfBTS(BTS_ID), JsonRequestBehavior.AllowGet);
        }
        public List<CONTROLLER_LOCATION> GetLocationsControllerOfBTS(string BTS_ID)
        {
            try
            {
                List<CONTROLLER_LOCATION> lst = new List<CONTROLLER_LOCATION>();
                Bo_Bts_Monitoring bo = new Bo_Bts_Monitoring();
                DataTable dt = bo.GetDTControllerLocation(BTS_ID);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return null;
                }
                foreach (DataRow item in dt.Rows)
                {
                    CONTROLLER_LOCATION con = new CONTROLLER_LOCATION();
                    con.ID = item["ID"].ToString();
                    con.BTS_ID = int.Parse(item["BTS_ID"].ToString().Trim());
                    con.NAME = item["NAME"].ToString();
                    con.LEFT = int.Parse(item["LEFT"].ToString().Trim());
                    con.TOP = int.Parse(item["TOP"].ToString().Trim());
                    con.TEMP = float.Parse(item["TEMP"].ToString().Trim());
                    con.HUMI = float.Parse(item["HUMI"].ToString().Trim());
                    lst.Add(con);
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }
    }
}