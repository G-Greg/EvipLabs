using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class ArrayUserRepository : IUserRepository
    {
        private User[] users = new User[10000];

        private int count = 0;

        public int Count()
        {
            return users.Length;
        }

        public User Get(int index)
        {
            return users[index];
        }

        public User GetById(string id)
        {
            for (int i = 0; i < count; i++)
            {
                if (users[i].Id == id)
                {
                    return users[i];
                }
            }

            return null;
        }

        public void Insert(User user)
        {
            users[count] = user;
            count++;
        }
    }
}
