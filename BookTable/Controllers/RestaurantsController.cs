using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookTable.Models;
using BookTable.Models.Repositories;
using BookTable.Models.Abstract;

namespace BookTable.Controllers
{
    public class RestaurantsController : Controller
    {
        private IRestaurantInterface restaurantInterface;

        public RestaurantsController(IRestaurantInterface resturantInterface)
        {
            this.restaurantInterface = resturantInterface;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(restaurantInterface.getAllRestaurants().ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = restaurantInterface.findRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantID,Cvr,Name,Address,Phone,Email,Description")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurantInterface.Insert(restaurant);
                restaurantInterface.Save();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = restaurantInterface.findRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantID,Cvr,Name,Address,Phone,Email,Description")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurantInterface.Update(restaurant);
                restaurantInterface.Save();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = restaurantInterface.findRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            restaurantInterface.Delete(id);
            restaurantInterface.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                restaurantInterface.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
