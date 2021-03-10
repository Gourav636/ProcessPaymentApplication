using ProcessPaymentDataLayer.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentDataLayer.DomainObjects
{
    public class PaymentDo
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public double Amount { get; set; }
        public RequestStatusDo requestStatus {get;set;}
    }
}
