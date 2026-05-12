using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomIfsExercs.Models
{
    public class User
    {

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        string Username { get; set; }
        string Password { get; set; }
    }
}
