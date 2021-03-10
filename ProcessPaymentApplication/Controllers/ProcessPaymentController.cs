using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProcessPaymentApi.Services.Interface;
using ProcessPaymentApplication.Dto;
using ProcessPaymentApplication.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApplication.Controllers
{
    [ApiController]
    [Route("api/processpayment")]
    public class ProcessPaymentController : ControllerBase
    {
        IMapper _mapper;
        ICheapPaymentGateway _cheapPaymentGateway;
        IExpensivePaymentGateway _expensivePaymentGateway;
        IPremiumPaymentService _premiumPaymentService;

        public ProcessPaymentController(
            ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway,
            IPremiumPaymentService premiumPaymentService,
            IMapper mapper)
        {
            _mapper = mapper ??
             throw new ArgumentNullException(nameof(mapper));
            _expensivePaymentGateway = expensivePaymentGateway ??
             throw new ArgumentNullException(nameof(expensivePaymentGateway));
            _cheapPaymentGateway = cheapPaymentGateway ??
             throw new ArgumentNullException(nameof(cheapPaymentGateway));
            _premiumPaymentService = premiumPaymentService ??
                throw new ArgumentNullException(nameof(premiumPaymentService));
        }

       
        [HttpPost]
        public IActionResult ProcessPayment(PaymentDto paymentDto)
        {
            int count = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (paymentDto.Amount <= 20)
            {
                _cheapPaymentGateway.ProcessPayment(_mapper.Map<PaymentSo>(paymentDto));
            }
            else if (paymentDto.Amount > 20 && paymentDto.Amount < 501)
            {
                if (!_expensivePaymentGateway.isAvailable)
                {
                    do
                    {
                        _cheapPaymentGateway.ProcessPayment(_mapper.Map<PaymentSo>(paymentDto));
                        count++;
                    } while (count < 1);
                }
                else
                {
                    _expensivePaymentGateway.ProcessPayment(_mapper.Map<PaymentSo>(paymentDto));
                }
            }
            else if(paymentDto.Amount > 500)
            {
                do
                {
                    bool res = _premiumPaymentService.ProcessPayment(_mapper.Map<PaymentSo>(paymentDto));
                    if (!res)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                } while (count < 3);
            }
            return Ok();
        }
    }
}
