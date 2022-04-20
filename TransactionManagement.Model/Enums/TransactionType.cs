using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.Model.Enums
{
    public enum TransactionType
    {
        [Description("Unknown")]
        UNKNOWN = 0,
        [Description("Debit")]
        DEBIT = 1,
        [Description("Credit")]
        CREDIT = 2,
    }
}
