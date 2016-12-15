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
        string setSurname(string ID, string NewName);
        string getSurname(string ID);
        string setName(string ID, string NewEmail);
        string getName(string ID);

    }
}
