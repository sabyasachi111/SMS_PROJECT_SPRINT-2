using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SMS_APP.Models
{
    public class CashierModel
    {

        public CashierModel()
        {
            Fees = new HashSet<FeeModel>();
        }

        [Required]
        [RegularExpression(@"^[\d]{6,8}$", ErrorMessage = "Invalid")]
        public long CashierId { get; set; }



        [Required]
        [MaxLength(25)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]+$", ErrorMessage = "Invalid")]
        public string CashierName { get; set; }

        public virtual ICollection<FeeModel> Fees { get; set; }
    }
}
