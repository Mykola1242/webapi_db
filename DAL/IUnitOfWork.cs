using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        BillboardRepository<T> Billboards<T>(bool hasCustomRepository = false) where T : class;
        void Save();
    }
}
