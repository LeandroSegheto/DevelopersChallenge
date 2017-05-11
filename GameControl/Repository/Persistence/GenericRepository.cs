using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repository.Configuration;

namespace Repository.Persistence
{
    public class GenericRepository<T> where T: class
    {
        public virtual void Insert(T obj)
        {
            using (Connection con = new Connection())
            {
                con.Entry(obj).State = EntityState.Added;
                con.SaveChanges();
            }
        }

        public virtual void Update(T obj)
        {
            using (Connection con = new Connection())
            {
                con.Entry(obj).State = EntityState.Modified;
                con.SaveChanges();
            }
        }

        public virtual void Delete(T obj)
        {
            using (Connection con = new Connection())
            {
                con.Entry(obj).State = EntityState.Deleted;
                con.SaveChanges();
            }
        }

        public virtual List<T> ListAll()
        {
            using (Connection con = new Connection())
            {
                return con.Set<T>().ToList();
            }
        }

        public virtual T GetByID(int id)
        {
            using (Connection con = new Connection())
            {
                return con.Set<T>().Find(id);
            }
        }
    }
}
