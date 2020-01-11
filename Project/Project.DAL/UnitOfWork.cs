using System;
using System.Collections.Generic;
using System.Text;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using Project.DAL.Repositories;

namespace Project.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EFContext _context;
        private UserRepository _users;
        private MaterialRepository _materials;
        private RatingRepository _ratings;

        public UnitOfWork(EFContext context) => _context = context;
        public IRepository<UserProfile> Users => _users ??=  new UserRepository(_context);
        public IRepository<Material> Materials => _materials ??= new MaterialRepository(_context);
        public IRepository<Rating> Ratings => _ratings ??= new RatingRepository(_context);
        public void Save()
        {
            _context.SaveChanges();
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
                _ratings.Dispose();
                _materials.Dispose();
                _users.Dispose();
            }
            this._disposed = true;
        }
    }
}
