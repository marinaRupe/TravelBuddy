using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models
{
    public class User : EntityBase<Guid>
    {
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual IList<Travel> Travels { get; set; }

        public User() : base(new Guid())
        {
        }

        public User(string username, string email, string password) : this()
        {
            Username = username;
            Email = email;
            Password = password; // TODO: hash
        }
    }
}
