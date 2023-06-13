using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private BillboardContext db;
        //private BillboardRepository<T> billboardRepository;
        private bool _disposed = false;

        public UnitOfWork(BillboardContext db)
        {
            this.db = db;
        }


        //public BillboardRepository<DBBillboard> Billboards
        //{
        //    get
        //    {
        //        if (billboardRepository == null) billboardRepository = new BillboardRepository<DBBillboard>(db);
        //        return billboardRepository;
        //    }
        //}

        public BillboardRepository<T> Billboards<T>(bool hasCustomRepository = false) where T : class
        {
            if (!hasCustomRepository)
            {
                BillboardRepository<T> billboardRepository = new BillboardRepository<T>(db);
                return billboardRepository;
            }

            return db.GetService<BillboardRepository<T>>();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool displosing)
        {
            if (!_disposed) db.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
