using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookTable.Models;
using Microsoft.AspNet.Identity;

namespace BookTable.Controllers
{
    [Authorize]

    public class BookingsController : Controller
    {
      
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
       // [Authorize(Roles ="Administrator")]
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.ApplicationUser).Include(b => b.Restaurant);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
           // ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantID", "Name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,ApplicationUserId,RestaurantId,BookingDate,NumberOfPeople")] Booking booking)
        {
            booking.ApplicationUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", booking.ApplicationUserId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantID", "Name", booking.RestaurantId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
           // ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", booking.ApplicationUserId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantID", "Name", booking.RestaurantId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,ApplicationUserId,RestaurantId,BookingDate,NumberOfPeople")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         //   ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", booking.ApplicationUserId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantID", "Name", booking.RestaurantId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DisplayBookings()
        {


            string userId = User.Identity.GetUserId();
             var bookings = from a in db.Bookings.Include(b => b.ApplicationUser).Include(b => b.Restaurant)
             where a.ApplicationUserId == userId
                           select a;
     

            return View(bookings.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
