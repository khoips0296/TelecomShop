using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class ShopDao
    {
        TelecomShopDbContext db;
        public ShopDao()
        {
            db = new TelecomShopDbContext();
        }

        public IEnumerable<Shop> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Shop> model = db.Shops;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.shopName.Contains(searchString));
            }

            return model.OrderBy(x => x.shopId).ToPagedList(page, pageSize);
        }

        public Shop ViewDetail(int id)
        {
            return db.Shops.Find(id);
        }

    }
}
