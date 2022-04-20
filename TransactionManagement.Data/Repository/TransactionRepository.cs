using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Data.Interface;
using TransactionManagement.Model;

namespace TransactionManagement.Data.Repository
{
    public class TransactionRepository : GenericRepository<Transactions>, ITransactionRepository
    {
        public TransactionRepository(TransactionManagementContext context) : base(context)
        {

        }
    }
}
