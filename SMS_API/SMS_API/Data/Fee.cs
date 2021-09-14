using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Fee
    {
        public long InvoiceId { get; set; }
        public long StudentId { get; set; }
        public long? CashierId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal FeesAmount { get; set; }

        public virtual Cashier Cashier { get; set; }
        public virtual Student Student { get; set; }
    }
}
