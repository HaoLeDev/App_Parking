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
    public class TicketTypeManagerController : BaseController
    {
        public TicketTypeManagerController()
        {
            db = new TICKET_MANAGEREntities3();
            db.Configuration.AutoDetectChangesEnabled = false;
        }
        // GET: TicketType
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll(JqueryDataTableParamModel model)
        {
            try
            {
                var loaiVe = db.TICKET_TYPE.OrderBy(c => c.TYPEID);
                if (!string.IsNullOrWhiteSpace(model.sSearch))
                {
                    string search = model.sSearch.Trim().ToUpper();
                    loaiVe = loaiVe.Where(c => (c.TYPENAME.ToUpper().Contains(search) || c.DESCRIPTIONS.ToUpper().Contains(search) || c.TYPE_CODE.ToUpper().Contains(search))).OrderBy(c => c.TYPEID);
                }
                switch (model.iSortCol_0)
                {
                    case 1:
                        {
                            if (model.sSortDir_0 == "asc")
                                loaiVe = loaiVe.OrderBy(s => s.TYPENAME);
                            else
                                loaiVe = loaiVe.OrderByDescending(s => s.TYPENAME);
                            break;
                        }
                    case 2:
                        {
                            if (model.sSortDir_0 == "asc")
                                loaiVe.OrderBy(s => s.TYPE_CODE);
                            else
                                loaiVe.OrderByDescending(s => s.TYPE_CODE);
                            break;
                        }
                    default: break;
                }
                //Lấy bản ghi trả về view
                var lstArry = loaiVe.Skip(model.iDisplayStart).Take(model.iDisplayLength);
                int count = loaiVe.Count();

                var entity = new List<TicketTypeModel>();
                foreach(var item in lstArry)
                {
                    var ticket= new TicketTypeModel();
                    ticket.TYPEID = item.TYPEID;
                    ticket.TYPENAME = item.TYPENAME;
                    ticket.DESCRIPTIONS = item.DESCRIPTIONS;
                    ticket.TYPE_CHECK = item.TYPE_CHECK;
                    ticket.TYPE_CODE = item.TYPE_CODE;
                    entity.Add(ticket);
                }
                return this.Json(new
                {
                    sEcho = model.sEcho,
                    iTotalRecords = count,
                    iTotalDisplayRecords = count,
                    data = entity
                }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllJson()
        {
            try
            {

                List<TICKET_TYPE> lst = db.TICKET_TYPE.ToList();
                var entity = new List<TicketTypeModel>();
                foreach (var item in lst)
                {
                    var ticket = new TicketTypeModel();
                    ticket.TYPEID = item.TYPEID;
                    ticket.TYPENAME = item.TYPENAME;
                    ticket.DESCRIPTIONS = item.DESCRIPTIONS;
                    ticket.TYPE_CHECK = item.TYPE_CHECK;
                    ticket.TYPE_CODE = item.TYPE_CODE;
                    entity.Add(ticket);
                }
                return this.Json(new
                {
                    entity
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CapNhatLoaiVe(TicketTypeModel _model)
        {
            try
            {
                if (_model.TYPEID > 0)
                {
                    TICKET_TYPE ticketType = db.TICKET_TYPE.Where(s => s.TYPEID == _model.TYPEID).FirstOrDefault();
                    ticketType.TYPENAME = _model.TYPENAME;
                    ticketType.DESCRIPTIONS = _model.DESCRIPTIONS;
                    ticketType.TYPE_CHECK = _model.TYPE_CHECK;
                    ticketType.TYPE_CODE = _model.TYPE_CODE;
                    db.SaveChanges();
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    int checkTrungMaLoaiVe = db.TICKET_TYPE.Where(s => s.TYPE_CODE == _model.TYPE_CODE).Count();
                    if (checkTrungMaLoaiVe > 0)
                    {
                        return Json("Trùng mã loại vé", JsonRequestBehavior.AllowGet);
                    }
                    TICKET_TYPE ticket = new TICKET_TYPE();
                    ticket.TYPENAME = _model.TYPENAME;
                    ticket.DESCRIPTIONS = _model.DESCRIPTIONS;
                    ticket.TYPE_CHECK = _model.TYPE_CHECK;
                    ticket.TYPE_CODE = _model.TYPE_CODE;
                    db.TICKET_TYPE.Add(ticket);
                    db.SaveChanges();
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult TimKiemLoaiVe(int TYPEID)
        {
            try
            {
                TICKET_TYPE loaiVe = db.TICKET_TYPE.Where(c => c.TYPEID == TYPEID).FirstOrDefault();
                return new JsonResult { Data = loaiVe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult XoaLoaiVe(int TYPEID)
        {
            try
            {
                if (TYPEID == 1 || TYPEID == 2 || TYPEID == 3)
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                TICKET_TYPE loaiVe = db.TICKET_TYPE.Where(c => c.TYPEID == TYPEID).First();
                if (loaiVe != null)
                {
                    db.TICKET_TYPE.Remove(loaiVe);
                }
                db.SaveChanges();
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}