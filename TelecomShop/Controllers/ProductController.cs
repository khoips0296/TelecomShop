using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelecomShop.Controllers
{
    public class ProductController : Controller
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string id, int page=1, int pageSize=1)
        {

            ViewBag.cate = db.CategoryPacks.SingleOrDefault(x => x.catId == id);
            ViewBag.allCate = db.CategoryPacks.ToList();

            

            int totalRecord = 0;
            ViewBag.listProductByCat = new ProductDao().ListProductByCate(id, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;


            return View();
        }

        public ActionResult Detail(string id)
        {
            var catId = new ProductDao().ProductById(id).catId;
            ViewBag.productById = new ProductDao().ProductById(id);
            ViewBag.cate = db.CategoryPacks.SingleOrDefault(x => x.catId == catId);
            ViewBag.allCate = new CategoryDao().ListAll();

            ViewBag.relateProduct = new ProductDao().RelateProduct(catId);

            return View();
        }

    }
}