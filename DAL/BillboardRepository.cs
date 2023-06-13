using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillboardRepository<T> : IRepository<T> where T : class
    {
        private BillboardContext db;

        public BillboardRepository(BillboardContext context) { db = context; }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            DBBillboard billboard = db.BillboardInf.Find(id);
            if (billboard != null) db.BillboardInf.Remove(billboard);
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {

            return db.Set<T>().AsEnumerable();
        }

        public void Update(DBBillboard item)
        {
            // db.Entry(item).State = EntityState.Modified;
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
