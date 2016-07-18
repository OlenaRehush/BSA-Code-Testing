using System;
using System.Collections.Generic;
using System.Linq;
using Cashbox.DataAccess;

namespace Cashbox.Tests.Fake
{
    public class FakeRepository<T> : IRepository<T> where T : class, IEntity
    {
        public readonly List<T> Data;

        public FakeRepository(params T[] data)
        {
            Data = new List<T>(data);
        }

        public IQueryable<T> Query()
        {
            return Data.AsQueryable();
        }

        public IEnumerable<T> All()
        {
            return Data;
        }

        public T Get(int id)
        {
            return Data.FirstOrDefault(x => x.Id == id);
        }

        public T Get(Func<T, bool> predicate)
        {
            return Data.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            Data.Add(entity);
        }

        public void Attach(T entity)
        {
        }

        public void Delete(T entity)
        {
            Data.Remove(entity);
        }
    }
}