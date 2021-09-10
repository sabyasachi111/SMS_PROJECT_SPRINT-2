using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class CashierModel
    {

        public CashierModel()
        {
            Fees = new HashSet<FeeModel>();
        }
        public long CashierId { get; set; }
        public string CashierName { get; set; }

        public virtual ICollection<FeeModel> Fees { get; set; }
    }
}
