using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class PackDao
    {
        TelecomShopDbContext db;
        public PackDao()
        {
            db = new TelecomShopDbContext();
        }

        public List<Pack> ListAll()
        {

            return db.Packs.Where(x => x.status == true).OrderBy(x => x.packId).ToList();
        }


        public List<Pack> ListPackCheap()
        {
            var top = (from p in db.Packs orderby p.Price descending select p).Take(4);
            return top.ToList();
        }


    }
}

