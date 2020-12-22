using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlockexBlazor.Models;

namespace BlockexBlazor.Data
{
    public class BlockexBlazorContext : DbContext
    {
        public BlockexBlazorContext (DbContextOptions<BlockexBlazorContext> options)
            : base(options)
        {
        }

        public DbSet<BlockexBlazor.Models.SourceHeader> SourceHeaders { get; set; }
    }
}
