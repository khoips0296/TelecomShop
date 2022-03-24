using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BillDao
    {
        TelecomShopDbContext db;
        public BillDao()
        {
            db = new TelecomShopDbContext();
        }

        public string Insert(Bill entity)
        {
            db.Bills.Add(entity);
            db.SaveChanges();
            return entity.billId;
        }
        public bool Update(Bill entity)
        {
            try
            {
                var bill = db.Bills.SingleOrDefault(x => x.billId == entity.billId);
                bill.billId = entity.billId;
                bill.empId = entity.empId;
                bill.memberId = entity.memberId;
                bill.shopId = entity.shopId;
                bill.payId = entity.payId;
                bill.dateOrder = entity.dateOrder;
                bill.dateInstall = entity.dateInstall;
                bill.Total = entity.Total;
                bill.status = entity.status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<Bill> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Bill> model = db.Bills;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.payId.Contains(searchString));
            }

            return model.OrderBy(x => x.billId).ToPagedList(page, pageSize);
        }


        public IEnumerable<Bill> ListAll()
        {
            IQueryable<Bill> model = db.Bills;
            

            return model.ToList();
        }

        public Bill ViewDetail(string id)
        {
            return db.Bills.Find(id);
        }



        public bool Delete(string id)
        {
            try
            {
                var entity = db.Bills.Find(id);
                db.Bills.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Bill BillById(string billId)
        {
            var billById = db.Bills.SingleOrDefault(x => x.billId == billId);
            return billById;
        }
    }
}
