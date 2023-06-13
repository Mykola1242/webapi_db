using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillboardContext : DbContext
    {
        public BillboardContext(DbContextOptions<BillboardContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<DBBillboard> BillboardInf { get; set; }
    }
}
