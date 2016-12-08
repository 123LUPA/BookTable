using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTable.Models
{
    public class Restaurant
    {

        public int RestaurantID { get; set; }
        public int Cvr { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Booking> Bookings { get; set; }
    }
}