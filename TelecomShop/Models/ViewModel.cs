using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomShop.Models
{
    public class ViewModel
    {
        public IEnumerable<CartPackItem> CartPackItem { get; set; }
        public IEnumerable<CartProductItem> CartProductItem { get; set; }
    }
}