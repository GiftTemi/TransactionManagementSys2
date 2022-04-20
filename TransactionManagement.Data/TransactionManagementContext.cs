using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Model;

namespace TransactionManagement.Data
{
    public class TransactionManagementContext : DbContext
    {
        public TransactionManagementContext(DbContextOptions<TransactionManagementContext> options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
