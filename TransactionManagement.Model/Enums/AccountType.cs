using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.Model.Enums
{
    public enum AccountType
    {
        [Description("Unknown")]
        UNKNOWN = 0,
        [Description("Savings")]
        SAVINGS = 1,
        [Description("Current")]
        CURRENT = 2
    }
}
