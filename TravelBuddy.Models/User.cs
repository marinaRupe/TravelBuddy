using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TravelBuddy.Models
{
    public class User : EntityBase<Guid>
    {
        private static HashAlgorithm hashAlgorithm = new SHA512Managed();

        private string _password;

        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password
        {
            get { return _password; }
            set
            {
                var valueBytes = Encoding.UTF8.GetBytes(value);
                _password = Encoding.UTF8.GetString(hashAlgorithm.ComputeHash(valueBytes));
            }
        }
        public virtual IList<Travel> Travels { get; set; }

        public User() : base()
        {
            Travels = new List<Travel>();
        }

        public User(string username, string email, string password) : this()
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public virtual bool IsSamePassword(string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashedPassword = Encoding.UTF8.GetString(hashAlgorithm.ComputeHash(passwordBytes));
            return hashedPassword == _password;
        }
    }
}
