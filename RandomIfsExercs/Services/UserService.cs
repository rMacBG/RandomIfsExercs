using RandomIfsExercs.Extensions;
using RandomIfsExercs.Models;
using RandomIfsExercs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomIfsExercs.Services
{
    public class UserService : IUserService
    {
        public void AddUser(string[] arguments, Dictionary<string, string> users)
        {
            if (users.ContainsKey(arguments[1]))
            {

                Console.WriteLine("User already exists!");
                return;
            }
            User user = new User(arguments[1], arguments[2]);
            users.Add(arguments[1], arguments[2]);
            JsonExtension.SaveUsers(users);
            Console.WriteLine($"Added {arguments[1]} to the dictionary!");
        }

        public void DeleteUser(string[] arguments, Dictionary<string, string> users)
        {
            throw new NotImplementedException();
        }

        public void EditUser(string[] arguments, Dictionary<string, string> users)
        {
            throw new NotImplementedException();
        }

       
    }
}
