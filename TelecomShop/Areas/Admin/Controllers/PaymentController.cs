using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class PaymentController : BaseController
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Admin/Payment
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new PaymentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Payment pay)
        {
            if (ModelState.IsValid)
            {
                var dao = new PaymentDao();
                string id = dao.Insert(pay);
                if (id != null)
                {

                    return RedirectToAction("Index", "Payment");
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
            var pay = new PaymentDao().ViewDetail(id);
            return View(pay);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Payment pay)
        {
            if (ModelState.IsValid)
            {
                var dao = new PaymentDao();
                var result = dao.Update(pay);
                if (result)
                {

                    return RedirectToAction("Index", "Payment");
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
            new PaymentDao().Delete(id);

            return RedirectToAction("Index");
        }

    }
}