using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MemberDao
    {
        TelecomShopDbContext db;
        public MemberDao()
        {
            db = new TelecomShopDbContext();
        }

        public long Insert(Member entity)
        {
            db.Members.Add(entity);
            db.SaveChanges();
            return entity.memberId;
        }

        public int Login(string email, string passWord)
        {
            /* 
            0: non existed
            1: success
            -1: status = false
            -2: wrong password
            */
            var result = db.Members.SingleOrDefault(x => x.email == email);
            if (result == null)
            {
                return 0;
            }
            if (result.status == false)
            {
                return -1;
            }
            if (result.password == passWord)
            {
                return 1;
            }
            return -2;
        }
        public Member GetById(string email)
        {
            return db.Members.SingleOrDefault(x => x.email == email);
        }
    }
}
