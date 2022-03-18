using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TelecomShop.Areas.Admin.Controllers;
using TelecomShop.Models;

namespace TelecomShop.Controllers
{
    public class CartController : BaseController
    {
        private const string CartProductSession = "CartProductSession";
        private const string CartPackSession = "CartPackSession";


        // GET: Cart
        public ActionResult Index()
        {
            var cartPro = Session[CartProductSession];
            var listPro = new List<CartProductItem>();
            if (cartPro != null)
            {
                listPro = (List<CartProductItem>)cartPro;
            }
            ViewBag.CartProductItem = listPro;

            var cartPack = Session[CartPackSession];
            var listPack = new List<CartPackItem>();
            if (cartPack != null)
            {
                listPack = (List<CartPackItem>)cartPack;
            }
            ViewBag.CartPackItem = listPack;
            return View();
        }


        /// <summary>
        /// add new product to shopping cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public ActionResult AddItemProduct(string productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            //var pack = new PackDao().PackById(packId);


            var cartPro = Session[CartProductSession];
            //var cartPack = Session[CartPackSession];


            if (cartPro != null)
            {
                var list = (List<CartProductItem>)cartPro;
                if (list.Exists(x => x.Product.proId == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.proId == productId)
                        {
                            item.productQuantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartProductItem();
                    item.Product = product;
                    item.productQuantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartProductSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartProductItem();
                item.Product = product;
                item.productQuantity = quantity;
                var list = new List<CartProductItem>();
                list.Add(item);
                //Gán vào session
                Session[CartProductSession] = list;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult AddItemPack(string packId, int quantity)
        {
            //var product = new ProductDao().ViewDetail(productId);
            var pack = new PackDao().PackById(packId);


            var cartPack = Session[CartPackSession];
            //var cartPack = Session[CartPackSession];


            if (cartPack != null)
            {
                var list = (List<CartPackItem>)cartPack;
                if (list.Exists(x => x.Pack.packId == packId))
                {

                    //foreach (var item in list)
                    //{
                    //    if (item.Pack.packId == packId)
                    //    {
                    //        item.packQuantity += quantity;
                    //    }
                    //}
                    ViewBag.msg = "Pack Data alredy existed";
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartPackItem();
                    item.Pack = pack;
                    item.packQuantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartPackSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartPackItem();
                item.Pack = pack;
                item.packQuantity = quantity;
                var list = new List<CartPackItem>();
                list.Add(item);
                //Gán vào session
                Session[CartPackSession] = list;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }


        public JsonResult Update(string cartModelPro)
        {
            var jsonCartPro = new JavaScriptSerializer().Deserialize<List<CartProductItem>>(cartModelPro);
            var sessionCartPro = (List<CartProductItem>)Session[CartProductSession];


            if (sessionCartPro != null)
            {
                foreach (var item in sessionCartPro)
                {
                    var jsonItem = jsonCartPro.SingleOrDefault(x => x.Product.proId == item.Product.proId);
                    if (jsonItem != null)
                    {
                        item.productQuantity = jsonItem.productQuantity;
                    }
                }
                Session[CartProductSession] = sessionCartPro;
            }
            

            return Json(new
            {
                status = true
            });
        }


        public JsonResult UpdatePack(string cartModelPack)
        {
            


            //for pack
            //var jsonCartPack = new JavaScriptSerializer().Deserialize<List<CartPackItem>>(cartModelPack);
            //var sessionCartPack = (List<CartPackItem>)Session[CartPackSession];
            
            //if (sessionCartPack != null)
            //{
            //    foreach (var item in sessionCartPack)
            //    {
            //        var jsonItem = jsonCartPack.SingleOrDefault(x => x.Pack.packId == item.Pack.packId);
            //        if (jsonItem != null)
            //        {
            //            item.packQuantity = jsonItem.packQuantity;
            //        }
            //    }
            //    Session[CartPackSession] = sessionCartPack;
            //}




            return Json(new
            {
                status = true
            });
        }


        public JsonResult DeleteAll()
        {
            Session[CartProductSession] = null;
            Session[CartPackSession] = null;

            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(string proId)
        {
            var sessionCart = (List<CartProductItem>)Session[CartProductSession];
            sessionCart.RemoveAll(x => x.Product.proId == proId);
            Session[CartProductSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeletePack(string packId)
        {
            var sessionCartPack = (List<CartPackItem>)Session[CartPackSession];
            sessionCartPack.RemoveAll(x => x.Pack.packId == packId);
            Session[CartPackSession] = sessionCartPack;
            return Json(new
            {
                status = true
            });
        }


    }
}