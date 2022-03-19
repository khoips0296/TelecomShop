using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomShop.Common;
using Model.EF;

using Model.Dao;
using TelecomShop.Areas.Admin.Models;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDao();
                var result = dao.Login(model.Email, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var emp = dao.GetById(model.Email);
                    var userSession = new EmployeeLogin();
                    userSession.EmployeeID = emp.empId;
                    userSession.EmployeeName = emp.email;
                    //userSession.GroupID = user.GroupID;
                    //var listCredentials = dao.GetListCredential(model.UserName);

                    //Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account does not exist");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account locked");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Invalid password");
                }
                //else if (result == -3)
                //{
                //    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
                //}
                else
                {
                    ModelState.AddModelError("", "Login fail");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return RedirectToAction("Index", "Login");
        }
    }
}