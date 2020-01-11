using System;
using Microsoft.AspNet.Identity;
using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserProfile> Profiles { get; }
        IRepository<Material> Materials { get; }
        IRepository<Rating> Ratings { get; }
        RoleManager<ApplicationRole> Roles { get; }
        UserManager<ApplicationUser> Users { get; }
        void Save();
    }
}