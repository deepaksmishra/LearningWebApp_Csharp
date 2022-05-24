using System;
using LWAJWTLOG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LWAJWTLOG.Model
{
 public partial class StoredDbContext : DbContext
        {
            public StoredDbContext()
            {
            }

            public StoredDbContext(DbContextOptions<StoredDbContext> options)
                : base(options)
            {
            }

        public virtual DbSet<Output>? Output { get; set; }


    }
    }


