using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelecomShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.manuId = new SelectList(db.Manufacturers, "manuId", "manuName");
            ViewBag.catId = new SelectList(db.CategoryPacks, "catId", "catName");
            
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                

                string id = dao.Insert(pro);
                if (id != null)
                {
                    //SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "Product");
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
            ViewBag.manuId = new SelectList(db.Manufacturers, "manuId", "manuName");
            ViewBag.catId = new SelectList(db.CategoryPacks, "catId", "catName");
            var pro = new ProductDao().ViewDetail(id);
            return View(pro);
        }

        [HttpPost]
        [ValidateInput(false)]
        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(Product pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(pro);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "Product");
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
            new ProductDao().Delete(id);

            return RedirectToAction("Index");
        }

    }
}