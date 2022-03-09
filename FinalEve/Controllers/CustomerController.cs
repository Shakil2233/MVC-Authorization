using FinalEve.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalEve.Controllers
{
    [Authorize]
    public class CustomerController:Controller
    {

        ApplicationContext db = new ApplicationContext();


        public ActionResult CustomerInfo()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Insert(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("CustomerInfo");
            }

            return View(customer);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]

        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerInfo");
            }
            return View(customer);
        }
        public ActionResult Delete(int CustomerId)
        {
            try
            {
                var firstEntity = db.Customers.Where(c => c.CustomerId == CustomerId).FirstOrDefault();
                db.Customers.Remove(firstEntity);
                db.SaveChanges();
            }
            finally
            {

            }
            return RedirectToAction("CustomerInfo");
        }

    }
}

    