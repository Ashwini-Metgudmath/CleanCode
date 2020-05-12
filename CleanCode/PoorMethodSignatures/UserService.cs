using System;
using System.Linq;

namespace CleanCode.PoorMethodSignatures
{
    public class UserService
    {
        private UserDbContext _dbContext = new UserDbContext();

       

        public User GetUser(string username)
        {
            // Check if there is a user with the given username
            // If yes, return it, otherwise return null
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }

        public User Login(string username, string password)
        {
            // Check if there is a user with the given username and password in db
            // If yes, set the last login date 
            // and then return the user. 
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
                user.LastLogin = DateTime.Now;
            return user;
        }
    }
}