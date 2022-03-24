using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace Model.Dao
{
    public class ManufacturerDao
    {
        TelecomShopDbContext db;
        public ManufacturerDao()
        {
            db = new TelecomShopDbContext();
        }

        public string Insert(Manufacturer entity)
        {
            db.Manufacturers.Add(entity);
            db.SaveChanges();
            return entity.manuId;
        }

        public bool Update(Manufacturer entity)
        {
            try
            {
                var manu = db.Manufacturers.SingleOrDefault(x => x.manuId == entity.manuId);
                manu.manuId = entity.manuId;
                manu.manuName = entity.manuName;
                manu.email = entity.email;
                manu.phone = entity.phone;
                manu.address = entity.address;
                manu.status = entity.status;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<Manufacturer> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Manufacturer> model = db.Manufacturers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.manuName.Contains(searchString));
            }

            return model.OrderBy(x => x.manuId).ToPagedList(page, pageSize);
        }

        public Manufacturer GetByName(string manuName)
        {
            return db.Manufacturers.SingleOrDefault(x => x.manuName == manuName);
        }
        public Manufacturer ViewDetail(string id)
        {
            return db.Manufacturers.Find(id);
        }

        public bool Delete(string id)
        {
            try
            {
                var entity = db.Manufacturers.Find(id);
                db.Manufacturers.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var manu = db.Manufacturers.Find(id);
            manu.status = !manu.status;
            db.SaveChanges();
            return (bool)manu.status;
        }

    }
}

