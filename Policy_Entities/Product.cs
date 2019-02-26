using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy_Entities
{
    class Product
    {
      

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal PremiumPayment { get; set; }
        public string PremiumPaymentFrequency { get; set; }
        public string ProductLine { get; set; }
    }
}
