using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using Project.DAL.Repositories;
using Project.DAL.Identity;

namespace Project.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EFContext _context;
        private UserRepository _users;
        private MaterialRepository _materials;
        private RatingRepository _ratings;
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public UnitOfWork() => _context = new EFContext();
        public UnitOfWork(string connectionString) => _context = new EFContext(connectionString);
        public UnitOfWork(EFContext context) => _context = context;
        public IUserRepository Profiles => _users ??=  new UserRepository(_context);
        public IRepository<Material> Materials => _materials ??= new MaterialRepository(_context);
        public IRepository<Rating> Ratings => _ratings ??= new RatingRepository(_context);
        public ApplicationRoleManager Roles => 
            _roleManager ??= new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));
        public ApplicationUserManager Users =>
            _userManager ??= new ApplicationUserManager(new UserStore<ApplicationUser>(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                _ratings?.Dispose();
                _materials?.Dispose();
                _users?.Dispose();
            }
            this._disposed = true;
        }
    }
}
