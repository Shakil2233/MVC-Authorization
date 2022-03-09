using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalEve.Models
{
    public class ApplicationContext: DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public ApplicationContext() : base("UserConnection")
        {

        }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
