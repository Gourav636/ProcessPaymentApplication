using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApplication.CustomValidations
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return DateTime.Today >= (DateTime)value;
        }
    }
}
