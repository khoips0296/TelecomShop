using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelecomShop.Controllers
{
    public class CategoryController : Controller
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string id)
        {

            ViewBag.cate = db.CategoryPacks.SingleOrDefault(x => x.catId == id);
            ViewBag.allCate = db.CategoryPacks.ToList();

            ViewBag.listPackByCat = new PackDao().ListPackByCate(id);

            return View();
        }

    }
}