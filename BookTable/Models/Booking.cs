using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookTable.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string ApplicationUserId { get; set; }
        public int RestaurantId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; }

        [Range(1,100)]
        public int NumberOfPeople { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

   
    }
}