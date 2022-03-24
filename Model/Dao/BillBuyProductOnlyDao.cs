using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BillBuyProductOnlyDao
    {
        TelecomShopDbContext db;
        public BillBuyProductOnlyDao()
        {
            db = new TelecomShopDbContext();
        }

        public int Insert(BillBuyProductOnly entity)
        {
            db.BillBuyProductOnlies.Add(entity);
            db.SaveChanges();
            return entity.billProOnlyId;
        }
        public bool Update(BillBuyProductOnly entity)
        {
            try
            {
                var billpro = db.BillBuyProductOnlies.SingleOrDefault(x => x.billProOnlyId == entity.billProOnlyId);
                billpro.billProOnlyId = entity.billProOnlyId;
                billpro.proId = entity.proId;
                billpro.empId = entity.empId;
                billpro.memberId = entity.memberId;
                billpro.shopId = entity.shopId;
                billpro.payId = entity.payId;
                billpro.dateOrder = entity.dateOrder;
                billpro.dateInstall = entity.dateInstall;
                billpro.Quantity = entity.Quantity;
                billpro.Total = entity.Total;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<BillBuyProductOnly> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<BillBuyProductOnly> model = db.BillBuyProductOnlies;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.payId.Contains(searchString));
            }

            return model.OrderBy(x => x.billProOnlyId).ToPagedList(page, pageSize);
        }


        public BillBuyProductOnly ViewDetail(string id)
        {
            return db.BillBuyProductOnlies.Find(id);
        }



        public bool Delete(string id)
        {
            try
            {
                var entity = db.BillBuyProductOnlies.Find(id);
                db.BillBuyProductOnlies.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public BillBuyProductOnly BillProductById(int billproId)
        {
            var billproductById = db.BillBuyProductOnlies.SingleOrDefault(x => x.billProOnlyId == billproId);
            return billproductById;
        }
    }
}
