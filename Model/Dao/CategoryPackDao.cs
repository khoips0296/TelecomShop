using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryPackDao
    {
        TelecomShopDbContext db;
        public CategoryPackDao()
        {
            db = new TelecomShopDbContext();
        }

        public string Insert(CategoryPack entity)
        {
            db.CategoryPacks.Add(entity);
            db.SaveChanges();
            return entity.catId;
        }

        public bool Update(CategoryPack entity)
        {
            try
            {
                var catepack = db.CategoryPacks.SingleOrDefault(x => x.catId == entity.catId);
                catepack.catId = entity.catId;
                catepack.catName = entity.catName;
                catepack.status = entity.status;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<CategoryPack> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<CategoryPack> model = db.CategoryPacks;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.catName.Contains(searchString));
            }

            return model.OrderBy(x => x.catId).ToPagedList(page, pageSize);
        }


        public CategoryPack ViewDetail(string id)
        {
            return db.CategoryPacks.Find(id);
        }



        public bool Delete(string id)
        {
            try
            {
                var entity = db.CategoryPacks.Find(id);
                db.CategoryPacks.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public CategoryPack CatePackById(string catId)
        {
            var catepackById = db.CategoryPacks.SingleOrDefault(x => x.catId == catId && x.status == true);
            return catepackById;
        }
    }
}
    