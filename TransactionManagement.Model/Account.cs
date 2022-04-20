using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Model.Enums;

namespace TransactionManagement.Model
{
    public class Account : BaseModel
    {
        public string Nuban { get; set; }
        public string CustomerNumber { get; set; }
        public string LegerCode { get; set; }
        public string BranchCode { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public AccountType AccountType { get; set; }

    }
}
