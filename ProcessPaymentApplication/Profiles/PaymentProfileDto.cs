using AutoMapper;
using ProcessPaymentApi.ServiceObjects;
using ProcessPaymentApi.ServiceObjects.Enums;
using ProcessPaymentApplication.Dto;
using ProcessPaymentApplication.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApi.Profiles
{
    public class PaymentProfileDto: Profile
    {
        public PaymentProfileDto()
        {
            CreateMap<PaymentDto, PaymentSo>();
            CreateMap<PaymentSo, PaymentDto>();
        }
    }
}
