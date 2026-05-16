using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomIfsExercs.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(string[] arguments, Dictionary<string, string> users);
        void EditUser(string[] arguments, Dictionary<string, string> users);
        void DeleteUser(string[] arguments, Dictionary<string, string> users);
    }
}
