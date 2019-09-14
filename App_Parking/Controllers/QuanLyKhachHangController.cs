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
    public class QuanLyKhachHangController : BaseController
    {
        public QuanLyKhachHangController()
        {
            db = new TICKET_MANAGEREntities3();
            db.Configuration.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// return view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// get list user info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetAll(JqueryDataTableParamModel model)
        {
            try
            {
                var khachHang = db.USER_INFO.Where(t => t.USER_TYPEID == 2).OrderBy(t => t.USER_ID);

                if (!string.IsNullOrWhiteSpace(model.sSearch))
                {
                    string search = model.sSearch.Trim().ToUpper();
                    // Lấy giá trị phù hợp với text nhập theo các cột muốn tìm
                    khachHang = khachHang.Where(c => (c.USER_NAME.ToUpper().Contains(search)
                        || c.USER_CODE.ToUpper().Contains(search)
                        || c.EMAIL.ToUpper().Contains(search)
                        || c.PHONE.ToUpper().Contains(search)
                        )).OrderBy(c => c.USER_ID);
                }


                // Sort: Sắp xếp
                switch (model.iSortCol_0)
                {
                    // Sort order: Thứ tự cột sắp xếp
                    case 0:
                        {
                            // Cột 1 không sắp xếp: checkbox
                            break;
                        }
                    // Sắp xếp theo tên khách hàng.
                    case 1:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => r.USER_NAME);
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => r.USER_NAME);
                            }
                            break;
                        }

                    // Sắp xếp theo mã khách hàng.
                    case 2:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => r.USER_CODE);
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => r.USER_CODE);
                            }
                            break;
                        }
                    // Sắp xếp theo số điện thoại.
                    case 3:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => r.PHONE);
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => r.PHONE);
                            }
                            break;
                        }
                    // Sắp xếp theo số CMND.
                    case 4:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => r.IDENTITY_NUMBER);
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => r.IDENTITY_NUMBER);
                            }
                            break;
                        }
                    // Sắp xếp theo giới tính.
                    case 5:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => r.SEX);
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => r.SEX);
                            }
                            break;
                        }
                    // Sắp xếp theo ngày sinh.
                    case 6:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => r.USER_BIRTH);
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => r.USER_BIRTH);
                            }
                            break;
                        }
                    // Sắp xếp theo email.
                    case 7:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => r.EMAIL);
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => r.EMAIL);
                            }
                            break;
                        }
                    // Sắp xếp theo điểm tích lũy.
                    case 8:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => Convert.ToDateTime(r.REDEEM_POINTS));
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => Convert.ToDateTime(r.REDEEM_POINTS));
                            }
                            break;
                        }
                    // Sắp xếp theo trạng thái.
                    case 9:
                        {
                            if (model.sSortDir_0 == "asc")
                            {
                                khachHang = khachHang.OrderBy(r => Convert.ToDateTime(r.USER_STATUS));
                            }
                            else
                            {
                                khachHang = khachHang.OrderByDescending(r => Convert.ToDateTime(r.USER_STATUS));
                            }
                            break;
                        }
                    default: { break; }
                }
                // Lấy bản ghi trả về view
                var lstArray = khachHang.Skip(model.iDisplayStart).Take(model.iDisplayLength).ToList();
                // Đếm số bản ghi
                int count = khachHang.Count();

                var entity = new List<USER_INFOViewModel>();
                foreach (var temp in lstArray)
                {
                    var tem = new USER_INFOViewModel();
                    tem.USER_ID = temp.USER_ID;
                    tem.USER_NAME = temp.USER_NAME;
                    tem.USER_CODE = temp.USER_CODE;
                    tem.USER_BIRTH = temp.USER_BIRTH;
                    tem.SEX = temp.SEX;
                    tem.REDEEM_POINTS = temp.REDEEM_POINTS;
                    tem.PHONE = temp.PHONE;
                    tem.IDENTITY_NUMBER = temp.IDENTITY_NUMBER;
                    tem.USER_STATUS = temp.USER_STATUS;
                    tem.EMAIL = temp.EMAIL;
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
        /// <summary>
        /// Danh sách loại khách hàng
        /// </summary>
        /// <returns></returns>
        public JsonResult DanhSachLoaiKhachHang()
        {
            var data = db.USER_TYPE.Select(t => new
            {
                USER_TYPEID = t.USER_TYPEID,
                USER_TYPENAME = t.USER_TYPENAME
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// tìm kiếm khách hàng theo UI_ID
        /// </summary>
        /// <param name="USER_ID"></param>
        /// <returns>DEPARTMENT</returns>
        public JsonResult TimKiemKhachHang(int USER_ID)
        {
            try
            {
                var data = db.USER_INFO.FirstOrDefault(t => t.USER_ID == USER_ID);
                USER_INFOViewModel model = new USER_INFOViewModel();
                model.ADDRESS = data.ADDRESS;
                model.CREATE_DATE = data.CREATE_DATE;
                model.EMAIL = data.EMAIL;
                model.IDENTITY_NUMBER = data.IDENTITY_NUMBER;
                model.IMAGE = data.IMAGE;
                model.NOTE = data.NOTE;
                model.PHONE = data.PHONE;
                model.REDEEM_POINTS = data.REDEEM_POINTS;
                model.SEX = data.SEX;
                model.UPDATE_DATE = data.UPDATE_DATE;
                model.USER_BIRTH = data.USER_BIRTH;
                model.USER_CODE = data.USER_CODE;
                model.USER_ID = data.USER_ID;
                model.USER_NAME = data.USER_NAME;
                model.USER_STATUS = data.USER_STATUS;
                model.USER_TYPEID = data.USER_TYPEID;
                return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// cập nhật khách hàng
        /// </summary>
        /// <param name="_model">USER_INFOModel</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult CapNhatKhachHang(USER_INFOModel _model)
        {
            try
            {
                var model = new USER_INFO();
                if (_model.USER_ID > 0)
                {
                    model = db.USER_INFO.FirstOrDefault(t => t.USER_ID == _model.USER_ID);
                    model.USER_NAME = _model.USER_NAME;
                    model.USER_CODE = _model.USER_CODE;
                    model.IDENTITY_NUMBER = _model.IDENTITY_NUMBER;
                    model.ADDRESS = _model.ADDRESS;
                    model.EMAIL = _model.EMAIL;
                    model.NOTE = _model.NOTE;
                    model.PHONE = _model.PHONE;
                    model.REDEEM_POINTS = _model.REDEEM_POINTS;
                    model.SEX = _model.SEX;
                    model.UPDATE_DATE = DateTime.Now;
                    model.USER_BIRTH = _model.USER_BIRTH;
                    model.USER_STATUS = _model.USER_STATUS;
                    model.USER_TYPEID = _model.USER_TYPEID;
                    db.SaveChanges();
                }
                else
                {
                    model.USER_NAME = _model.USER_NAME;
                    model.USER_CODE = _model.USER_CODE;
                    model.IDENTITY_NUMBER = _model.IDENTITY_NUMBER;
                    model.ADDRESS = _model.ADDRESS;
                    model.EMAIL = _model.EMAIL;
                    model.NOTE = _model.NOTE;
                    model.PHONE = _model.PHONE;
                    model.REDEEM_POINTS = _model.REDEEM_POINTS;
                    model.SEX = _model.SEX;
                    model.UPDATE_DATE = DateTime.Now;
                    model.USER_BIRTH = _model.USER_BIRTH;
                    model.USER_STATUS = _model.USER_STATUS;
                    model.USER_TYPEID = _model.USER_TYPEID;
                    db.USER_INFO.Add(model);
                    db.SaveChanges();
                }
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// delete a user
        /// </summary>
        /// <param name="USER_ID"></param>
        /// <returns></returns>
        public JsonResult XoaKhachHang(int USER_ID)
        {
            try
            {
                USER_INFO _user = db.USER_INFO.Where(c => c.USER_ID == USER_ID).First();
                if (_user != null)
                {
                    db.USER_INFO.Remove(_user);
                }
                db.SaveChanges();
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
               
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// multi delete employee
        /// </summary>
        /// <param name="id">list em_id</param>
        /// <returns></returns>
        public JsonResult XoaNhieuKhachHang(string id)
        {
            try
            {
                var arr = id.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    int a = int.Parse(arr[i]);
                    USER_INFO _user = db.USER_INFO.Where(c => c.USER_ID == a).FirstOrDefault();
                    if (_user != null)
                    {
                        db.USER_INFO.Remove(_user);
                    }
                }
                db.SaveChanges();
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}