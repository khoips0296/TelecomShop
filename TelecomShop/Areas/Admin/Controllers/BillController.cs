using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Admin/Bill
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new BillDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            
            ViewBag.empId = new SelectList(db.Employees, "empId", "empName");
            ViewBag.memberId = new SelectList(db.Members, "memberId", "fullName");
            ViewBag.shopId = new SelectList(db.Shops, "shopId", "shopName");
            ViewBag.payId = new SelectList(db.Payments, "payId", "payName");
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDao();


                string id = dao.Insert(bill);
                if (id != null)
                {

                    return RedirectToAction("Index", "Bill");
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
        public ActionResult Edit(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDao();
                var result = dao.Update(bill);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "Bill");
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