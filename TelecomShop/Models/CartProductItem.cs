using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomShop.Models
{
    public class CartProductItem
    {
        public Product Product { get; set; }
        public int productQuantity { get; set; }
    }
}