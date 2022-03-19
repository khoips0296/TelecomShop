using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using TelecomShop.Areas.Admin.Models;
using TelecomShop.Common;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class RegisterController : BaseController
    {
        private TelecomShopDbContext db = new TelecomShopDbContext();

        // GET: Admin/Register
        public ActionResult Index()
        {
            ViewBag.roleId = db.Roles.ToList();
            ViewBag.shopId = db.Shops.ToList();
            return View();
        }

        // POST: Admin/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDao();
                Employee emp = new Employee();
                emp.empName = model.FullName;
                emp.gender = model.Gender;
                emp.email = model.Email;
                emp.password = Encryptor.MD5Hash(model.Password);
                emp.phone = model.Phone;
                emp.dateStart = model.DateStart;
                emp.roleId = model.RoleId;
                emp.shopId = model.ShopId;
                emp.status = true;

                long id = dao.Insert(emp);
                if (id > 0)
                {
                    SetAlert("Account created successfully!", "success");
                    var userSession = new EmployeeLogin();
                    userSession.EmployeeID = emp.empId;
                    userSession.EmployeeName = emp.email;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Add new fail");
                }
            }
            ViewBag.roleId = db.Roles.ToList();
            ViewBag.shopId = db.Shops.ToList();
            return View(model);
        }
    }
}
