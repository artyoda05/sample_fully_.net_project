using System;
using System.Collections.Generic;

namespace Project.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}