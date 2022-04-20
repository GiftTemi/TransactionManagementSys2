using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Data.Interface;
using TransactionManagement.Model;

namespace TransactionManagement.Data.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TransactionManagementContext context) : base(context)
        {

        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var query = await Find(s => s.Email == email);
            return query.FirstOrDefault();
        }

        public async Task<Customer> GetCustomerByBVN(string bvn)
        {
            var query = await Find(s => s.BVN == bvn);
            return query.FirstOrDefault();
        }
    }
}
