using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class FeeModel
    {
        public long InvoiceId { get; set; }
        public long StudentId { get; set; }
        public long? CashierId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal FeesAmount { get; set; }


        public virtual CashierModel Cashier { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}
