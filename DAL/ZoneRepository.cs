using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ZoneRepository<T> : IRepository<T> where T : class
    {
        private DataContext db;

        public ZoneRepository(DataContext context) { db = context; }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            Zone zone = db.Zones.Find(id);
            if (zone != null) db.Zones.Remove(zone);
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {

            return db.Set<T>().AsEnumerable();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
