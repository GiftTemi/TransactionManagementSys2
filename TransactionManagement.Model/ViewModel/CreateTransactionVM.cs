using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Model.Enums;

namespace TransactionManagement.Model.ViewModel
{
    public class CreateTransactionVM
    {
        public Decimal Amount { get; set; }
        public string Narration { get; set; }
        public TransactionType TransactionType { get; set; }
        public string FromAcct { get; set; }
        public string ToAcct { get; set; }
        public TransactionChannels TransactionChannels { get; set; }
        public Guid AccountId { get; set; }
    }
}
