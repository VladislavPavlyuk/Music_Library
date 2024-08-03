using System.Collections.Generic;
using System;
using MusicLib.DAL.Entities;

namespace MusicLib.DAL.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Get(string name);
        Task Create(T item);
        void Update(T item);
        Task Delete(int id);
    }
}
