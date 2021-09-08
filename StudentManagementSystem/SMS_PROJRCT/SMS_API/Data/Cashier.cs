using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Cashier
    {
        public Cashier()
        {
            Fees = new HashSet<Fee>();
        }

        public decimal CashierId { get; set; }
        public string CashierName { get; set; }

        public virtual ICollection<Fee> Fees { get; set; }
    }
}
