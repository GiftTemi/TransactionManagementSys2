using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Model;

namespace TransactionManagement.Data.Interface
{
    public interface ITransactionRepository : IGenericRepository<Transactions>
    {
    }
}
