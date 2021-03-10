using AutoMapper;
using ProcessPaymentApi.ServiceObjects;
using ProcessPaymentApi.ServiceObjects.Enums;
using ProcessPaymentApplication.ServiceObjects;
using ProcessPaymentDataLayer.DomainObjects;
using ProcessPaymentDataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApi.Profiles
{
    public class PaymentProfileSo : Profile
    {
        public PaymentProfileSo()
        {
            CreateMap<PaymentSo, PaymentDo>();
            CreateMap<PaymentDo, PaymentSo>();

            CreateMap<RequestStatusSo, RequestStatusDo>();
            CreateMap<RequestStatusDo, RequestStatusSo>();

            CreateMap<ERequestStates, ERequestStatesSo>();
            CreateMap<ERequestStatesSo, ERequestStates>();

        }
    }
}
