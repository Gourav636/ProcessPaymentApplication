using ProcessPaymentApplication.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApplication.Dto
{
    public class PaymentDto
    {
        [Required]
        [Range(12,12, ErrorMessage = "Please Enter valid Card Number")]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        [DateValidation]
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        [Required]
        [Range(0,double.MaxValue,ErrorMessage ="Please enter valid amount")]
        public double Amount { get; set; }
    }
}
