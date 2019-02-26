using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy_Entities
{
    public class Customer
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerAge { get; set; }
        public long CustomerPhoneNo { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Habits { get; set; }
        public string Hobbies { get; set; }
        public int PolicyNumber { get; set; }
       
        public int ProductId { get; set; }
       
        public string NomineeName { get; set; }
        public string Relation { get; set; }
        public int Age { get; set; }
        
        public string ProductName { get; set; }
        public decimal PremiumPayment { get; set; }
        public string PremiumPaymentFrequency { get; set; }
        public string ProductLine { get; set; }
    }
}
