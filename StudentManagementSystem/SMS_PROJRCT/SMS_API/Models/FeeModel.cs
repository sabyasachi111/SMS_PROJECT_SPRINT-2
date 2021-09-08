using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Models
{
    public class FeeModel
    {
        public decimal InvoiceId { get; set; }
        public decimal StudentId { get; set; }
        public decimal? CashierId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal FeesAmount { get; set; }

        public virtual Cashier Cashier { get; set; }
        public virtual Student Student { get; set; }
    }
}
