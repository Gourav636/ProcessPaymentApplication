using ProcessPaymentDataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcessPaymentDataLayer.DomainObjects
{
    public class RequestStatusDo
    {
        public int Id { get; set; }

        public ERequestStates requestSates { get; set; }

        public string Message { get; set; }

        [ForeignKey("PaymentDoId")]
        public PaymentDo PaymentDo { get; set; }
        public int PaymentDoId { get; set; }

    }
}
