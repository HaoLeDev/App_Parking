using App_Parking.Common;
using App_Parking.Models;
using BusinessEntities;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace App_Parking.Controllers
{
    public class LoginController : Controller
    {
        ACCOUNT account = new ACCOUNT();
        // GET: Login
        TICKET_MANAGEREntities3 context = new TICKET_MANAGEREntities3();
        public LoginController()
        {
            context.Configuration.ProxyCreationEnabled = false;
        }
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
                var result = userDA.Login(model.UserName, MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = userDA.GetById(model.UserName);
                    var userSession = new ACCOUNT();
                    userSession.ACC_USERNAME = user.ACC_USERNAME;
                    userSession.ACC_PASSWORD = MD5Hash( user.ACC_PASSWORD);
                    userSession.ACC_ID = user.ACC_ID;
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
        public static string MD5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }

            return sbHash.ToString();
        }
    }
}
