using ProcessPaymentDataLayer.Contexts;
using ProcessPaymentDataLayer.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApi.Services
{
    public class ProcessPaymentRepository : IProcessPaymentRepository
    {
        ProcessPaymentContext _processPaymentContext;
        public ProcessPaymentRepository(ProcessPaymentContext processPaymentContext)
        {
            _processPaymentContext = processPaymentContext ??
                throw new ArgumentNullException(nameof(processPaymentContext));
        }

        public void AddProcessPayment(PaymentDo payment)
        {
            _processPaymentContext.Payment.Add(payment);
        }

        public bool Save()
        {
            return (_processPaymentContext.SaveChanges() > 0);
        }
    }
}
