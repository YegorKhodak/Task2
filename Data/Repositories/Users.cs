using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;

namespace Data.Repositories
{
    public class Users
    {
        private readonly ApplicationContext _db;

        public Users(ApplicationContext db)
        {
            _db = db;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            return _db.Users.FirstOrDefault(user => user.Name == login && user.Password == password);
        }
    }
}
