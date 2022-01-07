using System;
using System.Collections.Generic;
using System.Text;

namespace MultApp.Models
{
    public class PaymentModel
    {
        public string Token { get; set; }
        public decimal Amount { get; set; }
        public Multa Multa { get; set; }
    }
}
