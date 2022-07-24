using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ToList();
        T returnForId(int Id);
        void Insert(T entity);
        void Delete(int Id);
        void Update(int Id, T entity);
        int nextId();
    }
}