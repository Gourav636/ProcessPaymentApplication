using ProcessPaymentApi.ServiceObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPaymentApi.ServiceObjects
{
    public class RequestStatusSo
    {
        public ERequestStatesSo requestSates { get; set; }
        public string Message { get; set; }
    }
}
