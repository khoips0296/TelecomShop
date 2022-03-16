using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class BlogDao
    {
        TelecomShopDbContext db;
        public BlogDao()
        {
            db = new TelecomShopDbContext();
        }

        public List<Blog> ListAll()
        {

            return db.Blogs.Where(x => x.status == true).OrderBy(x => x.blogId).ToList();
        }


        public List<Blog> ListBlogCreated()
        {
            var listBlogCreated = (from p in db.Blogs orderby p.dateCreated descending select p).Take(4);
            return listBlogCreated.ToList();
        }


    }
}

