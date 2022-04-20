using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Data.Interface;

namespace TransactionManagement.Data.Repository
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly TransactionManagementContext _context;

        public UnitOfWorks(TransactionManagementContext context, ICustomerRepository customer, IAccountRepository account,
                            ITransactionRepository transaction)
        {
            _context = context;
            Customer = customer;
            Account = account;
            Transaction = transaction;
        }

        public UnitOfWorks()
        {
        }

        public ICustomerRepository Customer { get; private set; }
        public IAccountRepository Account { get; private set; }
        public ITransactionRepository Transaction { get; private set; }
        public async Task<int> Complete() => await _context.SaveChanges();
        public async void Cancel() => await _context.DisposeAsync();
        public void Dispose() => _context.Dispose();
    }

   
}
