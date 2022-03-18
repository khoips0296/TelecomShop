using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomShop.Common;
using TelecomShop.Models;

namespace TelecomShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            ViewBag.cateOnly = new CategoryDao().CateOnly();
            ViewBag.category = new CategoryDao().ListAll();
            ViewBag.listPackCheap = new PackDao().ListPackCheap();
            ViewBag.listBlogCreated = new BlogDao().ListBlogCreated();

            return View();
        }

        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartProductSession];
            var list = new List<CartProductItem>();
            if (cart != null)
            {
                list = (List<CartProductItem>)cart;
            }

            ViewBag.list = list;
            return PartialView(list);
        }

    }
}