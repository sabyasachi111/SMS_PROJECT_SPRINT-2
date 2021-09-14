using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class FeeModel
    {
        [Required]
        [RegularExpression(@"^[\d]{6,10}$", ErrorMessage = "Invalid")]
        public long InvoiceId { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{6,8}$", ErrorMessage = "Invalid")]
        public long StudentId { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{6,8}$", ErrorMessage = "Invalid")]
        public long? CashierId { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public decimal FeesAmount { get; set; }


        public virtual CashierModel Cashier { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}
