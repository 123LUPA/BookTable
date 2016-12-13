using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTable.Models
{

    public interface IUserInterface : IDisposable
    {
        int getAge(string ID);
        int setAge(string ID, int NewAge);

    }
}
