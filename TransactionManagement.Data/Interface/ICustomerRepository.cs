using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Model;

namespace TransactionManagement.Data.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerByEmail(string email);

        Task<Customer> GetCustomerByBVN(string bvn);
    }
}
