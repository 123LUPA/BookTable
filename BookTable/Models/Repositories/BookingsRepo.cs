using BookTable.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
namespace BookTable.Models.Repositories
{
    public class BookingsRepo : IBookingInterface
    {

        private readonly ApplicationDbContext db;

        public BookingsRepo(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void Delete(int? id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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

        public IEnumerable<Booking> getAllBookings()
        {
            var bookings = db.Bookings.Include(b => b.ApplicationUser).Include(b => b.Restaurant);

            return bookings;
        }

        public Booking findBooking(int? id)
        {
            return db.Bookings.Find(id);
        }

        public void Insert(Booking booking)
        {

            db.Bookings.Add(booking);
        }

        public void Update(Booking booking)
        {
            db.Entry(booking).State = System.Data.Entity.EntityState.Modified;
        }
    }
}