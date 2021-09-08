using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Fee
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
