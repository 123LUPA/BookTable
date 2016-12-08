using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTable.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
        public int SeatNumber { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}