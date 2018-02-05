using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TravelBuddy.Models
{
    public class User : EntityBase<Guid>
    {
        private static HashAlgorithm hashAlgorithm = new SHA512Managed();

        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] Password { get; set; }
        public virtual IList<Travel> Travels { get; set; }

        public User() : base()
        {
            Travels = new List<Travel>();
        }

        public User(string username, string email, string password) : this()
        {
            Username = username;
            Email = email;
            SetPassword(password);
        }

        public virtual void SetPassword(string password)
        {
            Password = HashPassword(password);
        }

        public virtual string GetPassword()
        {
            return Encoding.ASCII.GetString(Password);
        }

        public virtual bool IsSamePassword(string password)
        {
            var hashedPassword = Encoding.ASCII.GetString(HashPassword(password));
            return GetPassword() == hashedPassword;
        }

        private static byte[] HashPassword(string password)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password ?? "");
            return hashAlgorithm.ComputeHash(passwordBytes);
        }
    }
}
