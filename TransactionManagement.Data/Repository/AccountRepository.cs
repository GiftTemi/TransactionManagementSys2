using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Data.Interface;
using TransactionManagement.Model;

namespace TransactionManagement.Data.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(TransactionManagementContext context) : base(context)
        {

        }
    }
}
