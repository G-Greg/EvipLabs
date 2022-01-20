using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserRepository
{
    public class LinkedListUserRepository : IUserRepository
    {
        private LinkedList<User> users = new LinkedList<User>();
        public int Count()
        {
            return users.Count;
        }

        public User Get(int index)
        {
            return users.ElementAt(index);
        }

        public User GetById(string id)
        {
            // Binaris kereses rendezett tombon
            var left = 0;
            var right = users.Count - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (string.Compare(this.Get(mid).Id, id) > 0)
                {
                    right = mid - 1;
                }
                else if (string.Compare(this.Get(mid).Id, id) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    return users.ElementAt(mid);
                }
            } 
            return null;
        }

        public void Insert(User user)
        {
            // A string.Compare segítségével keresd meg, hova kell beszúrni az új usert.
            if (users.Count == 0)
            {
                users.AddFirst(user);
            }
            else
            {
                var step = users.First;
                var next = step.Next;
                var prev = step.Previous;
                string identity = Szoveg(user.Id);
                


                while (step != null)
                {
                    string toCompNext = "";
                    string toCompPrev = "";
                    string toCompStep = Szoveg(step.Value.Id);
                    if (next != null)
                    {
                        toCompNext = Szoveg(next.Value.Id);
                    }
                    if (prev != null)
                    {
                        toCompPrev = Szoveg(prev.Value.Id);
                    }

                    //jobbra kell tenni
                    if (string.Compare(identity, toCompStep) > 0)
                    {
                        //ha nincs jobbra senki
                        if (next == null)
                        {
                            users.AddAfter(step, user);
                            break;
                        }
                        //ha a következő után is jobbra kell tenni
                        else if (string.Compare(identity, toCompNext) >= 0)
                        {
                            step = step.Next;
                        }
                        //ha a mostanitól kell jobbra tenni
                        else if (string.Compare(identity, toCompStep) >= 0)
                        {
                            users.AddAfter(step, user);
                            break;
                        }


                    }
                    else if (string.Compare(identity, toCompStep) < 0)
                    {
                        if (prev == null)
                        {
                            users.AddBefore(step, user);
                            break;
                        }
                        else if (string.Compare(identity, toCompPrev) <= 0)
                        {
                            step = step.Previous;
                        }
                        else if (string.Compare(identity, toCompStep) <= 0)
                        {
                            users.AddBefore(step, user);
                        }

                    }
                    else {
                        step = step.Next;
                    }
                }
            }
        }

        public string Szoveg(string id) {
            if (id.Length == 3)
            {
                id = "0" + id;
            }
            else if (id.Length == 2)
            {
                id = "00" + id;
            }
            else if (id.Length == 1)
            {
                id = "000" + id;
            }

            return id;
        } 
    }
}
