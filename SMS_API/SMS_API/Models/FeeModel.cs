using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SMS_API.Models
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

        public virtual Cashier Cashier { get; set; }
        public virtual Student Student { get; set; }
    }
}
