﻿using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;
using NHibernate.Criterion;
using NHibernate.Linq;
using System.Linq;
using TravelBuddy.DAL.Extensions;
using TravelBuddy.Models.Exceptions;

namespace TravelBuddy.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        protected ISession Session => _unitOfWork.Session;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUser(Guid userId)
        {
            return Session.Get<User>(userId);
        }

        public void AddUser(User user)
        {
            if (GetUserByEmail(user.Email) != null)
            {
                throw new DuplicateUserException("Korisnik s navedonom adresom elektroničke poše već postoji!");
            }
            if (GetUserByUsername(user.Username) != null)
            {
                throw new DuplicateUserException("Korisničko ime je zauzeto!");
            }
            Session.Save(user);
        }

        public void UpdateUser(User user)
        {
            Session.Update(user);
        }

        public void DeleteUser(Guid userId)
        {
            var user = Session.Get<User>(userId);

            if (user != null)
            {
                Session.Delete(user);
            }
        }

        public User GetUserByEmail(string email)
        {
            var query = Session.QueryOver<User>()
                .WhereEqualInsensitive(u => u.Email, email)
                .Take(1);
            return query.SingleOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            var query = Session.QueryOver<User>()
                .Where(u => u.Username == username)
                .Take(1);
            return query.SingleOrDefault();
        }

        public bool DoesUserExist(string email = null, string username = null)
        {
            int count = 0;
            if (email == null)
            {
                count = Session.QueryOver<User>()
                    .Where(u => u.Username == username)
                    .RowCount();
            }
            else if (username == null)
            {
                count = Session.QueryOver<User>()
                    .WhereEqualInsensitive(u => u.Email, email)
                    .RowCount();
            }
            else
            {
                count = Session.QueryOver<User>()
                    .Where(Restrictions.And(
                        Restrictions.Eq(
                            Projections.SqlFunction("lower", NHibernateUtil.String, Projections.Property("Email")),
                            email?.ToLower()),
                        Restrictions.Where<User>(u => u.Username == username)))
                    .RowCount();
            }
            return count > 0;
        }
    }
}
