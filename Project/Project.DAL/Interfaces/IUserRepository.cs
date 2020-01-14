using System;
using System.Collections.Generic;
using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<UserProfile> ReadAll();
        UserProfile Read(string id);
        void Create(UserProfile item);
        void Update(UserProfile item);
        void Delete(UserProfile item);
    }
}