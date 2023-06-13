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
        private DataContext db;
        
        private bool _disposed = false;

        public UnitOfWork(DataContext db)
        {
            this.db = db;
        }



        public ZoneRepository<T> Zones<T>(bool hasCustomRepository = false) where T : class
        {
            if (!hasCustomRepository)
            {
                ZoneRepository<T> zoneRepository = new ZoneRepository<T>(db);
                return zoneRepository;
            }

            return db.GetService<ZoneRepository<T>>();
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
