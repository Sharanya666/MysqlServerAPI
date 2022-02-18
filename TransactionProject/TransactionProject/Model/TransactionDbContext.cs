using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TransactionProject.Model
{
    public class TransactionDbContext:DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerDetails> customerdetails { get; set; }
        public DbSet<TransactionDetails> transactiondetails { get; set; }
        public DbSet<adminlogin> adminlogin { get; set; }
    }
}
