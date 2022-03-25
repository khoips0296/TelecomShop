using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class CategoryPackController : BaseController
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Admin/CategoryPack
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CategoryPackDao();
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
        public ActionResult Create(CategoryPack catepack)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryPackDao();


                string id = dao.Insert(catepack);
                if (id != null)
                {

                    return RedirectToAction("Index", "CategoryPack");
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
            var catepack = new CategoryPackDao().ViewDetail(id);
            return View(catepack);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CategoryPack catepack)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryPackDao();
                var result = dao.Update(catepack);
                if (result)
                {

                    return RedirectToAction("Index", "CategoryPack");
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
            new CategoryPackDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
