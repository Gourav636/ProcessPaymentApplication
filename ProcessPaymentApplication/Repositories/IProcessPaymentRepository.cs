using ProcessPaymentDataLayer.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApi.Services
{
    public interface IProcessPaymentRepository
    {
        public void AddProcessPayment(PaymentDo payment);
        bool Save();
    }
}
