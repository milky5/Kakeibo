using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kakeibo3.Models
{
    public class kakeibo3Context : DbContext
    {
        public kakeibo3Context (DbContextOptions<kakeibo3Context> options)
            : base(options)
        {
        }

        public DbSet<kakeibo3.Models.CashRow> CashRow { get; set; }
    }
}
