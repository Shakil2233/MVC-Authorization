using FinalEve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalEve.ViewModel
{
    public class OrderViewModel
    {
        public IList<Order> Orders { get; set; }
        ApplicationContext db = new ApplicationContext();
        public OrderViewModel()
        {
            Orders = new List<Order>();
            Orders = db.Orders.Include("Customer").ToList();
            if (HttpContext.Current.Session["ActionToken"] != null)
            {
                if ((ActionMode)HttpContext.Current.Session["ActionToken"] == ActionMode.Insert)
                {
                    OrderaddKey = new Order()
                    {

                    };
                }
                else if ((ActionMode)HttpContext.Current.Session["ActionToken"] == ActionMode.Edit)
                {
                    int sessionId = (int)HttpContext.Current.Session["OrderId"];
                    OrderaddKey = db.Orders.Where(w => w.OrderId == sessionId).FirstOrDefault();

                }
            }

        }
        public Order OrderaddKey { get; set; }
    }
    public enum ActionMode
    {
        Select, Edit, Insert, Delete
    }
}