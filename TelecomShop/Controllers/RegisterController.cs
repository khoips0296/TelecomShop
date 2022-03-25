using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using TelecomShop.Common;
using TelecomShop.Models;

namespace TelecomShop.Controllers
{
    public class RegisterController : Controller
    {
        private TelecomShopDbContext db = new TelecomShopDbContext();

        // GET: Register
        public ActionResult Index()
        {
            if (Session[CommonConstants.MEMBER_SESSION] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Member member = new Member();
                member.fullName = model.FullName;
                member.gender = model.Gender;
                member.email = model.Email;
                member.password = Encryptor.MD5Hash(model.Password);
                member.phone = model.Phone;
                member.dateReg = DateTime.Today;
                member.status = true;
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }

    }
}
