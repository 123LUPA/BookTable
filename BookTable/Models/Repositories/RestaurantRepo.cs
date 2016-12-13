using BookTable.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTable.Models.Repositories
{
    public class RestaurantRepo : IRestaurantInterface
    {

        private readonly ApplicationDbContext db;

        public RestaurantRepo(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public IEnumerable<Restaurant> getAllRestaurants()
        {
            return db.Restaurants;
        }

        public void Delete(int? id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
        }

        public Restaurant findRestaurant(int? id)
        {
            return db.Restaurants.Find(id);
        }

        public void Insert(Restaurant restaurant)
        {

            db.Restaurants.Add(restaurant);

        }

        public void Update(Restaurant restaurant)
        {

            db.Entry(restaurant).State = System.Data.Entity.EntityState.Modified;

        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public object Bookings { get; internal set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}