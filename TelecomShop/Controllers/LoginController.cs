using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using TelecomShop.Models;
using Model.Dao;
using TelecomShop.Common;

namespace TelecomShop.Controllers
{
    public class LoginController : Controller
    {
        private TelecomShopDbContext db = new TelecomShopDbContext();

        // GET: Login
        public ActionResult Index()
        {
            if (Session[CommonConstants.MEMBER_SESSION] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new MemberDao();
                var result = dao.Login(model.Email, Encryptor.MD5Hash(model.Password));
                if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("", "Email and password can not be emptied!");
                }
                if (result == 1)
                {
                    var member = dao.GetById(model.Email);
                    var userSession = new MemberLogin();
                    userSession.MemberID = member.memberId;
                    userSession.MemberName = member.email;
                    //userSession.GroupID = user.GroupID;
                    //var listCredentials = dao.GetListCredential(model.UserName);

                    //Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.MEMBER_SESSION, userSession);
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
                else
                {
                    ModelState.AddModelError("", "Login fail");
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.MEMBER_SESSION);
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}
