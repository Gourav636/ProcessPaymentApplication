using AutoMapper;
using ProcessPaymentApi.Services.Interface;
using ProcessPaymentApplication.ServiceObjects;
using ProcessPaymentDataLayer.DomainObjects;
using ProcessPaymentDataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApi.Services.Implementation
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        IProcessPaymentRepository _processPayment;
        IMapper _mapper;
        public PremiumPaymentService(IProcessPaymentRepository processPayment, IMapper mapper)
        {
            _processPayment = processPayment ??
                throw new ArgumentNullException(nameof(processPayment));
            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
        }

        public bool ProcessPayment(PaymentSo payment)
        {
            var result = _mapper.Map<PaymentDo>(payment);
            try
            {
                 result.requestStatus.requestSates = ERequestStates.Pending;
                _processPayment.AddProcessPayment(result);
                result.requestStatus.requestSates = ERequestStates.processed;
                _processPayment.Save();

                return true;
            }
            catch (Exception e)
            {
                result.requestStatus.requestSates = ERequestStates.failed;
                result.requestStatus.Message = e.Message;
                _processPayment.Save();
            }

            return false;
        }
    }
}
