using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTable.Models.Abstract
{
     public interface IRestaurantInterface : IDisposable
    {

        IEnumerable<Restaurant> getAllRestaurants();
        Restaurant findRestaurant(int? id);
        void Insert(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(int? id);
        void Save();

    }
}
