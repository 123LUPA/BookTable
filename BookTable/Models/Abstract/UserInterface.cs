using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTable.Models
{

    interface UserInterface : IDisposable
    {


        int getAge(string ID);
        int setAge(string ID, int NewAge);

    }
}
