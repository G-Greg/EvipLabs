using System;
using System.Collections.Generic;

namespace Storage
{
    public class Store<T> where T : IStorable
    {
        private Dictionary<string, IStorable> storage = new Dictionary<string, IStorable>();

        public int Count()
        {
            return storage.Count;
        }

        public void Insert(IStorable item)
        {
            if (item == null || item.Id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                if (storage.ContainsKey(item.Id) || storage.ContainsValue(item))
                {
                    //throw new ArgumentException();

                }
                else
                {
                    if (item.InStock > 0)
                        storage.Add(item.Id, item);
                }
            }
        }

        public void InsertMany(List<IStorable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                storage.Add(items[i].Id, items[i]);
            }
        }

        public IStorable GetById(string id)
        {
            if (storage.ContainsKey(id))
                return storage[id];
            return null;
        }

        public Dictionary<string, IStorable> GetAllDictionary()
        {
            //4db
            /*
            Dictionary<string, IStorable> res = new Dictionary<string, IStorable>();
            foreach (var item in storage)
            {
                res.Add(item.Id, item);
            }*/
            return storage;

        }

        public List<IStorable> GetAllList()
        {
            List<IStorable> res = new List<IStorable>();
            foreach(var item in storage)
            {
                //res[int.Parse(item.Key)] = item.Value.InStock;
                res.Add(item.Value);
            }
            return res;
        }

        public void Sell(string id, int amount)
        {
            if (storage.Count >= int.Parse(id))
            {
                var item = storage[id];
                if (amount < 0 || item.InStock < amount)
                    throw new ArgumentException();
                else
                {
                    item.InStock -= amount;
                }
            }
        }

        public void Buy(IStorable item)
        {
            storage.Add(item.Id, item);
        }

        public void Buy(string id, int amount)
        {

            if (amount < 0)
                throw new ArgumentException();
            else
            {
                var item = storage[id];
                item.InStock += amount;
            }
        }

        public void Remove(string id)
        {
            storage.Remove(id);
        }

        public void Remove(IStorable item)
        {
            storage.Remove(item.Id);
        }
    }
}
