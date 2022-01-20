using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class ListUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public int Count()
        {
            return users.Count;
        }

        public User Get(int index)
        {
            // Tipp: használd az indexer "[]" operátort!
            return users[index];
        }

        public User GetById(string id)
        {

            foreach (var user in users) {
                if (user.Id.Equals(id)) {
                    return user;
                }
            }
            return null;
        }

        public void Insert(User user)
        {
            users.Add(user);
        }
    }
}
