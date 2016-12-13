using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTable.Models.Abstract
{
   public interface IBookingInterface : IDisposable
    {

        IEnumerable<Booking> getAllBookings();
        Booking findBooking(int? id);
        void Insert(Booking booking);
        void Update(Booking booking);
        void Delete(int? id);
        void Save();
    }
}
