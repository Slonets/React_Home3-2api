using DateAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Data
{
    public class CaseDbContext:DbContext
    {
        public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options) { }
        public DbSet<Case> Task { get; set; }
    }
}
