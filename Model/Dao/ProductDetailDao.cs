using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDetailDao
    {
        TelecomShopDbContext db;
        public ProductDetailDao()
        {
            db = new TelecomShopDbContext();
        }

        public int Insert(ProductAddDetail entity)
        {
            db.ProductAddDetails.Add(entity);
            db.SaveChanges();
            return entity.proAddDetailId;
        }




        public bool Update(ProductAddDetail entity)
        {
            try
            {
                var productdetail = db.ProductAddDetails.SingleOrDefault(x => x.proAddDetailId == entity.proAddDetailId);
                productdetail.proAddDetailId = entity.proAddDetailId;
                productdetail.billId = entity.billId;
                productdetail.proId = entity.proId;
                productdetail.Quantity = entity.Quantity;
                productdetail.Total = entity.Total;
                

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<ProductAddDetail> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductAddDetail> model = db.ProductAddDetails;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.billId.Contains(searchString));
            }

            return model.OrderBy(x => x.proId).ToPagedList(page, pageSize);
        }


        public Product ViewDetail(string id)
        {
            return db.Products.Find(id);
        }



        public bool Delete(string id)
        {
            try
            {
                var entity = db.ProductAddDetails.Find(id);
                db.ProductAddDetails.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public ProductAddDetail ProductById(int proId)
        {
            var prodetail = db.ProductAddDetails.SingleOrDefault(x => x.proAddDetailId == proId);
            return prodetail;
        }
    }
}
