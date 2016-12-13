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
using BookTable.Models.Repositories;
using BookTable.Models.Abstract;

namespace BookTable.Controllers
{
    [Authorize]

    public class BookingsController : Controller
    {
      
        private IBookingInterface bookingInterface;
        private IRestaurantInterface restaurantInterface;

      

       public BookingsController(IRestaurantInterface restaurantInterface, IBookingInterface bookingInterface)
        {
            this.restaurantInterface = restaurantInterface;
            this.bookingInterface = bookingInterface;
        }

   
        // GET: Bookings
        // [Authorize(Roles ="Administrator")]
        public ActionResult Index()
        {
            return View(bookingInterface.getAllBookings().ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingInterface.findBooking(id);
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
            ViewBag.RestaurantId = new SelectList(restaurantInterface.getAllRestaurants(), "RestaurantID", "Name");
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
                bookingInterface.Insert(booking);
                bookingInterface.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", booking.ApplicationUserId);
            ViewBag.RestaurantId = new SelectList(restaurantInterface.getAllRestaurants(), "RestaurantID", "Name", booking.RestaurantId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingInterface.findBooking(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
           // ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", booking.ApplicationUserId);
            ViewBag.RestaurantId = new SelectList(restaurantInterface.getAllRestaurants(), "RestaurantID", "Name", booking.RestaurantId);
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
                bookingInterface.Update(booking);
                bookingInterface.Save();
                return RedirectToAction("Index");
            }
         //   ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", booking.ApplicationUserId);
            ViewBag.RestaurantId = new SelectList(restaurantInterface.getAllRestaurants(), "RestaurantID", "Name", booking.RestaurantId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingInterface.findBooking(id);
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
           
            bookingInterface.Delete(id);
            bookingInterface.Save();
            return RedirectToAction("Index");
        }

        public ActionResult DisplayBookings()
        {


            string userId = User.Identity.GetUserId();
             var bookings = from a in bookingInterface.getAllBookings()
             where a.ApplicationUserId == userId
                           select a;
     

            return View(bookings.ToList());
        }

        ////protected override void dispose(bool disposing)
        ////{
        ////    if (disposing)
        ////    {
        ////        bookingrep.dispose();
        ////        restaurantrepo.dispose();


        ////    }
        ////    base.dispose(disposing);
        ////}
    }
}
