using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalEve.Models
{
    public class Customer
    {

        public Customer()
        {
            Orders = new List<Order>();
        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }


    }
}