using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerService.Models
{
    public partial class customersContext : DbContext
    {
        public customersContext()
        {
        }

        public customersContext(DbContextOptions<customersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        
    }
}
