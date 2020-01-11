using System;
using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserProfile> Users { get; }
        IRepository<Material> Materials { get; }
        IRepository<Rating> Ratings { get; }
        void Save();
    }
}