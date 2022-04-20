using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.Data.Interface
{
    public interface IUnitOfWorks : IDisposable
    {
        ICustomerRepository Customer { get; }
        IAccountRepository Account { get; }
        ITransactionRepository Transaction { get; }
        Task<int> Complete();
        void Cancel();
    }
}
