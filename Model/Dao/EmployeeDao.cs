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
    public class EmployeeDao
    {
        TelecomShopDbContext db;
        public EmployeeDao()
        {
            db = new TelecomShopDbContext();
        }

        public long Insert(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
            return entity.empId;
        }

        public int Login(string email, string passWord)
        {
            var result = db.Employees.SingleOrDefault(x => x.email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }


        public bool Update(Employee entity)
        {
            try
            {
                var emp = db.Employees.SingleOrDefault(x=>x.empId == entity.empId);
                emp.empName = entity.empName;
                emp.gender = entity.gender;
                emp.email = entity.email;
                emp.phone = entity.phone;
                emp.dateStart = entity.dateStart;
                emp.dateEnd = entity.dateEnd;
                emp.shopId = entity.shopId;
                emp.roleId = entity.roleId;
                emp.status = entity.status;

                if (!string.IsNullOrEmpty(entity.password))
                {
                    emp.password = entity.password;
                }
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<Employee> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Employee> model = db.Employees;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.empName.Contains(searchString));
            }

            return model.OrderBy(x => x.empId).ToPagedList(page, pageSize);
        }

        public Employee GetById(string email)
        {
            return db.Employees.SingleOrDefault(x => x.email == email);
        }
        public Employee ViewDetail(int id)
        {
            return db.Employees.Find(id);
        }


        public bool Delete(int id)
        {
            try
            {
                var entity = db.Employees.Find(id);
                db.Employees.Remove(entity);
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
            var emp = db.Employees.Find(id);
            emp.status = !emp.status;
            db.SaveChanges();
            return (bool)emp.status;
        }

    }
}
