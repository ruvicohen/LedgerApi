using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LedgerApi.Models;

namespace LedgerApi.Data
{
    public class LedgerApiContext : DbContext
    {
        public LedgerApiContext (DbContextOptions<LedgerApiContext> options)
            : base(options)
        {
        }

        public DbSet<LedgerApi.Models.User> User { get; set; } = default!;
        public DbSet<LedgerApi.Models.Ladger> Ladger { get; set; } = default!;
    }
}
