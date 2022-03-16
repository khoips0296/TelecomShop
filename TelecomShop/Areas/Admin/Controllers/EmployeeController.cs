using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomShop.Common;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class EmployeeController : BaseController
    {
        private TelecomShopDbContext db = new TelecomShopDbContext();

        // GET: Admin/Employee
        public ActionResult Index(string searchString, int page=1,int pageSize=10)
        {
            var dao = new EmployeeDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.roleId = new SelectList(db.Roles, "roleId", "roleName");
            ViewBag.shopId = new SelectList(db.Shops, "shopId", "shopName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDao();

                var encryptedMd5Pas = Encryptor.MD5Hash(emp.password);
                emp.password = encryptedMd5Pas;

                long id = dao.Insert(emp);
                if (id > 0)
                {
                    SetAlert("Insert success", "success");
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Add new fail");
                }
            }
            return View("Index");
        }


        public ActionResult Edit(int id)
        {
            ViewBag.roleId = new SelectList(db.Roles, "roleId", "roleName");
            ViewBag.shopId = new SelectList(db.Shops, "shopId", "shopName");
            var dao = new EmployeeDao();
            var employee = dao.ViewDetail(id);

            SetViewBag(employee.shopId);
            var emp = new EmployeeDao().ViewDetail(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateInput(false)]
        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDao();
                if (!string.IsNullOrEmpty(emp.password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(emp.password);
                    emp.password = encryptedMd5Pas;
                }


                var result = dao.Update(emp);
                if (result)
                {
                    SetAlert("Update success", "success");
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Update fail");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        //[HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new EmployeeDao().Delete(id);

            return RedirectToAction("Index");
        }


        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ShopDao();
            //ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
            ViewBag.shopId = new SelectList(db.Shops, "shopId", "shopName",selectedId);
        }


        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new EmployeeDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

    }
}