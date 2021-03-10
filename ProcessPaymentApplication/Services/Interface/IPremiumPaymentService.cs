using ProcessPaymentApplication.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApi.Services.Interface
{
    public interface IPremiumPaymentService
    {
        public bool ProcessPayment(PaymentSo payment);
    }
}
