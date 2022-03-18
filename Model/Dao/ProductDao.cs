using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Configuration;
using System.Data.Common;

namespace Model.Dao
{
    public class ProductDao
    {
        TelecomShopDbContext db;
        public ProductDao()
        {
            db = new TelecomShopDbContext();
        }

        public string Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.proId;
        }

        


        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.SingleOrDefault(x => x.proId == entity.proId);
                product.proName = entity.proName;
                product.proCode = entity.proCode;
                product.catId = entity.catId;
                product.manuId = entity.manuId;
                product.dateOfManu = entity.dateOfManu;
                product.color = entity.color;
                product.Quantity = entity.Quantity;
                product.Description = entity.Description;
                product.Price = entity.Price;
                product.salePrice = entity.salePrice;
                product.Warranty = entity.Warranty;
                product.status = entity.status;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
            
        }

        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.proName.Contains(searchString));
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
                var entity = db.Products.Find(id);
                db.Products.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Product ProductById(string proId)
        {
            var productById = db.Products.SingleOrDefault(x => x.proId == proId && x.status == true);
            return productById;
        }

        public List<Product> ListProductByCate(string catId, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.Products.Where(x => x.catId == catId).Count();
            var listProductByCate = db.Products.Where(x => x.catId == catId && x.status == true)
                .OrderBy(x=>x.proId).Skip((page-1)*pageSize).Take(pageSize).ToList();
            return listProductByCate;
        }


        public List<Product> RelateProduct(string catId)
        {
           
            var relateProduct = db.Products.Where(x => x.catId == catId && x.status == true).OrderBy(x => x.proId).ToList();
            return relateProduct;
        }

    }
}
