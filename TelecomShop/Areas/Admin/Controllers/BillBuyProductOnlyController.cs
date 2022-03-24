using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class BillBuyProductOnlyController : Controller
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Admin/BillBuyProductOnly
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new BillBuyProductOnlyDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.proId = new SelectList(db.Products, "proId", "proName");
            ViewBag.empId = new SelectList(db.Employees, "empId", "empName");
            ViewBag.memberId = new SelectList(db.Members, "memberId", "fullName");
            ViewBag.shopId = new SelectList(db.Shops, "shopId", "shopName");
            ViewBag.payId = new SelectList(db.Payments, "payId", "payName");
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BillBuyProductOnly billpro)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillBuyProductOnlyDao();


                int? id = dao.Insert(billpro);
                if (id != null)
                {
                    
                    return RedirectToAction("Index", "BillBuyProductOnly");
                }
                else
                {
                    ModelState.AddModelError("", "Add new fail");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(string id)
        {
            ViewBag.proId = new SelectList(db.Products, "proId", "proName");
            ViewBag.empId = new SelectList(db.Employees, "empId", "empName");
            ViewBag.memberId = new SelectList(db.Members, "memberId", "fullName");
            ViewBag.shopId = new SelectList(db.Shops, "shopId", "shopName");
            ViewBag.payId = new SelectList(db.Payments, "payId", "payName");
            var billpro = new ProductDao().ViewDetail(id);
            return View(billpro);
        }

        [HttpPost]
        [ValidateInput(false)]
        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(BillBuyProductOnly billpro)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillBuyProductOnlyDao();
                var result = dao.Update(billpro);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "BillBuyProductOnly");
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
        public ActionResult Delete(string id)
        {
            new BillBuyProductOnlyDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}