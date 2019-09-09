using App_Parking.Common;
using App_Parking.Models;
using BusinessEntities;
using BusinessObject.Context;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Parking.Controllers
{
    public class LoginController : Controller
    {
        Account account = new Account();
        // GET: Login
        PandaDbcontext context= new PandaDbcontext();
        //public LoginController()
        //{
        //    context = new PandaDbcontext();
        //}
        public ActionResult Index()
        {
            //Account account = new Account();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userDA = new UserDA();
                var result = userDA.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = userDA.GetById(model.UserName);
                    var userSession = new Account();
                    userSession.UserName = user.UserName;
                    userSession.Password = user.Password;
                    userSession.Id = user.Id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
            }  
            return View("Index");

        }
    }
}