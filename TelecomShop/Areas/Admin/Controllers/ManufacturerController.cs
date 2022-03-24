using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TelecomShop.Areas.Admin.Controllers
{
    public class ManufacturerController : BaseController
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Admin/Manufacturer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ManufacturerDao();
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
        public ActionResult Create(Manufacturer manu)
        {
            if (ModelState.IsValid)
            {
                var dao = new ManufacturerDao();


                string id = dao.Insert(manu);
                if (id != null)
                {

                    return RedirectToAction("Index", "Manufacturer");
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
            var manu = new ManufacturerDao().ViewDetail(id);
            return View(manu);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Manufacturer manu)
        {
            if (ModelState.IsValid)
            {
                var dao = new ManufacturerDao();
                var result = dao.Update(manu);
                if (result)
                {

                    return RedirectToAction("Index", "Manufacturer");
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
            new ManufacturerDao().Delete(id);

            return RedirectToAction("Index");
        }

    }
}
