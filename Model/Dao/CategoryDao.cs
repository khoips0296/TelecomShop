using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class CategoryDao
    {
        TelecomShopDbContext db;
        public CategoryDao()
        {
            db = new TelecomShopDbContext();
        }

        public List<CategoryPack> ListAll()
        {
            
            return db.CategoryPacks.Where(x => x.status == true).OrderBy(x => x.catId).ToList();
        }

        public CategoryPack CateOnly()
        {
            var cateOnly = (from c in db.CategoryPacks select c).FirstOrDefault();
            return cateOnly;
        }

    }
}

