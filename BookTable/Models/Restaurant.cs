using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookTable.Models
{
    public class Restaurant
    {
      
        public int RestaurantID { get; set; }

        [Range(0, 100000000,ErrorMessage ="Please remembr that CVR has 8 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CVR has to be numberic")]
        public int Cvr { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Name of resturant has to be at least 3 characters long", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The address has to be at least 3 characters", MinimumLength = 3)]
        public string Address { get; set; }

        [Range(0,10000000)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone has to be numberic")]
        public int Phone { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [StringLength(100, ErrorMessage = "Discription has to be at least 3 letters long", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Description { get; set; }


        public virtual ICollection<Booking> Bookings { get; set; }
    }
}