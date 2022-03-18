using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomShop.Models
{
    public class CartPackItem
    {
        public Pack Pack { get; set; }
        public int packQuantity { get; set; }

    }
}