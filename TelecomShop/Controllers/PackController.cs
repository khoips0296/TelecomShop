using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomShop.Models;

namespace TelecomShop.Controllers
{
    public class PackController : Controller
    {
        TelecomShopDbContext db = new TelecomShopDbContext();
        private const string CartPackSession = "CartPackSession";
        // GET: Pack
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(string id)
        {
            var catId = new PackDao().PackById(id).catId;
            ViewBag.packById = new PackDao().PackById(id);
            ViewBag.cate = db.CategoryPacks.SingleOrDefault(x => x.catId == catId);
            ViewBag.allCate = new CategoryDao().ListAll();


            var cartPack = Session[CartPackSession];
            var listPack = new List<CartPackItem>();
            if (cartPack != null)
            {
                listPack = (List<CartPackItem>)cartPack;
            }
            ViewBag.CartPackItem = listPack;

            return View();
        }
        
    }
}