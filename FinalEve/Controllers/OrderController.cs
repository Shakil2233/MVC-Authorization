using FinalEve.Models;
using FinalEve.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalEve.Controllers
{
    [Authorize]
    public class OrderController:Controller
    {
        ApplicationContext db = new ApplicationContext();

        public ActionResult OrderInfo()
        {
            OrderViewModel OrderList = new OrderViewModel();
            List<SelectListItem> customerList = new List<SelectListItem>();
            foreach (var c in db.Customers.ToList())
            {
                customerList.Add(new SelectListItem()
                {
                    Text = c.CustomerName,
                    Value = c.CustomerId.ToString()
                });
            }
            ViewBag.CustomerList = customerList;

            return View(OrderList);

        }
        public ActionResult Delete(int OrderId)
        {
            try
            {
                var firstEntity = db.Orders.Where(o => o.OrderId == OrderId).FirstOrDefault();
                db.Orders.Remove(firstEntity);
                db.SaveChanges();
            }
            finally
            {

            }
            return RedirectToAction("OrderInfo");
        }
        [HttpGet]
        public ActionResult Insert()
        {
            HttpContext.Session.Add("ActionToken", ActionMode.Insert);
            return RedirectToAction("OrderInfo");
        }

        [HttpPost]
        public ActionResult Insert(Order OrderaddKey)
        {
            try
            {
                string fileName = System.IO.Path.GetFileName(OrderaddKey.PictureUrl.FileName);
                OrderaddKey.PictureUrl.SaveAs(Server.MapPath("~/images/") + fileName);
                OrderaddKey.Picture = "Images/" + fileName;

                db.Orders.Add(OrderaddKey);
                db.SaveChanges();
            }
            finally
            {

            }
            return RedirectToAction("OrderInfo");
        }
        public ActionResult Edit(int OrderId)
        {
            HttpContext.Session.Add("ActionToken", ActionMode.Edit);
            HttpContext.Session.Add("OrderId", OrderId);

            return RedirectToAction("OrderInfo");
        }
        [HttpPost]
        public ActionResult Edit(Order OrderaddKey)
        {
            try
            {
                string fileName = System.IO.Path.GetFileName(OrderaddKey.PictureUrl.FileName);
                OrderaddKey.PictureUrl.SaveAs(Server.MapPath("~/images/") + fileName);
                var updateinfo = db.Orders.Where(o => o.OrderId == OrderaddKey.OrderId).FirstOrDefault();

                updateinfo.OrderId = OrderaddKey.OrderId;
                updateinfo.Item = OrderaddKey.Item;
                updateinfo.Total = OrderaddKey.Total;
                updateinfo.OrderDate = OrderaddKey.OrderDate;
                updateinfo.IsAvailable = OrderaddKey.IsAvailable;
                updateinfo.Picture = "Images/" + fileName;


                db.SaveChanges();
            }
            finally
            {

            }

            return RedirectToAction("OrderInfo");
        }
    }
}
