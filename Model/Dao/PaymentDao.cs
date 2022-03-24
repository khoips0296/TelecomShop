using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class PaymentDao
    {
        TelecomShopDbContext db;
        public PaymentDao()
        {
            db = new TelecomShopDbContext();
        }
        public string Insert(Payment entity)
        {
            db.Payments.Add(entity);
            db.SaveChanges();
            return entity.payId;
        }

        public bool Update(Payment entity)
        {
            try
            {
                var pay = db.Payments.SingleOrDefault(x => x.payId == entity.payId);
                pay.payId = entity.payId;
                pay.payName = entity.payName;
                pay.status = entity.status;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Payment> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Payment> model = db.Payments;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.payName.Contains(searchString));
            }

            return model.OrderBy(x => x.payId).ToPagedList(page, pageSize);
        }


        public Payment ViewDetail(string id)
        {
            return db.Payments.Find(id);
        }
        public bool Delete(string id)
        {
            try
            {
                var entity = db.Payments.Find(id);
                db.Payments.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
