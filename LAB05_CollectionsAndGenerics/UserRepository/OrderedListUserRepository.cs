using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class OrderedListUserRepository : IUserRepository
    {
        private SortedList<int, User> users = new SortedList<int, User>();

        public int Count()
        {
            return users.Count;
        }

        public User Get(int index)
        {
            return users[index];
        }

        public User GetById(string id)
        {
            // Binaris kereses rendezett tombon
            var left = 0;
            var right = users.Count - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (string.Compare(users[mid].Id, id) > 0)
                {
                    right = mid - 1;
                }
                else if (string.Compare(users[mid].Id, id) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    return users[mid];
                }
            }
            return null;
        }

        public void Insert(User user)
        {
            users.Add(int.Parse(user.Id), user);
            /*var id = user.Id;
            var left = 0;
            var right = users.Count-1;


            if (users.Count == 0)
            {
                users.Add(user);
            }
            else {
                while (left <= right)
                {
                    var mid = (left + right) / 2;



                    if (string.Compare(users[mid].Id, id) > 0)
                    {
                        if (users[mid] != null)
                        {
                            right = mid - 1;
                        }
                        else
                        {
                            users[mid] = user;
                        }
                    }
                    else if (string.Compare(users[mid].Id, id) < 0)
                    {
                        if (users[mid] == null)
                        {
                            users[mid] = user;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                    else
                    {
                        users[mid] = user;
                    }
                    
                }
            }*/
        }
    }
}
