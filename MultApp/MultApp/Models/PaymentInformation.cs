using System;
using System.Collections.Generic;
using System.Text;

namespace MultApp.Models
{
    public class PaymentInformation
    {
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string CardExpirationDate { get; set; }
        public long ExpMonth => long.Parse(this.CardExpirationDate.Split('/')[0]);
        public long ExpYear => long.Parse(this.CardExpirationDate.Split('/')[1]);
        public Multa Multa { get; set; }
    }
}
