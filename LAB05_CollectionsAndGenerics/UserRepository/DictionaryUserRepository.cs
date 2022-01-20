﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class DictionaryUserRepository : IUserRepository
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        public int Count()
        {
            return users.Count;
        }

        public User Get(int index)
        {
            // Ez nem NotImplementedException, mert nem is cél, hogy megvalósítsuk!
            //  A dictionary jellegéből adódóan nem alkalmas erre.
            throw new NotSupportedException();
        }

        public User GetById(string id)
        {
            return users[id];
        }

        public void Insert(User user)
        {
            users.Add(user.Id,user);
        }
    }
}

