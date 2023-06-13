using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        ZoneRepository<T> Zones<T>(bool hasCustomRepository = false) where T : class;
        void Save();
    }
}
