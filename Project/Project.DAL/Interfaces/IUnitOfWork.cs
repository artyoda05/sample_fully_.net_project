using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Project.DAL.Entities;
using Project.DAL.Identity;

namespace Project.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Profiles { get; }
        IRepository<Material> Materials { get; }
        IRepository<Rating> Ratings { get; }
        ApplicationRoleManager Roles { get; }
        ApplicationUserManager Users { get; }
        void Save();
        Task SaveAsync();
    }
}