using App_Parking.Common;
using App_Parking.Models;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Parking.Controllers
{
    public class QuanLyDonViTinhController : BaseController
    {
        // GET: QuanLyDonViTinh
        public QuanLyDonViTinhController()
        {
            db = new BusinessEntities.TICKET_MANAGEREntities3();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll(JqueryDataTableParamModel model)
        {
            try
            {
                var donvi = db.UNITs.ToList().OrderBy(s=>s.UNIT_ID);
                if (!string.IsNullOrWhiteSpace(model.sSearch))
                {
                    string search = model.sSearch.Trim().ToUpper();
                    donvi = donvi.Where(d => (d.UNIT_NAME ?? "").ToUpper().Contains(search) || (d.UNIT_CODE ?? "").ToUpper().Contains(search)).OrderBy(d => d.UNIT_ID);
                }
                switch (model.iSortCol_0)
                {
                    case 1:
                        {
                            if (model.sSortDir_0 == "asc")
                                donvi = donvi.OrderBy(s => s.UNIT_CODE);
                            else
                                donvi = donvi.OrderByDescending(s => s.UNIT_CODE);
                            break;
                        }
                    case 2:
                        {
                            if (model.sSortDir_0 == "asc")
                                donvi.OrderBy(s => s.UNIT_NAME);
                            else
                                donvi.OrderByDescending(s => s.UNIT_NAME);
                            break;
                        }
                    default: break;
                }

                var lst = donvi.Skip(model.iDisplayStart).Take(model.iDisplayLength).ToList();
                int count = db.UNITs.Count();
                
                var entity = new List<UnitModel>();
                foreach (var temp in lst)
                {
                    var tem = new UnitModel();
                    tem.UNIT_CODE = temp.UNIT_CODE;
                    tem.UNIT_DES = temp.UNIT_DES;
                    tem.UNIT_ID = temp.UNIT_ID;
                    tem.UNIT_NAME = temp.UNIT_NAME;
                    tem.UNIT_STATUS = temp.UNIT_STATUS;
                    entity.Add(tem);
                }
                return this.Json(new
                {
                    sEcho = model.sEcho,
                    iTotalRecords = count,
                    iTotalDisplayRecords = count,
                    data = entity
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            { 
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Insert(UnitModel model)
        {
            try
            {
                if (model.UNIT_ID > 0)
                {
                    UNIT unit = db.UNITs.Where(u => u.UNIT_ID == model.UNIT_ID).FirstOrDefault();
                    unit.UNIT_CODE = model.UNIT_CODE;
                    unit.UNIT_NAME = model.UNIT_NAME;
                    unit.UNIT_DES = model.UNIT_DES;
                    unit.UNIT_STATUS = model.UNIT_STATUS;
                    db.SaveChanges();
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    int check = db.UNITs.Where(u => u.UNIT_CODE == model.UNIT_CODE).Count();
                    if (check > 0)
                    {
                        return Json("Trùng mã đơn vị tính!", JsonRequestBehavior.AllowGet);
                    }
                    UNIT unit = new UNIT();
                    unit.UNIT_CODE = model.UNIT_CODE;
                    unit.UNIT_NAME = model.UNIT_NAME;
                    unit.UNIT_DES = model.UNIT_DES;
                    unit.UNIT_STATUS = model.UNIT_STATUS;
                    db.UNITs.Add(unit);
                    db.SaveChanges();
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetById(int UNIT_ID)
        {
            try
            {
                var unit = db.UNITs.Where(u => u.UNIT_ID == UNIT_ID).FirstOrDefault();
                return new JsonResult { Data = unit, JsonRequestBehavior=JsonRequestBehavior.AllowGet };
            }
            catch(Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Delete(int UNIT_ID)
        {
            try
            {
                UNIT unit = db.UNITs.Where(u => u.UNIT_ID == UNIT_ID).FirstOrDefault();
                if (unit != null)
                {
                    db.UNITs.Remove(unit);
                }
                db.SaveChanges();
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}