using App_Parking.Models;
using BusinessEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace App_Parking.Controllers
{
    public class ThongKeDonViController : BaseController
    {
        public ThongKeDonViController()
        {
            db = new TICKET_MANAGEREntities3();
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: ThongKeDonVi
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll(ThongKeDonViModel model)
        {
            try
            {
                var donvi = db.UNITs.ToList().OrderBy(s => s.UNIT_ID);
                return this.Json(new { data = donvi, result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return this.Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult CharterColumn()
        //{
        //    ArrayList xvalue = new ArrayList();
        //    ArrayList yvalue = new ArrayList();

        //    var results = (from c in db.UNITs select c);
        //    results.ToList().ForEach(rs => xvalue.Add(rs.UNIT_CODE));
        //    results.ToList().ForEach(rs => yvalue.Add(rs.UNIT_NAME));

        //    new Chart(width: 600, height: 400, theme: ChartTheme.Green).AddTitle("Biểu đồ đơn vị[Colum Chart]").AddSeries("Default", chartType: "Column", xValue: xvalue, yValues: yvalue).Write("bmp");
        //    return null;
        //}
        public JsonResult ExportToExcel()
        {
            try
            {
                var thongKe = db.UNITs.OrderBy(c => c.UNIT_ID).ToList();
                DataTable dtThongKe = new DataTable();
                dtThongKe.Columns.Add("STT");
                dtThongKe.Columns.Add("Tên đơn vị");
                dtThongKe.Columns.Add("Mã đơn vị");
                dtThongKe.Columns.Add("Trạng thái");
                int i = 1;
                foreach(var item in thongKe)
                {
                    DataRow dr = dtThongKe.NewRow();
                    dr["STT"] = i++.ToString();
                    dr["Tên đơn vị"] = item.UNIT_NAME;
                    dr["Mã đơn vị"] = item.UNIT_CODE;
                    dr["Trạng thái"] = item.UNIT_STATUS;
                    dtThongKe.Rows.Add(dr);
                }
                Random random = new Random();
                string path = "Thong-ke-Don-Vi" + DateTime.Now.ToString("ddMMyyyy-") + random.Next(1, 99999) + ".xlsx";
                string filePath = Path.Combine(Server.MapPath("~/upload/files/Excel/"), path);
                Common.Common.ExportToExcel2(filePath, "Sarica", "DANH SÁCH ĐƠN VỊ", "ThongKeDonVi", "DANH SÁCH ĐƠN VỊ", dtThongKe);
                return Json(new { data = "uploads/files/Excel/" + path, result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}