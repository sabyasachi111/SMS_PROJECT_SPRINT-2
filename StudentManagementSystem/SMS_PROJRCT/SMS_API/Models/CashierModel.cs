using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Models
{
    public class CashierModel
    {
        public CashierModel()
        {
            Fees = new HashSet<Fee>();
        }

        public decimal CashierId { get; set; }
        public string CashierName { get; set; }

        public virtual ICollection<Fee> Fees { get; set; }
    }
}
